using System.Drawing;
using System.Windows.Forms;

namespace Painter.WinForms.Tools.DrawingTools
{
    public abstract class ToolsBase
    {
        // Tools for the drawing on the pictureBox
        protected Pen Pen { get; set; }
        protected Point? Point { get; set; }

        /// <summary>
        /// Unique instrument name, initial in constructor
        /// </summary>
        public string Name { get; set; }

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

        /// <summary>
        /// Current <see cref="PictureBox"/>
        /// </summary>
        public PictureBox PictureBox { get; set; }

        /// <summary>
        /// Mouse move event
        /// </summary>
        /// <param name="e">Mouse event parameters</param>
        public abstract void MouseMove(MouseEventArgs e);

        /// <summary>
        /// Mouse up event
        /// </summary>
        /// <param name="e">Mouse event parameters</param>
        public virtual void MouseUp(MouseEventArgs e)
        {
            using (var g = Graphics.FromImage(PictureBox.Image))
            {
                if (Point != null) g.DrawLine(Pen, Point.Value.X, Point.Value.Y, e.X, e.Y);
            }
            Point = null;
        }

        /// <summary>
        /// Mouse down event
        /// </summary>
        /// <param name="e">Mouse event parameters</param>
        /// <param name="borderColor">Color for the border figure</param>
        /// <param name="backgroundColor">Back color for the figure</param>
        public virtual void MouseDown(MouseEventArgs e, Color borderColor, Color? backgroundColor = null)
        {
            Point = new Point(e.X, e.Y);
            Pen = new Pen(borderColor, 2);
            MouseMove(e);
        }
    }
}
