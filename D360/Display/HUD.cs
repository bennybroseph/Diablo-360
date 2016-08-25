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

        private GraphicsDevice dev;
        BasicEffect effect;

        SpriteBatch spriteBatch;

        Texture2D targetTexture;
        Texture2D moveModeTexture;
        Texture2D pointerModeTexture;
        Texture2D controllerNotFoundTexture;

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
            dev = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.Reach, p);

            using (var stream = new FileStream(@"Content\Target.png", FileMode.Open))
            {
                targetTexture = Texture2D.FromStream(dev, stream);
            }

            using (var stream = new FileStream(@"Content\Move.png", FileMode.Open))
            {
                moveModeTexture = Texture2D.FromStream(dev, stream);
            }

            using (var stream = new FileStream(@"Content\Pointer.png", FileMode.Open))
            {
                pointerModeTexture = Texture2D.FromStream(dev, stream);
            }

            using (var stream = new FileStream(@"Content\ControllerNotFound.png", FileMode.Open))
            {
                controllerNotFoundTexture = Texture2D.FromStream(dev, stream);
            }

            // Initialize basic effect
            effect = new BasicEffect(dev);

            spriteBatch = new SpriteBatch(dev);
        }

        public void Draw(ControllerState state, bool diabloActive)
        {
            dev.Clear(new Color(0, 0, 0, 0.0f));

            if (diabloActive)
            {
                spriteBatch.Begin();

                Rectangle targetRect;

                if (!state.connected)
                {
                    targetRect =
                        new Rectangle(
                            screenWidth / 2 - controllerNotFoundTexture.Width / 2,
                            screenHeight / 2 - controllerNotFoundTexture.Height / 2,
                            controllerNotFoundTexture.Width,
                            controllerNotFoundTexture.Height);
                    spriteBatch.Draw(controllerNotFoundTexture, targetRect, Color.White);
                }

                else
                {
                    if ((state.targetingReticulePosition.X != state.centerPosition.X) &&
                        (state.targetingReticulePosition.Y != state.centerPosition.Y))
                    {
                        var x = (int)(state.targetingReticulePosition.X / 65535.0f * screenWidth) - 16;
                        var y = (int)(state.targetingReticulePosition.Y / 65535.0f * screenHeight) - 16;
                        targetRect = new Rectangle(x, y, 32, 32);

                        spriteBatch.Draw(targetTexture, targetRect, new Color(1.0f, 1.0f, 1.0f, 0.5f));
                    }

                    spriteBatch.Draw(
                        state.inputMode == InputMode.Pointer ? pointerModeTexture : moveModeTexture,
                        new Rectangle(screenWidth - 128, screenHeight - 64, 128, 64),
                        Color.White);
                }
                spriteBatch.End();
            }
            /*
            

            spriteBatch.Begin();

            if ((rightStickXValue != 0) && (rightStickYValue != 0))
            {
                spriteBatch.Draw(targetTexture, targetRect, new Microsoft.Xna.Framework.Color(1.0f, 1.0f, 1.0f, 0.5f));
            }

            //spriteBatch.Draw(moveModeTexture, new Microsoft.Xna.Framework.Rectangle(screenWidth - 256, screenHeight - 128, 128, 64), Microsoft.Xna.Framework.Color.White);

            if (mouse_absolute) 
            {
                spriteBatch.Draw(moveModeTexture, new Microsoft.Xna.Framework.Rectangle(screenWidth - 256, screenHeight - 128, 128, 64), Microsoft.Xna.Framework.Color.White);
            }
            else
            {
                spriteBatch.Draw(pointerModeTexture, new Microsoft.Xna.Framework.Rectangle(screenWidth - 256, screenHeight - 128, 128, 64), Microsoft.Xna.Framework.Color.White);
            }


            spriteBatch.End();

             */
            // Present the device contents into form
            dev.Present();
        }
    }
}
