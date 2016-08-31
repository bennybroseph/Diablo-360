using D360.Display;
using D360.Utility;
using Microsoft.Xna.Framework.Input;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Keys = System.Windows.Forms.Keys;

namespace D360
{
    public partial class HUDForm : Form
    {
        // DLL libraries used to manage hotkeys
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        //[DllImport("user32.dll")]
        //public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const int CONFIG_HOTKEY = 0;
        private const int ACTIONS_HOTKEY = 1;
        private const int EXIT_HOTKEY = 2;

        private bool m_DiabloActive;

        private readonly bool m_HUDDisabled;

        private bool m_SetNonTopmost;

        private readonly HUD m_HUD;
        private readonly InputProcessor m_InputProcessor;
        private InputManager m_InputManager;

        private readonly ActionBindingsForm m_ActionBindingsForm;
        private readonly ConfigForm m_ConfigForm;

        //private GamePadState m_OldGamePadState;
        //private KeyboardState m_OldKeyboardState;

        /// <summary>
        /// Gets an IServiceProvider containing our IGraphicsDeviceService.
        /// This can be used with components such as the ContentManager,
        /// which use this service to look up the GraphicsDevice.
        /// </summary>
        public HUDForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.Manual;

            var screenWidth = Screen.GetBounds(this).Width;
            var screenHeight = Screen.GetBounds(this).Height;
            ClientSize = new Size(screenWidth, screenHeight);

            FormBorderStyle = FormBorderStyle.None;  // no borders

            Left = 0;
            Top = 0;

            TopMost = true;        // make the form always on top 
            Visible = true;        // Important! if this isn't set, then the form is not shown at all

            // Set the form click-through
            var initialStyle = GetWindowLong(Handle, -20);

            if (WindowFunctions.isCompositionEnabled())
                SetWindowLong(Handle, -20, initialStyle | 0x80000 | 0x20);
            else
                m_HUDDisabled = true;

            m_InputProcessor = new InputProcessor(GamePad.GetState(0));
            m_InputManager = new InputManager();

            m_HUD = new HUD(Handle)
            {
                screenWidth = screenWidth,
                screenHeight = screenHeight
            };

            // Extend aero glass style on form initialization
            OnResize(null);

            m_ActionBindingsForm = new ActionBindingsForm { inputProcessor = m_InputProcessor };

            if (File.Exists(@"ActionBindings.dat"))
                BinarySerializer.LoadObject(ref m_InputProcessor.actionBindings, @"ActionBindings.dat");
            else
            {
                BinarySerializer.SaveObject(m_InputProcessor.actionBindings, @"ActionBindings.dat");
                m_ActionBindingsForm.Show();
            }

            m_ConfigForm = new ConfigForm { inputManager = m_InputManager };

            if (File.Exists(@"Config.dat"))
                BinarySerializer.LoadObject(ref m_InputManager.configuration, @"Config.dat");
            else
            {
                BinarySerializer.SaveObject(m_InputManager.configuration, @"Config.dat");
                m_ConfigForm.Show();
            }

            m_InputProcessor.AddConfiguredBindings();

            //m_OldGamePadState = GamePad.GetState(0, GamePadDeadZone.Circular);
            //m_OldKeyboardState = Keyboard.GetState();

            if (m_HUDDisabled)
            {
                Visible = false;
                ClientSize = new Size(0, 0);

                //hudlessUpdateThread = new Thread(new ThreadStart(DoUpdate));
                //hudlessUpdateThread.Start();
                //while (!hudlessUpdateThread.IsAlive) ;

                backgroundWorker1.RunWorkerAsync();
            }

            RegisterHotKey(Handle, ACTIONS_HOTKEY, 2, (int)Keys.F10);
            RegisterHotKey(Handle, CONFIG_HOTKEY, 2, (int)Keys.F11);
            RegisterHotKey(Handle, EXIT_HOTKEY, 2, (int)Keys.F12);
        }

        protected override void OnResize(EventArgs e)
        {
            var margins = new[] { 0, 0, Width, Height };

            // Extend aero glass style to whole form
            DwmExtendFrameIntoClientArea(Handle, ref margins);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                // Set the form click-through
                //cp.ExStyle |= 0x80000 /* WS_EX_LAYERED */ | 0x20 /* WS_EX_TRANSPARENT */;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // do nothing here to stop window normal background painting
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Application.DoEvents();

            Time.Update();
#if !DEBUG
            var foregroundWindowString = WindowFunctions.GetActiveWindowTitle();

            m_DiabloActive =
                    !string.IsNullOrEmpty(foregroundWindowString) &&
                    foregroundWindowString.ToUpper() == "DIABLO III";
#else
            m_DiabloActive = true;
#endif

            try
            {
                if (m_DiabloActive && !m_SetNonTopmost)
                {
                    WindowFunctions.DisableTopMost(WindowFunctions.GetForegroundWindowHandle());

                    m_SetNonTopmost = true;
                }

            }
            catch (Exception exception)
            {
                WriteToLog(exception);
                MessageBox.Show(@"Exception in windowing functions. Written to crash.txt.");
                Close();
            }

            try
            {
                m_HUD.Draw(m_InputProcessor.currentControllerState, m_DiabloActive);
            }
            catch (Exception exception)
            {
                WriteToLog(exception);
                MessageBox.Show(@"Exception in HUD draw. Written to crash.txt.");
                Close();
            }

            // Redraw immediately
            Invalidate();

            try
            {
                if (m_DiabloActive)
                {
                    LogicUpdate();
                }
            }
            catch (Exception exception)
            {
                WriteToLog(exception);
                MessageBox.Show(@"Exception in Logic update. Written to crash.txt.");
                Close();
            }
        }


        //public void BindingsUpdate()
        //{
        //    var newState = GamePad.GetState(0, GamePadDeadZone.Circular);

        //    if ((newState.IsButtonDown(Buttons.Back)) && (newState.IsButtonDown(Buttons.Start)))
        //    {
        //        if ((oldGamePadState.IsButtonUp(Buttons.Back)) || (oldGamePadState.IsButtonUp(Buttons.Start)))
        //        {
        //            if (ActionBindingsForm.Visible)
        //            {
        //                ActionBindingsForm.Visible = false;
        //            }
        //            else
        //            {
        //                ActionBindingsForm.Visible = true;
        //            }
        //        }
        //    }

        //    oldGamePadState = newState;
        //}

        public void LogicUpdate()
        {
            //m_InputProcessor.Update(GamePad.GetState(0, GamePadDeadZone.Circular));
            m_InputManager.Update();
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("dwmapi.dll")]
        private static extern void DwmExtendFrameIntoClientArea(IntPtr hWnd, ref int[] pMargins);

        //[DllImport("user32.dll")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //public static extern bool SetWindowPos(
        //    IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private void HUDForm_Load(object sender, EventArgs e)
        {

        }

        private void HUDForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //terminateThread = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //DoUpdate();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                switch (m.WParam.ToInt32())
                {
                case CONFIG_HOTKEY:
                    m_ConfigForm.Visible = !m_ConfigForm.Visible;
                    break;
                case ACTIONS_HOTKEY:
                    m_ActionBindingsForm.Visible = !m_ActionBindingsForm.Visible;
                    break;
                case EXIT_HOTKEY:
                    Close();
                    break;
                }
            }
            base.WndProc(ref m);
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
