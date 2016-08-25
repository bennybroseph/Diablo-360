using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Windows.Forms;

namespace D360.Bindings
{
    public enum Action
    {
        ActionbarSkill1,
        ActionbarSkill2,
        ActionbarSkill3,
        ActionbarSkill4,

        ForceStandStill,
        ForceMove,

        Inventory,

        Map,

        Potion,

        TownPortal,

        GameMenu,
        WorldMap
    }

    [Serializable]
    public class ActionBindings
    {
        public Dictionary<Action, Keys> bindings;

        public ActionBindings()
        {
            bindings = new Dictionary<Action, Keys>
            {
                { Action.ActionbarSkill1, Keys.D1 },
                { Action.ActionbarSkill2, Keys.D2 },
                { Action.ActionbarSkill3, Keys.D3 },
                { Action.ActionbarSkill4, Keys.D4 },

                { Action.ForceStandStill, Keys.LShiftKey },
                { Action.ForceMove, Keys.Space },

                { Action.Inventory, Keys.I },

                { Action.Map, Keys.Tab },

                { Action.Potion, Keys.Q },

                { Action.TownPortal, Keys.T },

                { Action.GameMenu, Keys.Escape },
                { Action.WorldMap, Keys.M }
            };
        }
    }

    public static class ActionEnumExtensions
    {
        [Pure]
        public static string ParseDisplayName(this Action action)
        {
            var displayName = Enum.GetName(typeof(Action), action);

            if (string.IsNullOrEmpty(displayName))
                return displayName;

            for (var i = 0; i < displayName.Length; ++i)
                if (char.IsUpper(displayName[i]) || char.IsNumber(displayName[i]))
                {
                    displayName = displayName.Insert(i, " ");
                    ++i;
                }

            return displayName;
        }
        [Pure]
        public static Action ParseAction(this string action)
        {
            if (string.IsNullOrEmpty(action))
                return Action.ActionbarSkill1;

            action = action.Replace(" ", "");

            return (Action)Enum.Parse(typeof(Action), action);
        }
    }
}
