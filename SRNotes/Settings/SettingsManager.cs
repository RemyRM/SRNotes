using System.IO;
using System.Drawing;
using System;
using System.Globalization;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;

using SRNotes.Extensions;

namespace SRNotes.Settings
{
    public static class SettingsManager
    {
#if DEBUG
        public readonly static string SettingsFilePath = $"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\\Resources\\Settings.ini";
#else
        public readonly static string SettingsFilePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\SRNotes\\Settings.ini";
#endif

        public static Keys ScrollUpKey;
        public static Keys ScrollDownKey;
        public static bool ContinuousScrollingEnabled;
        public static int ScrollSpeed;
        public static bool SelectCurrentLine;
        public static int SelectedLineOffset;
        public static bool OverrideStoredPositionWindow;
        public static bool ImageWindowAlwaysOnTop;
        public static int ImageWindowXPos;
        public static int ImageWindowYPos;

        public static Color BackgroundColour;
        public static Color ForegroundColour;
        public static Color MenuStripColour;

        public static float FontSize;

        public static bool OpenLastFileOnLoad;
        public static string LastLoadedFilePath;

        public static void InitializeSettingsManager()
        {
            BaseInitialization();
            LoadUserSettingsFile();
            PrintSettings();
        }

        /// <summary>
        /// Ensure every setting has a base value in case there is no settings file found
        /// </summary>
        private static void BaseInitialization()
        {
            BackgroundColour = Color.FromArgb(0x1F, 0x1F, 0x1F);
            ForegroundColour = Color.FromArgb(0xCC, 0xCC, 0xCC);
            MenuStripColour = Color.FromArgb(0x18, 0x18, 0x18);

            FontSize = 11.0f;

            ScrollUpKey = Keys.PageDown;
            ScrollDownKey = Keys.PageUp;

            OpenLastFileOnLoad = true;

            ContinuousScrollingEnabled = false;
            ScrollSpeed = 1;

            SelectCurrentLine = true;
            SelectedLineOffset = 10;

            OverrideStoredPositionWindow = true;
            ImageWindowAlwaysOnTop = true;
        }

        /// <summary>
        /// Load all the data in the settings file
        /// </summary>
        private static void LoadUserSettingsFile()
        {
            if (!File.Exists(SettingsFilePath))
            {
                MessageBox.Show($"Error, no settings file found at {SettingsFilePath}", "Settings not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"Error: File {SettingsFilePath} was not found!");
                return;
            }

            string[] settingsData = File.ReadAllLines(SettingsFilePath);

            foreach (string setting in settingsData)
            {
                //Comment
                if (setting.StartsWith("#"))
                    continue;

                if (setting.Contains("BackgroundColour:"))
                    SetColourFromHex(ref BackgroundColour, setting.Replace("BackgroundColour:", ""));

                else if (setting.Contains("ForegroundColour:"))
                    SetColourFromHex(ref ForegroundColour, setting.Replace("ForegroundColour:", ""));

                else if (setting.Contains("MenuStripColour:"))
                    SetColourFromHex(ref MenuStripColour, setting.Replace("MenuStripColour:", ""));

                else if (setting.Contains("FontSize:"))
                    SetFloatFromSettings(ref FontSize, setting.Replace("FontSize:", ""));

                else if (setting.Contains("ScrollUpKey:"))
                    SetKeyboardKeyFromSettings(ref ScrollUpKey, setting.Replace("ScrollUpKey:", ""));

                else if (setting.Contains("ScrollDownKey:"))
                    SetKeyboardKeyFromSettings(ref ScrollDownKey, setting.Replace("ScrollDownKey:", ""));

                else if (setting.Contains("LoadLastFileOnOpen:"))
                    SetBoolFromSettings(ref OpenLastFileOnLoad, setting.Replace("LoadLastFileOnOpen:", ""));

                else if (setting.Contains("LastLoadedFilePath:"))
                    SetStringFromSettings(ref LastLoadedFilePath, setting.Replace("LastLoadedFilePath:", ""));

                else if (setting.Contains("ContinuousScrolling:"))
                    SetBoolFromSettings(ref ContinuousScrollingEnabled, setting.Replace("ContinuousScrolling:", ""));

                else if (setting.Contains("ScrollSpeed:"))
                    SetIntFromSettings(ref ScrollSpeed, setting.Replace("ScrollSpeed:", ""));

                else if (setting.Contains("SelectCurrentLine:"))
                    SetBoolFromSettings(ref SelectCurrentLine, setting.Replace("SelectCurrentLine:", ""));

                else if (setting.Contains("SelectedLineOffset:"))
                    SetIntFromSettings(ref SelectedLineOffset, setting.Replace("SelectedLineOffset:", ""));

                else if (setting.Contains("OverrideStoredPositionWindow:"))
                    SetBoolFromSettings(ref OverrideStoredPositionWindow, setting.Replace("OverrideStoredPositionWindow:", ""));

                else if (setting.Contains("ImageWindowXPos:"))
                    SetIntFromSettings(ref ImageWindowXPos, setting.Replace("ImageWindowXPos:", ""));

                else if (setting.Contains("ImageWindowYPos:"))
                    SetIntFromSettings(ref ImageWindowYPos, setting.Replace("ImageWindowYPos:", ""));

                else if (setting.Contains("ImageWindowAlwaysOnTop:"))
                    SetBoolFromSettings(ref ImageWindowAlwaysOnTop, setting.Replace("ImageWindowAlwaysOnTop:", ""));
            }
        }

        /// <summary>
        /// Save a key's new value to the settings file
        /// </summary>
        /// <param name="key">The key to update, exluding colon ":"</param>
        /// <param name="value">The new value of the key</param>
        public static void SaveToSettingsFile(string key, string value)
        {
            if (!File.Exists(SettingsFilePath))
                return;


            string[] settingsData = File.ReadAllLines(SettingsFilePath);
            string fullKey = settingsData.FirstOrDefault(k => k.StartsWith(key));
            int keyIndex = settingsData.ToList().IndexOf(fullKey);
            settingsData[keyIndex] = $"{key}:{value}";
            File.WriteAllLines(SettingsFilePath, settingsData);
        }

        private static void PrintSettings()
        {
            Debug.WriteLine($"Loaded settings:\n" +
                            $"BackgroundColour: {BackgroundColour.ToHexCode()} " +
                            $"ForegroundColour: {ForegroundColour.ToHexCode()} " +
                            $"MenuStirpColour: {MenuStripColour.ToHexCode()} " +
                            $"FontSize: {FontSize} " +
                            $"ScrollUpKey: {ScrollUpKey} " +
                            $"ScrollDownKey: {ScrollDownKey} " +
                            $"LoadLastFileOnOpen: {OpenLastFileOnLoad} ");
        }

        /// <summary>
        /// Take a hex colour string and convert it to a <see cref="Color"/>
        /// </summary>
        /// <param name="colorToSet">Reference colour that gets populated with the converted string</param>
        /// <param name="hex">The hex colour string to parse</param>
        private static void SetColourFromHex(ref Color colorToSet, string hex)
        {
            if (hex.StartsWith("#"))
                hex = hex.Replace("#", "");

            if (int.TryParse(hex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int result))
            {
                byte r = (byte)((result & 0xFF0000) >> 16);
                byte g = (byte)((result & 0xFF00) >> 8);
                byte b = (byte)((result & 0xFF) >> 0);
                colorToSet = Color.FromArgb(r, g, b);
            }
            else
            {
                MessageBox.Show($"Invalid value \"{hex}\" found. expected hex colour string in format #FFFFFF.\nValue was set to red (#FF0000)", "Invalid integer in settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                colorToSet = Color.Red;

            }
        }

        public static void SetColourFromColourPicker(ref Color colorToSet)
        {
            ColorDialog colourPicker = new ColorDialog();

            if(colourPicker.ShowDialog() == DialogResult.OK)
                colorToSet = colourPicker.Color;
        }

        /// <summary>
        /// Get an integer value from the settings file and convert it to an actual integer
        /// </summary>
        /// <param name="valueToSet">The integer to populate</param>
        /// <param name="data">The data as found in the settings file</param>
        private static void SetIntFromSettings(ref int valueToSet, string data)
        {
            if (int.TryParse(data, out int result))
                valueToSet = result;
            else
            {
                MessageBox.Show($"Invalid value \"{data}\" found. expected value type: integer. Value was set to 1.", "Invalid integer in settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                valueToSet = 1;
            }
        }

        /// <summary>
        /// Get a flaot value from the settings file and convert it to an actual float
        /// </summary>
        /// <param name="floatToSet">The float to populate</param>
        /// <param name="data">The data as found in the settings file</param>
        private static void SetFloatFromSettings(ref float floatToSet, string data)
        {
            if (float.TryParse(data, NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, out float value))
                floatToSet = value;
            else
            {
                MessageBox.Show($"Invalid value \"{data}\" found. expected value type: Float. Value was set to 1,0.", "Invalid float in settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                floatToSet = 1.0f;
            }
        }

        /// <summary>
        /// Get an enum value from the settings file and tries to convert it to a valid <see cref="Keys"/>
        /// </summary>
        /// <param name="keyToSet">The Key value to set</param>
        /// <param name="data">The data as found in the settings file</param>
        private static void SetKeyboardKeyFromSettings(ref Keys keyToSet, string data)
        {
            if (Enum.TryParse(data, out Keys result))
            {
                keyToSet = result;
            }
            else
            {
                MessageBox.Show($"Invalid value \"{data}\" found for keybind. See Settings.ini comments for valid values.\nKeybind was set to None.", "Invalid key in settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                keyToSet = Keys.None;
            }
        }

        /// <summary>
        /// Get a boolean value (0 for false, 1 for true) from the setting files and convert it to a boolean
        /// </summary>
        /// <param name="boolToSet">The boolean value to set</param>
        /// <param name="data">The data as found in settings file</param>
        private static void SetBoolFromSettings(ref bool boolToSet, string data)
        {
            if (int.TryParse(data, out int result))
                boolToSet = result == 1;
            else
            {
                MessageBox.Show($"Invalid value \"{data}\" found. expected value 0 for false, or 1 for true. Value was set to 0 (false).", "Invalid boolean in settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                boolToSet = false;
            }
        }

        /// <summary>
        /// Get a string value from the settings file and store it in a string variable
        /// </summary>
        /// <param name="stringToSet">The string value to set</param>
        /// <param name="data">The data as found in the settings file</param>
        private static void SetStringFromSettings(ref string stringToSet, string data)
        {
            stringToSet = data;
        }
    }
}

