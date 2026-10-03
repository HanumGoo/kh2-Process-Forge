using OpenCvSharp;
using ProcessForge.ApplicationLogic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace ProcessForge.FindWindowLogic
{
    public static class GetAndFindWindow
    {
        private const int SW_RESTORE = 9;
        private const int SW_MINIMIZE = 6;
        private const int SW_SHOW = 5;

        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPlacement(IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        
        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        public static void UpdateListbox(ListBox listBox, string NotepadFilePath, string ProcessName)
        {
            listBox.Items.Clear();
            Process[] AllApplicationProcess = Process.GetProcessesByName(ProcessName);
            List<string> ProcessNameList = new List<string>();


            foreach (Process p in AllApplicationProcess)
            {
                IntPtr hWnd = p.MainWindowHandle;

                if (hWnd != IntPtr.Zero)
                {
                    StringBuilder MySB = new StringBuilder(256);
                    int Title = GetWindowText(hWnd, MySB, MySB.Capacity);

                    if (Title != 0)
                    {
                        ProcessNameList.Add(MySB.ToString());
                    }

                }
                else
                {
                    MessageBox.Show($"there is no {ProcessName} opened. check again please?");
                    return;
                }
            }

            List<List<string>> AllDataFromNotepad = DataProcessFromImport.ProcessDataFromImport(NotepadFilePath);
            List<string> NewDataStructure = new List<string>();

            for (int o = 0; o < ProcessNameList.Count; o++)
            {
                bool CheckingTheStatus = false;



                for (int i = 0; i < AllDataFromNotepad[0].Count; i++)
                {

                    if (ProcessNameList[o] == AllDataFromNotepad[0][i])
                    {
                        ProcessNameList[o] = ProcessNameList[o] + " | Status: " + AllDataFromNotepad[1][i];
                        CheckingTheStatus = true;
                        break;
                    }
                    else
                    {

                    }
                }

                if (CheckingTheStatus)
                {
                    //listBox1.Items.Add(ProcessName[o]);
                    NewDataStructure.Add(ProcessNameList[o]);
                }
                else
                {
                    //listBox1.Items.Add(ProcessName[o] + "     | Status : No Account in notepad Import");
                    NewDataStructure.Add(ProcessName[o] + " | Status: No Item in notepad Import");
                }
            }
            //NewDataStructure.Sort();
            foreach (string s in NewDataStructure)
            {
                listBox.Items.Add(s);
            }
        }
        public static void WindowRestore(string TitleName)
        {

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                IntPtr hWnd = FindWindow(null, TitleName);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

                if (hWnd != IntPtr.Zero)
                {
                    ShowWindow(hWnd, SW_RESTORE);
                    ShowWindow(hWnd, SW_SHOW);

                }
                else
                {
                    MessageBox.Show("fail2");
                }


            
        }
        public static IntPtr GetWindowHandle(int processId)
        {
            try
            {
                Process p = Process.GetProcessById(processId);
                if (p.MainWindowHandle != IntPtr.Zero)
                    return p.MainWindowHandle;
            }
            catch { }

            IntPtr found = IntPtr.Zero;
            try
            {
                EnumWindows((hWnd, lParam) =>
                {
                    GetWindowThreadProcessId(hWnd, out uint pid);
                    if (pid == (uint)processId)
                    {
                        StringBuilder sb = new StringBuilder(256);
                        GetWindowText(hWnd, sb, sb.Capacity);
                        if (sb.Length > 0)
                        {
                            found = hWnd;
                            return false; // Found titled main window
                        }
                        if (found == IntPtr.Zero)
                        {
                            found = hWnd;
                        }
                    }
                    return true;
                }, IntPtr.Zero);
            }
            catch { }

            return found;
        }

        public static void WindowRestore(int processId)
        {
            IntPtr hWnd = GetWindowHandle(processId);
            if (hWnd != IntPtr.Zero)
            {
                ShowWindow(hWnd, SW_RESTORE);
                ShowWindow(hWnd, SW_SHOW);
                SetForegroundWindow(hWnd);
            }
            else
            {
                MessageBox.Show("Window not found.");
            }
        }

        public static void WindowMinimize(int processId)
        {
            IntPtr hWnd = GetWindowHandle(processId);
            if (hWnd != IntPtr.Zero)
            {
                ShowWindow(hWnd, SW_MINIMIZE);
            }
            else
            {
                MessageBox.Show("Window not found.");
            }
        }

        public static Rectangle WindowSize(int processId)
        {
            var bounds = GetWindowBounds(processId);
            if (bounds.HasValue) return bounds.Value;
            return Rectangle.Empty;
        }

        public static Rectangle? GetWindowBounds(IntPtr hWnd)
        {
            if (hWnd == IntPtr.Zero) return null;

            try
            {
                WINDOWPLACEMENT wp = new WINDOWPLACEMENT();
                wp.length = Marshal.SizeOf(typeof(WINDOWPLACEMENT));
                if (GetWindowPlacement(hWnd, ref wp))
                {
                    int w = wp.rcNormalPosition.Right - wp.rcNormalPosition.Left;
                    int h = wp.rcNormalPosition.Bottom - wp.rcNormalPosition.Top;
                    if (w > 50 && h > 50 && wp.rcNormalPosition.Left >= -10000 && wp.rcNormalPosition.Top >= -10000)
                    {
                        return new Rectangle(wp.rcNormalPosition.Left, wp.rcNormalPosition.Top, w, h);
                    }
                }

                if (GetWindowRect(hWnd, out RECT rect))
                {
                    int w = rect.Right - rect.Left;
                    int h = rect.Bottom - rect.Top;
                    if (w > 50 && h > 50 && rect.Left >= -10000 && rect.Top >= -10000)
                    {
                        return new Rectangle(rect.Left, rect.Top, w, h);
                    }
                }
            }
            catch { }

            return null;
        }

        public static Rectangle? GetWindowBounds(int processId)
        {
            IntPtr hWnd = GetWindowHandle(processId);
            if (hWnd != IntPtr.Zero)
            {
                return GetWindowBounds(hWnd);
            }
            return null;
        }

        public static void SetWindowBounds(int processId, int x, int y, int width, int height)
        {
            try
            {
                IntPtr hWnd = GetWindowHandle(processId);
                if (hWnd != IntPtr.Zero)
                {
                    WINDOWPLACEMENT wp = new WINDOWPLACEMENT();
                    wp.length = Marshal.SizeOf(typeof(WINDOWPLACEMENT));
                    if (GetWindowPlacement(hWnd, ref wp))
                    {
                        wp.rcNormalPosition.Left = x;
                        wp.rcNormalPosition.Top = y;
                        wp.rcNormalPosition.Right = x + width;
                        wp.rcNormalPosition.Bottom = y + height;
                        wp.showCmd = SW_RESTORE;
                        SetWindowPlacement(hWnd, ref wp);
                    }

                    ShowWindow(hWnd, SW_RESTORE);
                    ShowWindow(hWnd, SW_SHOW);
                    MoveWindow(hWnd, x, y, width, height, true);
                    SetForegroundWindow(hWnd);
                }
            }
            catch { }
        }

        public static void RestoreWindows(IEnumerable<int> processIds)
        {
            if (processIds == null) return;
            foreach (int pid in processIds)
            {
                if (pid <= 0) continue;
                try
                {
                    IntPtr hWnd = GetWindowHandle(pid);
                    if (hWnd != IntPtr.Zero)
                    {
                        ShowWindow(hWnd, SW_RESTORE);
                        ShowWindow(hWnd, SW_SHOW);
                        SetForegroundWindow(hWnd);
                    }
                }
                catch { }
            }
        }

        public static void MinimizeWindows(IEnumerable<int> processIds)
        {
            if (processIds == null) return;
            foreach (int pid in processIds)
            {
                if (pid <= 0) continue;
                try
                {
                    IntPtr hWnd = GetWindowHandle(pid);
                    if (hWnd != IntPtr.Zero)
                    {
                        ShowWindow(hWnd, SW_MINIMIZE);
                    }
                }
                catch { }
            }
        }

        public static void TileWindows(IEnumerable<int> processIds)
        {
            if (processIds == null) return;
            var validIds = processIds.Where(id => id > 0).ToList();
            if (validIds.Count == 0) return;

            Rectangle workArea = Screen.PrimaryScreen?.WorkingArea ?? new Rectangle(0, 0, 1920, 1080);
            int count = validIds.Count;

            int cols = (int)Math.Ceiling(Math.Sqrt(count));
            int rows = (int)Math.Ceiling((double)count / cols);

            int cellWidth = workArea.Width / cols;
            int cellHeight = workArea.Height / rows;

            for (int i = 0; i < count; i++)
            {
                int row = i / cols;
                int col = i % cols;

                int x = workArea.Left + col * cellWidth;
                int y = workArea.Top + row * cellHeight;

                try
                {
                    IntPtr hWnd = GetWindowHandle(validIds[i]);
                    if (hWnd != IntPtr.Zero)
                    {
                        ShowWindow(hWnd, SW_RESTORE);
                        ShowWindow(hWnd, SW_SHOW);
                        MoveWindow(hWnd, x, y, cellWidth, cellHeight, true);
                        SetForegroundWindow(hWnd);
                    }
                }
                catch { }
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPLACEMENT
    {
        public int length;
        public int flags;
        public int showCmd;
        public POINT ptMinPosition;
        public POINT ptMaxPosition;
        public RECT rcNormalPosition;
    }
}
