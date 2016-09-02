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

        Pointer = 1 << 0,
        Move = 1 << 1,
        Inventory = 1 << 2,
        Config = 1 << 3
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
        public List<ControlBinding> controlBindings = new List<ControlBinding>();
    }

    public enum StickMode
    {
        Cursor,
        Target
    }
    [Serializable]
    public class StickConfig : BindingConfig
    {
        public float moveDeadzone;
        public float actionDeadzone;

        public StickMode mode;
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

        public Dictionary<GamePadControl, BindingConfig> bindingConfigs =
            new Dictionary<GamePadControl, BindingConfig>();

        public Configuration()
        {
            leftTriggerBinding = Action.ActionbarSkill1;
            rightTriggerBinding = Action.ActionbarSkill2;

            foreach (GamePadControl button in Enum.GetValues(typeof(GamePadControl)))
            {
                BindingConfig newBindingConfig;

                switch (button.ParseControlType())
                {
                case ControlType.Buttons:
                case ControlType.DPad:
                    newBindingConfig = new BindingConfig();
                    break;

                case ControlType.Triggers:
                    newBindingConfig = new TriggerConfig();
                    break;

                case ControlType.ThumbSticks:
                    newBindingConfig = new StickConfig();
                    break;

                default:
                    newBindingConfig = new BindingConfig();
                    break;
                }

                ControlBinding newControlBinding;
                switch (button)
                {

                case GamePadControl.Start:
                    {
                        newControlBinding = new ControlBinding
                        {
                            keys = Keys.Escape,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBindingConfig.controlBindings.Add(newControlBinding);
                    }
                    break;
                case GamePadControl.Back:
                    {
                        newControlBinding = new ControlBinding
                        {
                            keys = Keys.I,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBindingConfig.controlBindings.Add(newControlBinding);
                    }
                    break;

                case GamePadControl.LeftShoulder:
                    {
                        newControlBinding = new ControlBinding
                        {
                            keys = Keys.D1,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBindingConfig.controlBindings.Add(newControlBinding);
                        newControlBinding = new ControlBinding
                        {
                            keys = Keys.D2,
                            onHold = true,
                            bindingMode = BindingMode.Move
                        };
                        newBindingConfig.controlBindings.Add(newControlBinding);
                    }
                    break;
                case GamePadControl.RightShoulder:
                    {
                        newControlBinding = new ControlBinding
                        {
                            keys = Keys.D3,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBindingConfig.controlBindings.Add(newControlBinding);
                        newControlBinding = new ControlBinding
                        {
                            keys = Keys.D4,
                            onHold = true,
                            bindingMode = BindingMode.Move
                        };
                        newBindingConfig.controlBindings.Add(newControlBinding);
                    }
                    break;

                case GamePadControl.LeftStick:
                    {
                        newControlBinding = new ControlBinding
                        {
                            keys = Keys.Space,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBindingConfig.controlBindings.Add(newControlBinding);
                    }
                    break;

                default:
                    {
                        newControlBinding = new ControlBinding
                        {
                            keys = Keys.None,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBindingConfig.controlBindings.Add(newControlBinding);
                    }
                    break;
                }
                bindingConfigs.Add(button, newBindingConfig);
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
