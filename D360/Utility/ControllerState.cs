using D360.Types;
using Microsoft.Xna.Framework;

namespace D360.Utility
{
    public class ControllerState
    {
        public bool connected;

        public Vector2 targetingReticulePosition;
        public Vector2 cursorPosition;

        public BindingMode currentMode;
        public Vector2 centerOffset;
    }

    public class OldControllerState
    {
        public bool connected;

        public UIntVector targetingReticulePosition;
        public UIntVector cursorPosition;

        public InputMode inputMode;
        public UIntVector centerPosition;
    }
}
