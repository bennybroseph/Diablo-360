namespace D360.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using XInputDotNetPure;

    public class Controller
    {
        public PlayerIndex index;

        public bool isConnected;
        public bool wasConnected;

        /// <summary> The current raw state of the controller via XInput </summary>
        public GamePadState rawState;
        public GamePadState prevRawState;

        /// <summary> Each individual button on the controller </summary>
        public readonly Dictionary<ControlIndex, Control> controls = new Dictionary<ControlIndex, Control>();

        public Controller(PlayerIndex pIndex)
        {
            index = pIndex;

            foreach (ControlIndex controlIndex in Enum.GetValues(typeof(ControlIndex)))
            {
                Control control;

                // Creates a new State class of the appropriate type based on the control type
                switch (controlIndex.ParseControlType())
                {
                    default:
                        control = new Control(controlIndex);
                        break;

                    case ControlType.DPad:
                        control = new DPad(controlIndex);
                        break;

                    case ControlType.Trigger:
                        control = new Trigger(controlIndex);
                        break;

                    case ControlType.Stick:
                        control = new Stick(controlIndex);
                        break;
                }

                controls.Add(controlIndex, control);
            }
        }

        public void RefreshState()
        {
            prevRawState = rawState;
            rawState = GamePad.GetState(index);

            wasConnected = isConnected;

            isConnected = rawState.IsConnected;

            if (!isConnected)
            {
                if (wasConnected)
                    Debug.WriteLine($"Controller {index} disconnected.");
                return;
            }

            if (!wasConnected)
                Debug.WriteLine($"Controller {index} connected.");

            foreach (var controlPair in controls)
                controlPair.Value.RefreshState(rawState);
        }

        public void ParseInput()
        {
            foreach (var controlPair in controls)
                controlPair.Value.ParseInput();
        }

        public void SetDebugText(ref string pDebugText)
        {
            pDebugText += $"\n\nController {index}: ";
            pDebugText += (isConnected ? "Connected" : "Disconnected") + "\n";

            if (!isConnected)
                return;

            foreach (var controlPair in controls)
                controlPair.Value.SetDebugText(ref pDebugText);
        }
    }

    public static class ControllerUtility
    {
        public static ControlType ParseControlType(this ControlIndex control)
        {
            switch (control)
            {
                case ControlIndex.A:
                case ControlIndex.B:
                case ControlIndex.X:
                case ControlIndex.Y:
                    return ControlType.Face;

                case ControlIndex.DPadUp:
                case ControlIndex.DPadDown:
                case ControlIndex.DPadLeft:
                case ControlIndex.DPadRight:
                    return ControlType.DPad;

                case ControlIndex.LeftShoulder:
                case ControlIndex.RightShoulder:
                    return ControlType.Shoulder;

                case ControlIndex.LeftTrigger:
                case ControlIndex.RightTrigger:
                    return ControlType.Trigger;

                case ControlIndex.Start:
                case ControlIndex.Back:
                case ControlIndex.Guide:
                    return ControlType.Option;

                case ControlIndex.LeftThumb:
                case ControlIndex.RightThumb:
                    return ControlType.Thumb;

                case ControlIndex.LeftStick:
                case ControlIndex.RightStick:
                    return ControlType.Stick;

                default:
                    return ControlType.None;
            }
        }

        public static DirectionIndex ParseDirectionIndex(this ControlIndex control)
        {
            switch (control)
            {
                case ControlIndex.LeftTrigger:
                case ControlIndex.LeftStick:
                    return DirectionIndex.Left;

                case ControlIndex.RightTrigger:
                case ControlIndex.RightStick:
                    return DirectionIndex.Right;

                default:
                    return DirectionIndex.None;
            }
        }

        public static ControlIndex ParseControlIndex(string pString)
        {
            Enum.TryParse(pString.Replace("StickButton", "Thumb"), true, out ControlIndex result);

            return result;
        }
    }
}
