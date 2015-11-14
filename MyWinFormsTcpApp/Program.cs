using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinFormsTcpApp
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(MyCommonExceptionHandlingMethod);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMyWinFormsTcpApp());
        }

        /// <summary>
        /// MyCommonExceptionHandlingMethod
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        private static void MyCommonExceptionHandlingMethod(object sender, ThreadExceptionEventArgs ex)
        {
            MessageBox.Show(ex.Exception.Message, "Exception MessageBox", MessageBoxButtons.OK);
            Debug.WriteLine(ex);
        }

    }
}
