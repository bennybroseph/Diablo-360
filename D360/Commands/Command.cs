using D360.SystemCode;
using D360.Types;

namespace D360.Commands
{
    public class Command
    {
        public InputMode applicableMode = InputMode.None;
        public CommandTarget target = CommandTarget.Cursor;

        //public InputMode inputMode;

        public virtual bool Execute(ref ControllerState state)
        {
            if (applicableMode == InputMode.None)
                return false;

            return (applicableMode == state.inputMode) || (applicableMode == InputMode.All);

            /*
            if (target == CommandTarget.Cursor)
            {
                VirtualMouse.MoveAbsolute(state.cursorPosition.X, state.cursorPosition.Y);
            }
            else if (target == CommandTarget.TargetReticule)
            {
                if ((state.targetingReticulePosition.X == state.centerPosition.X) && (state.targetingReticulePosition.Y == state.centerPosition.Y))
                {
                    VirtualMouse.MoveAbsolute(state.cursorPosition.X, state.cursorPosition.Y);
                }
                else
                {
                    VirtualMouse.MoveAbsolute(state.targetingReticulePosition.X, state.targetingReticulePosition.Y);
                }
            }
            else if (target == CommandTarget.None)
            {
                //
            }
            */
        }
    }
}
