public class Score
{
	private readonly Color _color;

	private readonly int _multiplierMax = 10;
	private readonly int _pointsPerFood = 20;

	private int _multiplier = 10;
	private int _points;

	public Score(Color color)
	{
		_color = color;
	}

	public void AddScore()
	{
		_points += _pointsPerFood * _multiplier;
	}

	public void DecreaseMultiplier() => _multiplier = Math.Max(_multiplier - 1, 1);

	public void Draw(Renderer renderer)
	{
		renderer.Write(ToString(), Game.Bounds.Left, Game.Bounds.Top - 1, _color.Front, _color.Back);
	}

	public void ResetMultipler() => _multiplier = _multiplierMax;

	public override string ToString()
	{
		return $"Score: {_points,-6} Multiplier {_multiplier,-2}X";
	}
}