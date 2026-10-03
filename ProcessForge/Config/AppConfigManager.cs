using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ProcessForge.Config
{
    public class AppConfig
    {
        public MainFormConfig MainForm { get; set; } = new MainFormConfig();
        public BulkWindowConfig BulkWindow { get; set; } = new BulkWindowConfig();
    }

    public class MainFormConfig
    {
        public string ProcessName { get; set; } = string.Empty;
        public string FilePathName { get; set; } = string.Empty;
        public string RenameTextbox { get; set; } = string.Empty;
        public string NotepadPathTextbox { get; set; } = string.Empty;
        public string FilePathNameLogin { get; set; } = string.Empty;
    }

    public class BulkWindowConfig
    {
        public List<ProcessGroupModel> Groups { get; set; } = new List<ProcessGroupModel>();
        public Dictionary<string, WindowBoundsModel> OriginalWindowBounds { get; set; } = new Dictionary<string, WindowBoundsModel>(StringComparer.OrdinalIgnoreCase);
    }

    public class WindowBoundsModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public WindowBoundsModel() { }

        public WindowBoundsModel(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }

    public class ProcessGroupModel
    {
        public string GroupName { get; set; } = string.Empty;
        public List<string> ProcessTitles { get; set; } = new List<string>();

        public ProcessGroupModel() { }

        public ProcessGroupModel(string groupName)
        {
            GroupName = groupName;
        }

        public ProcessGroupModel(string groupName, IEnumerable<string> titles)
        {
            GroupName = groupName;
            ProcessTitles = new List<string>(titles);
        }
    }

    public static class AppConfigManager
    {
        private static readonly object _fileLock = new object();
        public static string ConfigFilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "main_config.json");

        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        public static AppConfig LoadConfig()
        {
            lock (_fileLock)
            {
                try
                {
                    if (File.Exists(ConfigFilePath))
                    {
                        string json = File.ReadAllText(ConfigFilePath);
                        var loaded = JsonSerializer.Deserialize<AppConfig>(json);
                        if (loaded != null)
                        {
                            loaded.MainForm ??= new MainFormConfig();
                            loaded.BulkWindow ??= new BulkWindowConfig();
                            loaded.BulkWindow.Groups ??= new List<ProcessGroupModel>();
                            loaded.BulkWindow.OriginalWindowBounds ??= new Dictionary<string, WindowBoundsModel>(StringComparer.OrdinalIgnoreCase);
                            return loaded;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error loading config: {ex.Message}");
                }

                return new AppConfig();
            }
        }

        public static void SaveConfig(AppConfig config)
        {
            lock (_fileLock)
            {
                try
                {
                    string json = JsonSerializer.Serialize(config, _jsonOptions);
                    File.WriteAllText(ConfigFilePath, json);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error saving config: {ex.Message}");
                }
            }
        }

        public static void SaveMainFormConfig(MainFormConfig mainFormConfig)
        {
            lock (_fileLock)
            {
                var config = LoadConfig();
                config.MainForm = mainFormConfig;
                SaveConfig(config);
            }
        }

        public static void SaveBulkWindowConfig(BulkWindowConfig bulkWindowConfig)
        {
            lock (_fileLock)
            {
                var config = LoadConfig();
                config.BulkWindow = bulkWindowConfig;
                SaveConfig(config);
            }
        }

        public static void RecordInitialWindowBounds(string processTitle, IntPtr hWnd)
        {
            if (string.IsNullOrWhiteSpace(processTitle) || hWnd == IntPtr.Zero) return;
            try
            {
                var bounds = ProcessForge.FindWindowLogic.GetAndFindWindow.GetWindowBounds(hWnd);
                if (bounds.HasValue)
                {
                    RecordInitialWindowBounds(processTitle, bounds.Value.X, bounds.Value.Y, bounds.Value.Width, bounds.Value.Height);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to record bounds for {processTitle}: {ex.Message}");
            }
        }

        public static void RecordInitialWindowBounds(string processTitle, int x, int y, int width, int height)
        {
            if (string.IsNullOrWhiteSpace(processTitle)) return;
            lock (_fileLock)
            {
                try
                {
                    var config = LoadConfig();
                    string key = processTitle.Trim();
                    config.BulkWindow.OriginalWindowBounds[key] = new WindowBoundsModel(x, y, width, height);
                    SaveConfig(config);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Failed to save bounds for {processTitle}: {ex.Message}");
                }
            }
        }
    }
}
