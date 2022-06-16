using SnakeProject.Common;

namespace SnakeProject.Game
{
	public class SnakeSegmentFactory
	{
		private Position _spawnPos = new Position(
			SnakeGame.Bounds.Left + SnakeGame.Bounds.Width / 2,
			SnakeGame.Bounds.Top + SnakeGame.Bounds.Height / 2);

		public SnakeSegment Create(Snake snake, bool isHead = false)
		{
			var lastSegment = snake.Segments.Count == 0 ? null : snake.Segments.Last();
			var position = lastSegment == null ? _spawnPos : lastSegment.LastPosition;

			return new SnakeSegment()
			{
				IsHead = isHead,
				Position = position
			};
		}
	}
}