using System;
using System.Drawing;
using System.Windows.Forms;

namespace Painter.WinForms.Tools.DrawingTools
{
    public class Rectangle: ToolsBase
    {
        private SolidBrush _backgroundColor;
        public Rectangle()
        {
            Name = GetType().Name;
        }

        public override void MouseDown(MouseEventArgs e, Color borderColor, Color? backgroundColor = null)
        {
            Point = new Point(e.X, e.Y);
            Pen = new Pen(borderColor, 2);

            if (backgroundColor == null) return;

            _backgroundColor = new SolidBrush(backgroundColor.Value);
            MouseMove(e);
        }

        public override void MouseMove(MouseEventArgs e)
        {
            if (Point == null) return;

            CreateImage();
            PictureBox.Invalidate();
            PictureBox.Update();

            Draw(e, Graphics.FromImage(PictureBox.Image));            
        }

        public override void MouseUp(MouseEventArgs e)
        {
            Draw(e, Graphics.FromImage(PictureBox.Image));
            Point = null;
        }

        // Draw rectangle
        private void Draw(MouseEventArgs e, Graphics g)
        {
            if (Point == null) return;

            var x1 = Math.Min(Point.Value.X, e.X);
            var y1 = Math.Min(Point.Value.Y, e.Y);
            var width = Math.Abs(e.X - Point.Value.X);
            var height = Math.Abs(e.Y - Point.Value.Y);

            g.FillRectangle(_backgroundColor, x1, y1, width, height);
            g.DrawRectangle(Pen, x1, y1, width, height);
        }
    }
}
