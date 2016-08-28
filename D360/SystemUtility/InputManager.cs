using System;
using D360.Types;
using XInputDotNetPure;

using ButtonState = XInputDotNetPure.ButtonState;

namespace D360.SystemUtility
{
    public class InputManager
    {
        private delegate ButtonState GetButtonState();

        private bool m_PlayerIndexSet;
        private PlayerIndex m_PlayerIndex;
        private GamePadState m_State;
        private GamePadState m_PrevState;

        // Update is called once per frame
        public void Update()
        {
            // Find a PlayerIndex, for a single player game
            // Will find the first controller that is connected and use it
            if (!m_PlayerIndexSet || !m_PrevState.IsConnected)
            {
                for (var i = 0; i < 4; ++i)
                {
                    var testPlayerIndex = (PlayerIndex)i;
                    var testState = GamePad.GetState(testPlayerIndex);
                    if (!testState.IsConnected)
                        continue;

                    Console.WriteLine(@"GamePad found {0}", testPlayerIndex);
                    m_PlayerIndex = testPlayerIndex;
                    m_PlayerIndexSet = true;
                }
            }

            m_PrevState = m_State;
            m_State = GamePad.GetState(m_PlayerIndex);

            ParseInput();
            // Set vibration according to triggers
            GamePad.SetVibration(m_PlayerIndex, m_State.Triggers.Left, m_State.Triggers.Right);
        }

        private void ParseInput()
        {
            foreach (GamePadButton button in Enum.GetValues(typeof(GamePadButton)))
            {
                var property = typeof(GamePadButtons).GetProperty(button.ToString());

                if (property == null)
                    continue;

                var buttonState = (ButtonState)property.GetMethod.Invoke(m_State.Buttons, null);

                if (buttonState == ButtonState.Pressed)
                    Console.WriteLine(button + @": " + buttonState);
            }
        }
    }
}
