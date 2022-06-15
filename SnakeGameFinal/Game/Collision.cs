using SnakeProject.Common;

namespace SnakeProject.Game
{
	public class Collision
	{
		public static bool IsColliding(Position a, Position b) => a == b;

		public static bool IsColliding(Position a, IEnumerable<Position> b) => b.Any(x => x == a);
	}
}