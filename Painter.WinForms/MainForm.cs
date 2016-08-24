using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Painter.WinForms.DrawingTools;
using Rectangle = Painter.WinForms.DrawingTools.Rectangle;

namespace Painter.WinForms
{
    public partial class MainForm : Form
    {
        private ToolsBase CurrentTool { get; set; }
        private IEnumerable<ToolsBase> Tools { get; } = new List<ToolsBase> { new Pencil(), new Line(), new Rectangle(), new Circle() };
        public MainForm()
        {
            InitializeComponent();
        }

        private void ChoiceDrawingTool_Click(object sender, EventArgs e)
        {
            CurrentTool = Tools.FirstOrDefault(q => (sender as Button)?.Name == q.Name);
            if (CurrentTool != null) CurrentTool.PictureBox = DrawField;
        }

        private void DrawField_MouseDown(object sender, MouseEventArgs e)
        {
            CurrentTool?.MouseDown(e, Color.Black, Color.AliceBlue);
        }

        private void DrawField_MouseMove(object sender, MouseEventArgs e)
        {
            CurrentTool?.MouseMove(e);
        }

        private void DrawField_MouseUp(object sender, MouseEventArgs e)
        {
            CurrentTool?.MouseUp(e);
        }
    }
}
