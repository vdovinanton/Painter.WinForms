using System;
using System.Drawing;
using System.Windows.Forms;

namespace Painter.WinForms.Tools.DrawingTools
{
    public class Circle: ToolsBase
    {
        private SolidBrush _backgroundColor;
        public Circle()
        {
            Name = GetType().Name;
        }
        public override void MouseMove(MouseEventArgs e)
        {
            if (Point == null) return;

            CreateImage();
            PictureBox.Invalidate();
            PictureBox.Update();
                
            Draw(e, PictureBox.CreateGraphics());
        }

        public override void MouseDown(MouseEventArgs e, Color borderColor, Color? backgroundColor = null)
        {
            Point = new Point(e.X, e.Y);
            Pen = new Pen(borderColor, 2);
            if (backgroundColor != null) _backgroundColor = new SolidBrush(backgroundColor.Value);
            MouseMove(e);
        }

        public override void MouseUp(MouseEventArgs e)
        {
            Draw(e, Graphics.FromImage(PictureBox.Image));
            Point = null;
        }

        private void Draw(MouseEventArgs e, Graphics g)
        {
            if (Point == null) return;

            var size = Math.Min(e.X - Point.Value.X, e.Y - Point.Value.Y);

            g.FillEllipse(_backgroundColor, Point.Value.X, Point.Value.Y, size, size);
            g.DrawEllipse(Pen, Point.Value.X, Point.Value.Y, size, size);
        }
    }
}
