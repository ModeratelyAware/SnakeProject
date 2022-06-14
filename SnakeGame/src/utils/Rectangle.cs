public class Rectangle
{
	public int Left { get; init; }
	public int Top { get; init; }
	public int Width { get; init; }
	public int Height { get; init; }
	public int Bottom => Top + Height - 1;
	public int Right => Left + Width - 1;
}