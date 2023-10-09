using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using SRNotes.Input;
using SRNotes.Settings;
using SRNotes.Util;
using SRNotes.Commands;

namespace SRNotes
{
    public partial class MainView : Form
    {
        public enum ScrollDirection
        {
            Up = -1,
            Down = 1,
        }

        public SettingsManager Settings { get; private set; }
        private string[] AllText { get; set; }
        private string CurrentLineText { get; set; }

        private int VisibleLinesCount { get; set; }
        private int CaretPosition { get; set; } = 0;
        private int CaretLinePosition { get; set; } = 0;

        public MainView()
        {
            try
            {
                InitializeComponent();
                Initialize();
                LoadfileOnLoad();
                StartInputLoop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Initialize()
        {
            Settings = new SettingsManager();

            // Theme settings
            this.BackColor = Settings.BackgroundColour;
            this.ForeColor = Settings.ForegroundColour;

            MainTextBox.BackColor = Settings.BackgroundColour;
            MainTextBox.ForeColor = Settings.ForegroundColour;
            MainTextBox.BorderStyle = BorderStyle.None;

            MainMenuStrip.BackColor = Settings.MenuStripColour;
            MainMenuStrip.ForeColor = Settings.ForegroundColour;

            // Font
            MainTextBox.Font = new Font("Arial", Settings.FontSize);

            // Keyboard events
            KeyboardInput.OnScrollDownKeyPressed += OnScrollDown;
            KeyboardInput.OnScrollUpKeyPressed += OnScrollUp;

            VisibleLinesCount = GetVisibleLinesCount();
            Debug.WriteLine(VisibleLinesCount);
        }

        private int GetVisibleLinesCount()
        {
            var rect = new RECT();
            User32.SendMessage(MainTextBox.Handle, 0xB2, IntPtr.Zero, ref rect);
            return (int)Math.Floor((rect.Bottom - rect.Top) / (float)MainTextBox.Font.Height);
        }

        /// <summary>
        /// Load the last file from the file path as stored in settings.ini
        /// </summary>
        private void LoadfileOnLoad()
        {
            if (!Settings.OpenLastFileOnLoad)
                return;

            if (Settings.LastLoadedFilePath == null || Settings.LastLoadedFilePath == "")
                return;

            AllText = File.ReadAllLines(Settings.LastLoadedFilePath);
            SetText();
            MainTextBox.Select(0, 0);
        }

        private async void StartInputLoop()
        {
            KeyboardInput.RunInputLoop = true;
            KeyboardInput.InputLoop();
        }


        /// <summary>
        /// Populate the main textbox with all text lines loaded from the selected file
        /// </summary>
        private void SetText()
        {
            MainTextBox.Text = "";
            foreach (var line in AllText)
            {
                MainTextBox.Text += line;
                MainTextBox.Text += Environment.NewLine;
            }
        }

        /// <summary>
        /// Scroll the textbox down when the user defined ScrollDown key is pressed
        /// </summary>
        public async void OnScrollDown(object sender, EventArgs e)
        {
            if (AllText == null || AllText.Length <= 0 || CaretLinePosition == AllText.Length - 1)
                return;

            ScrollTextbox(MainTextBox.Handle, SettingsManager.ScrollSpeed);

            if (SettingsManager.SelectCurrentLine)
            {
                CaretPosition += AllText[CaretLinePosition - 1].Length + 1;
                MainTextBox.Select(CaretPosition, AllText[CaretLinePosition].Length);
            }

            CurrentLineText = AllText[CaretLinePosition];
            if (CurrentLineText.StartsWith("["))
                await CommandHandler.RunCommand(CurrentLineText);
        }

        /// <summary>
        /// Scroll the textbox up when the user defined ScrollUp key is pressed
        /// </summary>

        public async void OnScrollUp(object sender, EventArgs e)
        {
            if (AllText == null || AllText.Length <= 0 || CaretLinePosition <= 0)
                return;

            ScrollTextbox(MainTextBox.Handle, -SettingsManager.ScrollSpeed);

            if (SettingsManager.SelectCurrentLine)
            {
                CaretPosition -= AllText[CaretLinePosition].Length + 1;
                MainTextBox.Select(CaretPosition, AllText[CaretLinePosition].Length);
            }

            CurrentLineText = AllText[CaretLinePosition];
            if (CurrentLineText.StartsWith("["))
                await CommandHandler.RunCommand(CurrentLineText);
        }


        /// <summary>
        /// Scrol the scrollbar for the given UI handle using the winuser.h API 
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="scrollAmount"></param>
        private void ScrollTextbox(IntPtr handle, int scrollAmount)
        {
            IntPtr wParam = (IntPtr)User32.SB_LINEDOWN;
            IntPtr lParam = IntPtr.Zero;

            if (scrollAmount < 0)
                CaretLinePosition = Math.Max(0, CaretLinePosition + scrollAmount);
            else
                CaretLinePosition = Math.Min(CaretLinePosition + scrollAmount, AllText.Length);

            //If we have not yet reached the treshold for the line offset we return to wait with scrolling until the treshold was reached
            if (CaretLinePosition < SettingsManager.SelectedLineOffset)
                return;

            if (scrollAmount < 0)
            {
                wParam = (IntPtr)User32.SB_LINEUP;
                scrollAmount = -scrollAmount;
            }

            for (int i = 0; i < scrollAmount; i++)
                User32.SendMessage(handle, User32.WM_VSCROLL, wParam, lParam);
        }


        #region UIEvents
        /// <summary>
        /// Open a file dialog when the "Open" menu strip button is clicked and load its contents
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                RestoreDirectory = true,
                Multiselect = false,
                Filter = "Txt files (*.txt)|*.txt|All files (*.*)|*.*",
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                AllText = File.ReadAllLines(fileDialog.FileName);
                SetText();

                Settings.SaveToSettingsFile("LastLoadedFilePath:", fileDialog.FileName);
            }
        }

        /// <summary>
        /// Recalculate the visible lines count when resizing the window
        /// </summary>
        private void MainWindow_Resize(object sender, EventArgs e)
        {
            VisibleLinesCount = GetVisibleLinesCount();
            Debug.WriteLine(VisibleLinesCount);
        }

        /// <summary>
        /// Open the settings file for editing
        /// </summary>
        private void OpenSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(SettingsManager.SettingsFilePath))
            {
                Console.WriteLine($"Error: File {SettingsManager.SettingsFilePath} was not found!");
                return;
            }

            using (Process process = new Process())
            {
                process.StartInfo.FileName = "explorer";
                process.StartInfo.Arguments = $"{SettingsManager.SettingsFilePath}";
                process.Start();
            }
        }
        #endregion

    }
}
