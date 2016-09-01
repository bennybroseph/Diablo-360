using D360.Types;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Action = D360.Types.Action;

namespace D360.Utility
{
    public enum BindingMode
    {
        None,

        Pointer,
        Move
    }

    [Serializable]
    public class ControlBinding
    {
        public Keys keys;

        public bool onHold;
        public BindingMode bindingMode;
    }

    [Serializable]
    public class BindingConfig
    {
        public List<ControlBinding> controlBindings;
    }
    [Serializable]
    public class StickConfig : BindingConfig
    {
        public float moveDeadzone;
        public float actionDeadzone;
    }
    [Serializable]
    public class TriggerConfig : BindingConfig
    {
        public float deadzone;
    }

    [Serializable]
    public class Configuration
    {
        public Action leftTriggerBinding;
        public Action rightTriggerBinding;

        public Dictionary<GamePadButton, List<ControlBinding>> buttonBindings =
            new Dictionary<GamePadButton, List<ControlBinding>>();
        public Dictionary<GamePadDPadButton, List<ControlBinding>> dPadBindings =
            new Dictionary<GamePadDPadButton, List<ControlBinding>>();

        public Configuration()
        {
            leftTriggerBinding = Action.ActionbarSkill1;
            rightTriggerBinding = Action.ActionbarSkill2;

            foreach (GamePadButton button in Enum.GetValues(typeof(GamePadButton)))
            {
                var newBindings = new List<ControlBinding>();
                ControlBinding newControlBinding;
                switch (button)
                {

                case GamePadButton.Start:
                    {
                        newControlBinding = new ControlBinding
                        {
                            keys = Keys.Escape,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBindings.Add(newControlBinding);
                    }
                    break;
                case GamePadButton.Back:
                    {
                        newControlBinding = new ControlBinding
                        {
                            keys = Keys.I,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBindings.Add(newControlBinding);
                    }
                    break;

                case GamePadButton.LeftShoulder:
                    {
                        newControlBinding = new ControlBinding
                        {
                            keys = Keys.D1,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBindings.Add(newControlBinding);
                        newControlBinding = new ControlBinding
                        {
                            keys = Keys.D2,
                            onHold = true,
                            bindingMode = BindingMode.Move
                        };
                        newBindings.Add(newControlBinding);
                    }
                    break;
                case GamePadButton.RightShoulder:
                    {
                        newControlBinding = new ControlBinding
                        {
                            keys = Keys.D3,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBindings.Add(newControlBinding);
                        newControlBinding = new ControlBinding
                        {
                            keys = Keys.D4,
                            onHold = true,
                            bindingMode = BindingMode.Move
                        };
                        newBindings.Add(newControlBinding);
                    }
                    break;

                case GamePadButton.LeftStick:
                    break;
                case GamePadButton.RightStick:
                    break;

                case GamePadButton.Guide:
                    break;

                default:
                    {
                        newControlBinding = new ControlBinding
                        {
                            keys = Keys.None,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBindings.Add(newControlBinding);
                    }
                    break;
                }
                buttonBindings.Add(button, newBindings);
            }

            foreach (GamePadDPadButton button in Enum.GetValues(typeof(GamePadDPadButton)))
            {
                var newBindings = new List<ControlBinding>();
                ControlBinding newControlBinding;
                switch (button)
                {
                default:
                    newControlBinding = new ControlBinding
                    {
                        keys = Keys.None,
                        onHold = false,
                        bindingMode = BindingMode.Move
                    };
                    newBindings.Add(newControlBinding);
                    break;
                }
                dPadBindings.Add(button, newBindings);
            }
        }
    }

    public static class StringExtensions
    {
        public static string ToPascal(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            str = str.Substring(0, 1).ToUpper() + str.Substring(1);

            return str;
        }
    }
}
