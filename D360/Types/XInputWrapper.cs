using System;
using D360.Utility;

namespace D360.Types
{
    public enum ControlState
    {
        /// <summary> Button is not pressed </summary>
        Released,
        /// <summary> Button was released this frame </summary>
        OnRelease,

        /// <summary> Button was pressed this frame </summary>
        OnPress,
        /// <summary> Button is being held down </summary>
        Pressed
    }

    public enum ControlType
    {
        None = 0,

        Buttons,
        DPad,
        Triggers,
        ThumbSticks
    }

    public enum GamePadControl
    {
        None = 0,

        A = 1 << 0,
        B = 1 << 1,
        X = 1 << 2,
        Y = 1 << 3,

        Down = 1 << 4,
        Left = 1 << 5,
        Right = 1 << 6,
        Up = 1 << 7,

        Start = 1 << 8,
        Back = 1 << 9,

        LeftTrigger = 1 << 10,
        RightTrigger = 1 << 11,

        LeftShoulder = 1 << 12,
        RightShoulder = 1 << 13,

        LeftStick = 1 << 14,
        RightStick = 1 << 15,

        LeftStickButton = 1 << 16,
        RightStickButton = 1 << 17,

        Guide = 1 << 18
    }

    public static class GamePadUtility
    {
        private static string ParseControlName(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return
                str.ToPascal().
                    Replace("Panel", "").
                    Replace("Label", "").
                    Replace("EditButton", "");
        }

        public static GamePadControl ParseControl(string str)
        {
            if (string.IsNullOrEmpty(str))
                return GamePadControl.None;

            try
            {
                return (GamePadControl)Enum.Parse(typeof(GamePadControl), ParseControlName(str), true);
            }
            catch (Exception e)
            {
                HUDForm.WriteToLog(e);
            }

            return GamePadControl.None;
        }

        public static string ParseOrientation(this GamePadControl control)
        {
            if (control.ToString().Contains("Left"))
                return "Left";
            if (control.ToString().Contains("Right"))
                return "Right";

            return null;
        }

        public static ControlType ParseControlType(this GamePadControl control)
        {
            switch (control)
            {
            case GamePadControl.None:
                return ControlType.None;

            case GamePadControl.A:
            case GamePadControl.B:
            case GamePadControl.X:
            case GamePadControl.Y:

            case GamePadControl.Start:
            case GamePadControl.Back:

            case GamePadControl.LeftShoulder:
            case GamePadControl.RightShoulder:

            case GamePadControl.LeftStickButton:
            case GamePadControl.RightStickButton:

            case GamePadControl.Guide:
                return ControlType.Buttons;

            case GamePadControl.Down:
            case GamePadControl.Left:
            case GamePadControl.Right:
            case GamePadControl.Up:
                return ControlType.DPad;

            case GamePadControl.LeftTrigger:
            case GamePadControl.RightTrigger:
                return ControlType.Triggers;

            case GamePadControl.LeftStick:
            case GamePadControl.RightStick:
                return ControlType.ThumbSticks;

            default:
                return ControlType.None;
            }
        }
    }
}
