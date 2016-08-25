using System.Windows.Forms;
using D360.InputEmulation;
using D360.SystemCode;

using ButtonState = D360.Types.ButtonState;

namespace D360.Commands
{
    public class KeyboardCommand : Command
    {
        public Keys? key { get; set; }

        public ButtonState commandState = ButtonState.Down;
        
        public override bool Execute(ref ControllerState state)
        {
            if (!base.Execute(ref state) || !key.HasValue)
                return false;
            
            if (commandState == ButtonState.Down)
                VirtualKeyboard.KeyDown(key.Value);
            else
                VirtualKeyboard.KeyUp(key.Value);

            return true;
        }
    }
}
