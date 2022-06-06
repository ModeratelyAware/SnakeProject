public record struct Position(int X, int Y)
{
	public static implicit operator Position(Direction direction)
	{
		return direction switch
		{
			Direction.Up => new Position(0, -1),
			Direction.Down => new Position(0, 1),
			Direction.Left => new Position(-1, 0),
			Direction.Right => new Position(1, 0),
			Direction.None => new Position(0, 0)
		};
	}

	public static Position operator +(Position a, Position b) => new Position(a.X + b.X, a.Y + b.Y);
	public static Position operator -(Position a, Position b) => new Position(a.X - b.X, a.Y - b.Y);
}
