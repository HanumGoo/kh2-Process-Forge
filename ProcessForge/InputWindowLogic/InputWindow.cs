using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace ProcessForge.InputWindowLogic
{
    public static class InputWindow
    {
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point point);

        [DllImport("user32.dll")]
        private static extern IntPtr GetAncestor(IntPtr hWnd, uint gaFlags);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ScreenToClient(IntPtr hWnd, ref Point lpPoint);

        [DllImport("user32.dll")]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private const uint GA_ROOT = 2;

        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const uint MOUSEEVENTF_RIGHTUP = 0x0010;

        private const uint WM_MOUSEMOVE = 0x0200;
        private const uint WM_LBUTTONDOWN = 0x0201;
        private const uint WM_LBUTTONUP = 0x0202;
        private const uint WM_LBUTTONDBLCLK = 0x0203;
        private const uint WM_RBUTTONDOWN = 0x0204;
        private const uint WM_RBUTTONUP = 0x0205;
        private const uint MK_LBUTTON = 0x0001;
        private const uint MK_RBUTTON = 0x0002;

        public static void ClickAt(int x, int y, int clickType = 0)
        {
            // 1. Move cursor to the target screen coordinate
            SetCursorPos(x, y);

            // 2. Locate window/control at (x, y) and bring to foreground if needed
            IntPtr hWnd = IntPtr.Zero;
            try
            {
                hWnd = WindowFromPoint(new Point(x, y));
                if (hWnd != IntPtr.Zero)
                {
                    IntPtr rootHwnd = GetAncestor(hWnd, GA_ROOT);
                    SetForegroundWindow(rootHwnd != IntPtr.Zero ? rootHwnd : hWnd);
                }
            }
            catch { }

            // Calculate client coordinates for target window
            Point clientPt = new Point(x, y);
            if (hWnd != IntPtr.Zero)
            {
                ScreenToClient(hWnd, ref clientPt);
            }
            IntPtr lParam = (IntPtr)((clientPt.Y << 16) | (clientPt.X & 0xFFFF));

            // Wait brief moment for OS and window to process cursor movement and hover state
            Thread.Sleep(35);

            if (clickType == 3) // Hover Only
            {
                if (hWnd != IntPtr.Zero)
                {
                    PostMessage(hWnd, WM_MOUSEMOVE, IntPtr.Zero, lParam);
                }
                return;
            }

            if (clickType == 2) // Single Right Click
            {
                mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, UIntPtr.Zero);
                if (hWnd != IntPtr.Zero)
                {
                    PostMessage(hWnd, WM_RBUTTONDOWN, (IntPtr)MK_RBUTTON, lParam);
                }

                Thread.Sleep(50); // Hold duration

                mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, UIntPtr.Zero);
                if (hWnd != IntPtr.Zero)
                {
                    PostMessage(hWnd, WM_RBUTTONUP, IntPtr.Zero, lParam);
                }

                Thread.Sleep(30);
                return;
            }

            int clicks = (clickType == 1) ? 2 : 1; // 1 = Double Left Click, 0 = Single Left Click

            for (int i = 0; i < clicks; i++)
            {
                if (i > 0) Thread.Sleep(80); // Double-click interval

                // Press button down
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
                if (hWnd != IntPtr.Zero)
                {
                    if (i == 1)
                    {
                        PostMessage(hWnd, WM_LBUTTONDBLCLK, (IntPtr)MK_LBUTTON, lParam);
                    }
                    else
                    {
                        PostMessage(hWnd, WM_LBUTTONDOWN, (IntPtr)MK_LBUTTON, lParam);
                    }
                }

                // Hold down for 50ms so game frame loop / Windows UI detects the button press
                Thread.Sleep(50);

                // Release button up
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
                if (hWnd != IntPtr.Zero)
                {
                    PostMessage(hWnd, WM_LBUTTONUP, IntPtr.Zero, lParam);
                }

                Thread.Sleep(30);
            }
        }
    }
}
