using SnakeProject.Graphics;

public class SnakeGameOptions
{
	public SnakeGameOptions(
		int size = 48,
		int borderThickness = 3,
		ConsoleColor frontColor = ConsoleColor.Black,
		ConsoleColor backColor = ConsoleColor.Gray)
	{
		var consoleMargin = 30;
		var consoleSize = size + consoleMargin;

		Console.CursorVisible = false;
		Console.SetWindowSize(1, 1);
		Console.SetBufferSize(consoleSize, consoleSize / 2);
		Console.SetWindowSize(consoleSize, consoleSize / 2);

		PlayBounds = new DrawableRectangle(
			borderThickness,
			new Color(frontColor, backColor))
		{
			Width = size,
			Height = size / 2,
			Left = (Console.WindowWidth - size) / 2,
			Top = (Console.WindowHeight - size / 2) / 2
		};
	}

	public DrawableRectangle PlayBounds { get; }
}