namespace SRNotes.Interfaces
{
    public enum CommandType
    {
        None,
        LoadImage,
        UnloadImage
    }

    internal interface ICommand
    {
        string Command { get; }
        string[] Args { get; }
        CommandType Type { get; }

        void Run(); 
    }
}
