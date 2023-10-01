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
        public readonly static string SettingsFilePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\SRNotes\\Settings.ini";

        public static Keys ScrollUpKey;
        public static Keys ScrollDownKey;
        public static bool ContinuousScrollingEnabled;
        public static int ScrollSpeed;
        public static bool SelectCurrentLine;
        public static int SelectedLineOffset;

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

                //Application background colour
                if (setting.Contains("BackgroundColour:"))
                    SetColourFromHex(ref BackgroundColour, setting.Replace("BackgroundColour:", ""));

                //Application foreground colour
                if (setting.Contains("ForegroundColour:"))
                    SetColourFromHex(ref ForegroundColour, setting.Replace("ForegroundColour:", ""));

                //MenuStrip background colour
                if (setting.Contains("MenuStripColour:"))
                    SetColourFromHex(ref MenuStripColour, setting.Replace("MenuStripColour:", ""));

                //Text font size
                if (setting.Contains("FontSize:"))
                    SetFloatFromSettings(ref FontSize, setting.Replace("FontSize:", ""));

                //Scroll down key
                if (setting.Contains("ScrollUpKey:"))
                    SetKeyboardKeyFromSettings(ref ScrollUpKey, setting.Replace("ScrollUpKey:", ""));

                //Scroll up key
                if (setting.Contains("ScrollDownKey:"))
                    SetKeyboardKeyFromSettings(ref ScrollDownKey, setting.Replace("ScrollDownKey:", ""));

                if (setting.Contains("LoadLastFileOnOpen:"))
                    SetBoolFromSettings(ref OpenLastFileOnLoad, setting.Replace("LoadLastFileOnOpen:", ""));

                if (setting.Contains("LastLoadedFilePath:"))
                    SetStringFromSettings(ref LastLoadedFilePath, setting.Replace("LastLoadedFilePath:", ""));

                if (setting.Contains("ContinuousScrolling:"))
                    SetBoolFromSettings(ref ContinuousScrollingEnabled, setting.Replace("ContinuousScrolling:", ""));

                if (setting.Contains("ScrollSpeed:"))
                    SetIntFromSettings(ref ScrollSpeed, setting.Replace("ScrollSpeed:", ""));

                if (setting.Contains("SelectCurrentLine:"))
                    SetBoolFromSettings(ref SelectCurrentLine, setting.Replace("SelectCurrentLine:", ""));

                if (setting.Contains("SelectedLineOffset:"))
                    SetIntFromSettings(ref SelectedLineOffset, setting.Replace("SelectedLineOffset:", ""));
            }
        }

        /// <summary>
        /// Save a key's new value to the settings file
        /// </summary>
        /// <param name="key">The key to update, including :</param>
        /// <param name="value">The new value of the key</param>
        public void SaveToSettingsFile(string key, string value)
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

