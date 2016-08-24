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
            if (Previous == null) return;

            CreateImage();

            PictureBox.Invalidate();
            PictureBox.Update();
            using (var g = PictureBox.CreateGraphics())
            {
                g.DrawLine(Pen, Previous.Value.X, Previous.Value.Y, e.X, e.Y);
            }
        }
    }
}
