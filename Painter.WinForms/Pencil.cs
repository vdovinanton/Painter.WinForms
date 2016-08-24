using System.Drawing;
using System.Windows.Forms;

namespace Painter.WinForms
{
    public class Pencil
    {
        private Pen _pen;
        private Point? _previous;

        public string Name { get; } = "Pencil";
        public PictureBox PictureBox { get; set; }

        public void MouseDown(MouseEventArgs e, Color c1, Color? c2 = null)
        {
            _previous = new Point(e.X, e.Y);
            _pen = new Pen(c1, 2);
            MouseMove(e);
        }

        public void MouseMove(MouseEventArgs e)
        {
            if (_previous == null) return;

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
                g.DrawLine(_pen, _previous.Value.X, _previous.Value.Y, e.X, e.Y);
            }

            PictureBox.Invalidate();
            _previous = new Point(e.X, e.Y);
        }
        public void MouseUp(MouseEventArgs e)
        {
            var g = Graphics.FromImage(PictureBox.Image);

            if (_previous != null)
                g.DrawLine(_pen, _previous.Value.X, _previous.Value.Y, e.X, e.Y);

            _previous = null;
        }
    }
}
