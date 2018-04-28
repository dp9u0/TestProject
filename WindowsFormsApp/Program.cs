// FileName:  Program.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20170914 15:05
// Description:   

#region

using System;
using System.Windows.Forms;

#endregion

namespace WindowsFormsApp {

    internal static class Program {

        /// <summary>
        ///     应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }

}