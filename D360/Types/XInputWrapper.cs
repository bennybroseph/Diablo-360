using System;
using D360.Utility;

namespace D360.Types
{
    public enum GamePadButtonStates
    {
        /// Button is not pressed
        Released,
        /// Button was released this frame
        OnRelease,
        /// Button was pressed this frame
        OnPress,
        /// Button is being held down
        Pressed
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

    public enum GamePadButton
    {
        None = 0,

        A = 1 << 0,
        B = 1 << 1,
        X = 1 << 2,
        Y = 1 << 3,

        Start = 1 << 4,
        Back = 1 << 5,

        LeftShoulder = 1 << 6,
        RightShoulder = 1 << 7,

        LeftStick = 1 << 8,
        RightStick = 1 << 9,

        Guide = 1 << 10
    }

    public enum GamePadDPadButton
    {
        None = 0,

        Down = 1 << 0,
        Left = 1 << 1,
        Right = 1 << 2,
        Up = 1 << 3,
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

        public static TControl ParseControl<TControl>(string str)
        {
            object returnValue = 0;

            if (string.IsNullOrEmpty(str))
                return (TControl)returnValue;

            try
            {
                return (TControl)Enum.Parse(typeof(TControl), ParseControlName(str), true);
            }
            catch (Exception e)
            {
                HUDForm.WriteToLog(e);
            }

            return (TControl)returnValue;
        }
    }
}
