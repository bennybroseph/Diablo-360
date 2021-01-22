namespace D360.Controller
{
    using System;
    using System.Collections.Generic;
    using SharpDX;
    using Utility;
    using XInputDotNetPure;

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

        /// <summary> Input was Pressed long enough to be a Hold this frame </summary>
        Hold,

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

        protected virtual void ParseState()
        {
            prevState = state;
            if (rawState == ButtonState.Released && prevState == InputState.Holding)
                state = InputState.Held;
            else if (rawState == ButtonState.Released)
                state = InputState.Released;
            else if (rawState == ButtonState.Pressed && prevRawState == ButtonState.Released)
                state = InputState.Pressed;
            else if (rawState == ButtonState.Pressed && prevState == InputState.Pressed)
                state = InputState.Hold;
            else if (rawState == ButtonState.Pressed && prevState == InputState.Hold)
                state = InputState.Holding;

            if (state != prevState)
                System.Diagnostics.Debug.WriteLine(state);
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

    public class Trigger : Control
    {
        public static float s_MaxValue = 32768f;

        public DirectionIndex directionIndex;

        public float value;
        public float prevValue;

        public Trigger(ControlIndex pIndex) : base(pIndex) { }

        protected override void ParseRawState(object pParsedProperty)
        {
            var parsedProperty = (GamePadTriggers) pParsedProperty;

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
        }
    }

    public class Stick : Trigger
    {
        public new static float s_MaxValue = 32768f;

        public new Vector2 value;
        public new Vector2 prevValue;

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
        }
    }

    public class Controller
    {
        public PlayerIndex index;

        public bool isConnected;
        public bool wasConnected;

        /// <summary> The current raw state of the controller via XInput </summary>
        public GamePadState rawState;

        public GamePadState prevRawState;

        /// <summary> Each individual button on the controller </summary>
        public readonly Dictionary<ControlIndex, Control> controls = new Dictionary<ControlIndex, Control>();
    }

    public static class ControllerUtility
    {
        public static ControlType ParseControlType(this ControlIndex control)
        {
            switch (control)
            {
                case ControlIndex.A:
                case ControlIndex.B:
                case ControlIndex.X:
                case ControlIndex.Y:
                    return ControlType.Face;

                case ControlIndex.DPadUp:
                case ControlIndex.DPadDown:
                case ControlIndex.DPadLeft:
                case ControlIndex.DPadRight:
                    return ControlType.DPad;

                case ControlIndex.LeftShoulder:
                case ControlIndex.RightShoulder:
                    return ControlType.Shoulder;

                case ControlIndex.LeftTrigger:
                case ControlIndex.RightTrigger:
                    return ControlType.Trigger;

                case ControlIndex.Start:
                case ControlIndex.Back:
                case ControlIndex.Guide:
                    return ControlType.Option;

                case ControlIndex.LeftThumb:
                case ControlIndex.RightThumb:
                    return ControlType.Thumb;

                case ControlIndex.LeftStick:
                case ControlIndex.RightStick:
                    return ControlType.Stick;

                default:
                    return ControlType.None;
            }
        }

        public static DirectionIndex ParseDirectionIndex(this ControlIndex control)
        {
            switch (control)
            {
                case ControlIndex.LeftTrigger:
                case ControlIndex.LeftStick:
                    return DirectionIndex.Left;

                case ControlIndex.RightTrigger:
                case ControlIndex.RightStick:
                    return DirectionIndex.Right;

                default:
                    return DirectionIndex.None;
            }
        }
    }
}
