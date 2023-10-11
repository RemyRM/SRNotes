using System;
using System.Threading.Tasks;

using SRNotes.Settings;
using SRNotes.Util;

namespace SRNotes.Input
{
    internal class KeyboardInput
    {
        public static bool RunInputLoop = false;

        public static event EventHandler OnScrollDownKeyPressed;
        public static event EventHandler OnScrollUpKeyPressed;

        /// <summary>
        /// Check if either the <see cref="OnScrollDownKeyPressed"/> or <see cref="OnScrollUpKeyPressed"/> keys are pressed.
        /// If true raise the respective event for the keypress
        /// </summary>
        public async static Task InputLoop()
        {
            while (RunInputLoop)
            {
                if (User32.GetAsyncKeyState(SettingsManager.ScrollUpKey) < 0)
                {
                    OnScrollUpKeyPressed.Invoke(null, null);

                    if (SettingsManager.ContinuousScrollingEnabled)
                        await Task.Delay(10);
                    else
                        //If continous scrolling is disabled we wait until the key is released before firing the event again
                        while (User32.GetAsyncKeyState(SettingsManager.ScrollUpKey) < 0)
                            await Task.Delay(10);
                }

                if (User32.GetAsyncKeyState(SettingsManager.ScrollDownKey) < 0)
                {
                    OnScrollDownKeyPressed.Invoke(null, null);

                    if (SettingsManager.ContinuousScrollingEnabled)
                        await Task.Delay(10);
                    else
                        //If continous scrolling is disabled we wait until the key is released before firing the event again
                        while (User32.GetAsyncKeyState(SettingsManager.ScrollDownKey) < 0)
                            await Task.Delay(10);
                }

                await Task.Delay(10);
            }
        }
    }
}
