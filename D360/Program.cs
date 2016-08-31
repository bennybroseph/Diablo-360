using System;
#if DEBUG
using System.Runtime.InteropServices;
#endif
#if !DEBUG
using System.Globalization;
using System.IO;
#endif
using System.Windows.Forms;
using D360.InputEmulation;

namespace D360
{
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

            Application.Run(new HUDForm());
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
            VirtualKeyboard.ReleaseAll();
        }
    }
}
