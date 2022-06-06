public class SnakeHead : Segment
{
	private readonly Symbol _headSymbol = new Symbol('█', ConsoleColor.White);
	private readonly Snake _snake;

	public SnakeHead(Snake snake)
	{
		_snake = snake;
	}

	public void Draw(Renderer renderer)
	{
		renderer.Write(" ", LastPosition.X, LastPosition.Y, Game.PlayBounds.FillColor, Game.PlayBounds.FillColor);
		renderer.Write(_headSymbol.Char.ToString(), Position.X, Position.Y, s, Game.PlayBounds.FillColor);
	}

	public void Move()
	{
		var nextPosition = Position + _snake.Direction;
		if (nextPosition.X >= Game.PlayBounds.Right) nextPosition.X = Game.PlayBounds.Left + 1;
		if (nextPosition.X <= Game.PlayBounds.Left) nextPosition.X = Game.PlayBounds.Right - 1;
		if (nextPosition.Y >= Game.PlayBounds.Bottom) nextPosition.Y = Game.PlayBounds.Top + 1;
		if (nextPosition.Y <= Game.PlayBounds.Top) nextPosition.Y = Game.PlayBounds.Bottom - 1;
		Position = nextPosition;
	}
}