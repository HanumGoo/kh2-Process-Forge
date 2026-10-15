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
    }
}
