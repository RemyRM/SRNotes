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
    public class SettingsManager
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
        public static int ImageWindowXPos;
        public static int ImageWindowYPos;


        public Color BackgroundColour;
        public Color ForegroundColour;
        public Color MenuStripColour;

        public float FontSize;

        public bool OpenLastFileOnLoad;
        public string LastLoadedFilePath;


        public SettingsManager()
        {
            BaseInitialization();
            LoadSettingsFile();
            PrintSettings();
        }

        /// <summary>
        /// Ensure every setting has a base value in case there is no settings file found
        /// </summary>
        private void BaseInitialization()
        {
            BackgroundColour = Color.FromArgb(0x1F, 0x1F, 0x1F);
            ForegroundColour = Color.FromArgb(0xCC, 0xCC, 0xCC);
            MenuStripColour = Color.FromArgb(0x18, 0x18, 0x18);

            FontSize = 11.0f;

            ScrollUpKey = Keys.I;
            ScrollDownKey = Keys.K;

            OpenLastFileOnLoad = false;
            ContinuousScrollingEnabled = true;
        }

        /// <summary>
        /// Load all the data in the settings file
        /// </summary>
        private void LoadSettingsFile()
        {
            if(!File.Exists(SettingsFilePath))
            {
                Console.WriteLine($"Error: File {SettingsFilePath} was not found!");
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
            }
        }

        /// <summary>
        /// Save a key's new value to the settings file
        /// </summary>
        /// <param name="key">The key to update, including colon ":"</param>
        /// <param name="value">The new value of the key</param>
        public static void SaveToSettingsFile(string key, string value)
        {
            if (!File.Exists(SettingsFilePath))
                return;

            string[] settingsData = File.ReadAllLines(SettingsFilePath);
            string fullKey = settingsData.FirstOrDefault(k => k.StartsWith(key));
            int keyIndex = settingsData.ToList().IndexOf(fullKey);
            settingsData[keyIndex] = $"{key}{value}";
            File.WriteAllLines(SettingsFilePath, settingsData);
        }

        private void PrintSettings()
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

        private void SetColourFromHex(ref Color colorToSet, string hex)
        {
            if (hex.StartsWith("#"))
                hex = hex.Replace("#", "");

            int result = Convert.ToInt32(hex, 16);
            byte r = (byte)((result & 0xFF0000) >> 16);
            byte g = (byte)((result & 0xFF00) >> 8);
            byte b = (byte)((result & 0xFF) >> 0);
            colorToSet = Color.FromArgb(r, g, b);
        }

        private void SetIntFromSettings(ref int valueToSet, string data)
        {
            if(int.TryParse(data, out int result))
                valueToSet = result;
            else
                valueToSet = 1;
        }

        private void SetFloatFromSettings(ref float floatToSet, string data)
        {
            if (float.TryParse(data, NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, out float value))
                floatToSet = value;
            else
                floatToSet = 11.0f;
        }

        private void SetKeyboardKeyFromSettings(ref Keys keysToSet, string data)
        {
            keysToSet = (Keys)Enum.Parse(typeof(Keys), data, false);
        }

        private void SetBoolFromSettings(ref bool boolToSet, string data)
        {
            if (int.TryParse(data, out int result))
                boolToSet = result == 1;
        }

        private void SetStringFromSettings(ref string stringToSet, string data)
        {
            stringToSet = data;
        }
    }
}

