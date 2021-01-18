using System;
using System.IO;
using System.Runtime.InteropServices;
using D360.Utility;
using Microsoft.Xna.Framework.Graphics;

namespace D360.Display
{
    using SharpDX;

    public class HUD
    {
        public int screenWidth;
        public int screenHeight;

        private readonly GraphicsDevice m_GraphicsDevice;

        private readonly SpriteBatch m_SpriteBatch;

        private readonly Texture2D m_TargetTexture;
        private readonly Texture2D m_MoveModeTexture;
        private readonly Texture2D m_PointerModeTexture;
        private readonly Texture2D m_ControllerNotFoundTexture;

        public HUD(IntPtr windowHandle)
        {
            // Create device presentation parameters
            var p = new PresentationParameters
            {
                IsFullScreen = false,
                DeviceWindowHandle = windowHandle,
                BackBufferFormat = SurfaceFormat.Vector4,
                PresentationInterval = PresentInterval.One
            };

            // Create XNA graphics device
            m_GraphicsDevice = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.Reach, p);

            using (var stream = new FileStream(@"Content\Target.png", FileMode.Open))
            {
                m_TargetTexture = Texture2D.FromStream(m_GraphicsDevice, stream);
            }

            using (var stream = new FileStream(@"Content\Move.png", FileMode.Open))
            {
                m_MoveModeTexture = Texture2D.FromStream(m_GraphicsDevice, stream);
            }

            using (var stream = new FileStream(@"Content\Pointer.png", FileMode.Open))
            {
                m_PointerModeTexture = Texture2D.FromStream(m_GraphicsDevice, stream);
            }

            using (var stream = new FileStream(@"Content\ControllerNotFound.png", FileMode.Open))
            {
                m_ControllerNotFoundTexture = Texture2D.FromStream(m_GraphicsDevice, stream);
            }

            // Initialize basic effect
            new BasicEffect(m_GraphicsDevice);

            m_SpriteBatch = new SpriteBatch(m_GraphicsDevice);
        }

        public void Draw(ControllerState state, bool diabloActive)
        {
            //m_GraphicsDevice.Clear(new Color(0, 0, 0, 0.0f));

            if (diabloActive)
            {
                if (state.currentMode != BindingMode.Config)
                    SetWindowPos(
                        m_GraphicsDevice.PresentationParameters.DeviceWindowHandle,
                        HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);

                m_SpriteBatch.Begin();
                {
                    //Rectangle targetRect;

                    if (!state.connected)
                    {
                        //targetRect =
                        //    new Rectangle(
                        //        screenWidth / 2 - m_ControllerNotFoundTexture.Width / 2,
                        //        screenHeight / 2 - m_ControllerNotFoundTexture.Height / 2,
                        //        m_ControllerNotFoundTexture.Width,
                        //        m_ControllerNotFoundTexture.Height);
                        //m_SpriteBatch.Draw(m_ControllerNotFoundTexture, targetRect, Color.White);
                    }

                    else
                    {
                        //if ((Math.Abs(state.targetPosition.X - state.centerOffset.X) > float.Epsilon) ||
                        //    (Math.Abs(state.targetPosition.Y - state.centerOffset.Y) > float.Epsilon))
                        //{
                            //var anchor =
                            //    state.pressedTargetKeys > 0 && state.targetPosition != Vector2.Zero ?
                            //    state.cursorPosition : state.targetPosition;

                            //var x = (int)(anchor.X * (screenWidth / 2f) + screenWidth / 2f) - 16;
                            //var y = (int)(anchor.Y * (screenHeight / 2f) + screenHeight / 2f) - 16;
                            //targetRect = new Rectangle(x, y, 32, 32);

                            //m_SpriteBatch.Draw(m_TargetTexture, targetRect, new Color(1.0f, 1.0f, 1.0f, 0.5f));
                        //}

                        //m_SpriteBatch.Draw(
                        //    state.currentMode == BindingMode.Pointer ? m_PointerModeTexture : m_MoveModeTexture,
                        //    new Rectangle(screenWidth - 128, screenHeight - 64, 128, 64),
                        //    Color.White);
                    }
                }
                m_SpriteBatch.End();
            }
            m_GraphicsDevice.Present();
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(
            IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;


    }
}
