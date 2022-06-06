public class PlayerInput
{
	private readonly Controls _controls;

	public PlayerInput(Controls controls)
	{
		_controls = controls;
	}

	public Command GatherInput() => _controls.KeyBinds.GetValueOrDefault(Console.ReadKey(true).Key);
}