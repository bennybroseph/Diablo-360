using System;
using D360.SystemUtility;

namespace D360.Types
{
    public enum GamePadButton
    {
        None = 0,

        A = 1 << 0,
        B = 1 << 1,
        X = 1 << 2,
        Y = 1 << 3,

        DPadUp = 1 << 4,
        DPadDown = 1 << 5,
        DPadLeft = 1 << 6,
        DPadRight = 1 << 7,

        Start = 1 << 8,
        Back = 1 << 9,

        LeftShoulder = 1 << 10,
        RightShoulder = 1 << 11,

        LeftStick = 1 << 12,
        RightStick = 1 << 13,

        Guide = 1 << 14
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
            switch (str.ParseButton())
            {
            case GamePadButton.Guide:
                str = "XBox Button";
                break;

            case GamePadButton.DPadUp:
                str = "DPad Up";
                break;
            case GamePadButton.DPadDown:
                str = "DPad Down";
                break;
            case GamePadButton.DPadLeft:
                str = "DPad Left";
                break;
            case GamePadButton.DPadRight:
                str = "DPad Right";
                break;

            default:
                for (var i = 0; i < str.Length; ++i)
                {
                    if (!char.IsUpper(str[i]))
                        continue;

                    str = str.Substring(0, i) + " " + str.Substring(i);
                    ++i;
                }
                break;
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
