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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Line = new System.Windows.Forms.Button();
            this.Pencil = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonNew = new System.Windows.Forms.Button();
            this.DrawField = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DrawField)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(-1, 397);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(827, 23);
            this.progressBar1.TabIndex = 1;
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
            // ButtonSave
            // 
            this.ButtonSave.Image = global::Painter.WinForms.Properties.Resources.Save_icon;
            this.ButtonSave.Location = new System.Drawing.Point(51, 3);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(33, 30);
            this.ButtonSave.TabIndex = 3;
            this.ButtonSave.UseVisualStyleBackColor = true;
            // 
            // ButtonNew
            // 
            this.ButtonNew.Image = global::Painter.WinForms.Properties.Resources.Files_New_File_icon;
            this.ButtonNew.Location = new System.Drawing.Point(10, 3);
            this.ButtonNew.Name = "ButtonNew";
            this.ButtonNew.Size = new System.Drawing.Size(33, 30);
            this.ButtonNew.TabIndex = 2;
            this.ButtonNew.UseVisualStyleBackColor = true;
            // 
            // DrawField
            // 
            this.DrawField.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DrawField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawField.Location = new System.Drawing.Point(51, 39);
            this.DrawField.Name = "DrawField";
            this.DrawField.Size = new System.Drawing.Size(710, 352);
            this.DrawField.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.DrawField.TabIndex = 0;
            this.DrawField.TabStop = false;
            this.DrawField.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawField_MouseDown);
            this.DrawField.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawField_MouseMove);
            this.DrawField.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawField_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 418);
            this.Controls.Add(this.Line);
            this.Controls.Add(this.Pencil);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonNew);
            this.Controls.Add(this.progressBar1);
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
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button ButtonNew;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button Pencil;
        private System.Windows.Forms.Button Line;
    }
}

