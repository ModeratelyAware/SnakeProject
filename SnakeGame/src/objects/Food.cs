public class Food
{
	private readonly Random _random = new Random();
	private readonly Symbol _symbol;

	public Food(Symbol symbol)
	{
		_symbol = symbol;
	}

	public Position Position { get; set; }

	public void Draw(Renderer renderer)
	{
		renderer.Write(_symbol.Char.ToString(), Position.X, Position.Y, _symbol.Color.Front, Game.Bounds.Color.Back);
	}

	public void SetPositionRandomly()
	{
		var x = _random.Next(Game.Bounds.Left + 1, Game.Bounds.Right - 1);
		var y = _random.Next(Game.Bounds.Top + 1, Game.Bounds.Bottom - 1);

		Position = new Position(x, y);
	}
}