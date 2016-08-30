using System;
using System.Collections.Generic;
using D360.Types;
using Action = D360.Types.Action;
using System.Windows.Forms;

namespace D360.Utility
{
    [Serializable]
    public class Configuration
    {
        public enum BindingMode
        {
            None,

            Pointer,
            Move
        }

        [Serializable]
        public class Binding
        {
            public List<GamePadBinding> bindings = new List<GamePadBinding>();
        }
        [Serializable]
        public class GamePadBinding
        {
            public Keys keys;

            public bool onHold;
            public BindingMode bindingMode;
        }

        public Action leftTriggerBinding;
        public Action rightTriggerBinding;

        public Dictionary<GamePadButton, Binding> buttonBindings = new Dictionary<GamePadButton, Binding>();
        public Dictionary<GamePadDPadButton, Binding> dPadBindings = new Dictionary<GamePadDPadButton, Binding>();

        public Configuration()
        {
            leftTriggerBinding = Action.ActionbarSkill1;
            rightTriggerBinding = Action.ActionbarSkill2;

            foreach (GamePadButton button in Enum.GetValues(typeof(GamePadButton)))
            {
                var newBinding = new Binding();
                GamePadBinding newGamePadBinding;
                switch (button)
                {

                case GamePadButton.Start:
                    {
                        newGamePadBinding = new GamePadBinding
                        {
                            keys = Keys.Escape,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBinding.bindings.Add(newGamePadBinding);
                    }
                    break;
                case GamePadButton.Back:
                    {
                        newGamePadBinding = new GamePadBinding
                        {
                            keys = Keys.I,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBinding.bindings.Add(newGamePadBinding);
                    }
                    break;

                case GamePadButton.LeftShoulder:
                    {
                        newGamePadBinding = new GamePadBinding
                        {
                            keys = Keys.D1,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBinding.bindings.Add(newGamePadBinding);
                        newGamePadBinding = new GamePadBinding
                        {
                            keys = Keys.D2,
                            onHold = true,
                            bindingMode = BindingMode.Move
                        };
                        newBinding.bindings.Add(newGamePadBinding);
                    }
                    break;
                case GamePadButton.RightShoulder:
                    {
                        newGamePadBinding = new GamePadBinding
                        {
                            keys = Keys.D3,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBinding.bindings.Add(newGamePadBinding);
                        newGamePadBinding = new GamePadBinding
                        {
                            keys = Keys.D4,
                            onHold = true,
                            bindingMode = BindingMode.Move
                        };
                        newBinding.bindings.Add(newGamePadBinding);
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
                        newGamePadBinding = new GamePadBinding
                        {
                            keys = Keys.None,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBinding.bindings.Add(newGamePadBinding);
                    }
                    break;
                }
                buttonBindings.Add(button, newBinding);
            }

            foreach (GamePadDPadButton button in Enum.GetValues(typeof(GamePadDPadButton)))
            {
                var newBinding = new Binding();
                GamePadBinding newGamePadBinding;
                switch (button)
                {
                default:
                    newGamePadBinding = new GamePadBinding
                    {
                        keys = Keys.None,
                        onHold = false,
                        bindingMode = BindingMode.Move
                    };
                    newBinding.bindings.Add(newGamePadBinding);
                    break;
                }
                dPadBindings.Add(button, newBinding);
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
