using System;
using Action = D360.Types.Action;

namespace D360.SystemCode
{
    [Serializable]
    public class Configuration
    {
        public Action leftTriggerBinding;
        public Action rightTriggerBinding;

        //public List<Keys> gamepadBindings;

        public Configuration()
        {
            leftTriggerBinding = Action.ActionbarSkill1;
            rightTriggerBinding = Action.ActionbarSkill2;


        }
    }
}
