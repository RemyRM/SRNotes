using SRNotes.Interfaces;
using System.Threading.Tasks;

namespace SRNotes.Commands
{
    internal class UnloadImageCommand : ICommand
    {
        public string Command { get; private set; }
        public string[] Args { get; private set; }
        public CommandType Type { get; private set; }

        public UnloadImageCommand(string command, string[] args)
        {
            Command = command;
            Args = args;
            Type = CommandType.UnloadImage;
        }

        public async void Run()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString() => $"Command: {Command}, Args:{string.Join(" ", Args)}";
    }
}
