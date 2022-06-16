using SnakeProject.Common;
using SnakeProject.Game;
using SnakeProject.Graphics;
using SnakeProject.Input;

public class SnakeGame
{
	private static SnakeGameOptions _options;

	private readonly CollisionManager _collisionManager;
	private readonly Controls _controls;
	private readonly InputManager _inputManager;
	private readonly Renderer _renderer;
	private bool _gameOver = false;
	private readonly float _gameSpeed = 1;
	private Keybind? _input;

	private List<IActor> _actors = new List<IActor>();

	public SnakeGame(SnakeGameOptions gameOptions)
	{
		_options = gameOptions;

		_collisionManager = new CollisionManager(this);
		_controls = new Controls();
		_inputManager = new InputManager(_controls);
		_renderer = new Renderer();

		Snake = new Snake(new SnakeSegmentFactory());
		Food = new Food();
		Score = new Score();

		var snakeActor = new SnakeActor(
			Snake,
			new Symbol('█', new Color(ConsoleColor.DarkBlue, SnakeGame.Bounds.Color.Back)),
			new Symbol('█', new Color(ConsoleColor.DarkCyan, SnakeGame.Bounds.Color.Back)));

		var foodActor = new FoodActor(
			Food,
			new Symbol('■', new Color(ConsoleColor.Red, _options.PlayBounds.Color.Back)));

		var scoreActor = new ScoreActor(
			Score,
			new Color(ConsoleColor.White, SnakeGame.Bounds.Color.Front));

		_actors.Add(snakeActor);
		_actors.Add(foodActor);
		_actors.Add(scoreActor);
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
		_input?.Command.Execute(this);
		Snake.Update();
		_collisionManager.Update();
	}

	public void Draw()
	{
		foreach (var actor in _actors)
		{
			actor.Draw(_renderer);
		}
		_renderer.Update();
	}

	public void Input()
	{
		var snakeai = new SnakeAI(this);
		while (!_gameOver)
		{
			snakeai.Run();
			//_input = _inputManager.GatherInput();
		}
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
}