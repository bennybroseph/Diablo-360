using System;
using System.Xml.Serialization;
using D360.Bindings;

using Action = D360.Bindings.Action;

namespace D360.SystemCode
{
    [Serializable]
    public class Configuration
    {
        public Action leftTriggerBinding;
        public Action rightTriggerBinding;

        public Configuration()
        {
            leftTriggerBinding = Action.ActionbarSkill1;
            rightTriggerBinding = Action.ActionbarSkill2;
        }
    }
}
