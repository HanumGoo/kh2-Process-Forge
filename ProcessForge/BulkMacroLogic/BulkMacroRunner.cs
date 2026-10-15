using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using ProcessForge.ApplicationLogic;
using ProcessForge.AutoLoginPatternLogic;
using ProcessForge.Config;
using ProcessForge.FindWindowLogic;
using ProcessForge.InputWindowLogic;
using ProcessForge.RefreshLogic;

namespace ProcessForge.BulkMacroLogic
{
    public static class BulkMacroRunner
    {
        private static CancellationTokenSource? _activeCts;

        public static bool IsRunning => _activeCts != null && !_activeCts.IsCancellationRequested;

        public static void Stop()
        {
            if (_activeCts != null && !_activeCts.IsCancellationRequested)
            {
                try
                {
                    _activeCts.Cancel();
                }
                catch { }
            }
        }

        public static async Task RunGroupMacro(
            List<ProcessData> processes,
            BulkWorkflowModel workflow,
            string accountDataFilePath = "",
            Action<int, int, string>? onProgress = null,
            Action? onCompleted = null,
            CancellationToken externalToken = default)
        {
            if (IsRunning) return;

            using var linkedCts = externalToken != default
                ? CancellationTokenSource.CreateLinkedTokenSource(externalToken)
                : new CancellationTokenSource();

            _activeCts = linkedCts;
            var token = linkedCts.Token;

            try
            {
                await Task.Run(() =>
                {
                    ExecuteMacro(processes, workflow, accountDataFilePath, onProgress, onCompleted, token);
                }, token);
            }
            catch (OperationCanceledException)
            {
                // Cancelled cleanly
            }
            finally
            {
                _activeCts = null;
            }
        }

        private static void ExecuteMacro(
            List<ProcessData> processes,
            BulkWorkflowModel workflow,
            string accountDataFilePath,
            Action<int, int, string>? onProgress,
            Action? onCompleted,
            CancellationToken cancellationToken)
        {
            if (processes == null || processes.Count == 0 || workflow == null) return;

            // Load account data for dynamic variable substitution if available
            List<DataLoginFormat> accounts = LoadAccounts(accountDataFilePath);

            var runningProcesses = processes.Where(p => p.ProcessId > 0).ToList();
            int total = runningProcesses.Count;
            int current = 0;

            foreach (var procData in runningProcesses)
            {
                if (cancellationToken.IsCancellationRequested) break;

                Process? process = null;
                try
                {
                    process = Process.GetProcessById(procData.ProcessId);
                }
                catch
                {
                    continue; // Process already terminated
                }

                if (process == null || process.HasExited) continue;

                current++;
                onProgress?.Invoke(current, total, procData.TitleName);

                // 1. Restore the window and bring it to foreground
                GetAndFindWindow.WindowRestore(procData.ProcessId);
                try { process.WaitForInputIdle(1000); } catch { }

                if (SleepOrCancel(800, cancellationToken)) break;

                // 2. Window bounds
                Rectangle windowSize = GetAndFindWindow.WindowSize(procData.ProcessId);
                if (windowSize.Width <= 0 || windowSize.Height <= 0)
                {
                    windowSize = new Rectangle(0, 0, 1024, 768);
                }

                // 3. Find matched account data by process title/nickname
                DataLoginFormat? matchedAccount = accounts.FirstOrDefault(a =>
                    string.Equals(a.nickname, procData.TitleName, StringComparison.OrdinalIgnoreCase));

                // 4. Execute workflow steps in linear order with Break and Goto support
                var allSteps = workflow.Steps ?? new List<TargetStepModel>();
                var mainSteps = allSteps.Where(s => !s.IsSubStep).ToList();
                var subSteps = allSteps.Where(s => s.IsSubStep).ToList();

                int stepPointer = 0;
                int maxJumpCount = 500;
                int jumpCount = 0;

                while (stepPointer >= 0 && stepPointer < mainSteps.Count)
                {
                    if (cancellationToken.IsCancellationRequested) break;
                    var step = mainSteps[stepPointer];

                    var stepResult = ExecuteStep(step, allSteps, subSteps, windowSize, matchedAccount, cancellationToken);
                    if (stepResult.Status == StepActionResult.Break)
                    {
                        break; // Stop workflow on this window, advance to next window
                    }
                    else if (stepResult.Status == StepActionResult.Goto && !string.IsNullOrWhiteSpace(stepResult.GotoTarget))
                    {
                        jumpCount++;
                        if (jumpCount > maxJumpCount)
                        {
                            MessageBox.Show($"Exceeded maximum goto loop count ({maxJumpCount}). Stopping workflow for safety.", "Workflow Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }

                        // Try finding target in mainSteps first
                        int targetIdx = mainSteps.FindIndex(s =>
                            string.Equals(s.StepTitle, stepResult.GotoTarget, StringComparison.OrdinalIgnoreCase) ||
                            string.Equals(s.TemplateName, stepResult.GotoTarget, StringComparison.OrdinalIgnoreCase) ||
                            string.Equals($"Step_{s.StepIndex + 1}", stepResult.GotoTarget, StringComparison.OrdinalIgnoreCase));

                        if (targetIdx != -1)
                        {
                            stepPointer = targetIdx;
                            continue;
                        }
                        else
                        {
                            // If target is a sub-step
                            var subTarget = subSteps.FirstOrDefault(s =>
                                string.Equals(s.StepTitle, stepResult.GotoTarget, StringComparison.OrdinalIgnoreCase) ||
                                string.Equals(s.TemplateName, stepResult.GotoTarget, StringComparison.OrdinalIgnoreCase));

                            if (subTarget != null)
                            {
                                ExecuteLinearActions(subTarget, new OpenCvSharp.Point(0, 0), windowSize, matchedAccount, cancellationToken);
                            }
                            stepPointer++;
                        }
                    }
                    else
                    {
                        stepPointer++;
                    }
                }

                if (cancellationToken.IsCancellationRequested) break;

                // 5. Short pause, then minimize the window after finishing
                SleepOrCancel(400, cancellationToken);
                GetAndFindWindow.WindowMinimize(procData.ProcessId);
                SleepOrCancel(500, cancellationToken);
            }

            if (!cancellationToken.IsCancellationRequested)
            {
                onCompleted?.Invoke();
            }
        }

        private static StepExecutionResult ExecuteStep(
            TargetStepModel step,
            List<TargetStepModel> allSteps,
            List<TargetStepModel> subSteps,
            Rectangle windowSize,
            DataLoginFormat? account,
            CancellationToken token)
        {
            if (token.IsCancellationRequested) return StepExecutionResult.Break();

            // Case A: Step has image template anchor
            if (!string.IsNullOrEmpty(step.ImagePath) && File.Exists(step.ImagePath))
            {
                OpenCvSharp.Point matchLoc;
                double matchScore;
                var detectResult = DetectImageWithSubSteps(windowSize, step, subSteps, account, out matchLoc, out matchScore, token);
                if (detectResult.Status != StepActionResult.Continue) return detectResult;

                if (token.IsCancellationRequested) return StepExecutionResult.Break();

                if (matchScore >= 0.85)
                {
                    var actionRes = ExecuteLinearActions(step, matchLoc, windowSize, account, token);
                    if (actionRes.Status != StepActionResult.Continue) return actionRes;
                }
            }
            // Case B: Step has no image template (action-only macro step)
            else
            {
                var actionRes = ExecuteLinearActions(step, new OpenCvSharp.Point(0, 0), windowSize, account, token);
                if (actionRes.Status != StepActionResult.Continue) return actionRes;
            }

            SleepOrCancel(350, token);
            return StepExecutionResult.Continue();
        }

        private static StepExecutionResult DetectImageWithSubSteps(
            Rectangle windowSize,
            TargetStepModel step,
            List<TargetStepModel> subSteps,
            DataLoginFormat? account,
            out OpenCvSharp.Point matchLocation,
            out double matchScore,
            CancellationToken token)
        {
            matchLocation = new OpenCvSharp.Point();
            matchScore = 0;

            string templatePath = step.ImagePath;
            if (!File.Exists(templatePath)) return StepExecutionResult.Continue();

            int maxAttempts = 60; // Up to ~30 seconds timeout
            int attempts = 0;

            using Bitmap captureWindow = new Bitmap(Math.Max(50, windowSize.Width), Math.Max(50, windowSize.Height));
            using Mat template = Cv2.ImRead(templatePath, ImreadModes.Color);

            while (!token.IsCancellationRequested && attempts++ < maxAttempts)
            {
                try
                {
                    using (Graphics g = Graphics.FromImage(captureWindow))
                    {
                        g.CopyFromScreen(windowSize.Location, System.Drawing.Point.Empty, windowSize.Size);
                    }

                    using (Mat screen = BitmapConverter.ToMat(captureWindow))
                    using (Mat result = new Mat())
                    using (Mat screenBGR = new Mat())
                    {
                        if (screen.Channels() == 4)
                            Cv2.CvtColor(screen, screenBGR, ColorConversionCodes.BGRA2BGR);
                        else
                            screen.CopyTo(screenBGR);

                        Cv2.MatchTemplate(screenBGR, template, result, TemplateMatchModes.CCoeffNormed);
                        Cv2.MinMaxLoc(result, out double minVal, out double maxVal, out OpenCvSharp.Point minLoc, out OpenCvSharp.Point maxLoc);

                        if (maxVal >= 0.85)
                        {
                            matchLocation = maxLoc;
                            matchScore = maxVal;
                            return StepExecutionResult.Continue();
                        }

                        // Check sub-steps while waiting
                        if (subSteps.Count > 0)
                        {
                            foreach (var sub in subSteps)
                            {
                                if (token.IsCancellationRequested) return StepExecutionResult.Break();
                                if (!string.IsNullOrEmpty(sub.ImagePath) && File.Exists(sub.ImagePath))
                                {
                                    using Mat subTemplate = Cv2.ImRead(sub.ImagePath, ImreadModes.Color);
                                    using Mat subResult = new Mat();
                                    Cv2.MatchTemplate(screenBGR, subTemplate, subResult, TemplateMatchModes.CCoeffNormed);
                                    Cv2.MinMaxLoc(subResult, out _, out double subMax, out _, out OpenCvSharp.Point subLoc);
                                    if (subMax >= 0.85)
                                    {
                                        var subRes = ExecuteLinearActions(sub, subLoc, windowSize, account, token);
                                        if (subRes.Status != StepActionResult.Continue)
                                        {
                                            return subRes;
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                catch { }

                if (SleepOrCancel(500, token)) return StepExecutionResult.Break();
            }

            return StepExecutionResult.Continue();
        }

        private static StepExecutionResult ExecuteLinearActions(
            TargetStepModel step,
            OpenCvSharp.Point matchLoc,
            Rectangle windowSize,
            DataLoginFormat? account,
            CancellationToken token)
        {
            if (step.Actions == null || step.Actions.Count == 0) return StepExecutionResult.Continue();

            int originX = windowSize.X;
            int originY = windowSize.Y;

            foreach (var action in step.Actions)
            {
                if (token.IsCancellationRequested) return StepExecutionResult.Break();

                if (action.ActionType == "Break")
                {
                    return StepExecutionResult.Break();
                }
                else if (action.ActionType == "Goto")
                {
                    return StepExecutionResult.Goto(action.GotoStepTarget ?? string.Empty);
                }
                else if (action.ActionType == "Mouse")
                {
                    int clickType = action.ClickTypeIndex ?? 0;
                    if (action.UseRelativeOffset ?? true)
                    {
                        int targetX = originX + matchLoc.X + (action.X ?? 0);
                        int targetY = originY + matchLoc.Y + (action.Y ?? 0);
                        InputWindow.ClickAt(targetX, targetY, clickType);
                    }
                    else
                    {
                        InputWindow.ClickAt(action.X ?? 0, action.Y ?? 0, clickType);
                    }
                }
                else if (action.ActionType == "Keyboard")
                {
                    string resolved = Case.ResolveVariables(action.Word ?? string.Empty, account);
                    if (!string.IsNullOrEmpty(resolved))
                    {
                        SendKeys.SendWait(resolved);
                    }
                }
                else if (action.ActionType == "Delay")
                {
                    int delay = action.DelayMs ?? 500;
                    if (SleepOrCancel(delay, token)) return StepExecutionResult.Break();
                    continue;
                }
                else if (action.ActionType == "InputBox")
                {
                    string prompt = string.IsNullOrWhiteSpace(action.PromptMessage) ? "Enter required input:" : action.PromptMessage;
                    string userInput = PromptDialog.Show(prompt);
                    if (token.IsCancellationRequested) return StepExecutionResult.Break();

                    if (!string.IsNullOrEmpty(userInput))
                    {
                        if (SleepOrCancel(200, token)) return StepExecutionResult.Break();
                        SendKeys.SendWait(userInput);
                    }
                }

                if (SleepOrCancel(300, token)) return StepExecutionResult.Break();
            }

            return StepExecutionResult.Continue();
        }

        private static List<DataLoginFormat> LoadAccounts(string accountDataFilePath)
        {
            var list = new List<DataLoginFormat>();

            if (string.IsNullOrEmpty(accountDataFilePath))
            {
                try
                {
                    var fullConfig = AppConfigManager.LoadConfig();
                    accountDataFilePath = fullConfig.MainForm?.FilePathNameLogin ?? string.Empty;
                }
                catch { }
            }

            if (!string.IsNullOrEmpty(accountDataFilePath) && File.Exists(accountDataFilePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(accountDataFilePath);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string line = lines[i];
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        string[] parts = line.Split(',');
                        if (parts.Length >= 4)
                        {
                            bool isLog = false;
                            if (parts.Length >= 5) bool.TryParse(parts[4], out isLog);

                            list.Add(new DataLoginFormat
                            {
                                nickname = parts[0].Trim(),
                                username = parts[1].Trim(),
                                password = parts[2].Trim(),
                                secondPassword = parts[3].Trim(),
                                isLogin = isLog,
                                LineIndex = i
                            });
                        }
                    }
                }
                catch { }
            }

            return list;
        }

        private static bool SleepOrCancel(int milliseconds, CancellationToken token)
        {
            if (token.IsCancellationRequested) return true;
            return token.WaitHandle.WaitOne(milliseconds);
        }
    }
}
