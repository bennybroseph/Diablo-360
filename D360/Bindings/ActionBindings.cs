using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Action = D360.Types.Action;

namespace D360.Bindings
{
    [Serializable]
    public class ActionBindings
    {
        public Dictionary<Action, Keys> bindings = new Dictionary<Action, Keys>
            {
                { Action.ActionbarSkill1, Keys.D1},
                { Action.ActionbarSkill2, Keys.D2},
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
