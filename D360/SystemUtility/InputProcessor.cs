using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using D360.Bindings;
using D360.Commands;
using D360.InputEmulation;
using D360.Types;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Action = D360.Types.Action;
using FormsKeys = System.Windows.Forms.Keys;

namespace D360.SystemUtility
{
    public class InputProcessor
    {
        private GamePadState m_LastState;

        public ControllerState currentControllerState;

        private UIntVector m_Center;

        public ActionBindings actionBindings;
        public Configuration config;

        private readonly List<ControllerInputBinding> m_Bindings;

        private readonly Queue<StateChangeCommand> m_StateChangeCommands;
        private readonly Queue<CursorMoveCommand> m_CursorMoveCommands;
        private readonly Queue<Command> m_ReticuleTargetedCommands;
        private readonly Queue<Command> m_CursorTargetedCommands;
        private readonly Queue<Command> m_UntargetedCommands;
        private readonly Queue<Command> m_CenterRandomTargetedCommands;

        public InputProcessor(GamePadState initialState)
        {
            m_Center = new UIntVector(32768, 30650);

            m_Bindings = new List<ControllerInputBinding>();
            m_LastState = initialState;

            currentControllerState = new ControllerState
            {
                inputMode = InputMode.Pointer,
                targetingReticulePosition = m_Center,
                cursorPosition = m_Center,
                centerPosition = m_Center
            };

            actionBindings = new ActionBindings();
            config = new Configuration();

            m_StateChangeCommands = new Queue<StateChangeCommand>();
            m_CursorMoveCommands = new Queue<CursorMoveCommand>();
            m_ReticuleTargetedCommands = new Queue<Command>();
            m_CursorTargetedCommands = new Queue<Command>();
            m_UntargetedCommands = new Queue<Command>();
            m_CenterRandomTargetedCommands = new Queue<Command>();

            CreateDefaultBindings();
        }

        private void CreateDefaultBindings()
        {
            foreach (Buttons buttons in Enum.GetValues(typeof(Buttons)))
            {
                if (config.gamepadBindings.ContainsKey(buttons))
                    AddButtonKeyBinding(
                        buttons, config.gamepadBindings[buttons], InputMode.Move, CommandTarget.TargetReticule);
            }

            //// Primary Skill Key
            //AddButtonKeyBinding(Buttons.LeftShoulder, actionBindings.bindings[Action.ForceMove], InputMode.Move, CommandTarget.TargetReticule);
            //AddButtonMouseBinding(Buttons.LeftShoulder, MouseButtons.Left, InputMode.Move, CommandTarget.TargetReticule);

            //// Secondary Skill Key
            //AddButtonKeyBinding(Buttons.RightShoulder, actionBindings.bindings[Action.ForceStandStill], InputMode.Move, CommandTarget.TargetReticule);
            //AddButtonMouseBinding(Buttons.RightShoulder, MouseButtons.Right, InputMode.Move, CommandTarget.TargetReticule);

            //// Action Bar Skill 1 - 4
            //AddButtonKeyBinding(Buttons.X, actionBindings.bindings[Action.ActionbarSkill1], InputMode.Move, CommandTarget.TargetReticule);
            //AddButtonKeyBinding(Buttons.A, actionBindings.bindings[Action.ActionbarSkill2], InputMode.Move, CommandTarget.TargetReticule);
            //AddButtonKeyBinding(Buttons.Y, actionBindings.bindings[Action.ActionbarSkill3], InputMode.Move, CommandTarget.TargetReticule);
            //AddButtonKeyBinding(Buttons.B, actionBindings.bindings[Action.ActionbarSkill4], InputMode.Move, CommandTarget.TargetReticule);

            //// Inventory Key
            //AddButtonKeyBinding(Buttons.DPadDown, actionBindings.bindings[Action.Inventory]);
            //AddButtonModeChangeBinding(Buttons.DPadDown, InputMode.Pointer);

            //// Map Key
            //AddButtonKeyBinding(Buttons.DPadLeft, actionBindings.bindings[Action.Map]);

            //// Potion Key
            //AddButtonKeyBinding(Buttons.DPadUp, actionBindings.bindings[Action.Potion]);

            //// Town Portal Key
            //AddButtonKeyBinding(Buttons.DPadRight, actionBindings.bindings[Action.TownPortal]);

            //// Game Menu Key
            //AddButtonKeyBinding(Buttons.Back, actionBindings.bindings[Action.GameMenu]);

            //// Game Menu Key
            //AddButtonKeyBinding(Buttons.Start, actionBindings.bindings[Action.WorldMap]);
            //AddButtonModeChangeBinding(Buttons.DPadDown, InputMode.Pointer);

            // Left stick click to toggle between Pointer and Move modes
            AddButtonModeChangeBinding(Buttons.LeftStick, InputMode.None, true);

            // Right stick click to loot nearby (spam left-mouse clicks in an area near center)
            AddButtonLootBinding(Buttons.RightStick);

            ////Left Stick to Move Character in Move Mode
            //AddStickCursorMoveBinding(ControllerStick.Left, Vector2.Zero, StickState.NotEqual, MouseMoveType.Absolute, new UIntVector(30000, 25000), CommandTarget.Cursor, InputMode.Move);
            //AddStickKeyBinding(ControllerStick.Left, actionBindings.bindings[Action.ForceMove], CommandTarget.Cursor, InputMode.Move);

            //// Left Stick to stop character in place when stick returns to zero in Move Mode
            //AddStickCursorMoveBinding(ControllerStick.Left, Vector2.Zero, StickState.Equal, StickState.NotEqual, MouseMoveType.Absolute, new UIntVector(30000, 25000), CommandTarget.Cursor, InputMode.Move);
            //AddStickKeyBinding(ControllerStick.Left, Vector2.Zero, StickState.Equal, StickState.NotEqual, actionBindings.bindings[Action.ForceMove], CommandTarget.Cursor, InputMode.Move);

            ////Right Stick to move reticule in Move Mode
            //AddStickCursorMoveBinding(ControllerStick.Right, MouseMoveType.Absolute, new UIntVector(30000, 25000), CommandTarget.TargetReticule, InputMode.Move);

            //#region Pointer Mode
            //// Left stick to move cursor in Pointer Mode
            //AddStickCursorMoveBinding(ControllerStick.Left, MouseMoveType.Relative, new UIntVector(600, 600), CommandTarget.Cursor, InputMode.Pointer);

            //AddButtonMouseBinding(Buttons.LeftShoulder, MouseButtons.Left, InputMode.Pointer, CommandTarget.None, ControllerButtonState.OnDown);
            //AddButtonMouseBinding(Buttons.RightShoulder, MouseButtons.Right, InputMode.Pointer, CommandTarget.None, ControllerButtonState.OnDown);
            //#endregion
        }

        public void loadChanges()
        {
            m_Bindings.Clear();
            CreateDefaultBindings();
            AddConfiguredBindings();
        }

        public void AddConfiguredBindings()
        {
            AddTriggerKeyBinding(ControllerTrigger.Left, 0.1f, actionBindings.bindings[config.leftTriggerBinding], InputMode.Move, CommandTarget.TargetReticule);
            AddTriggerKeyBinding(ControllerTrigger.Right, 0.1f, actionBindings.bindings[config.rightTriggerBinding], InputMode.Move, CommandTarget.TargetReticule);
        }

        private void AddButtonLootBinding(Buttons buttons)
        {
            m_Bindings.AddRange(ControllerInputBinding.createButtonLootBindings(buttons));
        }

        private void AddButtonMouseBinding(Buttons buttons, MouseButtons mouseButtons, InputMode bindingMode = InputMode.All, CommandTarget commandTarget = CommandTarget.None)
        {
            m_Bindings.AddRange(ControllerInputBinding.createMouseButtonBindings(buttons, mouseButtons, bindingMode, commandTarget));
        }

        private void AddButtonMouseBinding(Buttons buttons, MouseButtons mouseButtons, InputMode bindingMode = InputMode.All, CommandTarget commandTarget = CommandTarget.None, ControllerButtonState cbState = ControllerButtonState.WhileDown)
        {
            m_Bindings.AddRange(ControllerInputBinding.createMouseButtonBindings(buttons, mouseButtons, bindingMode, commandTarget, cbState));
        }

        public void AddButtonKeyBinding(Buttons button, FormsKeys key, InputMode bindingMode = InputMode.All, CommandTarget commandTarget = CommandTarget.None)
        {
            m_Bindings.AddRange(ControllerInputBinding.createButtonKeyBindings(button, key, bindingMode, commandTarget));
        }

        private void AddButtonModeChangeBinding(Buttons buttons, InputMode inputMode, bool toggle = false, InputMode bindingMode = InputMode.All, CommandTarget commandTarget = CommandTarget.None)
        {
            m_Bindings.Add(ControllerInputBinding.createButtonModeChangeBinding(buttons, inputMode, toggle, bindingMode, commandTarget));
        }

        private void AddStickCursorMoveBinding(ControllerStick stick, MouseMoveType moveType, UIntVector moveScale, CommandTarget commandTarget, InputMode bindingMode = InputMode.All)
        {
            m_Bindings.Add(ControllerInputBinding.createStickCursorMoveBinding(stick, Vector2.Zero, StickState.Any, moveType, moveScale, commandTarget, bindingMode));
        }

        private void AddStickCursorMoveBinding(ControllerStick stick, Vector2 comparisonVector, StickState comparisonState, MouseMoveType moveType, UIntVector moveScale, CommandTarget commandTarget, InputMode bindingMode = InputMode.All)
        {
            m_Bindings.Add(ControllerInputBinding.createStickCursorMoveBinding(stick, comparisonVector, comparisonState, moveType, moveScale, commandTarget, bindingMode));
        }

        private void AddStickCursorMoveBinding(ControllerStick stick, Vector2 comparisonVector, StickState comparisonState, StickState oldComparisonState, MouseMoveType moveType, UIntVector moveScale, CommandTarget commandTarget, InputMode bindingMode = InputMode.All)
        {
            m_Bindings.Add(ControllerInputBinding.createStickCursorMoveBinding(stick, comparisonVector, comparisonState, oldComparisonState, moveType, moveScale, commandTarget, bindingMode));
        }

        private void AddStickKeyBinding(ControllerStick stick, Vector2 comparisonVector, FormsKeys key, CommandTarget commandTarget, InputMode inputMode)
        {
            m_Bindings.AddRange(ControllerInputBinding.createStickKeyBinding(stick, comparisonVector, key, inputMode, commandTarget));
        }

        private void AddStickKeyBinding(ControllerStick stick, FormsKeys key, CommandTarget commandTarget, InputMode inputMode)
        {
            m_Bindings.AddRange(ControllerInputBinding.createStickKeyBinding(stick, Vector2.Zero, key, inputMode, commandTarget));
        }

        private void AddStickKeyBinding(ControllerStick stick, Vector2 comparisonVector, StickState comparisonState, StickState oldComparisonState, FormsKeys key, CommandTarget commandTarget, InputMode inputMode)
        {
            m_Bindings.AddRange(ControllerInputBinding.createStickKeyBinding(stick, comparisonVector, comparisonState, oldComparisonState, key, inputMode, commandTarget));
        }

        private void AddTriggerKeyBinding(ControllerTrigger controllerTrigger, float triggerValue, FormsKeys keys, InputMode inputMode, CommandTarget commandTarget)
        {
            m_Bindings.AddRange(ControllerInputBinding.createTriggerKeyBindings(controllerTrigger, triggerValue, keys, inputMode, commandTarget));
        }

        public void ClearBindingsForButton(Buttons button)
        {
            var i = 0;
            while (i < m_Bindings.Count)
            {
                if (m_Bindings[i].button == button)
                {
                    m_Bindings.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }

        public void Update(GamePadState newState)
        {
            currentControllerState.connected = newState.IsConnected;

            if (!newState.IsConnected)
            {
                return;
            }

            // Cursor Movement
            if (currentControllerState.inputMode == InputMode.Move)
            {
                var DeltaX = (int)currentControllerState.cursorPosition.X - (int)m_Center.X;
                var DeltaY = (int)currentControllerState.cursorPosition.Y - (int)m_Center.Y;

                var deltaVector = new Vector2(DeltaX, DeltaY);
                deltaVector.Normalize();

                deltaVector *= 1000.0f;

                currentControllerState.centerPosition = new UIntVector((uint)(m_Center.X + deltaVector.X), (uint)(m_Center.Y + deltaVector.Y));
                // VirtualMouse.MoveAbsolute(center.X, center.Y);
            }

            foreach (var binding in m_Bindings)
            {
                if (binding.button != 0)
                {
                    switch (binding.buttonState)
                    {
                        case ControllerButtonState.OnDown:
                            if (newState.IsButtonDown(binding.button) && m_LastState.IsButtonUp(binding.button))
                                enqueueCommands(binding, currentControllerState);
                            break;
                        case ControllerButtonState.OnUp:
                            if (newState.IsButtonUp(binding.button) && m_LastState.IsButtonDown(binding.button))
                                enqueueCommands(binding, currentControllerState);
                            break;
                        case ControllerButtonState.WhileDown:
                            if (newState.IsButtonDown(binding.button))
                                enqueueCommands(binding, currentControllerState);
                            break;
                        case ControllerButtonState.WhileUp:
                            if (newState.IsButtonUp(binding.button))
                                enqueueCommands(binding, currentControllerState);
                            break;
                    }
                }

                if (binding.trigger != null)
                {
                    switch (binding.trigger.side)
                    {
                        case ControllerTrigger.Left:
                            switch (binding.triggerState)
                            {
                                case ControllerTriggerState.OnDown:
                                    if ((newState.Triggers.Left > binding.trigger.position) && (m_LastState.Triggers.Left < binding.trigger.position))
                                        enqueueCommands(binding, currentControllerState);
                                    break;
                                case ControllerTriggerState.OnUp:
                                    if ((newState.Triggers.Left < binding.trigger.position) && (m_LastState.Triggers.Left > binding.trigger.position))
                                        enqueueCommands(binding, currentControllerState);
                                    break;
                                case ControllerTriggerState.WhileDown:
                                    if (newState.Triggers.Left > 0)
                                        enqueueCommands(binding, currentControllerState);
                                    break;
                                case ControllerTriggerState.WhileUp:
                                    if (newState.Triggers.Left == 0)
                                        enqueueCommands(binding, currentControllerState);
                                    break;
                            }
                            break;
                        case ControllerTrigger.Right:
                            switch (binding.triggerState)
                            {
                                case ControllerTriggerState.OnDown:
                                    if ((newState.Triggers.Right > binding.trigger.position) && (m_LastState.Triggers.Right < binding.trigger.position))
                                        enqueueCommands(binding, currentControllerState);
                                    break;
                                case ControllerTriggerState.OnUp:
                                    if ((newState.Triggers.Right < binding.trigger.position) && (m_LastState.Triggers.Right > binding.trigger.position))
                                        enqueueCommands(binding, currentControllerState);
                                    break;
                                case ControllerTriggerState.WhileDown:
                                    if (newState.Triggers.Right > 0)
                                        enqueueCommands(binding, currentControllerState);
                                    break;
                                case ControllerTriggerState.WhileUp:
                                    if (newState.Triggers.Right == 0)
                                        enqueueCommands(binding, currentControllerState);
                                    break;
                            }
                            break;
                    }
                }

                if (binding.stick == null)
                    continue;

                bool executeCommand;

                switch (binding.stick.side)
                {
                    case ControllerStick.Left:
                        executeCommand = true;

                        switch (binding.stick.newState)
                        {
                            case StickState.NotEqual:
                                if ((newState.ThumbSticks.Left.X == binding.stick.position.X) && (newState.ThumbSticks.Left.Y == binding.stick.position.Y))
                                    executeCommand = false;
                                break;
                            case StickState.Equal:
                                if ((newState.ThumbSticks.Left.X != binding.stick.position.X) || (newState.ThumbSticks.Left.Y != binding.stick.position.Y))
                                    executeCommand = false;
                                break;
                        }

                        switch (binding.stick.oldState)
                        {
                            case StickState.NotEqual:
                                if ((m_LastState.ThumbSticks.Left.X == binding.stick.position.X) && (m_LastState.ThumbSticks.Left.Y == binding.stick.position.Y))
                                    executeCommand = false;
                                break;
                            case StickState.Equal:
                                if ((m_LastState.ThumbSticks.Left.X != binding.stick.position.X) || (m_LastState.ThumbSticks.Left.Y != binding.stick.position.Y))
                                    executeCommand = false;
                                break;
                        }

                        if (executeCommand)
                        {
                            var inputCommandValue = new Vector2(newState.ThumbSticks.Left.X, newState.ThumbSticks.Left.Y);
                            enqueueCommands(binding, currentControllerState, inputCommandValue);
                        }
                        break;
                    case ControllerStick.Right:
                        executeCommand = true;

                        switch (binding.stick.newState)
                        {
                            case StickState.NotEqual:
                                if ((newState.ThumbSticks.Right.X == binding.stick.position.X) && (newState.ThumbSticks.Right.Y == binding.stick.position.Y))
                                    executeCommand = false;
                                break;
                            case StickState.Equal:
                                if ((newState.ThumbSticks.Right.X != binding.stick.position.X) || (newState.ThumbSticks.Right.Y != binding.stick.position.Y))
                                    executeCommand = false;
                                break;
                        }

                        switch (binding.stick.oldState)
                        {
                            case StickState.NotEqual:
                                if ((m_LastState.ThumbSticks.Right.X == binding.stick.position.X) && (m_LastState.ThumbSticks.Right.Y == binding.stick.position.Y))
                                    executeCommand = false;
                                break;
                            case StickState.Equal:
                                if ((m_LastState.ThumbSticks.Right.X != binding.stick.position.X) || (m_LastState.ThumbSticks.Right.Y != binding.stick.position.Y))
                                    executeCommand = false;
                                break;
                        }

                        if (executeCommand)
                        {
                            var inputCommandValue = new Vector2(newState.ThumbSticks.Right.X, newState.ThumbSticks.Right.Y);
                            enqueueCommands(binding, currentControllerState, inputCommandValue);
                        }
                        break;
                }
            }


            while (m_StateChangeCommands.Count > 0)
            {
                VirtualKeyboard.AllUp();

                currentControllerState.targetingReticulePosition = currentControllerState.centerPosition;
                //currentControllerState.cursorPosition = currentControllerState.centerPosition;

                m_StateChangeCommands.Dequeue().Execute(ref currentControllerState);
            }

            while (m_CursorMoveCommands.Count > 0)
                m_CursorMoveCommands.Dequeue().Execute(ref currentControllerState);

            if (m_CenterRandomTargetedCommands.Count > 0)
            {
                var DeltaX = (int)currentControllerState.cursorPosition.X - (int)m_Center.X;
                var DeltaY = (int)currentControllerState.cursorPosition.Y - (int)m_Center.Y;

                var deltaVector = new Vector2(DeltaX, DeltaY);
                deltaVector.Normalize();

                deltaVector *= 1000.0f;

                var centerOffset = new UIntVector((uint)(m_Center.X + deltaVector.X), (uint)(m_Center.Y + deltaVector.Y));
                VirtualMouse.MoveAbsolute(centerOffset.X, centerOffset.Y);
            }
            while (m_CenterRandomTargetedCommands.Count > 0)
                m_CenterRandomTargetedCommands.Dequeue().Execute(ref currentControllerState);

            if (m_ReticuleTargetedCommands.Count > 0)
            {
                //if ((currentControllerState.targetingReticulePosition.X == currentControllerState.centerPosition.X) && (currentControllerState.targetingReticulePosition.Y == currentControllerState.centerPosition.Y))
                //    VirtualMouse.MoveAbsolute(currentControllerState.cursorPosition.X, currentControllerState.cursorPosition.Y);
                //else
                //    VirtualMouse.MoveAbsolute(currentControllerState.targetingReticulePosition.X, currentControllerState.targetingReticulePosition.Y);
            }

            Thread.Sleep(10);

            while (m_ReticuleTargetedCommands.Count > 0)
                m_ReticuleTargetedCommands.Dequeue().Execute(ref currentControllerState);

            //if ((currentControllerState.inputMode != InputMode.None) && (currentControllerState.inputMode != InputMode.Pointer))
            //if (currentControllerState.inputMode != InputMode.None)
            //    VirtualMouse.MoveAbsolute(currentControllerState.cursorPosition.X, currentControllerState.cursorPosition.Y);
            while (m_CursorTargetedCommands.Count > 0)
                m_CursorTargetedCommands.Dequeue().Execute(ref currentControllerState);

            //if ((currentControllerState.inputMode != InputMode.None) && (currentControllerState.inputMode != InputMode.Pointer))

            while (m_UntargetedCommands.Count > 0)
                m_UntargetedCommands.Dequeue().Execute(ref currentControllerState);

            m_LastState = newState;
        }

        private void enqueueCommands(ControllerInputBinding binding, ControllerState currentControllerState)
        {
            foreach (var command in binding.commands)
            {
                if (command is StateChangeCommand)
                {
                    m_StateChangeCommands.Enqueue(command as StateChangeCommand);
                }
                else if (command is CursorMoveCommand)
                {
                    m_CursorMoveCommands.Enqueue(command as CursorMoveCommand);
                }
                else
                {
                    switch (command.target)
                    {
                        case CommandTarget.Cursor:
                            m_CursorTargetedCommands.Enqueue(command);
                            break;
                        case CommandTarget.TargetReticule:
                            m_ReticuleTargetedCommands.Enqueue(command);
                            break;
                        case CommandTarget.CenterRandom:
                            m_CenterRandomTargetedCommands.Enqueue(command);
                            break;
                        default:
                            m_UntargetedCommands.Enqueue(command);
                            break;
                    }
                }
            }
        }

        private void enqueueCommands(ControllerInputBinding binding, ControllerState currentControllerState, Vector2 inputValue)
        {
            foreach (var command in binding.commands)
            {
                if (command is CursorMoveCommand)
                {
                    var cmCommand = command as CursorMoveCommand;
                    cmCommand.inputCommandValue = inputValue;
                    m_CursorMoveCommands.Enqueue(cmCommand);
                }
                else
                    enqueueCommands(binding, currentControllerState);
            }
        }
    }
}

