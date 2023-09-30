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

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref RECT lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(Keys vKey);
    }
}
