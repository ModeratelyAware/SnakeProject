﻿public class Game
{
	private static GameOptions _options;

	private readonly CollisionManager _collisionManager;
	private readonly Controls _controls;
	private readonly InputManager _inputManager;
	private readonly Renderer _renderer;
	private bool _gameOver = false;
	private readonly float _gameSpeed = 1;
	private Keybind? _input;

	public Game(GameOptions gameOptions)
	{
		_options = gameOptions;

		_collisionManager = new CollisionManager(this);
		_controls = new Controls();
		_inputManager = new InputManager(_controls);
		_renderer = new Renderer();

		Snake = new Snake(
			new SegmentFactory());

		Food = new Food(
			new Symbol(
				'■',
				new Color(ConsoleColor.Red, _options.PlayBounds.Color.Back)));

		Score = new Score(
			new Color(
				ConsoleColor.White,
				ConsoleColor.Black));
	}

	public static DrawableRectangle Bounds => _options.PlayBounds;
	public Food Food { get; }
	public Score Score { get; }
	public Snake Snake { get; }
	private float FrameTime => 20 * _gameSpeed;

	private int TimePerFrame =>
		Snake.Direction == Position.Up ||
		Snake.Direction == Position.Down ?
		(int)FrameTime * 2 : (int)FrameTime;

	public void Run()
	{
		Initialize();

		while (!_gameOver)
		{
			Thread.Sleep(TimePerFrame);

			Update();
			Draw();
		}
	}

	public void Initialize()
	{
		Snake.ChangedDirection += Score.DecreaseMultiplier;
		Food.SetPositionRandomly();
		Bounds.Draw(_renderer);

		var input = new Thread(Input);
		input.IsBackground = true;
		input.Start();
	}

	public void Update()
	{
		Snake.Update();
		_collisionManager.Update();
	}

	public void Draw()
	{
		Snake.Draw(_renderer);
		Food.Draw(_renderer);
		Score.Draw(_renderer);
		_renderer.Update();
	}

	public void GameOver()
	{
		var text = "Press ANY key to lose again or ESC to rage quit.";
		var horizontalCenter = Console.WindowLeft + Console.WindowWidth / 2 - text.Length / 2;

		_renderer.Write(
			text,
			horizontalCenter,
			Bounds.Bottom + 1,
			ConsoleColor.Red,
			Bounds.Color.Front);

		_renderer.Update();
		_gameOver = true;
	}

	public void Input()
	{
		while (!_gameOver)
		{
			var input = _inputManager.GatherInput();
			if (input == null) continue;
			_input = input;
			_input.Command.Execute(this);
		}
	}
}