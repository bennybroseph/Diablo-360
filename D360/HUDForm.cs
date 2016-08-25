using D360.Bindings;
using D360.Display;
using D360.SystemCode;
using Microsoft.Xna.Framework.Input;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace D360
{
    public partial class HUDForm : Form
    {
        public bool diabloActive;
        private bool setNonTopmost;

        public bool hudDisabled;

        private int screenWidth;
        private int screenHeight;

        private HUD hud;
        InputProcessor inputProcessor;

        ActionBindingsForm m_ActionBindingsForm;
        ConfigForm configForm;

        GamePadState oldGamePadState;
        KeyboardState oldKeyboardState;

        /*
        Thread hudlessUpdateThread;
        private bool terminateThread = false;

        private bool currentlyUpdating = false;
         */

        /// <summary>
        /// Gets an IServiceProvider containing our IGraphicsDeviceService.
        /// This can be used with components such as the ContentManager,
        /// which use this service to look up the GraphicsDevice.
        /// </summary>
        public HUDForm()
        {
            InitializeComponent();


            StartPosition = FormStartPosition.Manual;
            screenWidth = Screen.GetBounds(this).Width;
            screenHeight = Screen.GetBounds(this).Height;

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
                hudDisabled = true;

            inputProcessor = new InputProcessor(GamePad.GetState(0));

            hud = new HUD(Handle)
            {
                screenWidth = screenWidth,
                screenHeight = screenHeight
            };

            // Extend aero glass style on form initialization
            OnResize(null);

            m_ActionBindingsForm = new ActionBindingsForm { inputProcessor = inputProcessor };

            if (File.Exists(@"ActionBindings.dat"))
            {
                inputProcessor.actionBindings = LoadD3Bindings();
#if DEBUG
                m_ActionBindingsForm.Show();
#endif
            }
            else
            {
                SaveD3Bindings(inputProcessor.actionBindings);
                m_ActionBindingsForm.Show();
            }

            configForm = new ConfigForm { inputProcessor = inputProcessor };

            if (File.Exists(@"Config.dat"))
            {
                inputProcessor.config = LoadConfig();
#if DEBUG
                configForm.Show();
#endif
            }
            else
            {
                SaveConfig(inputProcessor.config);
                configForm.Show();
            }

            inputProcessor.AddConfiguredBindings();

            var configHotKey = new Hotkey
            {
                KeyCode = System.Windows.Forms.Keys.F10,
                Control = true
            };
            configHotKey.Pressed +=
                delegate
                {
                    configForm.Visible = !configForm.Visible;
                };
            configHotKey.Register(this);

            var bindingsHotKey = new Hotkey
            {
                KeyCode = System.Windows.Forms.Keys.F11,
                Control = true
            };
            bindingsHotKey.Pressed +=
                delegate
                {
                    m_ActionBindingsForm.Visible = !m_ActionBindingsForm.Visible;
                };
            bindingsHotKey.Register(this);

            var quitHotKey = new Hotkey
            {
                KeyCode = System.Windows.Forms.Keys.F12,
                Control = true
            };
            quitHotKey.Pressed +=
                delegate
                {
                    Close();
                };
            quitHotKey.Register(this);

            oldGamePadState = GamePad.GetState(0, GamePadDeadZone.Circular);
            oldKeyboardState = Keyboard.GetState();

            if (hudDisabled)
            {
                Visible = false;
                ClientSize = new Size(0, 0);

                //hudlessUpdateThread = new Thread(new ThreadStart(DoUpdate));
                //hudlessUpdateThread.Start();
                //while (!hudlessUpdateThread.IsAlive) ;

                backgroundWorker1.RunWorkerAsync();
            }
        }

        /*
        public void DoUpdate()
        {
            while (!terminateThread)
            {
                if (!currentlyUpdating)
                {
                    currentlyUpdating = true;
                    diabloActive = false;
                    string foregroundWindowString = WindowFunctions.GetActiveWindowTitle();

                    try
                    {
                        if (foregroundWindowString != null)
                        {
                            if (foregroundWindowString.ToUpper() == "DIABLO III")
                            {
                                diabloActive = true;

                                if (!setNonTopmost)
                                {
                                    WindowFunctions.DisableTopMost(WindowFunctions.GetForegroundWindowHandle());

                                    setNonTopmost = true;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string crashPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\crash.txt";
                        using (StreamWriter outfile = new StreamWriter(crashPath, true))
                        {
                            outfile.WriteLine();
                            outfile.WriteLine(DateTime.Now.ToString());
                            outfile.WriteLine(ex.Message);
                            outfile.WriteLine(ex.StackTrace);
                            outfile.WriteLine();
                            outfile.Flush();
                        }
                        MessageBox.Show("Exception in windowing functions. Written to crash.txt.");
                        this.Close();
                    }

                    try
                    {
                        if (diabloActive) LogicUpdate();
                    }
                    catch (Exception ex)
                    {
                        string crashPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\crash.txt";
                        using (StreamWriter outfile = new StreamWriter(crashPath, true))
                        {
                            outfile.WriteLine();
                            outfile.WriteLine(DateTime.Now.ToString());
                            outfile.WriteLine(ex.Message);
                            outfile.WriteLine(ex.StackTrace);
                            outfile.WriteLine();
                            outfile.Flush();
                        }
                        MessageBox.Show("Exception in Logic update. Written to crash.txt.");
                        this.Close();
                    }

                    if (ActionBindingsForm.Visible)
                    {
                        ActionBindingsForm.Refresh();
                    }

                    if (configForm.Visible)
                    {
                        configForm.Refresh();
                    }

                    currentlyUpdating = false;
                }
                Thread.Sleep(10);
            }
        }
         */

        private void SaveD3Bindings(ActionBindings bindings)
        {
            var bindingsFileStream = new FileStream(Application.StartupPath + @"\ActionBindings.dat", FileMode.Create);
            var bindingsBinaryFormatter = new BinaryFormatter();

            bindingsBinaryFormatter.Serialize(bindingsFileStream, bindings);
            bindingsFileStream.Close();
        }

        private ActionBindings LoadD3Bindings()
        {
            var bindingsFileStream = new FileStream(Application.StartupPath + @"\ActionBindings.dat", FileMode.Open);
            var bindingsBinaryFormatter = new BinaryFormatter();
            var result = (ActionBindings)bindingsBinaryFormatter.Deserialize(bindingsFileStream);

            bindingsFileStream.Close();
            return result;
        }


        private void SaveConfig(Configuration config)
        {
            var configFileStream = new FileStream(Application.StartupPath + @"\Config.dat", FileMode.Create);
            var configBinaryFormatter = new BinaryFormatter();

            configBinaryFormatter.Serialize(configFileStream, config);
            configFileStream.Close();
        }

        private Configuration LoadConfig()
        {
            var configFileStream = new FileStream(Application.StartupPath + @"\Config.dat", FileMode.Open);
            var configBinaryFormatter = new BinaryFormatter();
            var result = (Configuration)configBinaryFormatter.Deserialize(configFileStream);

            configFileStream.Close();
            return result;
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
            // Clear device with fully transparent black
            //
            var foregroundWindowString = WindowFunctions.GetActiveWindowTitle();

            diabloActive =
                    !string.IsNullOrEmpty(foregroundWindowString) &&
                    foregroundWindowString.ToUpper() == "DIABLO III";

            try
            {
                if (diabloActive && !setNonTopmost)
                {
                    WindowFunctions.DisableTopMost(WindowFunctions.GetForegroundWindowHandle());

                    setNonTopmost = true;
                }

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
                MessageBox.Show("Exception in windowing functions. Written to crash.txt.");
                Close();
            }

            try
            {
                hud.Draw(inputProcessor.currentControllerState, diabloActive);
            }
            catch (Exception ex)
            {
                var crashPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\crash.txt";
                using (var outfile = new StreamWriter(crashPath, true))
                {
                    outfile.WriteLine();
                    outfile.WriteLine(DateTime.Now.ToString());
                    outfile.WriteLine(ex.Message);
                    outfile.WriteLine(ex.StackTrace);
                    outfile.WriteLine();
                    outfile.Flush();
                }
                MessageBox.Show("Exception in HUD draw. Written to crash.txt.");
                Close();
            }

            // Redraw immediately
            Invalidate();

            try
            {
                if (diabloActive)
                    LogicUpdate();
            }
            catch (Exception ex)
            {
                var crashPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\crash.txt";
                using (var outfile = new StreamWriter(crashPath, true))
                {
                    outfile.WriteLine();
                    outfile.WriteLine(DateTime.Now.ToString());
                    outfile.WriteLine(ex.Message);
                    outfile.WriteLine(ex.StackTrace);
                    outfile.WriteLine();
                    outfile.Flush();
                }
                MessageBox.Show("Exception in Logic update. Written to crash.txt.");
                Close();
            }

            if (m_ActionBindingsForm.Visible)
            {
                m_ActionBindingsForm.Refresh();
            }

            if (configForm.Visible)
            {
                configForm.Refresh();
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
            inputProcessor.Update(GamePad.GetState(0, GamePadDeadZone.Circular));
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
    }
}
