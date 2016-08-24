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
            if (Previous == null) return;

            CreateImage();
            PictureBox.Invalidate();
            PictureBox.Update();
                
            Draw(e, PictureBox.CreateGraphics());
        }

        public override void MouseDown(MouseEventArgs e, Color borderColor, Color? backgroundColor = null)
        {
            Previous = new Point(e.X, e.Y);
            Pen = new Pen(borderColor, 2);
            if (backgroundColor != null) _backgroundColor = new SolidBrush(backgroundColor.Value);
            MouseMove(e);
        }

        public override void MouseUp(MouseEventArgs e)
        {
            Draw(e, Graphics.FromImage(PictureBox.Image));
            Previous = null;
        }

        private void Draw(MouseEventArgs e, Graphics g)
        {
            if (Previous == null) return;

            var size = Math.Min(e.X - Previous.Value.X, e.Y - Previous.Value.Y);

            g.FillEllipse(_backgroundColor, Previous.Value.X, Previous.Value.Y, size, size);
            g.DrawEllipse(Pen, Previous.Value.X, Previous.Value.Y, size, size);
        }
    }
}
