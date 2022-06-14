public class ChangeSnakeDirectionCommand : ICommand
{
	private Position _direction;

	public ChangeSnakeDirectionCommand(Position direction)
	{
		_direction = direction;
	}

	public void Execute(Game game)
	{
		game.Snake.Direction = _direction;
	}
}