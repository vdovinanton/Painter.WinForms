using System.Drawing;
using System.Windows.Forms;

namespace Painter.WinForms.DrawingTools
{
    public abstract class ToolsBase
    {
        protected Pen Pen { get; set; }
        public string Name { get; set; }
        protected Point? Previous { get; set; }
        public PictureBox PictureBox { get; set; }

        public abstract void MouseMove(MouseEventArgs e);
        public abstract void MouseUp(MouseEventArgs e);

        public virtual void MouseDown(MouseEventArgs e, Color c1, Color? c2 = null)
        {
            Previous = new Point(e.X, e.Y);
            Pen = new Pen(c1, 2);
            MouseMove(e);
        }
    }
}
