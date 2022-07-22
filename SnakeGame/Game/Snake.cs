using SnakeProject.Common;

namespace SnakeProject.Game
{
	public class Snake
	{
		private readonly SnakeSegmentFactory _segmentFactory;
		private readonly List<SnakeSegment> _segments = new List<SnakeSegment>();
		private Position _direction;

		public Snake(SnakeSegmentFactory segmentFactory)
		{
			_segmentFactory = segmentFactory;
			_segments.Add(_segmentFactory.Create(this, true));
		}

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

		public SnakeSegment Head => _segments[0];
		public IEnumerable<SnakeSegment> Body => _segments.Skip(1);
		public IList<SnakeSegment> Segments => _segments.AsReadOnly();

		public event Action? ChangedDirection;

		public void Grow()
		{
			//Create a body segment.
			var segment = _segmentFactory.Create(this, false);

			//Set the new segment behind the last segment.
			_segments.Add(segment);
		}

		public void Move()
		{
			//Move the head segment based on direction within SnakeSnakeGame bounds.
			var nextPosition = Head.Position + Direction;
			if (nextPosition.X >= SnakeGame.Bounds.Right) nextPosition.X = SnakeGame.Bounds.Left + 1;
			if (nextPosition.X <= SnakeGame.Bounds.Left) nextPosition.X = SnakeGame.Bounds.Right - 1;
			if (nextPosition.Y >= SnakeGame.Bounds.Bottom) nextPosition.Y = SnakeGame.Bounds.Top + 1;
			if (nextPosition.Y <= SnakeGame.Bounds.Top) nextPosition.Y = SnakeGame.Bounds.Bottom - 1;
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
}