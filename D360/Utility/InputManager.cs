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

        private class GamePadControlState
        {
            public float timeHeld;
            public bool timerRan;
            public ControlState state = ControlState.Released;
        }

        private class GamePadTriggerState : GamePadControlState
        {
            public float amount;
        }

        private class GamePadStickState : GamePadControlState
        {
            public float x;
            public float y;
        }

        private class PlayerGamePad
        {
            public PlayerIndex playerIndex;

            public bool indexSet;

            public GamePadState state;
            public GamePadState prevState;

            public Dictionary<GamePadControl, GamePadControlState> controlStates =
                new Dictionary<GamePadControl, GamePadControlState>();
            public Dictionary<GamePadControl, GamePadControlState> prevControlStates =
                new Dictionary<GamePadControl, GamePadControlState>();
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

                foreach (GamePadControl control in Enum.GetValues(typeof(GamePadControl)))
                {
                    switch (control.ParseControlType())
                    {
                    case ControlType.Buttons:
                    case ControlType.DPad:
                        m_PlayerStates[playerIndex].controlStates.Add(control, new GamePadControlState());
                        break;

                    case ControlType.Triggers:
                        m_PlayerStates[playerIndex].controlStates.Add(control, new GamePadTriggerState());
                        break;

                    case ControlType.ThumbSticks:
                        m_PlayerStates[playerIndex].controlStates.Add(control, new GamePadStickState());
                        break;
                    }
                }
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
            ParseControlStates(playerGamePad, playerGamePad.controlStates);

            DoActions(
                playerGamePad.controlStates,
                playerGamePad.prevControlStates,
                configuration.bindingConfigs,
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

            playerGamePad.prevControlStates.Clear();
            foreach (var pair in playerGamePad.controlStates)
            {
                playerGamePad.prevControlStates.Add(
                    pair.Key,
                    new GamePadControlState
                    {
                        timeHeld = pair.Value.timeHeld,
                        timerRan = pair.Value.timerRan,
                        state = pair.Value.state
                    });
            }
        }

        ///TODO: This is literally the worst code I have ever written
        private void ParseControlStates<TControlState>(
            PlayerGamePad playerGamePad,
            IReadOnlyDictionary<GamePadControl, TControlState> controlStates) where TControlState : GamePadControlState
        {
            foreach (var pair in controlStates)
            {
                var controlType = pair.Key.ParseControlType();

                var buttonTypeProperty = typeof(GamePadState).GetProperty(controlType.ToString());
                if (buttonTypeProperty == null)
                    continue;

                var stateGetMethod = buttonTypeProperty.GetMethod;
                if (stateGetMethod == null)
                    continue;

                var state = stateGetMethod.Invoke(playerGamePad.state, null);
                var prevState = stateGetMethod.Invoke(playerGamePad.prevState, null);

                switch (controlType)
                {
                case ControlType.Buttons:
                case ControlType.DPad:
                    {
                        var controlProperty = state.GetType().GetProperty(pair.Key.ToString());
                        if (controlProperty == null)
                            continue;

                        var parsedControlState = (ButtonState)controlProperty.GetMethod.Invoke(state, null);
                        var parsedPrevControlState = (ButtonState)controlProperty.GetMethod.Invoke(prevState, null);

                        SetControlState(pair.Value, parsedControlState, parsedPrevControlState);
                    }
                    break;

                case ControlType.Triggers:
                case ControlType.ThumbSticks:
                    {
                        var controlProperty = state.GetType().GetProperty(pair.Key.ParseOrientation());
                        if (controlProperty == null)
                            continue;

                        var parsedControlState = controlProperty.GetMethod.Invoke(state, null);
                        var parsedPrevControlState = controlProperty.GetMethod.Invoke(prevState, null);

                        SetControlState(pair.Value, controlType, parsedControlState, parsedPrevControlState);
                    }
                    break;
                }
            }
        }

        private void SetControlState(
            GamePadControlState controlState,
            ButtonState parsedControlState,
            ButtonState parsedPrevControlState)
        {
            switch (parsedControlState)
            {
            case ButtonState.Pressed:
                {
                    switch (parsedPrevControlState)
                    {
                    case ButtonState.Pressed:
                        {
                            controlState.timeHeld += Time.deltaTime;
                            if (controlState.timeHeld >= HOLD_TIME)
                                controlState.state = ControlState.Pressed;
                        }
                        break;
                    case ButtonState.Released:
                        controlState.state = ControlState.OnPress;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                    }
                }
                break;
            case ButtonState.Released:
                {
                    controlState.timeHeld = 0f;
                    controlState.timerRan = false;
                    switch (parsedPrevControlState)
                    {
                    case ButtonState.Pressed:
                        controlState.state = ControlState.OnRelease;
                        break;
                    case ButtonState.Released:
                        controlState.state = ControlState.Released;
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

        ///TODO: This is literally the worst code I have ever written
        private void SetControlState<TControlState>(
            TControlState controlState,
            ControlType controlType,
            object parsedControlState,
            object parsedPrevControlState) where TControlState : GamePadControlState
        {
            switch (controlType)
            {
            case ControlType.Triggers:
                {
                    var triggerState = controlState as GamePadTriggerState;
                    if (triggerState == null)
                        return;

                    var parsedTriggerState =
                        (float)parsedControlState > 0f ?
                        ButtonState.Pressed : ButtonState.Released;
                    var parsedPrevTriggerState =
                        (float)parsedPrevControlState > 0f ?
                        ButtonState.Pressed : ButtonState.Released;

                    triggerState.amount = (float)parsedControlState;

                    SetControlState(triggerState, parsedTriggerState, parsedPrevTriggerState);
                }
                break;

            case ControlType.ThumbSticks:
                {
                    var stickState = controlState as GamePadStickState;
                    if (stickState == null)
                        return;

                    var stickPropertyX = parsedControlState.GetType().GetProperty("X");
                    if (stickPropertyX == null)
                        return;

                    var x = stickPropertyX.GetMethod.Invoke(parsedControlState, null);
                    var prevX = stickPropertyX.GetMethod.Invoke(parsedPrevControlState, null);

                    var parsedStickStateX =
                        (float)x > 0f ?
                        ButtonState.Pressed : ButtonState.Released;
                    var parsedPrevStickStateX =
                        (float)prevX > 0f ?
                        ButtonState.Pressed : ButtonState.Released;

                    stickState.x = (float)x;

                    var stickPropertyY = parsedControlState.GetType().GetProperty("Y");
                    if (stickPropertyY == null)
                        return;

                    var y = stickPropertyY.GetMethod.Invoke(parsedControlState, null);
                    var prevY = stickPropertyY.GetMethod.Invoke(parsedPrevControlState, null);

                    var parsedStickStateY =
                        (float)y > 0f ?
                        ButtonState.Pressed : ButtonState.Released;
                    var parsedPrevStickStateY =
                        (float)prevY > 0f ?
                        ButtonState.Pressed : ButtonState.Released;

                    stickState.y = (float)y;

                    var pressedState =
                        parsedStickStateX != ButtonState.Released || parsedStickStateY != ButtonState.Released ?
                        ButtonState.Pressed : ButtonState.Released;
                    var prevPressedState =
                        parsedPrevStickStateX != ButtonState.Released || parsedPrevStickStateY != ButtonState.Released ?
                        ButtonState.Pressed : ButtonState.Released;

                    SetControlState(stickState, pressedState, prevPressedState);
                }
                break;
            }
        }

        private void DoActions(
            IReadOnlyDictionary<GamePadControl, GamePadControlState> buttonStates,
            IReadOnlyDictionary<GamePadControl, GamePadControlState> prevButtonStates,
            IReadOnlyDictionary<GamePadControl, BindingConfig> bindingConfigs,
            PlayerIndex playerIndex)
        {
            foreach (var pair in bindingConfigs)
            {
                if (!buttonStates.ContainsKey(pair.Key) ||
                    !prevButtonStates.ContainsKey(pair.Key))
                    continue;

                var buttonState = buttonStates[pair.Key];
                var prevButtonState = prevButtonStates[pair.Key];

                foreach (var gamePadBinding in pair.Value.controlBindings)
                {
                    var hasHoldBinding = pair.Value.controlBindings.Any(x => x.onHold);
                    switch (buttonState.state)
                    {
                    case ControlState.OnPress:
                        if (!hasHoldBinding && prevButtonState.state == ControlState.Released)
                            VirtualKeyboard.KeyDown(gamePadBinding.keys);
                        break;

                    case ControlState.OnRelease:
                        if (!hasHoldBinding)
                            VirtualKeyboard.KeyUp(gamePadBinding.keys);
                        else if (!gamePadBinding.onHold &&
                                 prevButtonState.state == ControlState.OnPress)
                        {
                            VirtualKeyboard.KeyDown(gamePadBinding.keys);
                            VirtualKeyboard.KeyUp(gamePadBinding.keys);
                        }
                        else if (prevButtonState.state == ControlState.Pressed)
                            VirtualKeyboard.KeyUp(gamePadBinding.keys);
                        break;

                    case ControlState.Pressed:
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

                    case ControlState.Released:
                        break;
                    }
                }
            }
        }
    }
}
