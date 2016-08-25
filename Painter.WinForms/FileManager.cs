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

        private static readonly IDictionary<string, ImageFormat> AllowFormats  = new Dictionary<string, ImageFormat>
        {
            { ".png", ImageFormat.Png },
            { ".bmp", ImageFormat.Bmp},
            { ".jpg", ImageFormat.Jpeg},
        };

        private readonly string _formatFilter = AllowFormats.Keys.Aggregate(string.Empty,
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
                    var selectedFormat = AllowFormats.FirstOrDefault(q => q.Key == extension);
                    var format = selectedFormat.Value ?? ImageFormat.Png;

                    _drawField.Image.Save(saveFile.FileName, format);
                }
            }
        }
    }
}
