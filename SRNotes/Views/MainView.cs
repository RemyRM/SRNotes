using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using SRNotes.Input;
using SRNotes.Settings;
using SRNotes.Util;
using SRNotes.Commands;
using System.Threading.Tasks;
using SRNotes.Extensions;
using SRNotes.Views;

namespace SRNotes
{
    public partial class MainView : Form
    {
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

        /// <summary>
        /// Initialize and setup the application and load the necessary settings for:
        /// - GUI
        /// - Event Handlers
        /// </summary>
        private void Initialize()
        {
            SettingsManager.InitializeSettingsManager();

            // Theme settings
            this.BackColor = SettingsManager.BackgroundColour;
            this.ForeColor = SettingsManager.ForegroundColour;

            MainTextBox.BackColor = SettingsManager.BackgroundColour;
            MainTextBox.ForeColor = SettingsManager.ForegroundColour;
            MainTextBox.BorderStyle = BorderStyle.None;

            //Menu strip
            MainAppMenuStrip.BackColor = SettingsManager.MenuStripColour;
            MainAppMenuStrip.ForeColor = SettingsManager.ForegroundColour;

            ((ToolStripMenuItem)ContinuousScrollingToolStripMenuItem.DropDownItems[0]).Checked = !SettingsManager.ContinuousScrollingEnabled;
            ((ToolStripMenuItem)ContinuousScrollingToolStripMenuItem.DropDownItems[1]).Checked = SettingsManager.ContinuousScrollingEnabled;

            FontSizeInputtoolStripTextBox.Text = SettingsManager.FontSize.ToString();

            ((ToolStripMenuItem)SelectCurrentLineToolStripMenuItem.DropDownItems[0]).Checked = !SettingsManager.SelectCurrentLine;
            ((ToolStripMenuItem)SelectCurrentLineToolStripMenuItem.DropDownItems[1]).Checked = SettingsManager.SelectCurrentLine;

            ScrollSpeedToolStripTextBox.Text = SettingsManager.ScrollSpeed.ToString();
            SelectedLineOffsetToolStripTextBox.Text = SettingsManager.SelectedLineOffset.ToString();

            ((ToolStripMenuItem)LoadLastFileOnOpenToolStripMenuItem.DropDownItems[0]).Checked = !SettingsManager.OpenLastFileOnLoad;
            ((ToolStripMenuItem)LoadLastFileOnOpenToolStripMenuItem.DropDownItems[1]).Checked = SettingsManager.OpenLastFileOnLoad;

            ((ToolStripMenuItem)StoreImageWindowPositionToolStripMenuItem.DropDownItems[0]).Checked = !SettingsManager.OverrideStoredPositionWindow;
            ((ToolStripMenuItem)StoreImageWindowPositionToolStripMenuItem.DropDownItems[1]).Checked = SettingsManager.OverrideStoredPositionWindow;
            SettingsManager.SaveToSettingsFile("LoadLastFileOnOpen", "1");

            ((ToolStripMenuItem)ImageWindowAlwaysOnTopToolStripMenuItem.DropDownItems[0]).Checked = !SettingsManager.ImageWindowAlwaysOnTop;
            ((ToolStripMenuItem)ImageWindowAlwaysOnTopToolStripMenuItem.DropDownItems[1]).Checked = SettingsManager.ImageWindowAlwaysOnTop;

            // Font
            MainTextBox.Font = new Font("Arial", SettingsManager.FontSize);
            FontSizeInputtoolStripTextBox.Text = SettingsManager.FontSize.ToString();

            // Keyboard events
            KeyboardInput.OnScrollDownKeyPressed += OnScrollDown;
            KeyboardInput.OnScrollUpKeyPressed += OnScrollUp;

            VisibleLinesCount = GetVisibleLinesCount();
            Debug.WriteLine(VisibleLinesCount);
        }

        /// <summary>
        /// Get the amount of text lines that are currently visible inside the textbox
        /// </summary>
        /// <returns>The amount of visible lines</returns>
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
            if (!SettingsManager.OpenLastFileOnLoad)
                return;

            if (SettingsManager.LastLoadedFilePath == null || SettingsManager.LastLoadedFilePath == "")
                return;

            if (!File.Exists(SettingsManager.LastLoadedFilePath))
                return;

            AllText = File.ReadAllLines(SettingsManager.LastLoadedFilePath);
            SetText();
            MainTextBox.Select(0, 0);
        }

        /// <summary>
        /// Start the input loop for the keyboard listener
        /// </summary>
        private async void StartInputLoop()
        {
            KeyboardInput.RunInputLoop = true;
            await KeyboardInput.InputLoop();
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

            ScrollTextbox(MainTextBox.Handle, SettingsManager.ScrollSpeed);

            if (SettingsManager.SelectCurrentLine)
            {
                CaretPosition += AllText[CaretLinePosition - 1].Length + 1;
                MainTextBox.Select(CaretPosition, AllText[CaretLinePosition].Length);
            }

            CheckCurrentLineForCommand();
        }

        /// <summary>
        /// Scroll the textbox up when the user defined ScrollUp key is pressed
        /// </summary>
        public void OnScrollUp(object sender, EventArgs e)
        {
            if (AllText == null || AllText.Length <= 0 || CaretLinePosition <= 0)
                return;

            ScrollTextbox(MainTextBox.Handle, -SettingsManager.ScrollSpeed);

            if (SettingsManager.SelectCurrentLine)
            {
                CaretPosition -= AllText[CaretLinePosition].Length + 1;
                MainTextBox.Select(CaretPosition, AllText[CaretLinePosition].Length);
            }

            CheckCurrentLineForCommand();
        }

        /// <summary>
        /// Evaluates the current selected line. If it starts with a "[" to indicate it could be a command, run it.
        /// </summary>
        private async void CheckCurrentLineForCommand()
        {
            CurrentLineText = AllText[CaretLinePosition];
            if (CurrentLineText.StartsWith("["))
                await CommandHandler.RunCommand(CurrentLineText);
        }

        /// <summary>
        /// Scroll the scrollbar for the given UI handle using the winuser.h API 
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


        /// <summary>
        /// Validate if the input for the given ToolStripTextBox is numerical and not empty
        /// If it is numerical update the given keyname in the settings file with the new value
        /// </summary>
        /// <param name="input">A reference to the <see cref="ToolStripTextBox"/> to update</param>
        /// <param name="keyNameToUpdate">The name of the key to update in the settings file</param>
        private void ValidateToolStripTextBoxNumericalInput(ref ToolStripTextBox input, string keyNameToUpdate)
        {
            if (input.Text == "")
                return;

            //Remove , and .
            if (input.Text.Contains(".") || input.Text.Contains(","))
                input.Text = input.Text.Substring(0, input.Text.Length - 1);

            if (int.TryParse(input.Text, out int value))
                SettingsManager.SaveToSettingsFile(keyNameToUpdate, value.ToString());
            else
                input.Text = SettingsManager.FontSize.ToString();
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

                SettingsManager.SaveToSettingsFile("LastLoadedFilePath", fileDialog.FileName);
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

        private void BackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsManager.SetColourFromColourPicker(ref SettingsManager.BackgroundColour);
            SettingsManager.SaveToSettingsFile("BackgroundColour", SettingsManager.BackgroundColour.ToHexCode());
        }

        private void ForegroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsManager.SetColourFromColourPicker(ref SettingsManager.ForegroundColour);
            SettingsManager.SaveToSettingsFile("ForegroundColour", SettingsManager.ForegroundColour.ToHexCode());
        }


        private void MenustripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsManager.SetColourFromColourPicker(ref SettingsManager.MenuStripColour);
            SettingsManager.SaveToSettingsFile("MenuStripColour", SettingsManager.ForegroundColour.ToHexCode());
        }

        private void FontSizeInputtoolStripTextBox_TextChanged(object sender, EventArgs e) =>
            ValidateToolStripTextBoxNumericalInput(ref FontSizeInputtoolStripTextBox, "FontSize");

        private void ScrollUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetHotKeyForm setHotKeyForm = new SetHotKeyForm("Scroll Up", SettingsManager.ScrollUpKey.ToString());
            setHotKeyForm.Show();
        }

        private void ScrollDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetHotKeyForm setHotKeyForm = new SetHotKeyForm("Scroll Down", SettingsManager.ScrollDownKey.ToString());
            setHotKeyForm.Show();
        }

        private void ContinuousFalseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)ContinuousScrollingToolStripMenuItem.DropDownItems[0]).Checked = true;
            ((ToolStripMenuItem)ContinuousScrollingToolStripMenuItem.DropDownItems[1]).Checked = false;
            SettingsManager.SaveToSettingsFile("ContinuousScrolling", "0");
        }

        private void ContinuousTrueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)ContinuousScrollingToolStripMenuItem.DropDownItems[0]).Checked = false;
            ((ToolStripMenuItem)ContinuousScrollingToolStripMenuItem.DropDownItems[1]).Checked = true;
            SettingsManager.SaveToSettingsFile("ContinuousScrolling", "1");
        }

        private void ScrollSpeedToolStripTextBox1_TextChanged(object sender, EventArgs e) =>
            ValidateToolStripTextBoxNumericalInput(ref ScrollSpeedToolStripTextBox, "ScrollSpeed");

        private void SelectLineFalseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)SelectCurrentLineToolStripMenuItem.DropDownItems[0]).Checked = true;
            ((ToolStripMenuItem)SelectCurrentLineToolStripMenuItem.DropDownItems[1]).Checked = false;
            SettingsManager.SaveToSettingsFile("SelectCurrentLine", "0");
        }

        private void SelectLineTrueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)SelectCurrentLineToolStripMenuItem.DropDownItems[0]).Checked = false;
            ((ToolStripMenuItem)SelectCurrentLineToolStripMenuItem.DropDownItems[1]).Checked = true;
            SettingsManager.SaveToSettingsFile("SelectCurrentLine", "1");
        }

        private void SelectedLineOffsetToolStripTextBox_TextChanged(object sender, EventArgs e) =>
            ValidateToolStripTextBoxNumericalInput(ref SelectedLineOffsetToolStripTextBox, "SelectedLineOffset");


        private void LoadLastFileFalseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)LoadLastFileOnOpenToolStripMenuItem.DropDownItems[0]).Checked = true;
            ((ToolStripMenuItem)LoadLastFileOnOpenToolStripMenuItem.DropDownItems[1]).Checked = false;
            SettingsManager.SaveToSettingsFile("LoadLastFileOnOpen", "0");
        }

        private void LoadLastFileTrueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)LoadLastFileOnOpenToolStripMenuItem.DropDownItems[0]).Checked = false;
            ((ToolStripMenuItem)LoadLastFileOnOpenToolStripMenuItem.DropDownItems[1]).Checked = true;
            SettingsManager.SaveToSettingsFile("LoadLastFileOnOpen", "1");
        }

        private void StoreImageWinPosFalseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)StoreImageWindowPositionToolStripMenuItem.DropDownItems[0]).Checked = true;
            ((ToolStripMenuItem)StoreImageWindowPositionToolStripMenuItem.DropDownItems[1]).Checked = false;
            SettingsManager.SaveToSettingsFile("OverrideStoredPositionWindow", "0");
        }

        private void StoreImageWinPosTrueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)StoreImageWindowPositionToolStripMenuItem.DropDownItems[0]).Checked = false;
            ((ToolStripMenuItem)StoreImageWindowPositionToolStripMenuItem.DropDownItems[1]).Checked = true;
            SettingsManager.SaveToSettingsFile("OverrideStoredPositionWindow", "1");
        }

        private void ImageWindowOnTopFalseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)ImageWindowAlwaysOnTopToolStripMenuItem.DropDownItems[0]).Checked = true;
            ((ToolStripMenuItem)ImageWindowAlwaysOnTopToolStripMenuItem.DropDownItems[1]).Checked = false;
            SettingsManager.SaveToSettingsFile("ImageWindowAlwaysOnTop", "0");
        }

        private void ImageWindowOnTopTrueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)ImageWindowAlwaysOnTopToolStripMenuItem.DropDownItems[0]).Checked = false;
            ((ToolStripMenuItem)ImageWindowAlwaysOnTopToolStripMenuItem.DropDownItems[1]).Checked = true;
            SettingsManager.SaveToSettingsFile("ImageWindowAlwaysOnTop", "1");
        }
        #endregion


    }
}
