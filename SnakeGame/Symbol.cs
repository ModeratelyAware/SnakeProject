public struct Symbol
{
	public char Char { get; }
	public ConsoleColor Color { get; }

	public Symbol(char character, ConsoleColor color)
	{
		Char = character;
		Color = color;
	}
}