using System;
using System.Collections.Generic;
using D360.Types;
using Microsoft.Xna.Framework.Input;
using Action = D360.Types.Action;
using FormsKeys = System.Windows.Forms.Keys;

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

        public class GamePadBinding
        {
            public FormsKeys keys;

            public bool onHold;
            public BindingMode bindingMode;
        }

        public Action leftTriggerBinding;
        public Action rightTriggerBinding;

        public Dictionary<Buttons, FormsKeys> gamepadBindings = new Dictionary<Buttons, FormsKeys>();

        public Dictionary<GamePadButton, Binding> buttonBindings = new Dictionary<GamePadButton, Binding>();
        public Dictionary<GamePadDPadButton, Binding> dPadBindings = new Dictionary<GamePadDPadButton, Binding>();

        public Configuration()
        {
            leftTriggerBinding = Action.ActionbarSkill1;
            rightTriggerBinding = Action.ActionbarSkill2;

            foreach (GamePadButton value in Enum.GetValues(typeof(GamePadButton)))
            {
                var newBinding = new Binding();
                GamePadBinding newGamePadBinding;
                switch (value)
                {

                case GamePadButton.Start:
                    {
                        newGamePadBinding = new GamePadBinding
                        {
                            keys = FormsKeys.Escape,
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
                            keys = FormsKeys.I,
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
                            keys = FormsKeys.D1,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBinding.bindings.Add(newGamePadBinding);
                        newGamePadBinding = new GamePadBinding
                        {
                            keys = FormsKeys.D2,
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
                            keys = FormsKeys.D3,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBinding.bindings.Add(newGamePadBinding);
                        newGamePadBinding = new GamePadBinding
                        {
                            keys = FormsKeys.D4,
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
                            keys = FormsKeys.None,
                            onHold = false,
                            bindingMode = BindingMode.Move
                        };
                        newBinding.bindings.Add(newGamePadBinding);
                    }
                    break;
                }
                buttonBindings.Add(value, newBinding);
            }
        }
    }

    public static class ButtonsExtensions
    {
        public static string ParseButtonsName(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return str.ToPascal().Replace("Panel", "").Replace("Label", "");
        }
        public static string ParseButtonsDisplayName(this string str)
        {
            switch (str.ParseButtons())
            {
            case Buttons.BigButton:
                str = "XBox Button";
                break;

            case Buttons.DPadUp:
                str = "DPad Up";
                break;
            case Buttons.DPadDown:
                str = "DPad Down";
                break;
            case Buttons.DPadLeft:
                str = "DPad Left";
                break;
            case Buttons.DPadRight:
                str = "DPad Right";
                break;

            default:
                for (var i = 0; i < str.Length; ++i)
                {
                    if (!char.IsUpper(str[i]))
                        continue;

                    str = str.Substring(0, i) + " " + str.Substring(i);
                    ++i;
                }
                break;
            }

            return str.ToPascal().Replace("Panel", "").Replace("Label", "");
        }
        public static Buttons ParseButtons(this string str)
        {
            var returnValue = Buttons.DPadUp;

            if (string.IsNullOrEmpty(str))
                return returnValue;

            try
            {
                returnValue = (Buttons)Enum.Parse(typeof(Buttons), str.ParseButtonsName(), true);
            }
            catch (Exception e)
            {
                HUDForm.WriteToLog(e);
            }

            return returnValue;
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
