using System.Drawing;
using System.Windows.Forms;

namespace Painter.WinForms.DrawingTools
{
    public class Line: ToolsBase
    {
        //private Pen _pen;
        //private Point? _previous;


        //public string Name { get; } = "Line";
        //public PictureBox PictureBox { get; set; }
        public Line()
        {
            Name = "Line";
        }
        /*public override void MouseDown(MouseEventArgs e, Color c1, Color? c2 = null)
        {
            Previous = new Point(e.X, e.Y);
            Pen = new Pen(c1, 2);
            MouseMove(e);
        }*/

        public override void MouseMove(MouseEventArgs e)
        {
            if (Previous != null)
            {
                if (PictureBox.Image == null)
                {
                    Bitmap bmp = new Bitmap(PictureBox.Width, PictureBox.Height);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.White);
                    }
                    PictureBox.Image = bmp;
                }

                PictureBox.Invalidate();
                PictureBox.Update();
                using (Graphics g = PictureBox.CreateGraphics())
                {
                    g.DrawLine(Pen, Previous.Value.X, Previous.Value.Y, e.X, e.Y);
                }
            }
        }

        public override void MouseUp(MouseEventArgs e)
        {
            using (Graphics g = Graphics.FromImage(PictureBox.Image))
            {
                g.DrawLine(Pen, Previous.Value.X, Previous.Value.Y, e.X, e.Y);
            }

            Previous = null;
        }
    }
}
