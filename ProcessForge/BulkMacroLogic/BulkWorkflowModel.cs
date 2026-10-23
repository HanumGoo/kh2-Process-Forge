using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProcessForge.BulkMacroLogic
{
    public class BulkWorkflowModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string Name { get; set; } = "Default Workflow";
        public string Description { get; set; } = string.Empty;
        public List<TargetStepModel> Steps { get; set; } = new List<TargetStepModel>();

        public BulkWorkflowModel Clone(string newName)
        {
            var options = new JsonSerializerOptions { WriteIndented = false };
            string json = JsonSerializer.Serialize(this, options);
            var clone = JsonSerializer.Deserialize<BulkWorkflowModel>(json) ?? new BulkWorkflowModel();
            clone.Id = Guid.NewGuid().ToString("N");
            clone.Name = newName;
            return clone;
        }
    }

    public class BulkWorkflowConfig
    {
        public string SelectedWorkflowId { get; set; } = string.Empty;
        public List<BulkWorkflowModel> Workflows { get; set; } = new List<BulkWorkflowModel>();

        // Looper configuration
        public bool EnableLoop { get; set; } = false;
        public int LoopCount { get; set; } = 1;
        public bool LoopInfinite { get; set; } = false;
        public int LoopDelayValue { get; set; } = 10;
        public string LoopDelayUnit { get; set; } = "Seconds"; // "Seconds", "Minutes", "Hours"
    }

    public static class BulkWorkflowManager
    {
        private static readonly string StorageDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "screenshots");
        private static readonly string ConfigFilePath = Path.Combine(StorageDirectory, "bulk_workflows.json");

        public static BulkWorkflowConfig LoadConfig()
        {
            try
            {
                Directory.CreateDirectory(StorageDirectory);

                if (File.Exists(ConfigFilePath))
                {
                    string json = File.ReadAllText(ConfigFilePath);
                    var config = JsonSerializer.Deserialize<BulkWorkflowConfig>(json);
                    if (config != null && config.Workflows != null && config.Workflows.Count > 0)
                    {
                        // Ensure step consistency
                        foreach (var wf in config.Workflows)
                        {
                            wf.Steps ??= new List<TargetStepModel>();
                            for (int i = 0; i < wf.Steps.Count; i++)
                            {
                                wf.Steps[i].StepIndex = i;
                                wf.Steps[i].Actions ??= new List<StepInputAction>();
                            }
                        }
                        return config;
                    }
                }
            }
            catch { }

            // Default initial config with a sample flexible workflow
            var defaultConfig = new BulkWorkflowConfig();
            var defaultWf = CreateDefaultWorkflow("Default Macro");
            defaultConfig.Workflows.Add(defaultWf);
            defaultConfig.SelectedWorkflowId = defaultWf.Id;

            SaveConfig(defaultConfig);
            return defaultConfig;
        }

        public static void SaveConfig(BulkWorkflowConfig config)
        {
            try
            {
                Directory.CreateDirectory(StorageDirectory);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(config, options);
                File.WriteAllText(ConfigFilePath, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to save bulk workflows config: {ex.Message}");
            }
        }

        public static BulkWorkflowModel CreateDefaultWorkflow(string name)
        {
            var wf = new BulkWorkflowModel
            {
                Name = name,
                Description = "Custom workflow macro for bulk process execution"
            };

            // Initial Main Step 1 with a default {ENTER} action
            var step1 = new TargetStepModel
            {
                StepIndex = 0,
                StepTitle = "Step_1",
                CaptureTitle = "Main Step 1",
                IsSubStep = false,
                BranchType = "Main",
                TemplateName = "Macro_Step_1",
                ImagePath = string.Empty,
                Actions = new List<StepInputAction>
                {
                    new StepInputAction
                    {
                        ActionType = "Keyboard",
                        Word = "{ENTER}"
                    }
                }
            };

            wf.Steps.Add(step1);
            return wf;
        }

        /// <summary>
        /// Validates whether sourceWf can safely add candidateTargetWf as a sub-workflow without causing a recursive loop/cycle.
        /// If candidateTargetWf already calls sourceWf (directly or indirectly), it returns false and provides the reason.
        /// </summary>
        public static bool CanWorkflowReference(
            BulkWorkflowModel sourceWf,
            BulkWorkflowModel candidateTargetWf,
            IEnumerable<BulkWorkflowModel> allWorkflows,
            out string reason)
        {
            reason = string.Empty;

            if (sourceWf == null || candidateTargetWf == null)
            {
                reason = "Invalid workflow selection.";
                return false;
            }

            // 1. Cannot reference itself
            if (string.Equals(sourceWf.Id, candidateTargetWf.Id, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(sourceWf.Name, candidateTargetWf.Name, StringComparison.OrdinalIgnoreCase))
            {
                reason = $"Workflow '{sourceWf.Name}' cannot run itself as a sub-workflow.";
                return false;
            }

            // 2. Candidate target cannot reach sourceWf directly or transitively
            var workflowList = allWorkflows?.ToList() ?? new List<BulkWorkflowModel>();
            var visited = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var queue = new Queue<string>();

            queue.Enqueue(candidateTargetWf.Id);
            visited.Add(candidateTargetWf.Id);

            while (queue.Count > 0)
            {
                string currentId = queue.Dequeue();

                var wf = workflowList.FirstOrDefault(w => string.Equals(w.Id, currentId, StringComparison.OrdinalIgnoreCase))
                         ?? workflowList.FirstOrDefault(w => string.Equals(w.Name, currentId, StringComparison.OrdinalIgnoreCase));

                if (wf?.Steps == null) continue;

                foreach (var step in wf.Steps)
                {
                    if (step.Actions == null) continue;
                    foreach (var action in step.Actions)
                    {
                        if (action.ActionType == "Workflow" || action.ActionType == "RunWorkflow")
                        {
                            string? childId = action.TargetWorkflowId;
                            string? childName = action.TargetWorkflowName;

                            // Check if this action points back to sourceWf
                            bool matchesSource = (!string.IsNullOrEmpty(childId) && string.Equals(childId, sourceWf.Id, StringComparison.OrdinalIgnoreCase)) ||
                                                 (!string.IsNullOrEmpty(childName) && string.Equals(childName, sourceWf.Name, StringComparison.OrdinalIgnoreCase));

                            if (matchesSource)
                            {
                                reason = $"Circular dependency detected: '{candidateTargetWf.Name}' already uses '{sourceWf.Name}' (directly or through a sub-workflow). To avoid recursive confusion, '{sourceWf.Name}' cannot call '{candidateTargetWf.Name}'.";
                                return false;
                            }

                            // Continue BFS traversal
                            if (!string.IsNullOrEmpty(childId) && !visited.Contains(childId))
                            {
                                visited.Add(childId);
                                queue.Enqueue(childId);
                            }
                            else if (!string.IsNullOrEmpty(childName))
                            {
                                var childWf = workflowList.FirstOrDefault(w => string.Equals(w.Name, childName, StringComparison.OrdinalIgnoreCase));
                                if (childWf != null && !visited.Contains(childWf.Id))
                                {
                                    visited.Add(childWf.Id);
                                    queue.Enqueue(childWf.Id);
                                }
                            }
                        }
                    }
                }
            }

            return true;
        }

        public static List<BulkWorkflowModel> GetValidTargetWorkflows(
            BulkWorkflowModel currentWf,
            IEnumerable<BulkWorkflowModel> allWorkflows)
        {
            var result = new List<BulkWorkflowModel>();
            if (currentWf == null || allWorkflows == null) return result;

            var allList = allWorkflows.ToList();
            foreach (var candidate in allList)
            {
                if (CanWorkflowReference(currentWf, candidate, allList, out _))
                {
                    result.Add(candidate);
                }
            }
            return result;
        }
    }
}
