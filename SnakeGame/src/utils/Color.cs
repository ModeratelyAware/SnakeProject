public struct Color
{
	public Color(ConsoleColor front, ConsoleColor back)
	{
		Front = front;
		Back = back;
	}

	public ConsoleColor Front { get; }
	public ConsoleColor Back { get; }
}