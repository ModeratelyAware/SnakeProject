public struct Symbol
{
	public char Char { get; }
	public Color Color { get; }

	public Symbol(char character, Color color)
	{
		Char = character;
		Color = color;
	}
}