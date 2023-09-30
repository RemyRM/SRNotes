using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using SRNotes.Input;
using SRNotes.Settings;
using SRNotes.Util;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SRNotes
{
    public partial class MainWindow : Form
    {
        public enum ScrollDirection
        {
            Up = -1,
            Down = 1,
        }

        public SettingsManager Settings { get; private set; }
        private string[] AllText { get; set; }

        private int VisibleLinesCount { get; set; }
        private int CaretPosition { get; set; } = 0;
        private int CaretLinePosition { get; set; } = 0;

        public MainWindow()
        {
            InitializeComponent();
            Initialize();
            LoadfileOnLoad();
            StartInputLoop();
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
        public void OnScrollDown(object sender, EventArgs e)
        {
            if (AllText == null || AllText.Length <= 0 || CaretLinePosition == AllText.Length - 1)
                return;

            Debug.WriteLine("scrolling down");

            ScrollTextbox(MainTextBox.Handle, SettingsManager.ScrollSpeed);

            if (SettingsManager.SelectCurrentLine)
            {
                CaretPosition += AllText[CaretLinePosition - 1].Length + 1;
                MainTextBox.Select(CaretPosition, AllText[CaretLinePosition - 1].Length);
            }
        }

        /// <summary>
        /// Scroll the textbox up when the user defined ScrollUp key is pressed
        /// </summary>

        public void OnScrollUp(object sender, EventArgs e)
        {
            if (AllText == null || AllText.Length <= 0)
                return;

            Debug.WriteLine("scrolling up");

            ScrollTextbox(MainTextBox.Handle, -SettingsManager.ScrollSpeed);

            if (SettingsManager.SelectCurrentLine)
            {
                CaretPosition -= AllText[CaretLinePosition - 1].Length + 1;
                MainTextBox.Select(CaretPosition, AllText[CaretLinePosition - 1].Length);
            }
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

            if (scrollAmount < 0)
            {
                wParam = (IntPtr)User32.SB_LINEUP;
                scrollAmount = -scrollAmount;
            }

            for (int i = 0; i < scrollAmount; i++)
                User32.SendMessage(handle, User32.WM_VSCROLL, wParam, lParam);

            Debug.WriteLine(CaretLinePosition);
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
        #endregion
    }
}
