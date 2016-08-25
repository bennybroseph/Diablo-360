using D360.Types;

namespace D360.Bindings
{
    public class ControllerTriggerBinding
    {
        public ControllerTrigger side;
        public float position;


        public ControllerTriggerBinding(ControllerTrigger leftOrRight, float v)
        {
            side = leftOrRight;
            position = v;
        }
    }
}
