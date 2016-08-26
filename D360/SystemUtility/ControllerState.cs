using D360.Types;

namespace D360.SystemUtility
{
    public class ControllerState
    {
        public bool connected;

        public UIntVector targetingReticulePosition;
        public UIntVector cursorPosition;

        public InputMode inputMode;
        public UIntVector centerPosition;
    }
}
