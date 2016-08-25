using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

//TODO: This entire class could use a rework using lists
namespace D360.InputEmulation
{
    public static class VirtualKeyboard
    {
        private static List<Keys> s_DownKeys;

        [DllImport("user32.dll")]
        private static extern uint keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        public static void KeyDown(Keys key)
        {
            if (s_DownKeys == null)
                s_DownKeys = new List<Keys>();

            if (s_DownKeys.Contains(key))
                return;

            s_DownKeys.Add(key);
            keybd_event((byte)key, 0, 0, 0);
        }

        public static void KeyUp(Keys key)
        {
            if (s_DownKeys == null)
                s_DownKeys = new List<Keys>();

            if (!s_DownKeys.Contains(key))
                return;

            // key is down, send up signal
            keybd_event((byte)key, 0, 0x0002, 0);
            s_DownKeys.Remove(key);
        }

        internal static void AllUp()
        {
            if (s_DownKeys == null)
                return;

            var downKeysArray = new Keys[s_DownKeys.Count];
            s_DownKeys.CopyTo(downKeysArray);

            foreach (var key in downKeysArray)
            {
                KeyUp(key);
            }
        }
    }
}
