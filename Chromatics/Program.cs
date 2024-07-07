using Chromatics.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chromatics
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!ThereCanOnlyBeOne())
            {
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }

                return;
            }

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(ThreadExceptionHandler);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionHandler);

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.EnableVisualStyles();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Fm_MainWindow());
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            MessageBox.Show("Unhandled exception caught: " + ex.Message);
        }

        private static void ThreadExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Unhandled exception caught: " + e.Exception.Message);
        }

        private static bool ThereCanOnlyBeOne()
        {
            var thisprocessname = Process.GetCurrentProcess().ProcessName;
            var otherProcesses = Process.GetProcesses()
                .Where(p => p.ProcessName == thisprocessname)
                .Where(p => p.Id != Process.GetCurrentProcess().Id);

            var enumerable = otherProcesses.ToList();
            if (enumerable.Any())
            {
                if (MessageBox.Show(@"Another instance of Chromatics is currently running, and only one can run at a time. Would you like to close the other instance and use this one?", @"Already running", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (var process in enumerable)
                    {
                        process.Kill();
                        process.WaitForExit(5000);
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
