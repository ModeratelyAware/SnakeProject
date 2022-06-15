using SnakeProject.Common;

namespace SnakeProject.Game
{
	public abstract class GameObject
	{
		private Position _position;

		public Position Position
		{
			get => _position;
			set
			{
				LastPosition = Position;
				_position = value;
			}
		}

		public Position LastPosition { get; private set; }
	}
}