using SnakeProject.Game;

namespace SnakeProject.Graphics
{
	public class ScoreActor : IActor
	{
		private readonly Score _score;
		private readonly Color _color;

		public ScoreActor(Score score, Color color)
		{
			_score = score;
			_color = color;
		}

		public void Draw(Renderer renderer)
		{
			renderer.Write(_score.ToString(), SnakeGame.Bounds.Left, SnakeGame.Bounds.Top - 1, _color.Front, _color.Back);
		}
	}
}