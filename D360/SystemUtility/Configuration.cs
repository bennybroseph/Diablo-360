using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

using Action = D360.Types.Action;
using FormsKeys = System.Windows.Forms.Keys;

namespace D360.SystemUtility
{
    [Serializable]
    public class Configuration
    {
        public Action leftTriggerBinding;
        public Action rightTriggerBinding;

        public readonly Dictionary<Buttons, FormsKeys> gamepadBindings = new Dictionary<Buttons, FormsKeys>();

        public Configuration()
        {
            leftTriggerBinding = Action.ActionbarSkill1;
            rightTriggerBinding = Action.ActionbarSkill2;

            foreach (Buttons value in Enum.GetValues(typeof(Buttons)))
            {
                gamepadBindings.Add(value, FormsKeys.D7);
            }
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
            var returnValue = Buttons.A;

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
