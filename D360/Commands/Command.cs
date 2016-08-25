using D360.SystemCode;
using D360.Types;

namespace D360.Commands
{
    public class Command
    {
        public InputMode applicableMode = InputMode.None;
        public CommandTarget target = CommandTarget.Cursor;
        
        public virtual bool Execute(ref ControllerState state)
        {
            if (applicableMode == InputMode.None)
                return false;

            return (applicableMode == state.inputMode) || (applicableMode == InputMode.All);
        }
    }
}
