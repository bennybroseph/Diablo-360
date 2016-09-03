using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using D360.Bindings;
using D360.InputEmulation;
using D360.Types;
using Microsoft.Xna.Framework;
using XInputDotNetPure;

using ButtonState = XInputDotNetPure.ButtonState;
using PlayerIndex = XInputDotNetPure.PlayerIndex;
using Rectangle = System.Drawing.Rectangle;
using Timer = System.Timers.Timer;

namespace D360.Utility
{
    public class InputManager
    {
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

        private Rectangle m_Screen;

        public readonly ControllerState controllerState;
        public ControllerState prevControllerState = new ControllerState();

        public InputManager()
        {
            m_Screen = Screen.PrimaryScreen.Bounds;

            controllerState = new ControllerState
            {
                targetingReticulePosition = new Vector2(0, 0),
                cursorPosition = new Vector2(0, 0),

                currentMode = BindingMode.Move,
                centerOffset = configuration.centerOffset
            };

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
            controllerState.connected = false;
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
                playerGamePad.state = GamePad.GetState(playerIndex, GamePadDeadZone.Circular);

                controllerState.connected = true;
                ParseInput(playerGamePad);
            }
        }

        private void ParseInput(PlayerGamePad playerGamePad)
        {
            playerGamePad.prevControlStates.Clear();
            foreach (var pair in playerGamePad.controlStates)
            {
                var newControlState = new GamePadControlState
                {
                    timeHeld = pair.Value.timeHeld,
                    timerRan = pair.Value.timerRan,
                    state = pair.Value.state
                };

                var triggerState = pair.Value as GamePadTriggerState;
                var stickState = pair.Value as GamePadStickState;

                if (triggerState != null)
                {
                    newControlState = new GamePadTriggerState();
                    ((GamePadTriggerState)newControlState).amount = triggerState.amount;
                }
                if (stickState != null)
                {
                    newControlState = new GamePadStickState();
                    ((GamePadStickState)newControlState).x = stickState.x;
                    ((GamePadStickState)newControlState).y = stickState.y;
                }

                playerGamePad.prevControlStates.Add(pair.Key, newControlState);
            }

            ParseControlStates(playerGamePad, playerGamePad.controlStates);

            ParseStickInput(playerGamePad, GamePadControl.LeftStick);
            ParseStickInput(playerGamePad, GamePadControl.RightStick);

            if (controllerState.cursorPosition != prevControllerState.cursorPosition &&
                controllerState.currentMode != BindingMode.Config)
                MoveMouseToOffset(controllerState.cursorPosition);

            ParseAction(
                playerGamePad.controlStates,
                playerGamePad.prevControlStates,
                configuration.bindingConfigs,
                playerGamePad.playerIndex);

            prevControllerState = new ControllerState
            {
                centerOffset = new Vector2(controllerState.centerOffset.X, controllerState.centerOffset.Y),
                connected = controllerState.connected,
                currentMode = controllerState.currentMode,
                cursorPosition = new Vector2(controllerState.cursorPosition.X, controllerState.cursorPosition.Y),
                targetingReticulePosition =
                    new Vector2(
                        controllerState.targetingReticulePosition.X,
                        controllerState.targetingReticulePosition.Y)
            };
        }

        ///TODO: This is literally the worst code I have ever written
        private void ParseControlStates<TControlState>(
            PlayerGamePad playerGamePad,
            IReadOnlyDictionary<GamePadControl,
            TControlState> controlStates) where TControlState : GamePadControlState
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
                        var controlProperty = state.GetType().GetProperty(pair.Key.ToString().Replace("Button", ""));
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

                        SetControlState(
                            pair.Value, pair.Key, controlType, parsedControlState, parsedPrevControlState);
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
                            if (controlState.timeHeld >= configuration.holdTime)
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
            GamePadControl control,
            ControlType controlType,
            object parsedControlState,
            object parsedPrevControlState) where TControlState : GamePadControlState
        {
            switch (controlType)
            {
            case ControlType.Triggers:
                {
                    var triggerState = controlState as GamePadTriggerState;
                    var triggerConfig = configuration.bindingConfigs[control] as TriggerConfig;
                    if (triggerState == null || triggerConfig == null)
                        return;

                    var parsedTriggerState =
                        (float)parsedControlState > triggerConfig.deadzone ?
                        ButtonState.Pressed : ButtonState.Released;
                    var parsedPrevTriggerState =
                        (float)parsedPrevControlState > triggerConfig.deadzone ?
                        ButtonState.Pressed : ButtonState.Released;

                    triggerState.amount = (float)parsedControlState;

                    SetControlState(triggerState, parsedTriggerState, parsedPrevTriggerState);
                }
                break;

            case ControlType.ThumbSticks:
                {
                    var stickState = controlState as GamePadStickState;
                    var stickConfig = configuration.bindingConfigs[control] as StickConfig;
                    if (stickState == null || stickConfig == null)
                        return;

                    var stickPropertyX = parsedControlState.GetType().GetProperty("X");
                    if (stickPropertyX == null)
                        return;

                    var x = stickPropertyX.GetMethod.Invoke(parsedControlState, null);
                    var prevX = stickPropertyX.GetMethod.Invoke(parsedPrevControlState, null);

                    var parsedStickStateX =
                        Math.Abs((float)x) > stickConfig.actionDeadzone ?
                        ButtonState.Pressed : ButtonState.Released;
                    var parsedPrevStickStateX =
                        Math.Abs((float)prevX) > stickConfig.actionDeadzone ?
                        ButtonState.Pressed : ButtonState.Released;

                    stickState.x = (float)x;

                    var stickPropertyY = parsedControlState.GetType().GetProperty("Y");
                    if (stickPropertyY == null)
                        return;

                    var y = stickPropertyY.GetMethod.Invoke(parsedControlState, null);
                    var prevY = stickPropertyY.GetMethod.Invoke(parsedPrevControlState, null);

                    var parsedStickStateY =
                        Math.Abs((float)y) > stickConfig.actionDeadzone ?
                        ButtonState.Pressed : ButtonState.Released;
                    var parsedPrevStickStateY =
                        Math.Abs((float)prevY) > stickConfig.actionDeadzone ?
                        ButtonState.Pressed : ButtonState.Released;

                    stickState.y = (float)y;

                    var pressedState =
                        parsedStickStateX != ButtonState.Released || parsedStickStateY != ButtonState.Released ?
                        ButtonState.Pressed : ButtonState.Released;
                    var prevPressedState =
                        parsedPrevStickStateX != ButtonState.Released ||
                        parsedPrevStickStateY != ButtonState.Released ?
                        ButtonState.Pressed : ButtonState.Released;

                    SetControlState(stickState, pressedState, prevPressedState);
                }
                break;
            }
        }

        private void ParseAction(
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

                foreach (var controlBinding in pair.Value.controlBindings)
                {
                    var hasHoldBinding = pair.Value.controlBindings.Any(x => x.onHold);
                    switch (buttonState.state)
                    {
                    case ControlState.OnPress:
                        if (!hasHoldBinding && prevButtonState.state == ControlState.Released)
                            DoAction(controlBinding, ActionType.Press);
                        break;

                    case ControlState.OnRelease:
                        if (!hasHoldBinding)
                            DoAction(controlBinding, ActionType.Release);
                        else if (!controlBinding.onHold &&
                                 prevButtonState.state == ControlState.OnPress)
                            DoAction(controlBinding, ActionType.Press | ActionType.Release);
                        else if (prevButtonState.state == ControlState.Pressed)
                            DoAction(controlBinding, ActionType.Release);
                        break;

                    case ControlState.Pressed:
                        {
                            if (controlBinding.onHold)
                            {
                                DoAction(controlBinding, ActionType.Press);
                                if (!buttonState.timerRan)
                                {
                                    GamePad.SetVibration(playerIndex, 1f, 1f);
                                    var newTimer = new Timer
                                    {
                                        Interval = configuration.vibrationTime
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

        [Flags]
        private enum ActionType
        {
            None,

            Press = 1 << 0,
            Release = 1 << 1
        }
        private void DoAction(ControlBinding controlBinding, ActionType actionType)
        {
            switch (controlBinding.bindingType)
            {
            case BindingType.Key:
                var swap =
                    controlBinding.targeted &&
                    (Math.Abs(controllerState.targetingReticulePosition.X) > float.Epsilon ||
                    Math.Abs(controllerState.targetingReticulePosition.Y) > float.Epsilon);

                if (swap)
                    MoveMouseToOffset(controllerState.targetingReticulePosition);

                switch (actionType)
                {
                case ActionType.Press:
                    VirtualKeyboard.KeyDown(controlBinding.keys);
                    break;
                case ActionType.Release:
                    VirtualKeyboard.KeyUp(controlBinding.keys);
                    break;

                case ActionType.Press | ActionType.Release:
                    VirtualKeyboard.KeyDown(controlBinding.keys);
                    VirtualKeyboard.KeyUp(controlBinding.keys);
                    break;
                }

                if (swap)
                    MoveMouseToOffset(controllerState.cursorPosition);
                break;
            case BindingType.SpecialAction:
                switch (actionType)
                {
                case ActionType.Press:
                case ActionType.Press | ActionType.Release:
                    switch (controlBinding.specialAction)
                    {
                    case SpecialAction.SwitchStickMode:
                        controllerState.currentMode ^= BindingMode.Pointer;
                        controllerState.currentMode ^= BindingMode.Move;
                        break;
                    }
                    break;
                }
                break;
            case BindingType.Script:
                switch (actionType)
                {
                case ActionType.Press:
                case ActionType.Press | ActionType.Release:
                    VirtualKeyboard.ExecuteScript(controlBinding.script);
                    break;
                }
                break;

            default:
                throw new ArgumentOutOfRangeException();
            }
        }
        private void ParseStickInput(PlayerGamePad playerGamePad, GamePadControl stick)
        {
            var stickConfig = configuration.bindingConfigs[stick] as StickConfig;
            var stickState = playerGamePad.controlStates[stick] as GamePadStickState;
            var prevStickState = playerGamePad.prevControlStates[stick] as GamePadStickState;

            if (stickConfig == null || stickState == null || prevStickState == null)
                return;

            var tempStickValue = new Vector2(stickState.x, stickState.y);

            if (Math.Abs(stickState.x) <= stickConfig.moveDeadzone &&
                Math.Abs(stickState.y) <= stickConfig.moveDeadzone)
                tempStickValue = new Vector2(0, 0);
            else
            {
                var signCoefficient =
                    new Vector2(
                        stickState.x < 0f ? -1f : 1f,
                        stickState.y < 0f ? -1f : 1f);

                var theta = Math.Abs(Math.Atan(stickState.y / stickState.x));
                var radius = Math.Sqrt(Math.Pow(stickState.x, 2f) + Math.Pow(stickState.y, 2f));
                radius = (radius - stickConfig.moveDeadzone) / (1f - stickConfig.moveDeadzone);

                switch (stickConfig.mode)
                {
                case StickMode.Cursor:
                    {
                        if (configuration.cursorAlwaysMax &&
                            !controllerState.currentMode.HasFlag(BindingMode.Pointer))
                            radius = 1f;

                        radius *= configuration.cursorRadius;
                    }
                    break;
                case StickMode.Target:
                    {
                        if (configuration.targetAlwaysMax &&
                            !controllerState.currentMode.HasFlag(BindingMode.Pointer))
                            radius = 1f;

                        radius *= configuration.targetRadius;
                    }
                    break;
                }

                tempStickValue.X = (float)(Math.Cos(theta) * radius) * signCoefficient.X;
                tempStickValue.Y = (float)(Math.Sin(theta) * radius) * signCoefficient.Y;
            }

            switch (stickConfig.mode)
            {
            case StickMode.Cursor:
                {
                    if (controllerState.currentMode.HasFlag(BindingMode.Move))
                        controllerState.cursorPosition =
                            new Vector2(tempStickValue.X, -tempStickValue.Y);
                    if (controllerState.currentMode.HasFlag(BindingMode.Pointer))
                    {
                        controllerState.cursorPosition.X += tempStickValue.X * 10f * Time.deltaTime;
                        controllerState.cursorPosition.Y -= tempStickValue.Y * 10f * Time.deltaTime;
                    }
                }
                break;

            case StickMode.Target:
                {
                    if (controllerState.currentMode.HasFlag(BindingMode.Move))
                        controllerState.targetingReticulePosition =
                            new Vector2(tempStickValue.X, -tempStickValue.Y);
                }
                break;
            }
        }

        private void MoveMouseToOffset(Vector2 newPosition)
        {
            newPosition =
                new Vector2(
                    newPosition.X * (m_Screen.Width / 2f)
                    + m_Screen.Width / 2f + controllerState.centerOffset.X,
                    newPosition.Y * (m_Screen.Height / 2f)
                    + m_Screen.Height / 2f + controllerState.centerOffset.Y);

            VirtualMouse.MoveAbsolute((int)newPosition.X, (int)newPosition.Y);
        }
    }
}
