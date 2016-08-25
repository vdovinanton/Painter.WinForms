using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter.WinForms.Tools
{
    public class Invertion
    {
        private static readonly Lazy<Invertion> _instance = new Lazy<Invertion>(() => new Invertion());
        public static Invertion Instance(PictureBox drawField, ProgressBar progressBar)
        {
            _drawField = drawField;
            _progressBar = progressBar;
            return _instance.Value;
        }

        private static PictureBox _drawField;
        private static ProgressBar _progressBar;

        public async Task<int> ChangePictureAsync(IProgress<int> progress)
        {
            var pic = new Bitmap(_drawField.Image);
            var totalCount = pic.Height;
            _progressBar.Maximum = totalCount;

            var progressCount = await Task.Run(() =>
            {
                var tempCount = 0;
                for (var y = 0; y <= (pic.Height - 1); y++)
                {
                    for (var x = 0; x <= (pic.Width - 1); x++)
                    {
                        var inv = pic.GetPixel(x, y);
                        inv = Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                        pic.SetPixel(x, y, inv);
                    }
                    Thread.Sleep(10);
                    progress?.Report((tempCount * 100) / totalCount);
                    tempCount++;
                }
                _drawField.Image = pic;
                return tempCount;
            });
            return progressCount;
        }
    }
}
