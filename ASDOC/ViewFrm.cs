using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;
using System.IO;
using DocumentLibrary;

namespace ASDOC
{
    public partial class ViewFrm : MetroForm
    {
        string FileName;
        public ViewFrm(string file)
        {
            FileName = file;
            InitializeComponent();
        }

        private void ViewFrm_Load(object sender, EventArgs e)
        {
            string code = "";
            if (File.Exists(FileName))
            {
                Dictionary<int, byte[]> data;
                ArsslenDocument.Read(FileName, out code, out data);

                ArsslenDocument.CurrentDocumentRessources = data;
                htmlPanel1.Text = code;
            }
            else
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Dictionary<int, byte[]> data;
                    ArsslenDocument.Read(openFileDialog1.FileName, out code, out data);

                    ArsslenDocument.CurrentDocumentRessources = data;
                    htmlPanel1.Text = code;
                }
                else
                    this.Close();
            }
        }

        private void ViewFrm_Shown(object sender, EventArgs e)
        {
         this.Size = new Size((int)htmlPanel1.HtmlContainer.Size.Width+10, (int)htmlPanel1.HtmlContainer.Size.Height+55);
            
        }
    }
}
