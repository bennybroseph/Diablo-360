using System.Xml.Serialization;

namespace D360.SystemCode
{
    public class Configuration
    {
        [XmlElement("leftTriggerBinding")]
        public string leftTriggerBinding;

        [XmlElement("rightTriggerBinding")]
        public string rightTriggerBinding;

        public Configuration()
        {
            leftTriggerBinding = "actionBarSkill1Key";
            rightTriggerBinding = "actionBarSkill2Key";
        }
    }
}
