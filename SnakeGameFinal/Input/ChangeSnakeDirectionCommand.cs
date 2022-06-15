using SnakeProject.Common;

namespace SnakeProject.Input
{
	public class ChangeSnakeDirectionCommand : ICommand
	{
		private Position _direction;

		public ChangeSnakeDirectionCommand(Position direction)
		{
			_direction = direction;
		}

		public void Execute(SnakeGame game)
		{
			game.Snake.Direction = _direction;
		}
	}
}