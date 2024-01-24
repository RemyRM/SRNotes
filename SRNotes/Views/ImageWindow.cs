using SRNotes.Settings;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SRNotes.Views
{
    public partial class ImageWindow : Form
    {
        public static ImageWindow Instance { get; private set; }

        public ImageWindow()
        {
            InitializeComponent();
            Instance = this;
            Location = new Point(SettingsManager.ImageWindowXPos, SettingsManager.ImageWindowYPos);
            TopMost = SettingsManager.ImageWindowAlwaysOnTop;
        }

        /// <summary>
        /// Update the currently shown image in the image window to the provided image
        /// </summary>
        /// <param name="bitmap">The new bitmap to display</param>
        /// <param name="width">The width of the display window</param>
        /// <param name="height">The height of the display window</param>
        public void SetImage(Bitmap bitmap, int width, int height)
        {
            Debug.WriteLine($"Args Width: {width}, Args Height:{Height}");
            this.Width = width;
            this.Height = height;

            ImageBox.Image = bitmap;
        }

        /// <summary>
        /// Event fired when the image window is closed
        /// </summary>
        private void ImageWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (SettingsManager.OverrideStoredPositionWindow)
            {
                SettingsManager.ImageWindowXPos = Location.X;
                SettingsManager.ImageWindowYPos = Location.Y;
                SettingsManager.SaveToSettingsFile("ImageWindowXPos", Location.X.ToString());
                SettingsManager.SaveToSettingsFile("ImageWindowYPos", Location.Y.ToString());
            }
            Instance = null;
        }
    }
}
