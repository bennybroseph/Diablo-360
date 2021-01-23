using System;

namespace D360.Utility
{
    public static class Time
    {
        private static float s_CurrentTime;
        private static float s_PrevTime;

        private static float s_DeltaTime;
        private static float s_TimeScale = 1f;

        private static float s_LastFpsTime = Environment.TickCount;
        private static int s_FPS = 1;
        private static int s_Frames;

        public static float deltaTime
        {
            get { return s_DeltaTime / 1000f * s_TimeScale; }
        }
        public static float timeScale
        {
            get { return s_TimeScale; }
            set { s_TimeScale = value; }
        }

        public static int fps
        {
            get { return s_FPS; }
        }

        public static void Update()
        {
            s_PrevTime = s_CurrentTime;
            s_CurrentTime = Environment.TickCount;

            if (s_CurrentTime - s_LastFpsTime >= 1000)
            {
                s_FPS = s_Frames;
                s_Frames = 0;
                s_LastFpsTime = s_CurrentTime;
            }
            s_Frames++;

            s_DeltaTime = s_CurrentTime - s_PrevTime;
        }
    }
}
