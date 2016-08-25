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

using Keys = System.Windows.Forms.Keys;

namespace D360.SystemCode
{
    public class InputProcessor
    {
        GamePadState lastState;

        public ControllerState currentControllerState;

        public UIntVector center;

        public D3Bindings d3Bindings;
        public Configuration config;

        public List<ControllerInputBinding> bindings;

        public Queue<StateChangeCommand> stateChangeCommands;
        public Queue<CursorMoveCommand> cursorMoveCommands;
        public Queue<Command> reticuleTargetedCommands;
        public Queue<Command> cursorTargetedCommands;
        public Queue<Command> untargetedCommands;
        public Queue<Command> centerRandomTargetedCommands;

        Random rand = new Random();

        public InputProcessor(GamePadState initialState)
        {
            center = new UIntVector(32768, 30650);

            bindings = new List<ControllerInputBinding>();
            lastState = initialState;

            currentControllerState = new ControllerState
            {
                inputMode = InputMode.Pointer,
                targetingReticulePosition = center,
                cursorPosition = center,
                centerPosition = center
            };

            d3Bindings = new D3Bindings();
            config = new Configuration();

            stateChangeCommands = new Queue<StateChangeCommand>();
            cursorMoveCommands = new Queue<CursorMoveCommand>();
            reticuleTargetedCommands = new Queue<Command>();
            cursorTargetedCommands = new Queue<Command>();
            untargetedCommands = new Queue<Command>();
            centerRandomTargetedCommands = new Queue<Command>();

            CreateDefaultBindings();
        }

        private void CreateDefaultBindings()
        {
            // Primary Skill Key
            AddButtonKeyBinding(Buttons.LeftShoulder, d3Bindings.forceStandStillKey, InputMode.Move, CommandTarget.TargetReticule);
            AddButtonMouseBinding(Buttons.LeftShoulder, MouseButtons.Left, InputMode.Move, CommandTarget.TargetReticule);

            // Secondary Skill Key
            AddButtonKeyBinding(Buttons.RightShoulder, d3Bindings.forceStandStillKey, InputMode.Move, CommandTarget.TargetReticule);
            AddButtonMouseBinding(Buttons.RightShoulder, MouseButtons.Right, InputMode.Move, CommandTarget.TargetReticule);

            // Action Bar Skill 1 - 4
            AddButtonKeyBinding(Buttons.X, d3Bindings.actionBarSkill1Key, InputMode.Move, CommandTarget.TargetReticule);
            AddButtonKeyBinding(Buttons.A, d3Bindings.actionBarSkill2Key, InputMode.Move, CommandTarget.TargetReticule);
            AddButtonKeyBinding(Buttons.Y, d3Bindings.actionBarSkill3Key, InputMode.Move, CommandTarget.TargetReticule);
            AddButtonKeyBinding(Buttons.B, d3Bindings.actionBarSkill4Key, InputMode.Move, CommandTarget.TargetReticule);

            // Inventory Key
            AddButtonKeyBinding(Buttons.DPadDown, d3Bindings.inventoryKey);
            AddButtonModeChangeBinding(Buttons.DPadDown, InputMode.Pointer);

            // Map Key
            AddButtonKeyBinding(Buttons.DPadLeft, d3Bindings.mapKey);

            // Potion Key
            AddButtonKeyBinding(Buttons.DPadUp, d3Bindings.potionKey);

            // Town Portal Key
            AddButtonKeyBinding(Buttons.DPadRight, d3Bindings.townPortalKey);

            // Game Menu Key
            AddButtonKeyBinding(Buttons.Back, d3Bindings.gameMenuKey);

            // Game Menu Key
            AddButtonKeyBinding(Buttons.Start, d3Bindings.worldMapKey);
            AddButtonModeChangeBinding(Buttons.DPadDown, InputMode.Pointer);

            // Left stick click to toggle between Pointer and Move modes
            AddButtonModeChangeBinding(Buttons.LeftStick, InputMode.None, true);

            // Right stick click to loot nearby (spam left-mouse clicks in an area near center)
            AddButtonLootBinding(Buttons.RightStick);

            //Left Stick to Move Character in Move Mode
            AddStickCursorMoveBinding(ControllerStick.Left, Vector2.Zero, StickState.NotEqual, MouseMoveType.Absolute, new UIntVector(30000, 25000), CommandTarget.Cursor, InputMode.Move);
            AddStickKeyBinding(ControllerStick.Left, d3Bindings.forceMoveKey, CommandTarget.Cursor, InputMode.Move);

            // Left Stick to stop character in place when stick returns to zero in Move Mode
            AddStickCursorMoveBinding(ControllerStick.Left, Vector2.Zero, StickState.Equal, StickState.NotEqual, MouseMoveType.Absolute, new UIntVector(30000, 25000), CommandTarget.Cursor, InputMode.Move);
            AddStickKeyBinding(ControllerStick.Left, Vector2.Zero, StickState.Equal, StickState.NotEqual, d3Bindings.forceMoveKey, CommandTarget.Cursor, InputMode.Move);

            //Right Stick to move reticule in Move Mode
            AddStickCursorMoveBinding(ControllerStick.Right, MouseMoveType.Absolute, new UIntVector(30000, 25000), CommandTarget.TargetReticule, InputMode.Move);

            #region Pointer Mode
            // Left stick to move cursor in Pointer Mode
            AddStickCursorMoveBinding(ControllerStick.Left, MouseMoveType.Relative, new UIntVector(600, 600), CommandTarget.Cursor, InputMode.Pointer);

            AddButtonMouseBinding(Buttons.LeftShoulder, MouseButtons.Left, InputMode.Pointer, CommandTarget.None, ControllerButtonState.OnDown);
            AddButtonMouseBinding(Buttons.RightShoulder, MouseButtons.Right, InputMode.Pointer, CommandTarget.None, ControllerButtonState.OnDown);
            #endregion
        }

        public void loadChanges()
        {
            bindings.Clear();
            CreateDefaultBindings();
            AddConfiguredBindings();
        }

        public void AddConfiguredBindings()
        {
            AddTriggerKeyBinding(ControllerTrigger.Left, 0.1f, d3Bindings.fromString(config.leftTriggerBinding), InputMode.Move, CommandTarget.TargetReticule);
            AddTriggerKeyBinding(ControllerTrigger.Right, 0.1f, d3Bindings.fromString(config.rightTriggerBinding), InputMode.Move, CommandTarget.TargetReticule);
        }

        private void AddButtonLootBinding(Buttons buttons)
        {
            bindings.AddRange(ControllerInputBinding.createButtonLootBindings(buttons));
        }


        private void AddButtonMouseBinding(Buttons buttons, MouseButtons mouseButtons, InputMode bindingMode = InputMode.All, CommandTarget commandTarget = CommandTarget.None)
        {
            bindings.AddRange(ControllerInputBinding.createMouseButtonBindings(buttons, mouseButtons, bindingMode, commandTarget));
        }

        private void AddButtonMouseBinding(Buttons buttons, MouseButtons mouseButtons, InputMode bindingMode = InputMode.All, CommandTarget commandTarget = CommandTarget.None, ControllerButtonState cbState = ControllerButtonState.WhileDown)
        {
            bindings.AddRange(ControllerInputBinding.createMouseButtonBindings(buttons, mouseButtons, bindingMode, commandTarget, cbState));
        }

        public void AddButtonKeyBinding(Buttons button, Keys key, InputMode bindingMode = InputMode.All, CommandTarget commandTarget = CommandTarget.None)
        {
            bindings.AddRange(ControllerInputBinding.createButtonKeyBindings(button, key, bindingMode, commandTarget));
        }

        private void AddButtonModeChangeBinding(Buttons buttons, InputMode inputMode, bool toggle = false, InputMode bindingMode = InputMode.All, CommandTarget commandTarget = CommandTarget.None)
        {
            bindings.Add(ControllerInputBinding.createButtonModeChangeBinding(buttons, inputMode, toggle, bindingMode, commandTarget));
        }

        private void AddStickCursorMoveBinding(ControllerStick stick, MouseMoveType moveType, UIntVector moveScale, CommandTarget commandTarget, InputMode bindingMode = InputMode.All)
        {
            bindings.Add(ControllerInputBinding.createStickCursorMoveBinding(stick, Vector2.Zero, StickState.Any, moveType, moveScale, commandTarget, bindingMode));
        }

        private void AddStickCursorMoveBinding(ControllerStick stick, Vector2 comparisonVector, StickState comparisonState, MouseMoveType moveType, UIntVector moveScale, CommandTarget commandTarget, InputMode bindingMode = InputMode.All)
        {
            bindings.Add(ControllerInputBinding.createStickCursorMoveBinding(stick, comparisonVector, comparisonState, moveType, moveScale, commandTarget, bindingMode));
        }

        private void AddStickCursorMoveBinding(ControllerStick stick, Vector2 comparisonVector, StickState comparisonState, StickState oldComparisonState, MouseMoveType moveType, UIntVector moveScale, CommandTarget commandTarget, InputMode bindingMode = InputMode.All)
        {
            bindings.Add(ControllerInputBinding.createStickCursorMoveBinding(stick, comparisonVector, comparisonState, oldComparisonState, moveType, moveScale, commandTarget, bindingMode));
        }

        private void AddStickKeyBinding(ControllerStick stick, Vector2 comparisonVector, Keys key, CommandTarget commandTarget, InputMode inputMode)
        {
            bindings.AddRange(ControllerInputBinding.createStickKeyBinding(stick, comparisonVector, key, inputMode, commandTarget));
        }

        private void AddStickKeyBinding(ControllerStick stick, Keys key, CommandTarget commandTarget, InputMode inputMode)
        {
            bindings.AddRange(ControllerInputBinding.createStickKeyBinding(stick, Vector2.Zero, key, inputMode, commandTarget));
        }

        private void AddStickKeyBinding(ControllerStick stick, Vector2 comparisonVector, StickState comparisonState, StickState oldComparisonState, Keys key, CommandTarget commandTarget, InputMode inputMode)
        {
            bindings.AddRange(ControllerInputBinding.createStickKeyBinding(stick, comparisonVector, comparisonState, oldComparisonState, key, inputMode, commandTarget));
        }

        private void AddTriggerKeyBinding(ControllerTrigger controllerTrigger, float triggerValue, Keys keys, InputMode inputMode, CommandTarget commandTarget)
        {
            bindings.AddRange(ControllerInputBinding.createTriggerKeyBindings(controllerTrigger, triggerValue, keys, inputMode, commandTarget));
        }

        public void ClearBindingsForButton(Buttons button)
        {
            var i = 0;
            while (i < bindings.Count)
            {
                if (bindings[i].button == button)
                {
                    bindings.RemoveAt(i);
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

            if (currentControllerState.inputMode == InputMode.Move)
            {
                var DeltaX = (int)currentControllerState.cursorPosition.X - (int)center.X;
                var DeltaY = (int)currentControllerState.cursorPosition.Y - (int)center.Y;

                var deltaVector = new Vector2(DeltaX, DeltaY);
                deltaVector.Normalize();

                deltaVector *= 1000.0f;


                currentControllerState.centerPosition = new UIntVector((uint)(center.X + deltaVector.X), (uint)(center.Y + deltaVector.Y));
                // VirtualMouse.MoveAbsolute(center.X, center.Y);
            }

            foreach (var binding in bindings)
            {
                if (binding.button != 0)
                {
                    switch (binding.buttonState)
                    {
                    case ControllerButtonState.OnDown:
                        if (newState.IsButtonDown(binding.button) && lastState.IsButtonUp(binding.button))
                            enqueueCommands(binding, currentControllerState);
                        break;
                    case ControllerButtonState.OnUp:
                        if (newState.IsButtonUp(binding.button) && lastState.IsButtonDown(binding.button))
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
                            if ((newState.Triggers.Left > binding.trigger.position) && (lastState.Triggers.Left < binding.trigger.position))
                                enqueueCommands(binding, currentControllerState);
                            break;
                        case ControllerTriggerState.OnUp:
                            if ((newState.Triggers.Left < binding.trigger.position) && (lastState.Triggers.Left > binding.trigger.position))
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
                            if ((newState.Triggers.Right > binding.trigger.position) && (lastState.Triggers.Right < binding.trigger.position))
                                enqueueCommands(binding, currentControllerState);
                            break;
                        case ControllerTriggerState.OnUp:
                            if ((newState.Triggers.Right < binding.trigger.position) && (lastState.Triggers.Right > binding.trigger.position))
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
                        if ((lastState.ThumbSticks.Left.X == binding.stick.position.X) && (lastState.ThumbSticks.Left.Y == binding.stick.position.Y))
                            executeCommand = false;
                        break;
                    case StickState.Equal:
                        if ((lastState.ThumbSticks.Left.X != binding.stick.position.X) || (lastState.ThumbSticks.Left.Y != binding.stick.position.Y))
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
                        if ((lastState.ThumbSticks.Right.X == binding.stick.position.X) && (lastState.ThumbSticks.Right.Y == binding.stick.position.Y))
                            executeCommand = false;
                        break;
                    case StickState.Equal:
                        if ((lastState.ThumbSticks.Right.X != binding.stick.position.X) || (lastState.ThumbSticks.Right.Y != binding.stick.position.Y))
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


            while (stateChangeCommands.Count > 0)
            {
                VirtualKeyboard.AllUp();

                currentControllerState.targetingReticulePosition = currentControllerState.centerPosition;
                currentControllerState.cursorPosition = currentControllerState.centerPosition;

                stateChangeCommands.Dequeue().Execute(ref currentControllerState);
            }

            while (cursorMoveCommands.Count > 0)
                cursorMoveCommands.Dequeue().Execute(ref currentControllerState);

            if (centerRandomTargetedCommands.Count > 0)
            {
                var DeltaX = (int)currentControllerState.cursorPosition.X - (int)center.X;
                var DeltaY = (int)currentControllerState.cursorPosition.Y - (int)center.Y;

                var deltaVector = new Vector2(DeltaX, DeltaY);
                deltaVector.Normalize();

                deltaVector *= 1000.0f;

                var centerOffset = new UIntVector((uint)(center.X + deltaVector.X), (uint)(center.Y + deltaVector.Y));
                VirtualMouse.MoveAbsolute(centerOffset.X, centerOffset.Y);
            }
            while (centerRandomTargetedCommands.Count > 0)
                centerRandomTargetedCommands.Dequeue().Execute(ref currentControllerState);

            if (reticuleTargetedCommands.Count > 0)
            {
                if ((currentControllerState.targetingReticulePosition.X == currentControllerState.centerPosition.X) && (currentControllerState.targetingReticulePosition.Y == currentControllerState.centerPosition.Y))
                    VirtualMouse.MoveAbsolute(currentControllerState.cursorPosition.X, currentControllerState.cursorPosition.Y);
                else
                    VirtualMouse.MoveAbsolute(currentControllerState.targetingReticulePosition.X, currentControllerState.targetingReticulePosition.Y);
            }

            Thread.Sleep(10);

            while (reticuleTargetedCommands.Count > 0)
                reticuleTargetedCommands.Dequeue().Execute(ref currentControllerState);

            //if ((currentControllerState.inputMode != InputMode.None) && (currentControllerState.inputMode != InputMode.Pointer))
            if (currentControllerState.inputMode != InputMode.None)
                VirtualMouse.MoveAbsolute(currentControllerState.cursorPosition.X, currentControllerState.cursorPosition.Y);
            while (cursorTargetedCommands.Count > 0)
                cursorTargetedCommands.Dequeue().Execute(ref currentControllerState);

            //if ((currentControllerState.inputMode != InputMode.None) && (currentControllerState.inputMode != InputMode.Pointer))

            while (untargetedCommands.Count > 0)
                untargetedCommands.Dequeue().Execute(ref currentControllerState);

            lastState = newState;
        }

        private void enqueueCommands(ControllerInputBinding binding, ControllerState currentControllerState)
        {
            foreach (var command in binding.commands)
            {
                if (command is StateChangeCommand)
                {
                    stateChangeCommands.Enqueue(command as StateChangeCommand);
                }
                else if (command is CursorMoveCommand)
                {
                    cursorMoveCommands.Enqueue(command as CursorMoveCommand);
                }
                else
                {
                    switch (command.target)
                    {
                    case CommandTarget.Cursor:
                        cursorTargetedCommands.Enqueue(command);
                        break;
                    case CommandTarget.TargetReticule:
                        reticuleTargetedCommands.Enqueue(command);
                        break;
                    case CommandTarget.CenterRandom:
                        centerRandomTargetedCommands.Enqueue(command);
                        break;
                    default:
                        untargetedCommands.Enqueue(command);
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
                    cursorMoveCommands.Enqueue(cmCommand);
                }
                else
                    enqueueCommands(binding, currentControllerState);
            }
        }
    }
}

