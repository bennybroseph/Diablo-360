using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
}
