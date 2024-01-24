using System;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                await HandleKeyPress(SettingsManager.ScrollUpKey, OnScrollUpKeyPressed);
                await HandleKeyPress(SettingsManager.ScrollDownKey, OnScrollDownKeyPressed);
                await Task.Delay(10);
            }
        }

        /// <summary>
        /// Handle the actual key presses
        /// </summary>
        /// <param name="key">The key that was pressed</param>
        /// <param name="onKeyDownEvent">The event that needs to get invoked when the key is pressed</param>
        /// <returns></returns>
        private async static Task HandleKeyPress(Keys key, EventHandler onKeyDownEvent)
        {
            if (User32.GetAsyncKeyState(key) < 0)
            {
                onKeyDownEvent.Invoke(null, null);

                if (SettingsManager.ContinuousScrollingEnabled)
                {
                    await Task.Delay(10);
                }
                else
                {
                    //If continous scrolling is disabled we wait until the key is released before firing the event again
                    while (User32.GetAsyncKeyState(key) < 0)
                        await Task.Yield();
                }
            }
        }
    }
}
