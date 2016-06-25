namespace ASDOC
{
    partial class EditorFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorFrm));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.editor1 = new DocumentLibrary.Editor.Editor();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "Document";
            this.saveFileDialog1.Filter = "*.asdoc|*.asdoc";
            // 
            // editor1
            // 
            this.editor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.editor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor1.ForeColor = System.Drawing.Color.Black;
            this.editor1.Location = new System.Drawing.Point(0, 0);
            this.editor1.Name = "editor1";
            this.editor1.ShowAlignCenterButton = true;
            this.editor1.ShowAlignLeftButton = true;
            this.editor1.ShowAlignRightButton = true;
            this.editor1.ShowBackColorButton = true;
            this.editor1.ShowBolButton = true;
            this.editor1.ShowBulletButton = true;
            this.editor1.ShowCopyButton = true;
            this.editor1.ShowCutButton = true;
            this.editor1.ShowFontFamilyButton = true;
            this.editor1.ShowFontSizeButton = true;
            this.editor1.ShowIndentButton = true;
            this.editor1.ShowItalicButton = true;
            this.editor1.ShowJustifyButton = true;
            this.editor1.ShowLinkButton = true;
            this.editor1.ShowNewButton = true;
            this.editor1.ShowOrderedListButton = true;
            this.editor1.ShowOutdentButton = true;
            this.editor1.ShowPasteButton = true;
            this.editor1.ShowPrintButton = true;
            this.editor1.ShowTxtBGButton = true;
            this.editor1.ShowTxtColorButton = true;
            this.editor1.ShowUnderlineButton = true;
            this.editor1.ShowUnlinkButton = true;
            this.editor1.Size = new System.Drawing.Size(734, 478);
            this.editor1.TabIndex = 0;
            this.editor1.OnSaveCalled += new System.EventHandler(this.editor1_OnSaveCalled);
            // 
            // EditorFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 478);
            this.Controls.Add(this.editor1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditorFrm";
            this.Text = "Arsslensoft Document Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.EditorFrm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private DocumentLibrary.Editor.Editor editor1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}