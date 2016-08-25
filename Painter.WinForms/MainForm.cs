using System;
using System.Linq;
using System.Windows.Forms;
using Painter.WinForms.Tools;

namespace Painter.WinForms
{
    public partial class MainForm : Form
    {
        private readonly StartupParams _prms;
        private readonly FileManager _fileManager;
        private readonly Invertion _invert;

        public MainForm()
        {
            InitializeComponent();

            _prms = StartupParams.Instance();
            _fileManager = FileManager.Instance(DrawField);
            _invert = Invertion.Instance(DrawField, LoadBar);

            labelLoadPercent.BackColor = System.Drawing.Color.Transparent;

            BorderColor.BackColor = _prms.CurrentBorderColor;
            BackgroundColor.BackColor = _prms.CurrentBackgroundColor;
        }

        private void ChoiceDrawingTool_Click(object sender, EventArgs e)
        {
            _prms.CurrentTool = _prms.Tools.FirstOrDefault(q => (sender as Button)?.Name == q.Name);
            if (_prms.CurrentTool != null) _prms.CurrentTool.PictureBox = DrawField;
        }

        private void ButtonChoiceColor_Click(object sender, EventArgs e)
        {
            using (var colors = new ColorDialog())
            {
                if (colors.ShowDialog() == DialogResult.OK)
                {
                    switch ((sender as Button)?.Name)
                    {
                        case "BorderColor":
                            BorderColor.BackColor = colors.Color;
                            _prms.CurrentBorderColor = colors.Color; break;
                        case "BackgroundColor":
                            BackgroundColor.BackColor = colors.Color;
                            _prms.CurrentBackgroundColor = colors.Color; break;
                    }
                }
            }
        }

        private void ButtonSaveOrLoad_Click(object sender, EventArgs e)
        {
            switch ((sender as Button)?.Name)
            {
                case "Save":
                    _fileManager.Save();
                    break;
                case "Load":
                    _fileManager.Load();
                    break;
            }
        }

        private async void ButtonInvertion_Click(object sender, EventArgs e)
        {
            var progressIndocator = new Progress<int>(ReportProgress);
            await _invert.ChangePictureAsync(progressIndocator);
        }

        private void ReportProgress(int value)
        {
            LoadBar.Increment(1);
            DrawProgressPercent();
            if (LoadBar.Value == LoadBar.Maximum)
                LoadBar.Value = 0;
        }

        private void DrawProgressPercent()
        {
            var percent =
                (int) (((double) (LoadBar.Value - LoadBar.Minimum)/(double) (LoadBar.Maximum - LoadBar.Minimum))*100);
            labelLoadPercent.Text = percent == 100 ? "" : $"{percent} %";
        }

        #region Draw events
        private void DrawField_MouseDown(object sender, MouseEventArgs e)
        {
            _prms.CurrentTool?.MouseDown(e, _prms.CurrentBorderColor, _prms.CurrentBackgroundColor);
        }

        private void DrawField_MouseMove(object sender, MouseEventArgs e)
        {
            _prms.CurrentTool?.MouseMove(e);
        }

        private void DrawField_MouseUp(object sender, MouseEventArgs e)
        {
            _prms.CurrentTool?.MouseUp(e);
        }
        #endregion
    }
}
