using System;
using System.Drawing;
using System.Windows.Forms;

namespace Painter.WinForms.DrawingTools
{
    public class Rectangle: ToolsBase
    {
        private SolidBrush _backgroundColor;
        public Rectangle()
        {
            Name = GetType().Name;
        }

        public override void MouseDown(MouseEventArgs e, Color c1, Color? c2 = null)
        {
            Previous = new Point(e.X, e.Y);
            Pen = new Pen(c1, 2);

            if (c2 != null)
            {
                _backgroundColor = new SolidBrush(c2.Value);
                MouseMove(e);
            }
        }

        public override void MouseMove(MouseEventArgs e)
        {
            if (Previous != null)
            {
                if (PictureBox.Image == null)
                {
                    //TODO: выделить функциб в базовом классе
                    var bmp = new Bitmap(PictureBox.Width, PictureBox.Height);
                    using (var g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.White);
                    }
                    PictureBox.Image = bmp;
                }
                PictureBox.Invalidate();
                PictureBox.Update();

                using (var g = Graphics.FromImage(PictureBox.Image))
                {
                    Draw(e, g);
                }
            }
        }

        public override void MouseUp(MouseEventArgs e)
        {
            using (var g = Graphics.FromImage(PictureBox.Image))
            {
                Draw(e, g);
            }

            Previous = null;
        }

        private void Draw(MouseEventArgs e, Graphics g)
        {
            if (Previous != null)
            {
                var x1 = Math.Min(Previous.Value.X, e.X);
                var y1 = Math.Min(Previous.Value.Y, e.Y);
                var width = Math.Abs(e.X - Previous.Value.X);
                var height = Math.Abs(e.Y - Previous.Value.Y);

                g.FillRectangle(_backgroundColor, x1, y1, width, height);
                g.DrawRectangle(Pen, x1, y1, width, height);
            }
        }
    }
}
