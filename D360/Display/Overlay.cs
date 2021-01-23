
namespace D360.Display
{
    using Controller;
    using GameOverlay.Drawing;
    using GameOverlay.Windows;
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Utility;

    public class MyOverlayWindow
    {
        public IntPtr Handle => m_GraphicsWindow.Handle;

        private GraphicsWindow m_GraphicsWindow;

        private Graphics m_Graphics => m_GraphicsWindow.Graphics;

        private readonly Screen m_Screen;
        private readonly ControllerManager m_ControllerManager;

        private Image m_ControllerNotFoundImage;

        private Font m_DefaultFont;

        private struct Brushes
        {
            public IBrush Black;
            public IBrush Green;
        }

        private Brushes m_Brushes;

        public delegate void SetDebugTextDelegate(ref string pDebugText);
        public SetDebugTextDelegate setDebugText;

        public delegate void OnDrawGraphicsDelegate();
        public OnDrawGraphicsDelegate onDrawGraphics;

        public MyOverlayWindow()
        {
            m_Screen = Main.self.configuration.screen;

            m_GraphicsWindow =
                new GraphicsWindow
                {
                    Title = "D360",

                    X = m_Screen.Bounds.X,
                    Y = m_Screen.Bounds.Y,
                    Width = m_Screen.Bounds.Width,
                    Height = m_Screen.Bounds.Height,

                    Graphics = { MeasureFPS = true, VSync = true},

                    IsTopmost = true,
                };

            m_GraphicsWindow.DrawGraphics += OnDrawGraphics;
            m_GraphicsWindow.SetupGraphics += OnSetupGraphics;
        }

        public void Run()
        {
            m_GraphicsWindow.Create();
            m_GraphicsWindow.Join();
        }

        private void OnSetupGraphics(object sender, SetupGraphicsEventArgs e)
        {
            m_ControllerNotFoundImage = m_Graphics.CreateImage(@"Content\ControllerNotFound.png");

            m_DefaultFont = m_Graphics.CreateFont("Consolas", 14);

            m_Brushes.Green = m_Graphics.CreateSolidBrush(Color.Green);
            m_Brushes.Black = m_Graphics.CreateSolidBrush(new Color(0, 0, 0));
        }

        private void OnDrawGraphics(object sender, DrawGraphicsEventArgs e)
        {
            onDrawGraphics.Invoke();

            try
            {
                Draw();
            }
            catch (Exception exception)
            {
                Program.WriteToLog(exception);
                MessageBox.Show(new Form(), @"Exception in HUD draw. Written to crash.txt.");
                Close();
            }
        }

        private void Draw()
        {
            m_Graphics.ClearScene();

            if (!Main.self.controllerManager.controllers.Any(x => x.Value.isConnected))
                m_Graphics.DrawImage(
                    m_ControllerNotFoundImage,
                    Rectangle.Create(
                        m_Screen.Bounds.X + (m_Screen.Bounds.Width / 2f) - (m_ControllerNotFoundImage.Width),
                        m_Screen.Bounds.Y + (m_Screen.Bounds.Height / 2f) - (m_ControllerNotFoundImage.Height),
                        m_ControllerNotFoundImage.Width * 2,
                        m_ControllerNotFoundImage.Height * 2), 1f, false);

            var debugText = string.Empty;
            setDebugText.Invoke(ref debugText);

            m_Graphics.DrawTextWithBackground(
                m_DefaultFont,
                m_Brushes.Green,
                m_Brushes.Black,
                10, 10,
                m_Graphics.FPS + "\n\n" +
                debugText);
        }

        public void Close()
        {
            m_GraphicsWindow.Dispose();
        }
    }
}
