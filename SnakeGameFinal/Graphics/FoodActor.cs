using SnakeProject.Common;
using SnakeProject.Game;

namespace SnakeProject.Graphics
{
	public class FoodActor : IActor
	{
		private readonly Food _food;
		private readonly Symbol _symbol;

		public FoodActor(Food food)
		{
			_food = food;
		}

		public void Draw(Renderer renderer)
		{
			renderer.Write(_symbol.Char.ToString(), _food.Position.X, _food.Position.Y, _symbol.Color.Front, SnakeGame.Bounds.Color.Back);
		}
	}
}