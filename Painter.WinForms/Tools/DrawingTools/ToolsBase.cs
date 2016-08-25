using System.Drawing;
using System.Windows.Forms;

namespace Painter.WinForms.Tools.DrawingTools
{
    public abstract class ToolsBase
    {
        protected Pen Pen { get; set; }
        public string Name { get; set; }
        protected Point? Point { get; set; }
        public PictureBox PictureBox { get; set; }

        public abstract void MouseMove(MouseEventArgs e);

        public virtual void MouseUp(MouseEventArgs e)
        {
            using (var g = Graphics.FromImage(PictureBox.Image))
            {
                if (Point != null) g.DrawLine(Pen, Point.Value.X, Point.Value.Y, e.X, e.Y);
            }

            Point = null;
        }

        protected void CreateImage()
        {
            if (PictureBox.Image != null) return;

            var bmp = new Bitmap(PictureBox.Width, PictureBox.Height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
            }
            PictureBox.Image = bmp;
        }

        public virtual void MouseDown(MouseEventArgs e, Color borderColor, Color? backgroundColor = null)
        {
            Point = new Point(e.X, e.Y);
            Pen = new Pen(borderColor, 2);
            MouseMove(e);
        }
    }
}
