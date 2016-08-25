using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

using Action = D360.Types.Action;
using FormsKeys = System.Windows.Forms.Keys;

namespace D360.SystemCode
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
        public static string ParseButtonsDisplayName(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return str.ToPascal().Replace("Panel", "").Replace("Label", "");
        }
        public static Buttons ParseButtons(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return Buttons.A;

            var test = str.ParseButtonsDisplayName();
            Buttons returnValue = (Buttons)Enum.Parse(typeof(Buttons), str.ParseButtonsDisplayName(), true);
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
