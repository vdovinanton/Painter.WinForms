using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter.WinForms
{
    public partial class MainForm : Form
    {
        private readonly StartupParams _prms;
        public MainForm()
        {
            _prms = StartupParams.Instance();
            InitializeComponent(_prms.CurrentBorderColor, _prms.CurrentBackgroundColor);
        }

        private void ChoiceDrawingTool_Click(object sender, EventArgs e)
        {
            _prms.CurrentTool = _prms.Tools.FirstOrDefault(q => (sender as Button)?.Name == q.Name);
            if (_prms.CurrentTool != null) _prms.CurrentTool.PictureBox = DrawField;
        }

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
    }
}
