using SRNotes.Interfaces;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace SRNotes.Commands
{
    internal class LoadImageCommand : ICommand
    {
        public string Command { get; private set; }
        public string[] Args { get; private set; }
        public CommandType Type { get; private set; }

        public LoadImageCommand(string command, string[] args)
        {
            Command = command;
            Args = args;
            Type = CommandType.LoadImage;
        }

        public async void Run()
        {
            Bitmap bmp = new Bitmap(Args[0]);

        }

        public override string ToString() => $"Command: {Command}, Args:{string.Join(" ", Args)}";
    }
}
