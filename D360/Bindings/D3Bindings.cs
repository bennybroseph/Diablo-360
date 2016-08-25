using System.Windows.Forms;
using System.Xml.Serialization;

namespace D360.Bindings
{
    public class D3Bindings
    {
        [XmlElement("inventoryKey")]
        public Keys inventoryKey;

        [XmlElement("mapKey")]
        public Keys mapKey;

        [XmlElement("forceStandStillKey")]
        public Keys forceStandStillKey;
        [XmlElement("forceMoveKey")]
        public Keys forceMoveKey;

        [XmlElement("actionBarSkill1Key")]
        public Keys actionBarSkill1Key;
        [XmlElement("actionBarSkill2Key")]
        public Keys actionBarSkill2Key;
        [XmlElement("actionBarSkill3Key")]
        public Keys actionBarSkill3Key;
        [XmlElement("actionBarSkill4Key")]
        public Keys actionBarSkill4Key;

        [XmlElement("potionKey")]
        public Keys potionKey;

        [XmlElement("townPortalKey")]
        public Keys townPortalKey;

        [XmlElement("gameMenuKey")]
        public Keys gameMenuKey;

        [XmlElement("worldMapKey")]
        public Keys worldMapKey;

        public D3Bindings()
        {
            inventoryKey = Keys.I;

            mapKey = Keys.Tab;

            forceStandStillKey = Keys.LShiftKey;
            forceMoveKey = Keys.Space;

            actionBarSkill1Key = Keys.D1;
            actionBarSkill2Key = Keys.D2;
            actionBarSkill3Key = Keys.D3;
            actionBarSkill4Key = Keys.D4;

            potionKey = Keys.Q;

            townPortalKey = Keys.T;

            gameMenuKey = Keys.Escape;

            worldMapKey = Keys.M;
        }

        internal Keys fromString(string p)
        {
            switch (p)
            {
                case "actionBarSkill1Key": return actionBarSkill1Key;
                case "actionBarSkill2Key": return actionBarSkill2Key;
                case "actionBarSkill3Key": return actionBarSkill3Key;
                case "actionBarSkill4Key": return actionBarSkill4Key;

                case "inventoryKey": return inventoryKey;

                case "mapKey": return mapKey;

                case "potionKey": return potionKey;

                case "townPortalKey": return townPortalKey;

                default: return actionBarSkill1Key;
            }
        }
    }
}
