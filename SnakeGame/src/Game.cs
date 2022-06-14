public class Game
{
	private static GameOptions _options;
	private readonly Controls _controls;
	private readonly InputManager _inputManager;
	private readonly Renderer _renderer;
	private Keybind? _input;
	public static DrawableRectangle Bounds => _options.PlayBounds;

	public Food Food { get; }
	public bool Paused { get; set; }
	public Score Score { get; }
	public Snake Snake { get; }

	public Game(GameOptions gameOptions)
	{
		_options = gameOptions;

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

	public void Initialize()
	{
		Snake.ChangedDirection += Score.DecreaseMultiplier;
		Food.SetPositionRandomly();
		Bounds.Draw(_renderer);

		var input = new Thread(Input);
		input.Start();
	}

	public void Input()
	{
		while (true)
		{
			var input = _inputManager.GatherInput();
			if (input == null) continue;
			_input = input;
			_input.Command.Execute(this);
		}
	}

	public void Run()
	{
		Initialize();

		while (true)
		{
			if (Snake.Direction == Position.Up ||
				Snake.Direction == Position.Down)
			{
				Thread.Sleep(30);
			}
			else Thread.Sleep(15);

			Update();
			Draw();

			if (Collision.IsColliding(Food.Position, Snake.Head.Position))
			{
				Food.SetPositionRandomly();
				Snake.Grow();
				Score.AddScore();
				Score.ResetMultipler();
			}

			if (Collision.IsColliding(Snake.Head.Position, Snake.Body.Select(x => x.Position)))
			{
				Console.ReadKey();
			}
		}
	}

	public void Update()
	{
		Snake.Update();
	}

	public void Draw()
	{
		Snake.Draw(_renderer);
		Food.Draw(_renderer);
		Score.Draw(_renderer);
		_renderer.Update();
	}
}