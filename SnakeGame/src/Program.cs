Console.CursorVisible = false;
Console.SetWindowSize(1, 1);
Console.SetBufferSize(60, 30);
Console.SetWindowSize(60, 30);

var quit = false;

while (!quit)
{
	var options = new GameOptions(33);
	var game = new Game(options);
	game.Run();

	if (Console.ReadKey(true).Key == ConsoleKey.Escape) break;
	else if (!Console.KeyAvailable) continue;
}