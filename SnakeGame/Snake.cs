public class Snake
{
	public Position Position => Head.Position;
	public Direction Direction { get; set; }
	public Action? ChangedDirection;
	public SnakeBody Body { get; }
	public SnakeHead Head { get; }

	private readonly Position _spawnPos = new Position(
		Game.PlayBounds.Left + Game.PlayBounds.Width / 2,
		Game.PlayBounds.Top + Game.PlayBounds.Height / 2);

	public Snake()
	{
		Head = new SnakeHead(this) { Position = _spawnPos };
		Body = new SnakeBody(this);
	}

	public void Draw(Renderer renderer)
	{
		Head.Draw(renderer);
		Body.Draw(renderer);
	}

	public void Update()
	{
		Head.Move();
		Body.Move();
	}

	public void ChangeDirection(Direction direction)
	{
		if (direction == Direction.None || direction == Direction) return;
		if ((Position)Direction + (Position)direction == (Position)Direction.None) return;
		Direction = direction;
		ChangedDirection?.Invoke();
	}
}
