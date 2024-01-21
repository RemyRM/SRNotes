using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SRNotes.Util
{
    public class User32
    {
        public const int WM_VSCROLL = 0x115;
        public const int SB_LINEUP = 0;
        public const int SB_LINEDOWN = 1;
        public const int SB_PAGEUP = 2;
        public const int SB_PAGEDOWN = 3;
        public const int SB_THUMBPOSITION = 4;
        public const int SB_THUMBTRACK = 5;
        public const int SB_TOP = 6;
        public const int SB_BOTTOM = 7;

        /// <summary>
        /// Send a (command) message to a window based on its handle.
        /// Currently this particular SendMessage is used to get the visible line count (0xB2)
        /// For an overview of messages see: https://wiki.winehq.org/List_Of_Windows_Messages
        /// </summary>
        /// <param name="hWnd">The handle for the window you want to send the message to</param>
        /// <param name="Msg">The message to send to the window (in this case 0xB2)</param>
        /// <param name="wParam">The first parameter (in this case intPtr.zero)</param>
        /// <param name="lParam">Second parameter, in this case the bounds of the textbox rectangle</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref RECT lParam);

        /// <summary>
        /// Send a (command) message to a window based on its handle.
        /// Currently this particular SendMessage is used to send the scroll events
        /// Use together with VM_SCROLL to scroll a window that does not have windows focus based on the window handle
        /// For an overview of messages see: https://wiki.winehq.org/List_Of_Windows_Messages
        /// </summary>
        /// <param name="hWnd">The handle for the window you want to send the message to</param>
        /// <param name="Msg">The message to send (e.g. VM_SCROLL)</param>
        /// <param name="wParam">The parameter to send alongside the message, e.g. scroll direction (SB_LINEDOWN, SB_LINEUP)</param>
        /// <param name="lParam">Second parameter, usually intPtr.zero</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Get the current state of the given key pressed
        /// </summary>
        /// <param name="vKey">The <see cref="Keys"/> code of the key to check</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(Keys vKey);
    }
}
