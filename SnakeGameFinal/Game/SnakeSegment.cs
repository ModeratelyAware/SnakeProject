using SnakeProject.Common;

namespace SnakeProject.Game
{
	public class SnakeSegment : GameObject
	{
		public bool IsHead { get; init; }

		public Position LastPosition { get; private set; }

		public override Position Position
		{
			get => base.Position;
			set
			{
				LastPosition = Position;
				base.Position = value;
			}
		}
	}
}