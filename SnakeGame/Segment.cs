public class Segment
{
	private Position _position;
	private Position _lastPosition;

	public Position Position
	{
		get => _position;
		set
		{
			_lastPosition = Position;
			_position = value;
		}
	}

	public Position LastPosition => _lastPosition;

	public Segment? Next { get; set; }
	public Segment? Previous { get; set; }
}
