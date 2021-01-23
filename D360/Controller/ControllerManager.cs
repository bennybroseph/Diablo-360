
namespace D360.Controller
{
    using System;
    using System.Collections.Generic;
    using InputEmulation;
    using XInputDotNetPure;

    public class ControllerManager
    {
        private readonly Dictionary<PlayerIndex, Controller> m_Controllers = new Dictionary<PlayerIndex, Controller>();

        public Dictionary<PlayerIndex, Controller> controllers => m_Controllers;

        public InputMode currentMode = InputMode.Default;

        public readonly List<Binding> pressActions = new List<Binding>();
        public readonly List<Binding> releaseActions = new List<Binding>();

        public ControllerManager()
        {
            foreach (PlayerIndex playerIndex in Enum.GetValues(typeof(PlayerIndex)))
                m_Controllers.Add(playerIndex, new Controller(playerIndex));

            Main.self.overlayWindow.setDebugText += SetDebugText;
        }

        public void Update()
        {
            foreach (var controllerPair in m_Controllers)
            {
                controllerPair.Value.RefreshState();

                if (currentMode == InputMode.Config)
                    continue;

                controllerPair.Value.ParseInput();
            }

            ProcessInput();
        }

        private void ProcessInput()
        {
            foreach (var action in pressActions)
                action.OnPress();

            foreach (var action in releaseActions)
                action.OnRelease();

            pressActions.Clear();
            releaseActions.Clear();
        }

        private void SetDebugText(ref string pDebugText)
        {
            pDebugText += $"Current Mode: {currentMode}";

            foreach (var controllerPair in m_Controllers)
                controllerPair.Value.SetDebugText(ref pDebugText);
        }
    }
}
