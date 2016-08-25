using System;
#if !DEBUG
using System.Globalization;
using System.IO;
#endif
using System.Windows.Forms;

namespace D360
{
    internal static class Program
    {
        /// <summary> The main entry point for the application. </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
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
        }
    }
}
