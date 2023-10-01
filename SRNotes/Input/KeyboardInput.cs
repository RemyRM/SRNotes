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


        public async static Task InputLoop()
        {
            while (RunInputLoop)
            {
                if (User32.GetAsyncKeyState(SettingsManager.ScrollUpKey) < 0)
                {
                    OnScrollUpKeyPressed.Invoke(null, null);

                    if (SettingsManager.ContinuousScrollingEnabled)
                    {
                        await Task.Delay(10);
                    }
                    else
                    {
                        while (User32.GetAsyncKeyState(SettingsManager.ScrollUpKey) < 0)
                        {
                            await Task.Delay(10);
                        }
                    }
                }

                if (User32.GetAsyncKeyState(SettingsManager.ScrollDownKey) < 0)
                {
                    OnScrollDownKeyPressed.Invoke(null, null);

                    if (SettingsManager.ContinuousScrollingEnabled)
                    {
                        await Task.Delay(10);
                    }
                    else
                    {
                        while (User32.GetAsyncKeyState(SettingsManager.ScrollDownKey) < 0)
                        {
                            await Task.Delay(10);
                        }
                    }
                }

                await Task.Delay(10);
            }
        }
    }
}
