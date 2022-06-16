using SnakeProject.Common;
using SnakeProject.Graphics;

namespace SnakeProject.Game
{
	public class SegmentFactory
	{
		private Position _spawnPos = new Position(30, 15);

		public Segment Create(Snake snake, bool isHead = false)
		{
			var lastSegment = snake.Segments.Count == 0 ? null : snake.Segments.Last();

			return new Segment()
			{
				IsHead = isHead,
				Position = lastSegment == null ? _spawnPos : lastSegment.LastPosition
			};
		}
	}
}