using System;
using System.Diagnostics.Contracts;

namespace D360.Types
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