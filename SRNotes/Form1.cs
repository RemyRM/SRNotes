using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SRNotes.Input;
using SRNotes.Settings;

namespace SRNotes
{
    public partial class MainWindow : Form
    {
        public SettingsManager Settings { get; private set; }
        private string[] AllText { get; set; }
        private int CaretPosition { get; set; } = 0;
        private int CaretLinePosition { get; set; } = 0;

        public MainWindow()
        {
            InitializeComponent();
            Initialize();
            StartInputLoop();
        }

        private void Initialize()
        {
            Settings = new SettingsManager();

            // Colours
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
        }

        private async void StartInputLoop()
        {
            KeyboardInput.RunInputLoop = true;
            KeyboardInput.InputLoop();
        }

        private void SetText()
        {
            MainTextBox.Text = "";
            foreach (var line in AllText)
            {
                MainTextBox.Text += line;
                MainTextBox.Text += Environment.NewLine;
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
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
            }
        }

        public void OnScrollDown(object sender, EventArgs e)
        {
            if (AllText == null || AllText.Length <= 0 || CaretLinePosition == AllText.Length - 1)
                return;
            Debug.WriteLine("scrolling down");
            Debug.WriteLine($"Caret position: {CaretPosition}");
            Debug.WriteLine($"Adding length: {AllText[CaretLinePosition].Length + 2}");
            CaretPosition += AllText[CaretLinePosition].Length + 2; ;
            CaretLinePosition++;


            //CaretPosition += 200;
            MainTextBox.Select(CaretPosition, 0);
            MainTextBox.ScrollToCaret();

        }

        public void OnScrollUp(object sender, EventArgs e)
        {
            if (AllText == null || AllText.Length <= 0 || CaretLinePosition == 0)
                return;

            Debug.WriteLine("scrolling up");
            CaretPosition -= AllText[CaretLinePosition].Length + 2; ;
            CaretLinePosition--;
            //CaretPosition -= Math.Min(CaretPosition, 200);

            MainTextBox.Select(CaretPosition, 0);
            MainTextBox.ScrollToCaret();
        }
    }
}
