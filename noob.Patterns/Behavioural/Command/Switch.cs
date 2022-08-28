namespace noob.Patterns.Behavioural.Command;

/// <summary>
/// Invoker class.
/// Will store and execute commands from the client
/// </summary>
public class Switch
{
    private readonly List<ICommand> _commands = new();

    public void Execute(ICommand command)
    {
        _commands.Add(command);
        command.Execute();
    }
}
