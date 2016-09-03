using D360.Commands;
using D360.Utility;
using D360.Types;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Windows.Forms;

using ButtonState = D360.Types.ButtonState;
using FormsKeys = System.Windows.Forms.Keys;

namespace D360.Bindings
{
    public class ControllerInputBinding
    {
        public Buttons button { get; set; }
        public ControllerTriggerBinding trigger { get; set; }
        public ControllerStickBinding stick { get; set; }

        public ControllerButtonState buttonState { get; set; }
        public ControllerTriggerState triggerState { get; set; }

        public readonly List<Command> commands = new List<Command>();
        
        internal void ExecuteCommands(ref OldControllerState state)
        {
            foreach (var command in commands)
                command.Execute(ref state);
        }

        /// <summary>
        /// createButtonKeyBindings creates two new binding and command sets, which directly maps a 
        /// controller button to a keyboard key. Given keyboard key is signaled as down when the button is 
        /// down, and up when the button is up.
        /// </summary>
        /// <param name="button">Controller button to bind</param>
        /// <param name="key">Keyboard Key to bind </param>
        /// <param name="applicableMode">Which input mode in which this binding is active - 
        /// all modes by default.</param>
        /// <param name="target">Indicates if the key should be pressed with the mouse cursor at 
        /// a particular location (cursorPosition, reticulePosition, or none)</param>
        /// <returns>A two-element array of ControllerInputBinding, to be passed to bindings.AddRange()</returns>
        public static IEnumerable<ControllerInputBinding> createButtonKeyBindings(
            Buttons button,
            FormsKeys key,
            InputMode applicableMode = InputMode.All,
            CommandTarget target = CommandTarget.None)
        {
            var downResult = new ControllerInputBinding
            {
                button = button,
                buttonState = ControllerButtonState.OnDown
            };
            var newCommand = new KeyboardCommand
            {
                key = key,
                commandState = ButtonState.Down,
                applicableMode = applicableMode,
                target = target
            };
            downResult.commands.Add(newCommand);

            var upResult = new ControllerInputBinding
            {
                button = button,
                buttonState = ControllerButtonState.OnUp
            };
            newCommand = new KeyboardCommand
            {
                key = key,
                commandState = ButtonState.Up,
                applicableMode = applicableMode,
                target = target
            };
            upResult.commands.Add(newCommand);

            return new[] { downResult, upResult };
        }

        /// <summary>
        /// createButtonModeChangeBinding creates a new binding and command set, which changes between input modes.
        /// </summary>
        /// <param name="button">Controller button to bind</param>
        /// <param name="newMode">Which input mode to change to. Disregarded if toggle == true</param>
        /// <param name="toggle">If toggle, newMode is ignored, and the bound key will 
        /// instead cycle through all available modes</param>
        /// <param name="applicableMode">Which input mode in which this binding is active - 
        /// all modes by default.</param>
        /// <param name="target">Indicates if the key should be pressed with the mouse cursor at 
        /// a particular location (cursorPosition, reticulePosition, or none)</param>
        /// <returns></returns>
        public static ControllerInputBinding createButtonModeChangeBinding(
            Buttons button,
            InputMode newMode,
            bool toggle = false,
            InputMode applicableMode = InputMode.All,
            CommandTarget target = CommandTarget.None)
        {
            var result = new ControllerInputBinding
            {
                button = button,
                buttonState = ControllerButtonState.OnDown
            };

            var newCommand = new StateChangeCommand
            {
                stateChange = new StateChange { toggle = toggle, newMode = newMode },
                applicableMode = applicableMode,
                target = target
            };
            result.commands.Add(newCommand);

            return result;
        }

        /// <summary>
        /// createButtonKeyBindings creates two new binding and command sets, which directly maps a 
        /// controller button to a mouse button. Given mouse button is signaled as down when the button is 
        /// down, and up when the button is up.
        /// </summary>
        /// <param name="buttons">Controller button to bind</param>
        /// <param name="mouseButtons">Mouse button to bind</param>
        /// <param name="applicableMode">Which input mode in which this binding is active - 
        /// all modes by default.</param>
        /// <param name="target">Indicates if the mouse button should be pressed with the mouse cursor at 
        /// a particular location (cursorPosition, reticulePosition, or none)</param>
        /// <returns></returns>
        internal static IEnumerable<ControllerInputBinding> createMouseButtonBindings(
            Buttons button,
            MouseButtons mouseButton,
            InputMode applicableMode = InputMode.All,
            CommandTarget target = CommandTarget.None,
            ControllerButtonState cbState = ControllerButtonState.WhileDown)
        {
            var downResult = new ControllerInputBinding
            {
                button = button,
                buttonState = cbState
            };
            var newCommand = new MouseButtonCommand
            {
                mouseButton = mouseButton,
                commandState = ButtonState.Down,
                applicableMode = applicableMode,
                target = target
            };
            downResult.commands.Add(newCommand);

            var upResult = new ControllerInputBinding
            {
                button = button,
                buttonState = ControllerButtonState.OnUp
            };
            newCommand = new MouseButtonCommand
            {
                mouseButton = mouseButton,
                commandState = ButtonState.Up,
                applicableMode = applicableMode,
                target = target
            };
            upResult.commands.Add(newCommand);

            return new[] { downResult, upResult };
        }

        internal static ControllerInputBinding createStickCursorMoveBinding(
            ControllerStick stick,
            Vector2 comparisonVector,
            StickState comparisonState,
            MouseMoveType moveType,
            UIntVector moveScale,
            CommandTarget commandTarget,
            InputMode applicableMode)
        {
            var newBinding = new ControllerInputBinding
            {
                stick = new ControllerStickBinding(stick, comparisonVector, comparisonState)
            };

            var newCommand = new CursorMoveCommand
            {
                mouseMove = new MouseMove
                {
                    commandTarget = commandTarget,
                    moveType = moveType,
                    moveScale = moveScale
                },
                applicableMode = applicableMode
            };

            newBinding.commands.Add(newCommand);
            //bindings.Add(newBinding);

            return newBinding;
        }

        internal static ControllerInputBinding createStickCursorMoveBinding(
            ControllerStick stick,
            Vector2 comparisonVector,
            StickState comparisonState,
            StickState oldState,
            MouseMoveType moveType,
            UIntVector moveScale,
            CommandTarget commandTarget,
            InputMode applicableMode)
        {
            var newBinding = new ControllerInputBinding
            {
                stick = new ControllerStickBinding(stick, comparisonVector, comparisonState, oldState)
            };

            var newCommand = new CursorMoveCommand
            {
                mouseMove = new MouseMove
                {
                    commandTarget = commandTarget,
                    moveType = moveType,
                    moveScale = moveScale
                },
                applicableMode = applicableMode
            };

            newBinding.commands.Add(newCommand);
            //bindings.Add(newBinding);

            return newBinding;
        }

        internal static IEnumerable<ControllerInputBinding> createStickKeyBinding(
            ControllerStick stick,
            Vector2 comparisonVector,
            FormsKeys key,
            InputMode applicableMode = InputMode.All,
            CommandTarget target = CommandTarget.None)
        {
            var downResult = new ControllerInputBinding
            {
                stick = new ControllerStickBinding(stick, comparisonVector, StickState.NotEqual)
            };
            var newCommand = new KeyboardCommand
            {
                key = key,
                commandState = ButtonState.Down,
                applicableMode = applicableMode,
                target = target
            };
            downResult.commands.Add(newCommand);

            var upResult = new ControllerInputBinding
            {
                stick = new ControllerStickBinding(stick, comparisonVector, StickState.Equal)
            };
            newCommand = new KeyboardCommand
            {
                key = key,
                commandState = ButtonState.Up,
                applicableMode = applicableMode,
                target = target
            };
            upResult.commands.Add(newCommand);

            return new[] { downResult, upResult };
        }

        internal static IEnumerable<ControllerInputBinding> createStickKeyBinding(
            ControllerStick stick,
            Vector2 comparisonVector,
            StickState comparisonState,
            StickState oldState,
            FormsKeys key,
            InputMode applicableMode = InputMode.All,
            CommandTarget target = CommandTarget.None)
        {
            var downResult = new ControllerInputBinding
            {
                stick = new ControllerStickBinding(stick, comparisonVector, comparisonState, oldState)
            };
            var newCommand = new KeyboardCommand
            {
                key = key,
                commandState = ButtonState.Down,
                applicableMode = applicableMode,
                target = target
            };
            downResult.commands.Add(newCommand);

            var upResult = new ControllerInputBinding
            {
                stick = new ControllerStickBinding(stick, comparisonVector, comparisonState, oldState)
            };
            newCommand = new KeyboardCommand
            {
                key = key,
                commandState = ButtonState.Up,
                applicableMode = applicableMode,
                target = target
            };
            upResult.commands.Add(newCommand);

            return new[] { downResult, upResult };
        }

        internal static IEnumerable<ControllerInputBinding> createTriggerKeyBindings(
            ControllerTrigger controllerTrigger,
            float triggerValue,
            FormsKeys key,
            InputMode applicableMode,
            CommandTarget target)
        {
            var downResult = new ControllerInputBinding
            {
                trigger = new ControllerTriggerBinding(controllerTrigger, triggerValue),
                triggerState = ControllerTriggerState.OnDown
            };
            var newCommand = new KeyboardCommand
            {
                key = key,
                commandState = ButtonState.Down,
                applicableMode = applicableMode,
                target = target
            };
            downResult.commands.Add(newCommand);

            var upResult = new ControllerInputBinding
            {
                trigger = new ControllerTriggerBinding(controllerTrigger, triggerValue),
                triggerState = ControllerTriggerState.OnUp,
                buttonState = ControllerButtonState.OnUp
            };
            newCommand = new KeyboardCommand
            {
                key = key,
                commandState = ButtonState.Up,
                applicableMode = applicableMode,
                target = target
            };
            upResult.commands.Add(newCommand);

            return new[] { downResult, upResult };
        }

        internal static IEnumerable<ControllerInputBinding> createButtonLootBindings(Buttons buttons)
        {
            var addResult = new ControllerInputBinding
            {
                button = buttons,
                buttonState = ControllerButtonState.WhileDown
            };

            var newCommand = new MouseButtonCommand
            {
                mouseButton = MouseButtons.Left,
                commandState = ButtonState.Down,
                target = CommandTarget.CenterRandom,
                applicableMode = InputMode.Move
            };
            addResult.commands.Add(newCommand);

            newCommand = new MouseButtonCommand
            {
                mouseButton = MouseButtons.Left,
                commandState = ButtonState.Up,
                target = CommandTarget.CenterRandom,
                applicableMode = InputMode.Move
            };
            addResult.commands.Add(newCommand);

            return new[] { addResult };
        }
    }
}
