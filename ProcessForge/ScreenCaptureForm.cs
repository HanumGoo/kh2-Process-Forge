using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProcessForge
{
    public enum ScreenCaptureMode
    {
        Area,
        Point
    }

    public class ScreenCaptureForm : Form
    {
        public ScreenCaptureMode Mode { get; }
        public Rectangle SelectedArea { get; private set; }
        public Point SelectedPoint { get; private set; }

        private Point startPoint;
        private Point currentPoint;
        private bool isSelecting;

        public ScreenCaptureForm(ScreenCaptureMode mode = ScreenCaptureMode.Area)
        {
            this.Mode = mode;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.Bounds = SystemInformation.VirtualScreen;
            this.TopMost = true;
            this.BackColor = Color.Black;
            this.Opacity = 0.35;
            this.Cursor = Cursors.Cross;
            this.DoubleBuffered = true;
            this.KeyPreview = true;

            this.MouseDown += ScreenCaptureForm_MouseDown;
            this.MouseMove += ScreenCaptureForm_MouseMove;
            this.MouseUp += ScreenCaptureForm_MouseUp;
            this.KeyDown += ScreenCaptureForm_KeyDown;
        }

        private void ScreenCaptureForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void ScreenCaptureForm_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            if (Mode == ScreenCaptureMode.Point)
            {
                SelectedPoint = Cursor.Position;
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            startPoint = e.Location;
            currentPoint = e.Location;
            isSelecting = true;
        }

        private void ScreenCaptureForm_MouseMove(object? sender, MouseEventArgs e)
        {
            currentPoint = e.Location;
            if (isSelecting || Mode == ScreenCaptureMode.Point)
            {
                Invalidate();
            }
        }

        private void ScreenCaptureForm_MouseUp(object? sender, MouseEventArgs e)
        {
            if (Mode != ScreenCaptureMode.Area || !isSelecting || e.Button != MouseButtons.Left) return;

            isSelecting = false;
            Rectangle clientRect = GetRectangle(startPoint, currentPoint);
            SelectedArea = new Rectangle(this.PointToScreen(clientRect.Location), clientRect.Size);

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private Rectangle GetRectangle(Point start, Point end)
        {
            int x = Math.Min(start.X, end.X);
            int y = Math.Min(start.Y, end.Y);
            int width = Math.Abs(end.X - start.X);
            int height = Math.Abs(end.Y - start.Y);

            return new Rectangle(x, y, width, height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw instruction banner at top
            string tipText = Mode == ScreenCaptureMode.Point
                ? "CLICK ON TARGET CLICK LOCATION  |  PRESS ESC TO CANCEL"
                : "DRAG TO SELECT SCREENSHOT REGION  |  PRESS ESC TO CANCEL";

            using (Font tipFont = new Font("Segoe UI", 11F, FontStyle.Bold))
            using (Brush bgBrush = new SolidBrush(Color.FromArgb(200, 0, 0, 0)))
            using (Brush textBrush = new SolidBrush(Color.White))
            {
                SizeF textSize = e.Graphics.MeasureString(tipText, tipFont);
                int bannerW = (int)textSize.Width + 40;
                int bannerH = (int)textSize.Height + 16;
                int bannerX = (this.ClientSize.Width - bannerW) / 2;
                int bannerY = 20;

                e.Graphics.FillRectangle(bgBrush, bannerX, bannerY, bannerW, bannerH);
                using (Pen borderPen = new Pen(Color.FromArgb(120, 255, 255, 255), 1))
                {
                    e.Graphics.DrawRectangle(borderPen, bannerX, bannerY, bannerW, bannerH);
                }

                e.Graphics.DrawString(tipText, tipFont, textBrush, bannerX + 20, bannerY + 8);
            }

            if (Mode == ScreenCaptureMode.Area && isSelecting)
            {
                Rectangle rect = GetRectangle(startPoint, currentPoint);
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
            else if (Mode == ScreenCaptureMode.Point)
            {
                // Draw a crosshair around current mouse point
                using (Pen guidePen = new Pen(Color.Red, 1.5f))
                {
                    e.Graphics.DrawLine(guidePen, currentPoint.X - 15, currentPoint.Y, currentPoint.X + 15, currentPoint.Y);
                    e.Graphics.DrawLine(guidePen, currentPoint.X, currentPoint.Y - 15, currentPoint.X, currentPoint.Y + 15);
                    e.Graphics.DrawEllipse(guidePen, currentPoint.X - 8, currentPoint.Y - 8, 16, 16);
                }
            }
        }
    }
}