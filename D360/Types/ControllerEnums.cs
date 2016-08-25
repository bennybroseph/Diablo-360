﻿



namespace D360.Types
{
    public enum ControllerButtonState { OnDown, WhileDown, OnUp, WhileUp }
    public enum ControllerTrigger { Left, Right }
    public enum ControllerStick { Left, Right }
    public enum ButtonState { Down, Up }
    public enum InputMode { All, None, Move, Pointer }
    public enum ControllerTriggerState { OnDown, WhileDown, OnUp, WhileUp }
    public enum CommandTarget { Cursor, TargetReticule, CenterRandom, None }
    public enum MouseMoveType { CurrentState, Absolute, Relative }
    public enum StickState { Equal, NotEqual, Any }
}
