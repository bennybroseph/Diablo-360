using System;
using System.IO;
using D360.SystemCode;
using D360.Types;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace D360.Display
{
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
            m_GraphicsDevice.Clear(new Color(0, 0, 0, 0.0f));

            if (diabloActive)
            {
                m_SpriteBatch.Begin();
                {
                    Rectangle targetRect;

                    if (!state.connected)
                    {
                        targetRect =
                            new Rectangle(
                                screenWidth / 2 - m_ControllerNotFoundTexture.Width / 2,
                                screenHeight / 2 - m_ControllerNotFoundTexture.Height / 2,
                                m_ControllerNotFoundTexture.Width,
                                m_ControllerNotFoundTexture.Height);
                        m_SpriteBatch.Draw(m_ControllerNotFoundTexture, targetRect, Color.White);
                    }

                    else
                    {
                        if ((state.targetingReticulePosition.X != state.centerPosition.X) &&
                            (state.targetingReticulePosition.Y != state.centerPosition.Y))
                        {
                            var x = (int)(state.targetingReticulePosition.X / 65535.0f * screenWidth) - 16;
                            var y = (int)(state.targetingReticulePosition.Y / 65535.0f * screenHeight) - 16;
                            targetRect = new Rectangle(x, y, 32, 32);

                            m_SpriteBatch.Draw(m_TargetTexture, targetRect, new Color(1.0f, 1.0f, 1.0f, 0.5f));
                        }

                        m_SpriteBatch.Draw(
                            state.inputMode == InputMode.Pointer ? m_PointerModeTexture : m_MoveModeTexture,
                            new Rectangle(screenWidth - 128, screenHeight - 64, 128, 64),
                            Color.White);
                    }
                }
                m_SpriteBatch.End();
            }
            m_GraphicsDevice.Present();
        }
    }
}
