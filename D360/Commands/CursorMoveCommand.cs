using D360.Bindings;
using D360.Utility;
using D360.Types;
using Microsoft.Xna.Framework;

namespace D360.Commands
{
    public class CursorMoveCommand : Command
    {
        public MouseMove mouseMove { get; set; }
        public Vector2 inputCommandValue;

        public override bool Execute(ref OldControllerState state)
        {
            if (!base.Execute(ref state) || mouseMove == null)
                return false;

            #region Mouse Movements
            switch (mouseMove.commandTarget)
            {
                case CommandTarget.Cursor:
                    switch (mouseMove.moveType)
                    {
                        case MouseMoveType.Absolute:
                            state.cursorPosition.X = state.centerPosition.X + (uint)(inputCommandValue.X * mouseMove.moveScale.X);
                            state.cursorPosition.Y = state.centerPosition.Y - (uint)(inputCommandValue.Y * mouseMove.moveScale.Y);
                            break;
                        case MouseMoveType.Relative:
                            state.cursorPosition.X += (uint)(inputCommandValue.X * mouseMove.moveScale.X);
                            state.cursorPosition.Y -= (uint)(inputCommandValue.Y * mouseMove.moveScale.Y);
                            break;
                    }
                    break;
                case CommandTarget.TargetReticule:
                    switch (mouseMove.moveType)
                    {
                        case MouseMoveType.Absolute:

                            state.targetingReticulePosition.X = state.centerPosition.X + (uint)(inputCommandValue.X * mouseMove.moveScale.X);
                            state.targetingReticulePosition.Y = state.centerPosition.Y - (uint)(inputCommandValue.Y * mouseMove.moveScale.Y);
                            break;
                        case MouseMoveType.Relative:
                            state.targetingReticulePosition.X += (uint)(inputCommandValue.X * mouseMove.moveScale.X);
                            state.targetingReticulePosition.Y -= (uint)(inputCommandValue.Y * mouseMove.moveScale.Y);
                            break;
                    }
                    break;
            }
            #endregion

            return true;
        }
    }
}
