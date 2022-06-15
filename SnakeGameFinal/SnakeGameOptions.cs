public class SnakeGameOptions
{
	public DrawableRectangle PlayBounds { get; }

	public SnakeGameOptions(
		int size = 48,
		ConsoleColor frontColor = ConsoleColor.Black,
		ConsoleColor backColor = ConsoleColor.Gray)
	{
		PlayBounds = new DrawableRectangle(
			new Color(frontColor, backColor))
		{
			Width = size,
			Height = size / 2,
			Left = (Console.WindowWidth - size) / 2,
			Top = (Console.WindowHeight - size / 2) / 2
		};
	}
}