using SnakeProject.Input;

public class Keybind
{
	public Keybind(ICommand command, ConsoleKey consoleKey)
	{
		Command = command;
		Key = consoleKey;
	}

	public Keybind(ChangeSnakeDirectionCommand changeSnakeDirectionCommand, ConsoleKey w)
	{
	}

	public ICommand Command { get; }
	public ConsoleKey Key { get; set; }
}