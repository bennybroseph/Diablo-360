
namespace D360
{
    using Display;
    using Newtonsoft.Json;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Utility;

    public class Main
    {
        private delegate IntPtr LowLevelProc(int nCode, IntPtr wParam, IntPtr lParam);
        private LowLevelProc m_KeyboardProc;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private enum GlobalHookTypes
        {
            WH_GETMESSAGE = 3,
            WH_CALLWNDPROC = 4,
            WH_CALLWNDPROCRET = 12,
            WH_KEYBOARD_LL = 13,
            WH_MOUSE_LL = 14,
        }

        private enum KeyboardMessages
        {
            WM_KEYDOWN = 0x0100,
            WM_KEYUP = 0x0101,
        }

        private IntPtr m_KeyboardHookID = IntPtr.Zero;

        private readonly InputManager m_InputManager;
        private ConfigForm m_ConfigForm;

        private MyOverlayWindow m_Overlay;

        public Main()
        {
            m_InputManager = new InputManager();

            var config = new Thread(() => m_ConfigForm = new ConfigForm { inputManager = m_InputManager });
            config.Start();
            config.Join();

            var serializerSettings = new JsonSerializerSettings{TypeNameHandling = TypeNameHandling.All};
            if (File.Exists(@"Config.json"))
            {
                m_InputManager.configuration =
                    JsonConvert.DeserializeObject<Configuration>(
                        File.ReadAllText(@"Config.json"),
                        serializerSettings);
            }
            else
            {
                File.AppendAllText(
                    @"Config.json",
                    JsonConvert.SerializeObject(m_InputManager.configuration, serializerSettings));

                m_ConfigForm.Show();
            }

            m_Overlay = new MyOverlayWindow(m_InputManager.configuration.screen, m_InputManager.controllerState);

            m_Overlay.onDrawGraphics += Update;

            m_KeyboardProc = KeyboardHookCallback;
            m_KeyboardHookID = SetKeyboardHook(m_KeyboardProc);

            m_Overlay.Run();
        }

        private void Update()
        {
            Time.Update();

#if !DEBUG
            try
            {
#endif
                m_InputManager.Update();
#if !DEBUG
            }

            catch (Exception exception)
            {
                Program.WriteToLog(exception);
                MessageBox.Show(new Form(), @"Exception in Logic update. Written to crash.txt.");
                m_Overlay.Close();
            }
#endif
        }


        private IntPtr KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                switch ((KeyboardMessages)wParam)
                {
                    case KeyboardMessages.WM_KEYDOWN:
                        {
                            switch ((Keys)vkCode)
                            {
                                case Keys.M:
                                    break;

                                case Keys.Escape:
                                    break;

                                case Keys.F12:
                                    m_Overlay.Close();
                                    break;

                                case Keys.F11:
                                    m_ConfigForm.Show();
                                    break;
                            }
                            break;
                        }
                    case KeyboardMessages.WM_KEYUP:
                        {
                            switch ((Keys)vkCode)
                            {
                                case Keys.M:
                                    break;
                            }
                            break;
                        }

                }
                Console.WriteLine((Keys)vkCode + " " + (KeyboardMessages)wParam);
            }

            return CallNextHookEx(m_KeyboardHookID, nCode, wParam, lParam);
        }

        private static IntPtr SetKeyboardHook(LowLevelProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx((int)GlobalHookTypes.WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }
    }
}
