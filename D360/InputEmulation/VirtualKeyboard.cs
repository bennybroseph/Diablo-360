using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

//TODO: This entire class could use a rework using lists
namespace D360.InputEmulation
{
    public static class VirtualKeyboard
    {
        static HashSet<Keys> downKeys;

        [DllImport("user32.dll")]
        private static extern uint keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        public static void KeyDown(Keys key)
        {
            if (downKeys == null)
            {
                downKeys = new HashSet<Keys>();
            }

            if (downKeys.Contains(key))
            {
                // key is already down
            }
            else
            {
                downKeys.Add(key);
                keybd_event((byte)key, 0, 0, 0);
            }
        }

        public static void KeyUp(Keys key)
        {
            if (downKeys == null)
                downKeys = new HashSet<Keys>();

            if (!downKeys.Contains(key))
                return;

            // key is down, send up signal
            keybd_event((byte)key, 0, 0x0002, 0);
            downKeys.Remove(key);
        }

        internal static void AllUp()
        {
            if (downKeys == null)
                return;

            var downKeysArray = new Keys[downKeys.Count];
            downKeys.CopyTo(downKeysArray);

            foreach (var key in downKeysArray)
            {
                KeyUp(key);
            }
        }
    }
}
