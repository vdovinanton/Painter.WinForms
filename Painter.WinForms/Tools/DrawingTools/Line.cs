using System.Windows.Forms;

namespace Painter.WinForms.Tools.DrawingTools
{
    public class Line: ToolsBase
    {
        public Line()
        {
            Name = GetType().Name;
        }
        public override void MouseMove(MouseEventArgs e)
        {
            if (Point == null) return;

            CreateImage();

            PictureBox.Invalidate();
            PictureBox.Update();
            using (var g = PictureBox.CreateGraphics())
            {
                g.DrawLine(Pen, Point.Value.X, Point.Value.Y, e.X, e.Y);
            }
        }
    }
}
