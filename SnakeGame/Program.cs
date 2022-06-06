using System.Diagnostics;

Console.CursorVisible = false;
Console.SetWindowSize(1, 1);
Console.SetBufferSize(60, 30);
Console.SetWindowSize(60, 30);

var game = new Game();
game.Run();

public class Game
{
	public static DrawableRectangle PlayBounds { get; private set; }
	private readonly Controls _controls;
	private readonly PlayerInput _playerInput;
	private readonly Renderer _renderer;
	private readonly Score _score;
	private readonly Snake _snake;
	private readonly Food _food;

	private Command _command;

	public Game()
	{
		PlayBounds = new DrawableRectangle(ConsoleColor.Black, ConsoleColor.Gray)
		{
			Width = 48,
			Height = 24,
			Left = 6,
			Top = 3,
		};
		_controls = new Controls();
		_playerInput = new PlayerInput(_controls);
		_renderer = new Renderer();
		_snake = new Snake();
		_food = new Food();
		_score = new Score(ConsoleColor.White, ConsoleColor.Black);

		_snake.ChangedDirection += _score.DecreaseMultiplier;
		_food.SetPositionRandomly();
	}

	public void Run()
	{
		Thread input = new Thread(Input);
		input.Start();

		while (true)
		{
			Thread.Sleep(20);
			var direction = GetDirectionFromCommand(_command);
			_snake.ChangeDirection(direction);
			_snake.Update();
			PlayBounds.Draw(_renderer);
			_snake.Draw(_renderer);
			_food.Draw(_renderer);
			_score.Draw(_renderer);
			_renderer.Update();

			if (_food.Position == _snake.Position)
			{
				_food.SetPositionRandomly();
				_score.AddScore();
				_score.ResetMultipler();
				_snake.Body.Grow();
			}

			var head = _snake;
			var body = _snake.Body.Segments;
			var bodyColliding = body.Any(x => x.Position == head.Position);
			if (bodyColliding)
			{
				Console.ReadKey();
			}
		}
	}

	public void Input()
	{
		while (true)
		{
			_command = _playerInput.GatherInput();
		}
	}

	public Direction GetDirectionFromCommand(Command command)
	{
		return command switch
		{
			Command.Up => Direction.Up,
			Command.Down => Direction.Down,
			Command.Left => Direction.Left,
			Command.Right => Direction.Right,
			Command.None => Direction.None
		};
	}
}