public partial class Controls
{
	public Dictionary<ConsoleKey, Command> KeyBinds { get; }

	public Controls()
	{
		KeyBinds = new Dictionary<ConsoleKey, Command>()
		{
			{ ConsoleKey.W, Command.Up },
			{ ConsoleKey.A, Command.Left },
			{ ConsoleKey.S, Command.Down },
			{ ConsoleKey.D, Command.Right }
		};
	}
}