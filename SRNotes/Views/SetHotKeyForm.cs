using System.Windows.Forms;
using SRNotes.Settings;

namespace SRNotes.Views
{
    public partial class SetHotKeyForm : Form
    {
        public SetHotKeyForm(string header, string currentKey)
        {
            InitializeComponent();
            FuncToBindLabel.Text = header;
            PressedKeyPreview.Text = currentKey;
        }

        private void SaveKeybindButton_Click(object sender, System.EventArgs e)
        {
            if (FuncToBindLabel.Text.Contains("Up"))
                SettingsManager.SaveToSettingsFile("ScrollUpKey", PressedKeyPreview.Text);
            else if (FuncToBindLabel.Text.Contains("Down"))
                SettingsManager.SaveToSettingsFile("ScrollDownKey", PressedKeyPreview.Text);
            this.Close();
        }

        private void PressedKeyPreview_KeyDown(object sender, KeyEventArgs e)
        {
            PressedKeyPreview.Text = e.KeyCode.ToString();
        }

        private void SetHotKeyForm_Shown(object sender, System.EventArgs e)
        {
            PressedKeyPreview.Focus();
        }
    }
}
