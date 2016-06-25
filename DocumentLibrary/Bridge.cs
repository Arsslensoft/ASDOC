using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace DocumentLibrary
{
    public static class Bridge
    {   
        #region Properties

        /// <summary>
        /// Gets the stylesheet for sample documents
        /// </summary>
        public static string StyleSheet
        {
            get {
                return @"
                    h1, h2, h3 { color: navy; font-weight:normal; }
                    body { font:10pt Tahoma }
		            pre  { border:solid 1px gray; background-color:#eee; padding:1em }
                    .gray    { color:gray; }
                    .example { background-color:#efefef; corner-radius:5px; padding:0.5em; }
                    .caption { font-weight:bold }
                    .whitehole { background-color:white; corner-radius:5px; padding:10px; }
                ";
            }
        }


        #endregion
    }
}
