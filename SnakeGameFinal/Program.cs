var quit = false;

while (!quit)
{
	var options = new SnakeGameOptions(size: 33, borderThickness: 2);
	var game = new SnakeGame(options);
	game.Run();

	var key = Console.ReadKey(true).Key;
	if (key == ConsoleKey.Escape) break;
	else continue;
}