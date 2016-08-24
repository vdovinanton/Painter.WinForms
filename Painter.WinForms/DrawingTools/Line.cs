using System.Drawing;
using System.Windows.Forms;

namespace Painter.WinForms.DrawingTools
{
    public class Line: ToolsBase
    {
        public Line()
        {
            Name = GetType().Name;
        }
        public override void MouseMove(MouseEventArgs e)
        {
            if (Previous != null)
            {
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

                PictureBox.Invalidate();
                PictureBox.Update();
                using (var g = PictureBox.CreateGraphics())
                {
                    g.DrawLine(Pen, Previous.Value.X, Previous.Value.Y, e.X, e.Y);
                }
            }
        }
    }
}
