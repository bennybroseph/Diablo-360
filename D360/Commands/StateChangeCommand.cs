using D360.Bindings;
using D360.SystemCode;
using D360.Types;

namespace D360.Commands
{
    public class StateChangeCommand : Command
    {
        public StateChange stateChange { get; set; }

        public override bool Execute(ref ControllerState state)
        {
            if (!base.Execute(ref state))
                return false;

            #region State Changes
            if (stateChange == null)
                return true;
            if (stateChange.toggle)
            {
                switch (state.inputMode)
                {
                    case InputMode.Move: state.inputMode = InputMode.Pointer; break;
                    case InputMode.Pointer: state.inputMode = InputMode.Move; break;
                }
            }
            else if (stateChange.newMode != InputMode.None)
            {
                state.inputMode = stateChange.newMode;
            }
            #endregion

            return true;
        }

    }
}
