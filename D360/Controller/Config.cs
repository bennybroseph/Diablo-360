
namespace D360.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using InputEmulation;
    using SharpDX;

    [Flags]
    public enum InputMode
    {
        Default,

        Pointer = 1 << 0,
        Inventory = 1 << 1,
        FreeTarget = 1 << 2,

        Config = 1 << 3,
    }

    [Serializable]
    public abstract class Binding
    {
        public bool isHoldAction;
        public bool isTargetedAction;

        public InputMode inputMode;

        public abstract void OnPress();
        public abstract void OnRelease();

        public abstract override string ToString();
        public abstract Binding Clone();
    }

    [Serializable]
    public class KeyBinding : Binding
    {
        public Keys keys = Keys.None;

        public override void OnPress()
        {
            VirtualKeyboard.KeyDown(keys);
        }

        public override void OnRelease()
        {
            VirtualKeyboard.KeyUp(keys);
        }

        public override string ToString()
        {
            return keys.ToString();
        }

        public override Binding Clone()
        {
            return new KeyBinding
            {
                keys = keys,

                inputMode = inputMode,
                isHoldAction = isHoldAction,
                isTargetedAction = isTargetedAction,
            };
        }
    }

    [Serializable]
    public class SpecialBinding : Binding
    {
        public override void OnPress()
        {

        }

        public override void OnRelease()
        {

        }

        public override string ToString()
        {
            return GetType().ToString();
        }

        public override Binding Clone()
        {
            return new SpecialBinding
            {
                inputMode = inputMode,
                isHoldAction = isHoldAction,
                isTargetedAction = isTargetedAction,
            };
        }
    }

    [Serializable]
    public class ScriptBinding : Binding
    {
        public string script = string.Empty;

        public override void OnPress()
        {

        }

        public override void OnRelease()
        {

        }

        public override string ToString()
        {
            return "Script";
        }

        public override Binding Clone()
        {
            return new ScriptBinding
            {
                script = script,

                inputMode = inputMode,
                isHoldAction = isHoldAction,
                isTargetedAction = isTargetedAction,
            };
        }
    }

    [Serializable]
    public class ControlConfig
    {
        public List<Binding> bindings = new List<Binding>();

        public override string ToString()
        {
            var result = string.Empty;
            for (var i = 0; i < bindings.Count; i++)
            {
                var action = bindings[i];

                result += action.ToString();
                if (i + 1 < bindings.Count)
                    result += ", ";
            }

            return result;
        }
    }

    public enum StickMode
    {
        Cursor,
        Target
    }
    [Serializable]
    public class StickConfig : ControlConfig
    {
        public float moveDeadzone;
        public float actionDeadzone;

        public StickMode mode;
    }

    [Serializable]
    public class TriggerConfig : ControlConfig
    {
        public float deadzone;
    }

    [Serializable]
    public class Configuration
    {
        public Screen screen = Screen.PrimaryScreen;

        public Dictionary<ControlIndex, ControlConfig> bindingConfigs =
            new Dictionary<ControlIndex, ControlConfig>();

        public float holdTime = 0.2f;
        public float vibrationTime = 0.25f * 1000f;

        public bool cursorAlwaysMax = true;
        public float cursorRadius = 1f;

        public bool targetAlwaysMax = false;
        public float targetRadius = 1f;

        public Vector2 centerOffset = new Vector2();

        public Configuration()
        {
            foreach (ControlIndex controlIndex in Enum.GetValues(typeof(ControlIndex)))
            {
                ControlConfig newControlConfig;

                switch (controlIndex.ParseControlType())
                {
                    default:
                        newControlConfig = new ControlConfig();
                        break;

                    case ControlType.Trigger:
                        newControlConfig = new TriggerConfig();
                        break;
                    case ControlType.Stick:
                        newControlConfig = new StickConfig();
                        break;
                }

                Binding newBinding;
                switch (controlIndex)
                {
                    case ControlIndex.Start:
                        {
                            newBinding = new KeyBinding()
                            {
                                keys = Keys.Escape,
                                isHoldAction = false,
                                isTargetedAction = false,
                            };
                            newControlConfig.bindings.Add(newBinding);
                        }
                        break;
                    case ControlIndex.Back:
                        {
                            newBinding = new KeyBinding()
                            {
                                keys = Keys.I,
                                isHoldAction = false,
                                isTargetedAction = false,
                            };
                            newControlConfig.bindings.Add(newBinding);
                        }
                        break;

                    case ControlIndex.RightTrigger:
                        {
                            newBinding = new KeyBinding()
                            {
                                keys = Keys.LButton,
                                isHoldAction = false,
                                isTargetedAction = false,
                            };
                            newControlConfig.bindings.Add(newBinding);
                        }
                        break;
                    case ControlIndex.LeftTrigger:
                        {
                            newBinding = new KeyBinding()
                            {
                                keys = Keys.Shift & Keys.LButton,
                                isHoldAction = false,
                                isTargetedAction = false,
                            };
                            newControlConfig.bindings.Add(newBinding);
                            newBinding = new KeyBinding()
                            {
                                keys = Keys.LButton,
                                isHoldAction = false,
                                isTargetedAction = false,

                                inputMode = InputMode.Pointer,
                            };
                            newControlConfig.bindings.Add(newBinding);
                        }
                        break;

                    case ControlIndex.LeftShoulder:
                        {
                            newBinding = new KeyBinding()
                            {
                                keys = Keys.D1,
                                isHoldAction = false,
                                isTargetedAction = true,
                            };
                            newControlConfig.bindings.Add(newBinding);
                            newBinding = new KeyBinding()
                            {
                                keys = Keys.D2,
                                isHoldAction = true,
                                isTargetedAction = true,
                            };
                            newControlConfig.bindings.Add(newBinding);
                        }
                        break;
                    case ControlIndex.RightShoulder:
                        {
                            newBinding = new KeyBinding()
                            {
                                keys = Keys.D3,
                                isHoldAction = false,
                                isTargetedAction = true,
                            };
                            newControlConfig.bindings.Add(newBinding);
                            newBinding = new KeyBinding()
                            {
                                keys = Keys.D4,
                                isHoldAction = true,
                                isTargetedAction = true,
                            };
                            newControlConfig.bindings.Add(newBinding);
                        }
                        break;

                    case ControlIndex.LeftStick:
                        {
                            if (!(newControlConfig is StickConfig newStickConfig))
                                continue;

                            newBinding = new KeyBinding()
                            {
                                keys = Keys.Space,
                                isHoldAction = false,
                                isTargetedAction = false,
                            };
                            newStickConfig.bindings.Add(newBinding);
                            newBinding = new KeyBinding()
                            {
                                keys = Keys.None,
                                isHoldAction = false,
                                isTargetedAction = false,

                                inputMode = InputMode.Pointer,
                            };
                            newStickConfig.bindings.Add(newBinding);

                            newStickConfig.mode = StickMode.Cursor;
                        }
                        break;
                    case ControlIndex.RightStick:
                        {
                            if (!(newControlConfig is StickConfig newStickConfig))
                                continue;

                            newBinding = new KeyBinding()
                            {
                                keys = Keys.Space,
                                isHoldAction = false,
                                isTargetedAction = false,
                            };
                            newStickConfig.bindings.Add(newBinding);

                            newStickConfig.mode = StickMode.Target;
                        }
                        break;

                    case ControlIndex.LeftThumb:
                        {
                            newBinding = new SpecialBinding()
                            {
                                isHoldAction = false,
                                isTargetedAction = false,
                            };
                            newControlConfig.bindings.Add(newBinding);
                        }
                        break;
                    case ControlIndex.RightThumb:
                        {
                            newBinding = new SpecialBinding()
                            {
                                isHoldAction = false,
                                isTargetedAction = false,
                            };
                            newControlConfig.bindings.Add(newBinding);
                        }
                        break;
                }
                bindingConfigs.Add(controlIndex, newControlConfig);
            }
        }
    }
}
