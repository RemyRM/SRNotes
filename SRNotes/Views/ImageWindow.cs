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
        }

        public void SetImage(Bitmap bitmap, int width, int height)
        {
            Debug.WriteLine($"Args Width: {width}, Args Height:{Height}");
            this.Width = width;
            this.Height = height;

            ImageBox.Image = bitmap;
        }

        private void ImageWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }
    }
}
