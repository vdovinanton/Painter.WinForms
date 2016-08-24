using System.Drawing;
using System.Windows.Forms;

namespace Painter.WinForms.DrawingTools
{
    public class Pencil: ToolsBase
    {
        public Pencil()
        {
            Name = GetType().Name;
        }
        public override void MouseMove(MouseEventArgs e)
        {
            if (Previous == null) return;

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
            using (var g = Graphics.FromImage(PictureBox.Image))
            {
                g.DrawLine(Pen, Previous.Value.X, Previous.Value.Y, e.X, e.Y);
            }

            PictureBox.Invalidate();
            Previous = new Point(e.X, e.Y);
        }
    }
}
