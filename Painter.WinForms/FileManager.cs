using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Painter.WinForms
{
    public class FileManager
    {
        #region Singleton
        private static readonly Lazy<FileManager> _instance = new Lazy<FileManager>(() => new FileManager());
        public static FileManager Instance(PictureBox drawField)
        {
            _drawField = drawField;
            return _instance.Value;
        }
        #endregion

        private static PictureBox _drawField;

        private static readonly IDictionary<string, ImageFormat> AvailableFormats  = new Dictionary<string, ImageFormat>
        {
            { ".png", ImageFormat.Png },
            { ".bmp", ImageFormat.Bmp},
            { ".jpg", ImageFormat.Jpeg},
        };

        /// <summary>
        /// formatting allow formats for the <see cref="OpenFileDialog"/> and <see cref="SaveFileDialog"/>
        /// </summary>
        private readonly string _formatFilter = AvailableFormats.Keys.Aggregate(string.Empty,
                (current, allowFormat) => current + $"|{allowFormat} (*{allowFormat})|*{allowFormat}")
                    .TrimStart('|');

        public void Load()
        {
            using (var openFile = new OpenFileDialog { Filter = _formatFilter })
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    using (var fsstream = new FileStream(openFile.FileName, FileMode.OpenOrCreate))
                        _drawField.Image = new Bitmap(fsstream);
                }
            }
        }

        public void Save()
        {
            using (var saveFile = new SaveFileDialog { Filter = _formatFilter })
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    var extension = Path.GetExtension(saveFile.FileName);
                    var selectedFormat = AvailableFormats.FirstOrDefault(q => q.Key == extension);
                    var format = selectedFormat.Value ?? ImageFormat.Png;

                    if (_drawField.Image == null)
                        CreateEmptyCanvas();

                    _drawField.Image?.Save(saveFile.FileName, format);
                }
            }
        }

        /// <summary>
        /// If a u want save empty canvans :\
        /// </summary>
        private static void CreateEmptyCanvas()
        {
            var image = new Bitmap(_drawField.Width, _drawField.Height);

            using (var grp = Graphics.FromImage(image))
            {
                grp.FillRectangle(Brushes.White, 0, 0, _drawField.Width, _drawField.Height);
                _drawField.Image = new Bitmap(_drawField.Width, _drawField.Height, grp);
            }
        }
    }
}
