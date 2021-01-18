namespace D360.Utility
{
    using SharpDX;
    using Types;

    public class ControllerState
    {
        public bool connected;

        public Vector2 targetPosition;
        public Vector2 cursorPosition;
        public int pressedTargetKeys;

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
