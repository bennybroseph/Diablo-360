using System.Windows.Forms;
using D360.InputEmulation;
using D360.SystemCode;
using ButtonState = D360.Types.ButtonState;

namespace D360.Commands
{
    public class MouseButtonCommand : Command
    {
        public MouseButtons mouseButton { get; set; }

        public ButtonState commandState = ButtonState.Down;

        public override bool Execute(ref ControllerState state)
        {
            if (!base.Execute(ref state))
                return false;

            #region Mouse Buttons
            switch (commandState)
            {
                case ButtonState.Down:
                {
                    switch (mouseButton)
                    {
                        case MouseButtons.Left: VirtualMouse.LeftDown(); break;
                        case MouseButtons.Right: VirtualMouse.RightDown(); break;
                    }
                }
                break;
                case ButtonState.Up:
                {
                    switch (mouseButton)
                    {
                        case MouseButtons.Left: VirtualMouse.LeftUp(); break;
                        case MouseButtons.Right: VirtualMouse.RightUp(); break;
                    }
                }
                break;
            }
            #endregion

            return true;
        }
    }
}
