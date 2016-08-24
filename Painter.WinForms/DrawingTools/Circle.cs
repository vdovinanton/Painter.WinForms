using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Painter.WinForms.Properties;

namespace Painter.WinForms.DrawingTools
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
                using (Graphics g = PictureBox.CreateGraphics())
                {
                    Draw(e, g);
                }
            }
        }

        public override void MouseDown(MouseEventArgs e, Color c1, Color? c2 = null)
        {
            Previous = new Point(e.X, e.Y);
            Pen = new Pen(c1, 2);
            _backgroundColor = new SolidBrush(c2.Value);
            MouseMove(e);
        }

        public override void MouseUp(MouseEventArgs e)
        {
            using (Graphics g = Graphics.FromImage(PictureBox.Image))
            {
                Draw(e, g);
            }

            Previous = null;
        }

        private void Draw(MouseEventArgs e, Graphics g)
        {
            if (Previous != null)
            {
                int size = Math.Min(e.X - Previous.Value.X, e.Y - Previous.Value.Y);

                g.FillEllipse(_backgroundColor, Previous.Value.X, Previous.Value.Y, size, size);
                g.DrawEllipse(Pen, Previous.Value.X, Previous.Value.Y, size, size);
            }
        }
    }
}
