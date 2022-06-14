public class Snake
{
	public Action? ChangedDirection;

	private readonly SegmentFactory _segmentFactory;
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

	public Segment Head => Segments[0];

	public IEnumerable<Segment> Body => Segments.Skip(1);

	public List<Segment> Segments { get; } = new List<Segment>();

	public Snake(SegmentFactory segmentFactory)
	{
		_segmentFactory = segmentFactory;
		Segments.Add(_segmentFactory.Create(this, true));
	}

	public void Update()
	{
		Move();
	}

	public void Draw(Renderer renderer)
	{
		foreach (var segment in Segments)
		{
			renderer.Write(" ", segment.LastPosition.X, segment.LastPosition.Y, Game.Bounds.Color.Front, Game.Bounds.Color.Back);
			renderer.Write(segment.Symbol.Char.ToString(), segment.Position.X, segment.Position.Y, segment.Symbol.Color.Front, segment.Symbol.Color.Back);
		}
	}

	public void Grow()
	{
		//Create a body segment.
		var segment = _segmentFactory.Create(this, false);

		//Set the new segment behind the last segment.
		Segments.Last().Behind = segment;
		Segments.Add(segment);
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
		foreach (var segment in Segments)
		{
			if (segment.Ahead != null)
			{
				segment.Position = segment.Ahead.LastPosition;
			}
		}
	}
}