namespace SnakeProject.Graphics
{
	public class ScoreActor : IActor
	{
		private readonly Color _color;

		public ScoreActor(Color color)
		{
			_color = color;
		}

		public void Draw(Renderer renderer)
		{
			renderer.Write(ToString(), SnakeGame.Bounds.Left, SnakeGame.Bounds.Top - 1, _color.Front, _color.Back);
		}
	}
}