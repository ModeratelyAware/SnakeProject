public class InputManager
{
	private readonly Controls _controls;

	public InputManager(Controls controls)
	{
		_controls = controls;
	}

	public Keybind? GatherInput()
	{
		var input = Console.ReadKey(true).Key;
		var output = _controls.Keybinds.Find(x => x.Key == input);
		return output;
	}
}