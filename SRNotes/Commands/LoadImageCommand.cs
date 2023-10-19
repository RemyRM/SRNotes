using SRNotes.Interfaces;
using SRNotes.Views;
using System.Drawing;
using System.Reflection;
using System.IO;

namespace SRNotes.Commands
{
    internal class LoadImageCommand : ICommand
    {
        public string Command { get; private set; }
        public string[] Args { get; private set; }
        public CommandType Type { get; private set; }

        public int Width { get; set; } = 500;
        public int Height { get; set; } = 500;

        private readonly string FileNotFoundImagePath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Resources\\ImageNotFound500x500.png";

        public LoadImageCommand(string command, string[] args)
        {
            Command = command;
            Args = args;
            Type = CommandType.LoadImage;
        }

        public async void Run()
        {
            if (ImageWindow.Instance == null)
                new ImageWindow();

            if (Args.Length == 3)
                TrySetWidthAndHeightFromArgs();

            if (Args[0].StartsWith("\"") && Args[0].EndsWith("\""))
                Args[0] = Args[0].Replace("\"", "");

            Bitmap bmp;
            if (Args == null || Args.Length == 0 || Args[0] == "" || !File.Exists(Args[0]))
                bmp = new Bitmap(FileNotFoundImagePath);
            else
                bmp = new Bitmap(Args[0]);

            ImageWindow.Instance.SetImage(bmp, Width, Height);
            ImageWindow.Instance.Show();
        }

        /// <summary>
        /// Try to parse the second and third argument of the command to integers for the Width and Height of the Bmp
        /// </summary>
        private void TrySetWidthAndHeightFromArgs()
        {
            if (int.TryParse(Args[1], out int width))
                Width = width;

            if (int.TryParse(Args[2], out int height))
                Height = height;
        }

        public override string ToString() => $"Command: {Command}, Args:{string.Join(" ", Args)}";
    }
}
