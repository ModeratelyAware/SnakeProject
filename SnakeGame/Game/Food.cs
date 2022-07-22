using SnakeProject.Common;

namespace SnakeProject.Game
{
	public class Food : GameObject
	{
		private readonly Random _random = new Random();

		public void SetPositionRandomly()
		{
			var x = _random.Next(SnakeGame.Bounds.Left + 1, SnakeGame.Bounds.Right - 1);
			var y = _random.Next(SnakeGame.Bounds.Top + 1, SnakeGame.Bounds.Bottom - 1);

			Position = new Position(x, y);
		}
	}
}