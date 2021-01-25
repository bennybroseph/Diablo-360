
namespace D360
{
    using Controller;
    using Display;
    using Newtonsoft.Json;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    using Utility;

    using Action = System.Action;
    using Configuration = Controller.Configuration;

    public class Main : Singleton<Main>
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

        private ControllerManager m_ControllerManager;
        public ControllerManager controllerManager => m_ControllerManager;

        private ConfigForm m_ConfigForm;
        public ConfigForm configForm => m_ConfigForm;

        public Configuration configuration = new Configuration();

        private MyOverlayWindow m_OverlayWindow;
        public MyOverlayWindow overlayWindow => m_OverlayWindow;

        public void Init()
        {
            m_OverlayWindow = new MyOverlayWindow();

            m_ControllerManager = new ControllerManager();

            RunConfig();

            m_OverlayWindow.onDrawGraphics += Update;

            m_KeyboardProc = KeyboardHookCallback;
            m_KeyboardHookID = SetKeyboardHook(m_KeyboardProc);

            m_OverlayWindow.Run();
        }

        private void RunConfig()
        {
            m_ConfigForm = new ConfigForm();
            new Thread(() => Application.Run(m_ConfigForm)).Start();

            var serializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            if (File.Exists(@"Config.json"))
            {
                configuration =
                    JsonConvert.DeserializeObject<Configuration>(
                        File.ReadAllText(@"Config.json"),
                        serializerSettings);
            }
            else
            {
                File.AppendAllText(
                    @"Config.json",
                    JsonConvert.SerializeObject(configuration, serializerSettings));

                if (m_ConfigForm.InvokeRequired)
                    m_ConfigForm.Invoke(new Action(() => { m_ConfigForm.Show(); }));
            }
        }

        private void Update()
        {
            Time.Update();

#if !DEBUG
            try
            {
#endif
                m_ControllerManager.Update();
#if !DEBUG
            }

            catch (Exception exception)
            {
                Program.WriteToLog(exception);
                MessageBox.Show(new Form(), @"Exception in Logic update. Written to crash.txt.");

                Close();
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
                                    Close();
                                    break;

                                case Keys.F11:
                                    if (m_ConfigForm.InvokeRequired)
                                        m_ConfigForm.Invoke(new Action(() => {m_ConfigForm.Show();}));
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
                Debug.WriteLine((Keys)vkCode + " " + (KeyboardMessages)wParam);
            }

            return CallNextHookEx(m_KeyboardHookID, nCode, wParam, lParam);
        }

        private void Close()
        {
            m_OverlayWindow.Close();
            if (m_ConfigForm.InvokeRequired)
                m_ConfigForm.Invoke(new Action(() => { m_ConfigForm.Close(); }));
        }

        private static IntPtr SetKeyboardHook(LowLevelProc proc)
        {
            using (var curProcess = Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx((int)GlobalHookTypes.WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }
    }
}
