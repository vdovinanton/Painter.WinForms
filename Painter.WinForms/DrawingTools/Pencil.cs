using System.Drawing;
using System.Windows.Forms;

namespace Painter.WinForms.DrawingTools
{
    public class Pencil: ToolsBase
    {
        //private Pen _pen;
        //private Point? _previous;

        //public string Name { get; } = "Pencil";
        //public PictureBox PictureBox { get; set; }

        public Pencil()
        {
            Name = "Pencil";
        }
        public override void MouseDown(MouseEventArgs e, Color c1, Color? c2 = null)
        {
            Previous = new Point(e.X, e.Y);
            Pen = new Pen(c1, 2);
            MouseMove(e);
        }

        public override void MouseMove(MouseEventArgs e)
        {
            if (Previous == null) return;

            if (PictureBox.Image == null)
            {
                var bmp = new Bitmap(PictureBox.Width, PictureBox.Height);
                using (var g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                }
                PictureBox.Image = bmp;
            }
            using (var g = Graphics.FromImage(PictureBox.Image))
            {
                g.DrawLine(Pen, Previous.Value.X, Previous.Value.Y, e.X, e.Y);
            }

            PictureBox.Invalidate();
            Previous = new Point(e.X, e.Y);
        }

        public override void MouseUp(MouseEventArgs e)
        {
            var g = Graphics.FromImage(PictureBox.Image);

            if (Previous != null)
                g.DrawLine(Pen, Previous.Value.X, Previous.Value.Y, e.X, e.Y);

            Previous = null;
        }
    }
}
