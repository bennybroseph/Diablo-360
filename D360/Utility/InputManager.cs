using System;
using System.Collections.Generic;
using System.Linq;
using D360.Bindings;
using D360.InputEmulation;
using D360.Types;
using XInputDotNetPure;

using ButtonState = XInputDotNetPure.ButtonState;
using Timer = System.Timers.Timer;

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
            public GamePadButtonStates gamePadButtonState = GamePadButtonStates.Released;
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

                    Console.WriteLine($"GamePad found {playerIndex}");
                    playerGamePad.playerIndex = playerIndex;
                    playerGamePad.state = testState;

                    playerGamePad.indexSet = true;
                }

                playerGamePad.prevState = playerGamePad.state;
                playerGamePad.state = GamePad.GetState(playerIndex);

                ParseInput(playerGamePad);
            }
        }

        private void ParseInput(PlayerGamePad playerGamePad)
        {
            SetButtonState(playerGamePad, "Buttons", playerGamePad.buttonStates);
            DoActions(
                playerGamePad.buttonStates,
                playerGamePad.prevButtonStates,
                configuration.buttonBindings,
                playerGamePad.playerIndex);

            SetButtonState(playerGamePad, "DPad", playerGamePad.dPadButtonStates);
            DoActions(
                playerGamePad.dPadButtonStates,
                playerGamePad.prevDPadButtonStates,
                configuration.dPadBindings,
                playerGamePad.playerIndex);

            if (playerGamePad.state.Triggers.Right >= 0.8f)
                VirtualMouse.LeftDown();
            else
                VirtualMouse.LeftUp();

            if (playerGamePad.state.Triggers.Left >= 0.8f)
                VirtualMouse.RightDown();
            else
                VirtualMouse.RightUp();

            VirtualMouse.MoveRelative(
                (int)(playerGamePad.state.ThumbSticks.Left.X * 1000f * Time.deltaTime),
                (int)(-playerGamePad.state.ThumbSticks.Left.Y * 1000f * Time.deltaTime));

            playerGamePad.prevButtonStates.Clear();
            foreach (var pair in playerGamePad.buttonStates)
            {
                playerGamePad.prevButtonStates.Add(
                    pair.Key,
                    new GamePadButtonState
                    {
                        timeHeld = pair.Value.timeHeld,
                        timerRan = pair.Value.timerRan,
                        gamePadButtonState = pair.Value.gamePadButtonState
                    });
            }

            playerGamePad.prevDPadButtonStates.Clear();
            foreach (var pair in playerGamePad.dPadButtonStates)
            {
                playerGamePad.prevDPadButtonStates.Add(
                    pair.Key,
                    new GamePadButtonState
                    {
                        timeHeld = pair.Value.timeHeld,
                        timerRan = pair.Value.timerRan,
                        gamePadButtonState = pair.Value.gamePadButtonState
                    });
            }
        }

        private void SetButtonState<TButton>(
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

                //if (buttonState.gamePadButtonState != GamePadButtonStates.Released)
                //  Console.WriteLine(button + @":" + buttonState.gamePadButtonState + @", " + buttonState.timeHeld);
            }
        }

        private void ParseButtonState(
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
                                buttonState.gamePadButtonState = GamePadButtonStates.Pressed;
                        }
                        break;
                    case ButtonState.Released:
                        buttonState.gamePadButtonState = GamePadButtonStates.OnPress;
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
                        buttonState.gamePadButtonState = GamePadButtonStates.OnRelease;
                        break;
                    case ButtonState.Released:
                        buttonState.gamePadButtonState = GamePadButtonStates.Released;
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

        private void DoActions<TButton>(
            IReadOnlyDictionary<TButton, GamePadButtonState> buttonStates,
            IReadOnlyDictionary<TButton, GamePadButtonState> prevButtonStates,
            IReadOnlyDictionary<TButton, List<ButtonBinding>> bindings,
            PlayerIndex playerIndex)
        {
            foreach (TButton button in Enum.GetValues(typeof(TButton)))
            {
                if (!buttonStates.ContainsKey(button) ||
                    !prevButtonStates.ContainsKey(button) ||
                    !bindings.ContainsKey(button))
                    continue;

                var buttonState = buttonStates[button];
                var prevButtonState = prevButtonStates[button];

                var binding = bindings[button];

                foreach (var gamePadBinding in bindings[button])
                {
                    var hasHoldBinding = bindings[button].Any(x => x.onHold);
                    switch (buttonState.gamePadButtonState)
                    {
                    case GamePadButtonStates.OnPress:
                        if (!hasHoldBinding && prevButtonState.gamePadButtonState == GamePadButtonStates.Released)
                            VirtualKeyboard.KeyDown(gamePadBinding.keys);
                        break;

                    case GamePadButtonStates.OnRelease:
                        if (!hasHoldBinding)
                            VirtualKeyboard.KeyUp(gamePadBinding.keys);
                        else if (!gamePadBinding.onHold &&
                                 prevButtonState.gamePadButtonState == GamePadButtonStates.OnPress)
                        {
                            VirtualKeyboard.KeyDown(gamePadBinding.keys);
                            VirtualKeyboard.KeyUp(gamePadBinding.keys);
                        }
                        else if (prevButtonState.gamePadButtonState == GamePadButtonStates.Pressed)
                            VirtualKeyboard.KeyUp(gamePadBinding.keys);
                        break;

                    case GamePadButtonStates.Pressed:
                        {
                            if (gamePadBinding.onHold)
                            {
                                VirtualKeyboard.KeyDown(gamePadBinding.keys);
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
                        }
                        break;

                    case GamePadButtonStates.Released:
                        break;
                    }
                }
            }
        }
    }
}
