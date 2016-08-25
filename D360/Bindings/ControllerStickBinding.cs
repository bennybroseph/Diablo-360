using D360.Types;
using Microsoft.Xna.Framework;

namespace D360.Bindings
{
    public class ControllerStickBinding
    {
        public readonly ControllerStick side;
        public Vector2 position;
        public readonly StickState newState;
        public readonly StickState oldState;

        public ControllerStickBinding(ControllerStick leftOrRight, Vector2 v, StickState newS, StickState oldS = StickState.Any)
        {
            side = leftOrRight;
            position = v;
            newState = newS;
            oldState = oldS;
        }
    }
}
