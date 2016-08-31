using System;
using System.Collections.Generic;
using D360.Types;
using Action = D360.Types.Action;
using System.Windows.Forms;

namespace D360.Utility
{
    [Serializable]
    public class ButtonBinding
    {
        public Keys keys;

        public bool onHold;
        public Configuration.BindingMode bindingMode;
    }

    [Serializable]
    public class Configuration
    {
        public enum BindingMode
        {
            None,

            Pointer,
            Move
        }

        public Action leftTriggerBinding;
        public Action rightTriggerBinding;

        public Dictionary<GamePadButton, List<ButtonBinding>> buttonBindings =
            new Dictionary<GamePadButton, List<ButtonBinding>>();
        public Dictionary<GamePadDPadButton, List<ButtonBinding>> dPadBindings =
            new Dictionary<GamePadDPadButton, List<ButtonBinding>>();

        public Configuration()
        {
            leftTriggerBinding = Action.ActionbarSkill1;
            rightTriggerBinding = Action.ActionbarSkill2;

            foreach (GamePadButton button in Enum.GetValues(typeof(GamePadButton)))
            {
                var newBindings = new List<ButtonBinding>();
                ButtonBinding newButtonBinding;
                switch (button)
                {

                case GamePadButton.Start:
                    {
                        newButtonBinding = new ButtonBinding
                        {
                            keys = Keys.Escape,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBindings.Add(newButtonBinding);
                    }
                    break;
                case GamePadButton.Back:
                    {
                        newButtonBinding = new ButtonBinding
                        {
                            keys = Keys.I,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBindings.Add(newButtonBinding);
                    }
                    break;

                case GamePadButton.LeftShoulder:
                    {
                        newButtonBinding = new ButtonBinding
                        {
                            keys = Keys.D1,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBindings.Add(newButtonBinding);
                        newButtonBinding = new ButtonBinding
                        {
                            keys = Keys.D2,
                            onHold = true,
                            bindingMode = BindingMode.Move
                        };
                        newBindings.Add(newButtonBinding);
                    }
                    break;
                case GamePadButton.RightShoulder:
                    {
                        newButtonBinding = new ButtonBinding
                        {
                            keys = Keys.D3,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBindings.Add(newButtonBinding);
                        newButtonBinding = new ButtonBinding
                        {
                            keys = Keys.D4,
                            onHold = true,
                            bindingMode = BindingMode.Move
                        };
                        newBindings.Add(newButtonBinding);
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
                        newButtonBinding = new ButtonBinding
                        {
                            keys = Keys.None,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBindings.Add(newButtonBinding);
                    }
                    break;
                }
                buttonBindings.Add(button, newBindings);
            }

            foreach (GamePadDPadButton button in Enum.GetValues(typeof(GamePadDPadButton)))
            {
                var newBindings = new List<ButtonBinding>();
                ButtonBinding newButtonBinding;
                switch (button)
                {
                default:
                    newButtonBinding = new ButtonBinding
                    {
                        keys = Keys.None,
                        onHold = false,
                        bindingMode = BindingMode.Move
                    };
                    newBindings.Add(newButtonBinding);
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
