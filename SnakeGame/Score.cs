public class Score
{
	private readonly ConsoleColor _foregroundColor;
	private readonly ConsoleColor _backgroundColor;

	public Score(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
	{
		_foregroundColor = foregroundColor;
		_backgroundColor = backgroundColor;
	}

	private readonly int _pointsPerFood = 20;
	private readonly int _multiplierMax = 10;
	private int _multiplier = 10;
	private int _points;

	public override string ToString()
	{
		return $"Score: {_points,-6} Multiplier {_multiplier,-2}X";
	}

	public void Draw(Renderer renderer)
	{
		renderer.Write(ToString(), Game.PlayBounds.Left, Game.PlayBounds.Top - 1, _foregroundColor, _backgroundColor);
	}

	public void AddScore()
	{
		_points += _pointsPerFood * _multiplier;
	}

	public void DecreaseMultiplier() => _multiplier = Math.Max(_multiplier - 1, 1);

	public void ResetMultipler() => _multiplier = _multiplierMax;
}