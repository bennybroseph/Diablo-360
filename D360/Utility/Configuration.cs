
namespace D360.Utility
{
    using Types;
    using Microsoft.Xna.Framework;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    [Flags]
    public enum BindingMode
    {
        None,

        Move = 1 << 0,
        Pointer = 1 << 1,
        Inventory = 1 << 2,
        Config = 1 << 3
    }

    public enum BindingType
    {
        Key,
        SpecialAction,
        Script,
    }

    [Serializable]
    public class ControlBinding
    {
        public Keys keys = Keys.None;
        public SpecialAction specialAction;
        public string script = string.Empty;

        public bool onHold;
        public bool targeted;
        public bool swap;
        public BindingMode bindingMode = BindingMode.Move;
        public BindingType bindingType = BindingType.Key;
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
        public Screen screen = Screen.PrimaryScreen;

        public Dictionary<GamePadControl, BindingConfig> bindingConfigs =
            new Dictionary<GamePadControl, BindingConfig>();

        public float holdTime = 0.2f;
        public float vibrationTime = 0.25f * 1000f;

        public bool cursorAlwaysMax = true;
        public float cursorRadius = 1f;

        public bool targetAlwaysMax = false;
        public float targetRadius = 1f;

        public Vector2 centerOffset = new Vector2();

        public Configuration()
        {
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
                            targeted = false,
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
                            targeted = false,
                            bindingMode = BindingMode.Move
                        };
                        newBindingConfig.controlBindings.Add(newControlBinding);
                    }
                    break;

                case GamePadControl.LeftTrigger:
                    {
                        newControlBinding = new ControlBinding
                        {
                            keys = Keys.RButton,
                            onHold = false,
                            targeted = false,
                            bindingMode = BindingMode.Move | BindingMode.Pointer
                        };
                        newBindingConfig.controlBindings.Add(newControlBinding);
                    }
                    break;
                case GamePadControl.RightTrigger:
                    {
                        newControlBinding = new ControlBinding
                        {
                            keys = Keys.LButton,
                            onHold = false,
                            targeted = false,
                            bindingMode = BindingMode.Move | BindingMode.Pointer
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
                            targeted = true,
                            bindingMode = BindingMode.Move
                        };
                        newBindingConfig.controlBindings.Add(newControlBinding);
                        newControlBinding = new ControlBinding
                        {
                            keys = Keys.D2,
                            onHold = true,
                            targeted = true,
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
                            targeted = true,
                            bindingMode = BindingMode.Move
                        };
                        newBindingConfig.controlBindings.Add(newControlBinding);
                        newControlBinding = new ControlBinding
                        {
                            keys = Keys.D4,
                            onHold = true,
                            targeted = true,
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
                            targeted = false,
                            bindingMode = BindingMode.Move
                        };
                        newBindingConfig.controlBindings.Add(newControlBinding);
                    }
                    break;

                case GamePadControl.LeftStickButton:
                    {
                        newControlBinding = new ControlBinding
                        {
                            specialAction = SpecialAction.SwitchStickMode,
                            onHold = false,
                            targeted = false,
                            bindingMode = BindingMode.Move | BindingMode.Pointer,
                            bindingType = BindingType.SpecialAction
                        };
                        newBindingConfig.controlBindings.Add(newControlBinding);
                    }
                    break;
                case GamePadControl.RightStickButton:
                    {
                        newControlBinding = new ControlBinding
                        {
                            specialAction = SpecialAction.Loot,
                            onHold = false,
                            targeted = false,
                            bindingMode = BindingMode.Move,
                            bindingType = BindingType.SpecialAction
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
                            targeted = false,
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
}
