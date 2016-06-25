using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace ASDOC
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                string[] args = Environment.GetCommandLineArgs();
                bool v = false;
                string file = "";
                foreach (string s in args)
                    if (s.ToUpper() == "VIEW")
                        v = true;
                    else if (File.Exists(s))
                        file = s;



                if (v)
                    Application.Run(new ViewFrm(file));
                else
                    Application.Run(new EditorFrm());
            }
            catch(Exception ex)
            {
               MessageBox.Show(ex.Message, ex.StackTrace);
            }
        }
    }
}
