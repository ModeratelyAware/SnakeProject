public class DrawableRectangle : Rectangle
{
	public Color Color { get; }

	public DrawableRectangle(Color color)
	{
		Color = color;
	}

	public void Draw(Renderer renderer)
	{
		//Draw corners.
		renderer.Write("█", Left, Top, Color.Front, Color.Back);
		renderer.Write("█", Right, Top, Color.Front, Color.Back);
		renderer.Write("█", Left, Bottom, Color.Front, Color.Back);
		renderer.Write("█", Right, Bottom, Color.Front, Color.Back);

		//Draw top and bottom sides.
		for (int i = 1; i < Width; i++)
		{
			renderer.Write("█", Left + i, Top, Color.Front, Color.Back);
			renderer.Write("█", Left + i, Bottom, Color.Front, Color.Back);
		}

		//Draw left and right sides.
		for (int i = 1; i < Height; i++)
		{
			renderer.Write("█", Left, Top + i, Color.Front, Color.Back);
			renderer.Write("█", Right, Top + i, Color.Front, Color.Back);
		}

		//Fill rectangle.
		for (int x = 1; x < Width - 1; x++)
		{
			for (int y = 1; y < Height - 1; y++)
			{
				renderer.Write(" ", Left + x, Top + y, Color.Front, Color.Back);
			}
		}
	}
}