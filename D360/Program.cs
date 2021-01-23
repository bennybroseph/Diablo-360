
namespace D360
{
    using InputEmulation;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Windows.Forms;

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
            D360.Main.self.Init();
#if !DEBUG
            }
            catch (Exception exception)
            {
                Program.WriteToLog(exception);
            }
#endif
            // Cleanup just in case
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
