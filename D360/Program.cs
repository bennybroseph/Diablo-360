 using System;
 using System.Threading;
 using System.Threading.Tasks;
#if DEBUG
using System.Runtime.InteropServices;
#endif
#if !DEBUG
using System.Globalization;
using System.IO;
#endif
using System.Windows.Forms;
 using D360.Display;
 using D360.InputEmulation;
using D360.Utility;

namespace D360
{
    using System.Globalization;
    using System.IO;

    internal static class Program
    {
#if DEBUG
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();
#endif
        /// <summary> The main entry point for the application. </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if DEBUG
            AllocConsole(); // Allows the console to show for debugging purposes
#endif

#if !DEBUG
            try
            {
#endif
            var main = new Main();

            //var maxFPS = 90f;

            //var main = new Main();
            //Task.Run(() =>
            //{
            //    var prevFrame = DateTime.Now;
            //    var prevSecond = DateTime.Now;

            //    var deltaTime = DateTime.Now - prevFrame;
            //    var fps = 0;

            //    while (true)
            //    {
            //        deltaTime = DateTime.Now - prevFrame;

            //        main.Update();
            //        ++fps;

            //        //while ((DateTime.Now - prevFrame).TotalMilliseconds < 1000f / maxFPS)
            //        //    Thread.Sleep(1);

            //        prevFrame = DateTime.Now;

            //        if ((DateTime.Now - prevSecond).TotalSeconds > 1)
            //        {
            //            prevSecond = DateTime.Now;

            //            System.Diagnostics.Debug.WriteLine(fps);
            //            fps = 0;

            //        }
            //    }
            //});

            //Application.Run(new HUDForm());
#if !DEBUG
            }
            catch (Exception ex)
            {
                var crashPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\crash.txt";
                using (var outfile = new StreamWriter(crashPath, true))
                {
                    outfile.WriteLine();
                    outfile.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    outfile.WriteLine(ex.Message);
                    outfile.WriteLine(ex.StackTrace);
                    outfile.WriteLine();
                    outfile.Flush();
                }
            }
#endif
            // Cleanup just in case
            TaskbarUtility.Show();
            VirtualKeyboard.ReleaseAll();
        }

        public static void WriteToLog(Exception exception)
        {
            var crashPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\crash.txt";
            using (var outfile = new StreamWriter(crashPath, true))
            {
                outfile.WriteLine();
                outfile.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture));
                outfile.WriteLine(exception.Message);
                outfile.WriteLine(exception.StackTrace);
                outfile.WriteLine();
                outfile.Flush();
            }
        }
    }
}
