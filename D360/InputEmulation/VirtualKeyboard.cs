using System.Collections.Generic;
using System.Windows.Forms;
using AutoHotkey.Interop;           // The AutoHotkey Wrapper for C#

namespace D360.InputEmulation
{
    /// <summary>
    /// Class which takes in 'System.Windows.Forms.Keys' values and sends an appropriate
    /// script to be executed by AutoHotkey in an attempt to provide keyboard emulation
    /// </summary>
    public static class VirtualKeyboard
    {
        /// A container for all the currently pressed keys
        private static readonly List<Keys> s_DownKeys = new List<Keys>();

        /// An instance of the AutoHotkey Engine
        private static readonly AutoHotkeyEngine s_AutoHotkey = new AutoHotkeyEngine();

        /// <summary>
        /// Sends AutoHotkey a script which executes a press down of a given key.<para/>
        /// Don't forget to release the key or it will be held down until the program stops
        /// </summary>
        /// <param name="keys">The keys to be pressed down</param>
        public static void KeyDown(Keys keys)
        {
            // Don't press the key down again if it already is
            if (s_DownKeys.Contains(keys))
                return;

            // Save as a currently pressed key
            s_DownKeys.Add(keys);

            // Convert the keys into a string and send it to AutoHotkey
            foreach (var key in keys.ParseToStrings())
                s_AutoHotkey.ExecRaw("Send {" + key + " down}");
        }

        /// <summary>
        /// Sends AutoHotkey a script which executes the release of a given key
        /// </summary>
        /// <param name="keys">The keys to be released</param>
        public static void KeyUp(Keys keys)
        {
            // Don't release a key that isn't currently pressed
            if (!s_DownKeys.Contains(keys))
                return;

            // Convert the keys into a string and send it to AutoHotkey
            foreach (var key in keys.ParseToStrings())
                s_AutoHotkey.ExecRaw("Send {" + key + " up}");

            // Remove the key as a currently pressed keys and allow the keys to be pressed again
            s_DownKeys.Remove(keys);
        }

        /// <summary>
        /// Releases all currently pressed keys
        /// </summary>
        public static void ReleaseAll()
        {
            // Release all keys stored as currently pressed
            foreach (var key in s_DownKeys)
                KeyUp(key);

            // Removes all keys as currently pressed so they are all allowed to be pressed again
            s_DownKeys.Clear();
        }

        /// <summary>
        /// Executes a given AutoHotkey script
        /// </summary>
        /// <param name="script">AutoHotkey script to be executed</param>
        public static void ExecuteScript(string script)
        {
            s_AutoHotkey.ExecRaw(script);
        }
    }

    public static class KeysExtension
    {
        /// An Instance of a key converter for 'System.Windows.Forms.Keys'
        private static readonly KeysConverter s_KeysConverter = new KeysConverter();

        public static IEnumerable<Keys> ParseFlags(this Keys keys)
        {
            if ((keys & Keys.Control) == Keys.Control)
                yield return Keys.Control;

            if ((keys & Keys.Shift) == Keys.Shift)
                yield return Keys.Shift;

            if ((keys & Keys.Alt) == Keys.Alt)
                yield return Keys.Alt;

            keys &= ~Keys.Shift & ~Keys.Control & ~Keys.Alt;

            yield return keys;
        }

        public static IEnumerable<string> ParseToStrings(this Keys keys)
        {
            foreach (var key in keys.ParseFlags())
            {
                switch (key)
                {
                case Keys.Shift:
                case Keys.Control:
                case Keys.Alt:
                    yield return key.ToString();
                    break;

                default:
                    yield return s_KeysConverter.ConvertToString(key);
                    break;
                }
            }
        }
    }
}
