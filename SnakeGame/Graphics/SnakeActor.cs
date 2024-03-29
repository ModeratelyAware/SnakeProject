﻿using SnakeProject.Game;

namespace SnakeProject.Graphics
{
	public class SnakeActor : IActor
	{
		private readonly Snake _snake;
		private readonly Symbol _headSymbol;
		private readonly Symbol _bodySymbol;

		public SnakeActor(Snake snake, Symbol headSymbol, Symbol bodySymbol)
		{
			_snake = snake;
			_headSymbol = headSymbol;
			_bodySymbol = bodySymbol;
		}

		public void Draw(Renderer renderer)
		{
			foreach (var segment in _snake.Segments)
			{
				var symbol = _bodySymbol;
				if (segment.IsHead)
				{
					symbol = _headSymbol;
				}

				renderer.Erase(
					segment.LastPosition.X,
					segment.LastPosition.Y);

				renderer.Write(
					symbol.Char,
					segment.Position.X,
					segment.Position.Y,
					symbol.Color.Front,
					symbol.Color.Back);
			}
		}
	}
}