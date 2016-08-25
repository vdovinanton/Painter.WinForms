using System.Drawing;

namespace Painter.WinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadBar = new System.Windows.Forms.ProgressBar();
            this.Colors = new System.Windows.Forms.ColorDialog();
            this.BorderColor = new System.Windows.Forms.Button();
            this.BackgroundColor = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Circle = new System.Windows.Forms.Button();
            this.Rectangle = new System.Windows.Forms.Button();
            this.Line = new System.Windows.Forms.Button();
            this.Pencil = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Load = new System.Windows.Forms.Button();
            this.DrawField = new System.Windows.Forms.PictureBox();
            this.labelLoadPercent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DrawField)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadBar
            // 
            this.LoadBar.BackColor = System.Drawing.SystemColors.Control;
            this.LoadBar.Location = new System.Drawing.Point(-1, 406);
            this.LoadBar.Name = "LoadBar";
            this.LoadBar.Size = new System.Drawing.Size(827, 13);
            this.LoadBar.TabIndex = 1;
            // 
            // Colors
            // 
            this.Colors.AllowFullOpen = false;
            // 
            // BorderColor
            // 
            this.BorderColor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BorderColor.Location = new System.Drawing.Point(778, 39);
            this.BorderColor.Name = "BorderColor";
            this.BorderColor.Size = new System.Drawing.Size(33, 30);
            this.BorderColor.TabIndex = 8;
            this.BorderColor.UseVisualStyleBackColor = true;
            this.BorderColor.Click += new System.EventHandler(this.ButtonChoiceColor_Click);
            // 
            // BackgroundColor
            // 
            this.BackgroundColor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackgroundColor.Location = new System.Drawing.Point(778, 75);
            this.BackgroundColor.Name = "BackgroundColor";
            this.BackgroundColor.Size = new System.Drawing.Size(33, 30);
            this.BackgroundColor.TabIndex = 9;
            this.BackgroundColor.UseVisualStyleBackColor = true;
            this.BackgroundColor.Click += new System.EventHandler(this.ButtonChoiceColor_Click);
            // 
            // button1
            // 
            this.button1.Image = global::Painter.WinForms.Properties.Resources.Cultures_Triskelion_icon;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(778, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 30);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonInvertion_Click);
            // 
            // Circle
            // 
            this.Circle.Image = global::Painter.WinForms.Properties.Resources.Arrow_Circle_icon;
            this.Circle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Circle.Location = new System.Drawing.Point(10, 146);
            this.Circle.Name = "Circle";
            this.Circle.Size = new System.Drawing.Size(33, 30);
            this.Circle.TabIndex = 7;
            this.Circle.UseVisualStyleBackColor = true;
            this.Circle.Click += new System.EventHandler(this.ChoiceDrawingTool_Click);
            // 
            // Rectangle
            // 
            this.Rectangle.Image = global::Painter.WinForms.Properties.Resources.Editing_Rectangle_icon;
            this.Rectangle.Location = new System.Drawing.Point(10, 110);
            this.Rectangle.Name = "Rectangle";
            this.Rectangle.Size = new System.Drawing.Size(33, 30);
            this.Rectangle.TabIndex = 6;
            this.Rectangle.UseVisualStyleBackColor = true;
            this.Rectangle.Click += new System.EventHandler(this.ChoiceDrawingTool_Click);
            // 
            // Line
            // 
            this.Line.Image = global::Painter.WinForms.Properties.Resources.Editing_Line_icon;
            this.Line.Location = new System.Drawing.Point(10, 74);
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(33, 30);
            this.Line.TabIndex = 5;
            this.Line.UseVisualStyleBackColor = true;
            this.Line.Click += new System.EventHandler(this.ChoiceDrawingTool_Click);
            // 
            // Pencil
            // 
            this.Pencil.Image = global::Painter.WinForms.Properties.Resources.Pencil_icon;
            this.Pencil.Location = new System.Drawing.Point(10, 38);
            this.Pencil.Name = "Pencil";
            this.Pencil.Size = new System.Drawing.Size(33, 30);
            this.Pencil.TabIndex = 4;
            this.Pencil.UseVisualStyleBackColor = true;
            this.Pencil.Click += new System.EventHandler(this.ChoiceDrawingTool_Click);
            // 
            // Save
            // 
            this.Save.Image = global::Painter.WinForms.Properties.Resources.Save_icon;
            this.Save.Location = new System.Drawing.Point(51, 3);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(33, 30);
            this.Save.TabIndex = 3;
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.ButtonSaveOrLoad_Click);
            // 
            // Load
            // 
            this.Load.Image = global::Painter.WinForms.Properties.Resources.open_file_icon;
            this.Load.Location = new System.Drawing.Point(10, 3);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(33, 30);
            this.Load.TabIndex = 2;
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.ButtonSaveOrLoad_Click);
            // 
            // DrawField
            // 
            this.DrawField.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DrawField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawField.Location = new System.Drawing.Point(51, 39);
            this.DrawField.Name = "DrawField";
            this.DrawField.Size = new System.Drawing.Size(721, 367);
            this.DrawField.TabIndex = 0;
            this.DrawField.TabStop = false;
            this.DrawField.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawField_MouseDown);
            this.DrawField.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawField_MouseMove);
            this.DrawField.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawField_MouseUp);
            // 
            // labelLoadPercent
            // 
            this.labelLoadPercent.AutoSize = true;
            this.labelLoadPercent.Location = new System.Drawing.Point(778, 387);
            this.labelLoadPercent.Name = "labelLoadPercent";
            this.labelLoadPercent.Size = new System.Drawing.Size(0, 13);
            this.labelLoadPercent.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 418);
            this.Controls.Add(this.labelLoadPercent);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BackgroundColor);
            this.Controls.Add(this.BorderColor);
            this.Controls.Add(this.Circle);
            this.Controls.Add(this.Rectangle);
            this.Controls.Add(this.Line);
            this.Controls.Add(this.Pencil);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Load);
            this.Controls.Add(this.LoadBar);
            this.Controls.Add(this.DrawField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Painter";
            ((System.ComponentModel.ISupportInitialize)(this.DrawField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DrawField;
        private System.Windows.Forms.ProgressBar LoadBar;
        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Pencil;
        private System.Windows.Forms.Button Line;
        private System.Windows.Forms.Button Rectangle;
        private System.Windows.Forms.Button Circle;
        private System.Windows.Forms.ColorDialog Colors;
        private System.Windows.Forms.Button BorderColor;
        private System.Windows.Forms.Button BackgroundColor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelLoadPercent;
    }
}

