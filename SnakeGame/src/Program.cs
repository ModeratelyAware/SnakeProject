Console.CursorVisible = false;
Console.SetWindowSize(1, 1);
Console.SetBufferSize(60, 30);
Console.SetWindowSize(60, 30);

var options = new GameOptions(33);
var game = new Game(options);
game.Run();