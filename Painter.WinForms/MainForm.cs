using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Painter.WinForms.Tools.DrawingTools;
using Rectangle = Painter.WinForms.Tools.DrawingTools.Rectangle;

namespace Painter.WinForms
{
    public partial class MainForm : Form
    {
        private Color _currentBorderColor = Color.Black;
        private Color _currentBackgroundColor = Color.AliceBlue;

        private ToolsBase CurrentTool { get; set; }
        private IEnumerable<ToolsBase> Tools { get; } = new List<ToolsBase> { new Pencil(), new Line(), new Rectangle(), new Circle() };
        public MainForm()
        {
            InitializeComponent(_currentBorderColor, _currentBackgroundColor);
        }

        private void ChoiceDrawingTool_Click(object sender, EventArgs e)
        {
            CurrentTool = Tools.FirstOrDefault(q => (sender as Button)?.Name == q.Name);
            if (CurrentTool != null) CurrentTool.PictureBox = DrawField;
        }

        private void DrawField_MouseDown(object sender, MouseEventArgs e)
        {
            CurrentTool?.MouseDown(e, _currentBorderColor, _currentBackgroundColor);
        }

        private void DrawField_MouseMove(object sender, MouseEventArgs e)
        {
            CurrentTool?.MouseMove(e);
        }

        private void DrawField_MouseUp(object sender, MouseEventArgs e)
        {
            CurrentTool?.MouseUp(e);
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
                            _currentBorderColor = colors.Color; break;
                        case "BackgroundColor":
                            BackgroundColor.BackColor = colors.Color;
                            _currentBackgroundColor = colors.Color; break;
                    }
                }
            }
        }
    }
}
