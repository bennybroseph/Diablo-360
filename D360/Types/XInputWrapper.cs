using System;
using D360.SystemUtility;

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

    public static partial class GamePadButtonsExtensions
    {
        public static string ParseButtonName(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return str.ToPascal().Replace("Panel", "").Replace("Label", "");
        }
        public static string ParseButtonDisplayName(this string str)
        {
            for (var i = 0; i < str.Length; ++i)
            {
                if (!char.IsUpper(str[i]))
                    continue;

                str = str.Substring(0, i) + " " + str.Substring(i);
                ++i;
            }

            return str.ToPascal().Replace("Panel", "").Replace("Label", "");
        }
        public static GamePadButton ParseButton(this string str)
        {
            var returnValue = GamePadButton.None;

            if (string.IsNullOrEmpty(str))
                return returnValue;

            try
            {
                returnValue = (GamePadButton)Enum.Parse(typeof(GamePadButton), str.ParseButtonName(), true);
            }
            catch (Exception e)
            {
                HUDForm.WriteToLog(e);
            }

            return returnValue;
        }
    }
}
