using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using SRNotes.Settings;

namespace SRNotes.Input
{
    internal class KeyboardInput
    {
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        public static bool RunInputLoop = false;

        public static event EventHandler OnScrollDownKeyPressed;
        public static event EventHandler OnScrollUpKeyPressed;


        public async static Task InputLoop()
        {
            while (RunInputLoop)
            {
                if (GetAsyncKeyState(SettingsManager.ScrollUpKey) < 0)
                {
                    OnScrollUpKeyPressed.Invoke(null, null);
                    while (GetAsyncKeyState(SettingsManager.ScrollUpKey) < 0)
                        await Task.Delay(10);
                }

                if (GetAsyncKeyState(SettingsManager.ScrollDownKey) < 0)
                {
                    OnScrollDownKeyPressed.Invoke(null, null);

                    while (GetAsyncKeyState(SettingsManager.ScrollDownKey) < 0)
                        await Task.Delay(10);
                }

                await Task.Delay(10);
            }
        }

    }
}
