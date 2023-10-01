using SRNotes.Interfaces;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SRNotes.Commands
{
    internal class CommandHandler
    {
        public static async Task RunCommand(string commandText)
        {
            if (!ValidateCommand(commandText))
                return;

            ICommand command = ParseCommandText(commandText);
            if (command == null)
                return;

            command.Run();
        }

        public static ICommand ParseCommandText(string commandText)
        {
            int argPos = commandText.IndexOf('(');
            string command = commandText.Substring(1, argPos - 1);
            string argsString = commandText.Substring(argPos + 1, commandText.IndexOf(')') - argPos - 1);

            string[] args = argsString.Split(',');

            if (Enum.TryParse(command, out CommandType commandType))
            {
                switch (commandType)
                {
                    default:
                    case CommandType.None:
                        Debug.WriteLine($"Error: Command Type was None for commantText: {commandText}");
                        return null;
                    case CommandType.LoadImage:
                        return new LoadImageCommand(command, args);
                    case CommandType.UnloadImage:
                        return new UnloadImageCommand(command, args);
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Validate the given <see cref="commandText"/> to check if it contains [ ] and a command keyword from <see cref="CommandType"/>
        /// </summary>
        /// <param name="commandText">The command to validate</param>
        /// <returns>True if the commandText is a valid command</returns>
        private static bool ValidateCommand(string commandText)
        {
            bool stringContainsCommand = Enum.GetNames(typeof(CommandType)).Any(s => commandText.Contains(s));
            if (!commandText.StartsWith("[") && !commandText.EndsWith("]") && !stringContainsCommand)
            {
                Debug.WriteLine($"Command {commandText} does not contain a command keyword, or does not start/end with \"[ or \"]");
                return false;
            }
            return true;
        }
    }
}
