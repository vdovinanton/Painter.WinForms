using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter.WinForms.Tools
{
    public class Inversion
    {
        #region Singleton
        private static readonly Lazy<Inversion> _instance = new Lazy<Inversion>(() => new Inversion());
        public static Inversion Instance(PictureBox drawField, ProgressBar progressBar)
        {
            _drawField = drawField;
            _progressBar = progressBar;
            return _instance.Value;
        }
        #endregion

        // Only using Singleton
        private Inversion() { }

        private static PictureBox _drawField;
        private static ProgressBar _progressBar;

        /// <summary>
        /// Invert picture
        /// </summary>
        /// <param name="progress">Report back progress</param>
        /// <returns></returns>
        public async Task ChangePictureAsync(IProgress<int> progress)
        {
            if (_drawField.Image == null) return;

            var pic = new Bitmap(_drawField.Image);
            var totalCount = pic.Height;
            _progressBar.Maximum = totalCount;

            await Task.Run(() =>
            {
                for (var y = 0; y <= (pic.Height - 1); y++)
                {
                    for (var x = 0; x <= (pic.Width - 1); x++)
                    {
                        var inv = pic.GetPixel(x, y);
                        inv = Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                        pic.SetPixel(x, y, inv);
                    }
                    Thread.Sleep(10);
                    progress?.Report((y * 100) / totalCount);
                }
                _drawField.Image = pic;
            });   
        }
    }
}
