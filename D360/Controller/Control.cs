
namespace D360.Controller
{
    using SharpDX;
    using System;
    using System.Diagnostics;
    using System.Linq;
    using Types;
    using Utility;
    using XInputDotNetPure;
    using ButtonState = XInputDotNetPure.ButtonState;

    public enum ControlIndex
    {
        A,
        B,
        X,
        Y,

        DPadUp,
        DPadDown,
        DPadLeft,
        DPadRight,

        LeftShoulder,
        RightShoulder,

        LeftTrigger,
        RightTrigger,

        Start,
        Back,

        Guide,

        LeftThumb,
        RightThumb,

        LeftStick,
        RightStick,
    }

    public enum ControlType
    {
        None,

        Face,
        DPad,

        Shoulder,
        Trigger,

        Option,

        Thumb,

        Stick,
    }

    public enum DirectionIndex
    {
        None,

        Left,
        Right,
    }

    public enum InputState
    {
        /// <summary> Input was Pressed this frame </summary>
        Pressed,
        /// <summary> Input was Released this frame </summary>
        Released,

        /// <summary> Input was considered Held last frame and is still Pressed </summary>
        Holding,
        /// <summary> Input started a Hold but was Released this frame </summary>
        Held,
    }

    public class Control
    {
        public ControlIndex index;

        public InputState state = InputState.Released;
        public InputState prevState = InputState.Released;

        public ButtonState rawState = ButtonState.Released;
        public ButtonState prevRawState = ButtonState.Released;

        public float timeHeld;
        public float vibrationTriggered;

        public Control(ControlIndex pIndex)
        {
            index = pIndex;
        }

        public void RefreshState(GamePadState pState)
        {
            var property = ParseProperty(pState);

            ParseRawState(property);

            if (rawState == ButtonState.Pressed && prevRawState == ButtonState.Pressed)
                timeHeld += Time.deltaTime;
            else
                timeHeld = 0f;

            ParseState();
        }

        private object ParseProperty(GamePadState pState)
        {
            switch (index.ParseControlType())
            {
                default:
                    return pState.Buttons;

                case ControlType.DPad:
                    return pState.DPad;

                case ControlType.Trigger:
                    return pState.Triggers;

                case ControlType.Stick:
                    return pState.ThumbSticks;
            }
        }

        protected virtual void ParseRawState(object pParsedProperty)
        {
            var parsedProperty = (GamePadButtons)pParsedProperty;

            var propertyInfo = typeof(GamePadButtons).GetProperty(index.ToString().Replace("Thumb", "Stick"));
            if (propertyInfo == null)
                return;

            var methodInfo = propertyInfo.GetMethod;
            if (methodInfo == null)
                return;

            prevRawState = rawState;
            rawState = (ButtonState)methodInfo.Invoke(parsedProperty, null);
        }

        private void ParseState()
        {
            prevState = state;
            if (rawState == ButtonState.Released && prevState == InputState.Holding)
                state = InputState.Held;
            else if (rawState == ButtonState.Released && prevState == InputState.Pressed)
                state = InputState.Released;
            else if (rawState == ButtonState.Pressed && prevRawState == ButtonState.Released)
                state = InputState.Pressed;
            else if (rawState == ButtonState.Pressed && prevState == InputState.Pressed &&
                     timeHeld >= Main.self.configuration.holdTime)
                state = InputState.Holding;

            if (state != prevState)
                Debug.WriteLine($"{index} - {state}");
        }

        public virtual void ParseInput()
        {
            if (state == prevState)
                return;

            Enum.TryParse(Main.self.controllerManager.currentMode.ToString(), out BindingMode bindingMode);

            var bindings =
                Main.self.configuration.bindingConfigs[index].bindings.
                    Where(x => Main.self.controllerManager.currentMode.HasFlag(x.inputMode));

            var hasOnHold = bindings.Any(x => x.isHoldAction);
            foreach (var binding in bindings)
            {
                if (binding.isHoldAction)
                {
                    switch (state)
                    {
                        case InputState.Holding:
                            Main.self.controllerManager.pressActions.Add(binding);
                            break;
                        case InputState.Held:
                            Main.self.controllerManager.releaseActions.Add(binding);
                            break;
                    }
                }
                else if (hasOnHold)
                {
                    switch (state)
                    {
                        case InputState.Released:
                            Main.self.controllerManager.pressActions.Add(binding);
                            Main.self.controllerManager.releaseActions.Add(binding);
                            break;
                    }
                }
                else
                {
                    switch (state)
                    {
                        case InputState.Pressed:
                            Main.self.controllerManager.pressActions.Add(binding);
                            break;
                        case InputState.Released:
                        case InputState.Held:
                            Main.self.controllerManager.releaseActions.Add(binding);
                            break;

                    }
                }
            }
        }

        public virtual void SetDebugText(ref string pDebugText)
        {
            pDebugText += $"\n{index} {state}";
        }
    }

    public class DPad : Control
    {
        public DPad(ControlIndex pIndex) : base(pIndex) { }

        protected override void ParseRawState(object pParsedProperty)
        {
            var parsedProperty = (GamePadDPad)pParsedProperty;

            var propertyInfo = typeof(GamePadDPad).GetProperty(index.ToString().Replace("DPad", ""));
            if (propertyInfo == null)
                return;

            var methodInfo = propertyInfo.GetMethod;
            if (methodInfo == null)
                return;

            prevRawState = rawState;
            rawState = (ButtonState)methodInfo.Invoke(parsedProperty, null);
        }
    }

    public class DirectionalControl : Control
    {
        public DirectionalControl(ControlIndex pIndex) : base(pIndex)
        {
            directionIndex = index.ParseDirectionIndex();
        }

        public DirectionIndex directionIndex;
    }

    public class Trigger : DirectionalControl
    {
        public static float s_MaxValue = 32768f;

        public float value;
        public float prevValue;

        public Trigger(ControlIndex pIndex) : base(pIndex) { }

        protected override void ParseRawState(object pParsedProperty)
        {
            var parsedProperty = (GamePadTriggers)pParsedProperty;

            prevValue = value;
            switch (directionIndex)
            {
                case DirectionIndex.Left:
                    value = parsedProperty.Left;
                    break;
                case DirectionIndex.Right:
                    value = parsedProperty.Right;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            prevRawState = rawState;
            if (value > 0f)
                rawState = ButtonState.Pressed;
            else
                rawState = ButtonState.Released;
        }

        public override void SetDebugText(ref string pDebugText)
        {
            base.SetDebugText(ref pDebugText);
            pDebugText += $" {value}";
        }
    }

    public class Stick : DirectionalControl
    {
        public static float s_MaxValue = 32768f;

        public Vector2 value;
        public Vector2 prevValue;

        public Stick(ControlIndex pIndex) : base(pIndex) { }

        protected override void ParseRawState(object pParsedProperty)
        {
            var parsedProperty = (GamePadThumbSticks)pParsedProperty;

            prevValue = new Vector2(value.X, value.Y);
            switch (directionIndex)
            {
                case DirectionIndex.Left:
                    value = new Vector2(parsedProperty.Left.X, parsedProperty.Left.Y);
                    break;
                case DirectionIndex.Right:
                    value = new Vector2(parsedProperty.Right.X, parsedProperty.Right.Y);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            prevRawState = rawState;
            if (value.X != 0f || value.Y != 0f)
                rawState = ButtonState.Pressed;
            else
                rawState = ButtonState.Released;
        }

        public override void SetDebugText(ref string pDebugText)
        {
            base.SetDebugText(ref pDebugText);
            pDebugText += $" {value}";
        }
    }
}
