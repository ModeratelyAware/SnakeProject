public class SegmentFactory
{
	private Symbol _bodySymbol = new Symbol('█', new Color(ConsoleColor.DarkCyan, Game.Bounds.Color.Back));
	private Symbol _headSymbol = new Symbol('█', new Color(ConsoleColor.DarkBlue, Game.Bounds.Color.Back));
	private Position _spawnPos = new Position(30, 15);

	public Segment Create(Snake snake, bool isHead = false)
	{
		var lastSegment = snake.Segments.Count == 0 ? null : snake.Segments.Last();

		return new Segment()
		{
			Symbol = isHead ? _headSymbol : _bodySymbol,
			Position = lastSegment == null ? _spawnPos : lastSegment.LastPosition
		};
	}
}