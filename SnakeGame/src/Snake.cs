public class Snake
{
	public Action? ChangedDirection;

	private readonly SegmentFactory _segmentFactory;
	private readonly List<Segment> _segments = new List<Segment>();
	private Position _direction;

	public Position Direction
	{
		get => _direction;
		set
		{
			//Return if direction has not changed.
			if (value == _direction) return;

			//Return if direction is opposite current direction.
			if (_direction.IsOpposite(value)) return;

			//Set direction and trigger event.
			_direction = value;
			ChangedDirection?.Invoke();
		}
	}

	public IEnumerable<Segment> Body => _segments.Skip(1);
	public Segment Head => _segments[0];
	public IList<Segment> Segments => _segments.AsReadOnly();

	public Snake(SegmentFactory segmentFactory)
	{
		_segmentFactory = segmentFactory;
		_segments.Add(_segmentFactory.Create(this, true));
	}

	public void Draw(Renderer renderer)
	{
		foreach (var segment in _segments)
		{
			renderer.Erase(
				segment.LastPosition.X,
				segment.LastPosition.Y);

			renderer.Write(
				segment.Symbol.Char,
				segment.Position.X,
				segment.Position.Y,
				segment.Symbol.Color.Front,
				segment.Symbol.Color.Back);
		}
	}

	public void Grow()
	{
		//Create a body segment.
		var segment = _segmentFactory.Create(this, false);

		//Set the new segment behind the last segment.
		_segments.Add(segment);
	}

	public void Move()
	{
		//Move the head segment based on direction within game bounds.
		var nextPosition = Head.Position + Direction;
		if (nextPosition.X >= Game.Bounds.Right) nextPosition.X = Game.Bounds.Left + 1;
		if (nextPosition.X <= Game.Bounds.Left) nextPosition.X = Game.Bounds.Right - 1;
		if (nextPosition.Y >= Game.Bounds.Bottom) nextPosition.Y = Game.Bounds.Top + 1;
		if (nextPosition.Y <= Game.Bounds.Top) nextPosition.Y = Game.Bounds.Bottom - 1;
		Head.Position = nextPosition;

		//Move each body segment's position to the last position of the segment ahead of it.
		for (int i = 1; i < _segments.Count; i++)
		{
			var segment = _segments[i];
			var segmentAhead = _segments[i - 1];
			if (segmentAhead == null) return;
			segment.Position = segmentAhead.LastPosition;
		}
	}

	public void Update()
	{
		Move();
	}
}