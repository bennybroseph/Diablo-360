using System;
using System.Collections.Generic;
using System.Timers;
using D360.Bindings;
using D360.Types;
using XInputDotNetPure;

using ButtonState = XInputDotNetPure.ButtonState;

namespace D360.Utility
{
    public class InputManager
    {
        private const float HOLD_TIME = 0.2f;
        private const float VIBRATION_TIME = 0.15f * 1000f;

        private class GamePadButtonState
        {
            public float timeHeld;
            public bool timerRan;
            public GamePadButtonStates gamePadButtonState = GamePadButtonStates.Releasing;
        }

        private class PlayerGamePad
        {
            public PlayerIndex playerIndex;

            public bool indexSet;

            public GamePadState state;
            public GamePadState prevState;

            public Dictionary<GamePadButton, GamePadButtonState> buttonStates =
                new Dictionary<GamePadButton, GamePadButtonState>();
            public Dictionary<GamePadButton, GamePadButtonState> prevButtonStates =
                new Dictionary<GamePadButton, GamePadButtonState>();

            public Dictionary<GamePadDPadButton, GamePadButtonState> dPadButtonStates =
                new Dictionary<GamePadDPadButton, GamePadButtonState>();
            public Dictionary<GamePadDPadButton, GamePadButtonState> prevDPadButtonStates =
                new Dictionary<GamePadDPadButton, GamePadButtonState>();
        }

        private readonly Dictionary<PlayerIndex, PlayerGamePad> m_PlayerStates =
            new Dictionary<PlayerIndex, PlayerGamePad>();

        public Configuration configuration = new Configuration();
        public ActionBindings actionBindings = new ActionBindings();

        public InputManager()
        {
            foreach (PlayerIndex playerIndex in Enum.GetValues(typeof(PlayerIndex)))
            {
                m_PlayerStates.Add(playerIndex, new PlayerGamePad());

                foreach (GamePadButton button in Enum.GetValues(typeof(GamePadButton)))
                    m_PlayerStates[playerIndex].buttonStates.Add(button, new GamePadButtonState());

                foreach (GamePadDPadButton button in Enum.GetValues(typeof(GamePadDPadButton)))
                    m_PlayerStates[playerIndex].dPadButtonStates.Add(button, new GamePadButtonState());
            }
        }

        // Update is called once per frame
        public void Update()
        {
            // Find a PlayerIndex, for a single player game
            // Will find the first controller that is connected and use it
            foreach (var pair in m_PlayerStates)
            {
                var playerIndex = pair.Key;
                var playerGamePad = pair.Value;

                if (!playerGamePad.indexSet || !playerGamePad.state.IsConnected)
                {
                    var testState = GamePad.GetState(playerIndex);
                    if (!testState.IsConnected)
                        continue;

                    Console.WriteLine(@"GamePad found {0}", playerIndex);
                    playerGamePad.playerIndex = playerIndex;
                    playerGamePad.state = testState;

                    playerGamePad.indexSet = true;
                }

                playerGamePad.prevState = playerGamePad.state;
                playerGamePad.state = GamePad.GetState(playerIndex);

                ParseInput(playerGamePad);
            }
        }

        private static void ParseInput(PlayerGamePad playerGamePad)
        {
            SetButtonState(playerGamePad, "Buttons", playerGamePad.buttonStates);

            SetButtonState(playerGamePad, "DPad", playerGamePad.dPadButtonStates);

            playerGamePad.prevButtonStates =
                new Dictionary<GamePadButton, GamePadButtonState>(playerGamePad.buttonStates);
            playerGamePad.prevDPadButtonStates =
                new Dictionary<GamePadDPadButton, GamePadButtonState>(playerGamePad.dPadButtonStates);
        }

        private static void SetButtonState<TButton>(
            PlayerGamePad playerGamePad,
            string buttonTypePropertyName,
            IReadOnlyDictionary<TButton, GamePadButtonState> buttonStates)
        {
            foreach (TButton button in Enum.GetValues(typeof(TButton)))
            {
                var buttonTypeProperty = typeof(GamePadState).GetProperty(buttonTypePropertyName);
                if (buttonTypeProperty == null)
                    continue;

                var stateGetMethod = buttonTypeProperty.GetMethod;
                if (stateGetMethod == null)
                    continue;

                var state = stateGetMethod.Invoke(playerGamePad.state, null);
                var prevState = stateGetMethod.Invoke(playerGamePad.prevState, null);

                var buttonProperty = state.GetType().GetProperty(button.ToString());

                if (buttonProperty == null)
                    continue;

                var parsedButtonState = (ButtonState)buttonProperty.GetMethod.Invoke(state, null);
                var parsedPrevButtonState = (ButtonState)buttonProperty.GetMethod.Invoke(prevState, null);

                var buttonState = buttonStates[button];
                ParseButtonState(buttonState, parsedButtonState, parsedPrevButtonState);
                DoActions(buttonState, playerGamePad.playerIndex);

                if (buttonState.gamePadButtonState != GamePadButtonStates.Releasing)
                    Console.WriteLine(button + @":" + buttonState.gamePadButtonState + @", " + buttonState.timeHeld);
            }
        }

        private static void ParseButtonState(
            GamePadButtonState buttonState,
            ButtonState parsedButtonState,
            ButtonState parsedPrevButtonState)
        {
            switch (parsedButtonState)
            {
            case ButtonState.Pressed:
                {
                    switch (parsedPrevButtonState)
                    {
                    case ButtonState.Pressed:
                        {
                            buttonState.timeHeld += Time.deltaTime;
                            if (buttonState.timeHeld >= HOLD_TIME)
                                buttonState.gamePadButtonState = GamePadButtonStates.Held;
                        }
                        break;
                    case ButtonState.Released:
                        buttonState.gamePadButtonState = GamePadButtonStates.Pressed;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                    }
                }
                break;
            case ButtonState.Released:
                {
                    buttonState.timeHeld = 0f;
                    buttonState.timerRan = false;
                    switch (parsedPrevButtonState)
                    {
                    case ButtonState.Pressed:
                        buttonState.gamePadButtonState = GamePadButtonStates.Released;
                        break;
                    case ButtonState.Released:
                        buttonState.gamePadButtonState = GamePadButtonStates.Releasing;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                    }
                }
                break;

            default:
                throw new ArgumentOutOfRangeException();
            }
        }

        private static void DoActions(GamePadButtonState buttonState, PlayerIndex playerIndex)
        {
            switch (buttonState.gamePadButtonState)
            {
            case GamePadButtonStates.Pressed:
                break;

            case GamePadButtonStates.Released:
                break;

            case GamePadButtonStates.Held:
                {
                    if (!buttonState.timerRan)
                    {
                        GamePad.SetVibration(playerIndex, 1f, 1f);
                        var newTimer = new Timer
                        {
                            Interval = VIBRATION_TIME
                        };

                        newTimer.Elapsed +=
                            (sender, args) =>
                            {
                                GamePad.SetVibration(playerIndex, 0f, 0f);
                                newTimer.Stop();
                            };

                        newTimer.Start();
                        buttonState.timerRan = true;
                    }
                }
                break;

            case GamePadButtonStates.Releasing:
                break;
            }
        }
    }
}
