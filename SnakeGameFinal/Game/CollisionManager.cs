namespace SnakeProject.Game
{
	public class CollisionManager
	{
		private readonly SnakeGame _game;

		public CollisionManager(SnakeGame game)
		{
			_game = game;
		}

		public void Update()
		{
			if (Collision.IsColliding(_game.Food.Position, _game.Snake.Head.Position))
			{
				_game.Food.SetPositionRandomly();
				_game.Snake.Grow();
				_game.Score.AddScore();
				_game.Score.ResetMultipler();
			}

			if (Collision.IsColliding(_game.Snake.Head.Position, _game.Snake.Body.Select(x => x.Position)))
			{
				_game.GameOver();
			}
		}
	}
}