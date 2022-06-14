public class SegmentFactory
{
	private Symbol _bodySymbol = new Symbol('█', new Color(ConsoleColor.DarkCyan, Game.Bounds.Color.Back));
	private Symbol _headSymbol = new Symbol('█', new Color(ConsoleColor.Blue, Game.Bounds.Color.Back));
	private Position _spawnPos = new Position(30, 15);

	public Segment Create(Snake snake, bool isHead)
	{
		var lastSegment = snake.Segments.Count == 0 ? null : snake.Segments.Last();

		return new Segment()
		{
			IsHead = isHead,
			Symbol = isHead ? _headSymbol : _bodySymbol,
			Ahead = lastSegment ?? null,
			Position = lastSegment == null ? _spawnPos : lastSegment.LastPosition
		};
	}
}