using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using XInputDotNetPure;

using Action = D360.Types.Action;
using FormsKeys = System.Windows.Forms.Keys;

namespace D360.SystemUtility
{
    [Serializable]
    public class Configuration
    {
        public Action leftTriggerBinding;
        public Action rightTriggerBinding;

        public Dictionary<Buttons, FormsKeys> gamepadBindings = new Dictionary<Buttons, FormsKeys>();

        public Configuration()
        {
            leftTriggerBinding = Action.ActionbarSkill1;
            rightTriggerBinding = Action.ActionbarSkill2;
            
            foreach (Buttons value in Enum.GetValues(typeof(Buttons)))
            {
                if (value >= Buttons.LeftThumbstickLeft)
                    continue;

                switch (value)
                {
                    case Buttons.DPadUp:
                        gamepadBindings.Add(value, FormsKeys.U | FormsKeys.P);
                        break;
                    case Buttons.DPadDown:
                        gamepadBindings.Add(value, FormsKeys.None);
                        break;
                    case Buttons.DPadLeft:
                        gamepadBindings.Add(value, FormsKeys.None);
                        break;
                    case Buttons.DPadRight:
                        gamepadBindings.Add(value, FormsKeys.None);
                        break;

                    case Buttons.Start:
                        gamepadBindings.Add(value, FormsKeys.None);
                        break;
                    case Buttons.Back:
                        gamepadBindings.Add(value, FormsKeys.None);
                        break;

                    case Buttons.LeftStick:
                        gamepadBindings.Add(value, FormsKeys.None);
                        break;
                    case Buttons.RightStick:
                        gamepadBindings.Add(value, FormsKeys.None);
                        break;

                    case Buttons.LeftShoulder:
                        gamepadBindings.Add(value, FormsKeys.None);
                        break;
                    case Buttons.RightShoulder:
                        gamepadBindings.Add(value, FormsKeys.None);
                        break;

                    case Buttons.A:
                        gamepadBindings.Add(value, FormsKeys.None);
                        break;
                    case Buttons.B:
                        gamepadBindings.Add(value, FormsKeys.None);
                        break;
                    case Buttons.X:
                        gamepadBindings.Add(value, FormsKeys.None);
                        break;
                    case Buttons.Y:
                        gamepadBindings.Add(value, FormsKeys.None);
                        break;

                    default:
                        gamepadBindings.Add(value, FormsKeys.None);
                        break;
                }
            }

            gamepadBindings.Add((Buttons)0x0400, FormsKeys.None);
        }
    }

    public static partial class ButtonsExtensions
    {
        public static string ParseButtonsName(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return str.ToPascal().Replace("Panel", "").Replace("Label", "");
        }
        public static string ParseButtonsDisplayName(this string str)
        {
            switch (str.ParseButtons())
            {
                case Buttons.BigButton:
                    str = "XBox Button";
                    break;

                case Buttons.DPadUp:
                    str = "DPad Up";
                    break;
                case Buttons.DPadDown:
                    str = "DPad Down";
                    break;
                case Buttons.DPadLeft:
                    str = "DPad Left";
                    break;
                case Buttons.DPadRight:
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
        public static Buttons ParseButtons(this string str)
        {
            var returnValue = Buttons.DPadUp;

            if (string.IsNullOrEmpty(str))
                return returnValue;

            try
            {
                returnValue = (Buttons)Enum.Parse(typeof(Buttons), str.ParseButtonsName(), true);
            }
            catch (Exception e)
            {
                HUDForm.WriteToLog(e);
            }

            return returnValue;
        }
    }

    public static partial class StringExtensions
    {
        public static string ToPascal(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            str = str.Substring(0, 1).ToUpper() + str.Substring(1);

            return str;
        }
    }
}
