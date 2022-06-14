public record struct Position(int X, int Y)
{
	public static Position Zero => new(0, 0);
	public static Position Up => new(0, -1);
	public static Position Down => new(0, 1);
	public static Position Left => new(-1, 0);
	public static Position Right => new(1, 0);

	public bool IsOpposite(Position position)
	{
		return this + position == Zero;
	}

	public static Position operator +(Position a, Position b) => new Position(a.X + b.X, a.Y + b.Y);
	public static Position operator -(Position a, Position b) => new Position(a.X - b.X, a.Y - b.Y);
}