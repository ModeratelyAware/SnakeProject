public class DrawableRectangle : Rectangle
{
	public ConsoleColor BorderColor { get; }
	public ConsoleColor FillColor { get; }

	public DrawableRectangle(ConsoleColor borderColor, ConsoleColor fillColor)
	{
		BorderColor = borderColor;
		FillColor = fillColor;
	}

	public void Draw(Renderer renderer)
	{
		//Draw corners.
		renderer.Write("█", Left, Top, BorderColor, FillColor);
		renderer.Write("█", Right, Top, BorderColor, FillColor);
		renderer.Write("█", Left, Bottom, BorderColor, FillColor);
		renderer.Write("█", Right, Bottom, BorderColor, FillColor);

		//Draw top and bottom sides.
		for (int i = 1; i < Width; i++)
		{
			renderer.Write("█", Left + i, Top, BorderColor, FillColor);
			renderer.Write("█", Left + i, Bottom, BorderColor, FillColor);
		}

		//Draw left and right sides.
		for (int i = 1; i < Height; i++)
		{
			renderer.Write("█", Left, Top + i, BorderColor, FillColor);
			renderer.Write("█", Right, Top + i, BorderColor, FillColor);
		}

		//Fill rectangle.
		for (int x = 1; x < Width - 1; x++)
		{
			for (int y = 1; y < Height - 1; y++)
			{
				renderer.Write(" ", Left + x, Top + y, BorderColor, FillColor);
			}
		}
	}
}