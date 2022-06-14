public class Controls
{
	public List<Keybind> Keybinds { get; } =
		new List<Keybind>
		{
			new Keybind(new ChangeSnakeDirectionCommand(Position.Up), ConsoleKey.W),
			new Keybind(new ChangeSnakeDirectionCommand(Position.Left), ConsoleKey.A),
			new Keybind(new ChangeSnakeDirectionCommand(Position.Down), ConsoleKey.S),
			new Keybind(new ChangeSnakeDirectionCommand(Position.Right), ConsoleKey.D),
			new Keybind(new PauseGameCommand(), ConsoleKey.Escape)
		};
}