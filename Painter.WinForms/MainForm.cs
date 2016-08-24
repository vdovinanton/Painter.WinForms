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
        public Pencil Pencil { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }

        private void ChoiceDrawingTool_Click(object sender, EventArgs e)
        {
            Pencil = new Pencil { PictureBox = DrawField };
        }

        private void DrawField_MouseDown(object sender, MouseEventArgs e)
        {
            Pencil?.MouseDown(e, Color.Black, Color.AliceBlue);
        }

        private void DrawField_MouseMove(object sender, MouseEventArgs e)
        {
            Pencil?.MouseMove(e);
        }

        private void DrawField_MouseUp(object sender, MouseEventArgs e)
        {
            Pencil?.MouseUp(e);
        }
    }
}
