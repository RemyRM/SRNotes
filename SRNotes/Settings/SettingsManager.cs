using System.IO;
using System.Drawing;
using System.Reflection;
using System;
using System.Globalization;
using System.Windows.Forms;
using System.Diagnostics;
using SRNotes.Extensions;

namespace SRNotes.Settings
{
    public class SettingsManager
    {
        private readonly string SettingsFilePath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Resources\\Settings.ini";

        public Color BackgroundColour;
        public Color ForegroundColour;
        public Color MenuStripColour;

        public float FontSize;

        public static Keys ScrollUpKey;
        public static Keys ScrollDownKey;

        public static bool SelectCurrentTextLine;


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
            ForegroundColour = Color.FromArgb(0x18, 0x18, 0x18);

            FontSize = 11.0f;

            ScrollUpKey = Keys.I;
            ScrollDownKey = Keys.K;

        }

        private void LoadSettingsFile()
        {
            string[] settingsData = File.ReadAllLines(SettingsFilePath);

            foreach (string setting in settingsData)
            {
                //Comment
                if (setting.StartsWith("#"))
                    continue;

                //Application background colour
                if (setting.Contains("BackgroundColour:"))
                    SetColorFromHex(ref BackgroundColour, setting.Replace("BackgroundColour:#", ""));

                //Application foreground colour
                if (setting.Contains("ForegroundColour:"))
                    SetColorFromHex(ref ForegroundColour, setting.Replace("ForegroundColour:#", ""));

                //MenuStrip background colour
                if (setting.Contains("MenuStripColour:"))
                    SetColorFromHex(ref MenuStripColour, setting.Replace("MenuStripColour:#", ""));

                //Text font size
                if (setting.Contains("FontSize:"))
                    SetFloatFromSettings(ref FontSize, setting.Replace("FontSize:", ""));

                //Scroll down key
                if (setting.Contains("ScrollUpKey:"))
                    SetKeyboardKeyFromSettings(ref ScrollUpKey, setting.Replace("ScrollUpKey:", ""));
                //Scroll up key
                if (setting.Contains("ScrollDownKey:"))
                    SetKeyboardKeyFromSettings(ref ScrollDownKey, setting.Replace("ScrollDownKey:", ""));
            }
        }

        private void PrintSettings()
        {
            Debug.WriteLine($"Loaded settings:\n" +
                            $"BackgroundColour: {BackgroundColour.ToHexCode()} " +
                            $"ForegroundColour: {ForegroundColour.ToHexCode()} " +
                            $"MenuStirpColour: {MenuStripColour.ToHexCode()} " +
                            $"FontSize: {FontSize} " +
                            $"ScrollUpKey: {ScrollUpKey} " +
                            $"ScrollDownKey: {ScrollDownKey} ");
        }

        private void SetColorFromHex(ref Color colorToSet, string hex)
        {
            int result = Convert.ToInt32(hex, 16);
            byte r = (byte)((result & 0xFF0000) >> 16);
            byte g = (byte)((result & 0xFF00) >> 8);
            byte b = (byte)((result & 0xFF) >> 0);
            colorToSet = Color.FromArgb(r, g, b);
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
    }
}

