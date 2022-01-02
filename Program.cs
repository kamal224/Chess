using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SrcChess {
    /// <summary>
    /// SrcChess:       Chess program
    /// Author:         Jacques Fournier
    /// </summary>
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmChessBoard());
        }
    }
}