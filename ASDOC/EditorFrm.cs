using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Text.RegularExpressions;
using System.IO;
using DocumentLibrary;
using System.Net;

namespace ASDOC
{
    public partial class EditorFrm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public EditorFrm()
        {
            InitializeComponent();
        }
        private string ReplaceFileSystemImages(string html, out List<string> files)
        {
            files = new List<string>();
            var matches = Regex.Matches(html, @"<img[^>]*?src\s*=\s*([""']?[^'"">]+?['""])[^>]*?>", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
            int i = 0;
            foreach (Match match in matches)
            {
                string src = match.Groups[1].Value;
                src = src.Trim('\"');
                if (File.Exists(src))
                {
                        src = string.Format("\"data:{0}\"", i.ToString());
                        files.Add(match.Groups[1].Value.Trim('\"'));
                        html = html.Replace(match.Groups[1].Value, src);
                        i++;
                }
                else if (src.StartsWith("http"))
                {
                    WebClient wb = new WebClient();
                    if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ASDOC\"))
                        Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ASDOC\");

                    string filename = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ASDOC\"+DateTime.Now.ToFileTimeUtc().ToString()+".jpg";
                    
                    wb.DownloadFile(src,filename);
                    src = string.Format("\"data:{0}\"", i.ToString());
                    files.Add(filename);
                    html = html.Replace(match.Groups[1].Value, src);
                    i++;
                }
            }
            return html;
        }
        private void editor1_OnSaveCalled(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(saveFileDialog1.FileName))
                    File.Delete(saveFileDialog1.FileName);


                List<string> str = new List<string>();
                  string  code = ReplaceFileSystemImages(editor1.getHTML(), out str);
                  ArsslenDocument.WriteDocument(saveFileDialog1.FileName, "<html><head><link rel=\"Stylesheet\" href=\"property:DocumentLibrary.Bridge.StyleSheet\" /></head><body bgcolor=black style=\"background-gradient:#666;margin:0\" color=#333><h1 align=center color=white>" + Path.GetFileNameWithoutExtension(saveFileDialog1.FileName) + "</h1><blockquote class=whitehole>" + code.Replace("&nbsp;", "") + "</blockquote></body></html>", str);

            }
        }

        private void EditorFrm_Shown(object sender, EventArgs e)
        {
            editor1.setHTML("");

        }
    }
}