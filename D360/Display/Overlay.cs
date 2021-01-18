
namespace D360.Display
{
    using GameOverlay.Drawing;
    using GameOverlay.Windows;
    using System;
    using System.Windows.Forms;
    using Utility;

    class MyOverlayWindow
    {
        public IntPtr Handle => m_GraphicsWindow.Handle;

        private GraphicsWindow m_GraphicsWindow;

        private Graphics m_Graphics => m_GraphicsWindow.Graphics;

        private readonly Screen m_Screen;
        private readonly ControllerState m_ControllerState;

        private Image m_ControllerNotFoundImage;

        private Font m_DefaultFont;

        private struct Brushes
        {
            public IBrush Green;
        }

        Brushes m_Brushes;

        public delegate void OnDrawGraphicsDelegate();
        public OnDrawGraphicsDelegate onDrawGraphics;

        public MyOverlayWindow(Screen pScreen, ControllerState pControllerState)
        {
            m_Screen = pScreen;
            m_ControllerState = pControllerState;

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
            //m_GraphicsWindow.Join();
        }

        private void OnSetupGraphics(object sender, SetupGraphicsEventArgs e)
        {
            m_ControllerNotFoundImage = m_Graphics.CreateImage(@"Content\ControllerNotFound.png");

            m_DefaultFont = m_Graphics.CreateFont("Consolas", 14);

            m_Brushes.Green = m_Graphics.CreateSolidBrush(Color.Green);
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

            m_Graphics.DrawText(m_DefaultFont, m_Brushes.Green, 0, 0, m_Graphics.FPS.ToString());

            if (!m_ControllerState.connected)
                m_Graphics.DrawImage(
                    m_ControllerNotFoundImage,
                    Rectangle.Create(
                        m_Screen.Bounds.X + (m_Screen.Bounds.Width / 2f) - (m_ControllerNotFoundImage.Width),
                        m_Screen.Bounds.Y + (m_Screen.Bounds.Height / 2f) - (m_ControllerNotFoundImage.Height),
                        m_ControllerNotFoundImage.Width * 2,
                        m_ControllerNotFoundImage.Height * 2), 1f, false);

            m_Graphics.DrawText(
                m_DefaultFont,
                m_Brushes.Green,
                0, 10,
                m_ControllerState.cursorPosition + "\n" +
                m_ControllerState.targetPosition + "\n" +
                m_ControllerState.pressedTargetKeys);
        }

        public void Close()
        {
            m_GraphicsWindow.Dispose();
        }
    }
}
