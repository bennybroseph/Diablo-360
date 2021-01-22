
namespace D360.Controller
{
    using SharpDX;
    using System;
    using System.Collections.Generic;
    using XInputDotNetPure;

    public class ControllerManager
    {
        private readonly Dictionary<PlayerIndex, Controller> m_Controllers = new Dictionary<PlayerIndex, Controller>();

        public Dictionary<PlayerIndex, Controller> controllers => m_Controllers;

        private string m_DebugText;

        public string debugText => m_DebugText;

        public ControllerManager()
        {
            foreach (PlayerIndex playerIndex in Enum.GetValues(typeof(PlayerIndex)))
            {
                var controller =
                    new Controller
                    {
                        index = playerIndex
                    };

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
                            control = new Trigger(controlIndex)
                            {
                                index = controlIndex,
                                directionIndex = controlIndex.ParseDirectionIndex(),

                            };
                            break;

                        case ControlType.Stick:
                            control = new Stick(controlIndex)
                            {
                                index = controlIndex,
                                directionIndex = controlIndex.ParseDirectionIndex(),
                            };
                            break;
                    }

                    controller.controls.Add(controlIndex, control);
                }

                m_Controllers.Add(playerIndex, controller);
            }
        }

        public void Update()
        {
            m_DebugText = string.Empty;

            foreach (var controllerPair in m_Controllers)
            {
                var playerIndex = controllerPair.Key;
                var controller = controllerPair.Value;

                m_DebugText += $"\n\nController {playerIndex}: ";

                var rawState = GamePad.GetState(playerIndex);

                controller.wasConnected = controller.isConnected;

                controller.isConnected = rawState.IsConnected;

                m_DebugText += (controller.isConnected ? "Connected" : "Disconnected") + "\n";
                if (!controller.isConnected)
                {
                    if (controller.wasConnected)
                        System.Diagnostics.Debug.WriteLine($"Controller {playerIndex} disconnected.");
                    continue;
                }

                if (!controller.wasConnected)
                    System.Diagnostics.Debug.WriteLine($"Controller {playerIndex} connected.");

                foreach (var controlPair in controller.controls)
                {
                    var controlIndex = controlPair.Key;
                    var control = controlPair.Value;

                    control.RefreshState(rawState);

                    m_DebugText += $"\n{control.index} {control.state}";
                }
            }
        }
    }
}
