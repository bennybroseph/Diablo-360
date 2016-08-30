using System;
using D360.Utility;

namespace D360.Types
{
    public enum GamePadButtonStates
    {
        Releasing,
        Released,
        Pressed,
        Held
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
        private static string ParseButtonName(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return
                str.ToPascal().
                    Replace("Panel", "").
                    Replace("Label", "").
                    Replace("EditButton", "");
        }

        public static TButton ParseButton<TButton>(string str)
        {
            object returnValue = 0;

            if (string.IsNullOrEmpty(str))
                return (TButton)returnValue;

            try
            {
                return (TButton)Enum.Parse(typeof(TButton), ParseButtonName(str), true);
            }
            catch (Exception e)
            {
                HUDForm.WriteToLog(e);
            }

            return (TButton)returnValue;
        }
    }
}
