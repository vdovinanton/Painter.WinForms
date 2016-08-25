using System.Drawing;
using System.Windows.Forms;

namespace Painter.WinForms.Tools.DrawingTools
{
    public class Pencil: ToolsBase
    {
        public Pencil()
        {
            Name = GetType().Name;
        }
        public override void MouseMove(MouseEventArgs e)
        {
            if (Point == null) return;

            CreateImage();
            using (var g = Graphics.FromImage(PictureBox.Image))
            {
                g.DrawLine(Pen, Point.Value.X, Point.Value.Y, e.X, e.Y);
            }

            PictureBox.Invalidate();
            Point = new Point(e.X, e.Y);
        }
    }
}
