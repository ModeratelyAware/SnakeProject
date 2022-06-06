public class Food
{
	public Position Position { get; set; }

	private readonly Symbol _foodSymbol = new Symbol('■', ConsoleColor.White);
	private readonly Random _random = new Random();

	public void SetPositionRandomly()
	{
		var x = _random.Next(Game.PlayBounds.Left + 1, Game.PlayBounds.Right - 1);
		var y = _random.Next(Game.PlayBounds.Top + 1, Game.PlayBounds.Bottom - 1);

		Position = new Position(x, y);
	}

	public void Draw(Renderer renderer)
	{
		renderer.Write(_foodSymbol.Char.ToString(), Position.X, Position.Y, ConsoleColor.Red, Game.PlayBounds.FillColor);
	}
}