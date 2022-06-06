public class SnakeBody
{
	private readonly Symbol _symbol;
	private readonly Snake _snake;

	public List<Segment> Segments { get; }

	public SnakeBody(Snake snake, Symbol symbol)
	{
		Segments = new List<Segment>();
		_symbol = symbol;
		_snake = snake;
	}

	public void Draw(Renderer renderer)
	{
		foreach (var segment in Segments)
		{
			renderer.Write(" ", segment.LastPosition.X, segment.LastPosition.Y, Game.PlayBounds.BorderColor, Game.PlayBounds.FillColor);
			renderer.Write(_symbol.Char.ToString(), segment.Position.X, segment.Position.Y, _symbol.Color, Game.PlayBounds.FillColor);
		}
	}

	public void Grow()
	{
		var newSegment = new Segment();

		if (Segments.Count == 0)
		{
			newSegment.Previous = _snake.Head;
			newSegment.Position = _snake.Head.LastPosition;
			_snake.Head.Next = newSegment;
		}
		else
		{
			var lastSegment = Segments.Last();
			newSegment.Previous = lastSegment;
			newSegment.Position = lastSegment.LastPosition;
			lastSegment.Next = newSegment;
		}

		Segments.Add(newSegment);
	}

	public void Move()
	{
		foreach (var segment in Segments)
		{
			if (segment.Previous != null)
			{
				segment.Position = segment.Previous.LastPosition;
			}
		}
	}
}