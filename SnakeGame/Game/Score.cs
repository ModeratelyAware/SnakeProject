namespace SnakeProject.Game
{
	public class Score
	{
		private readonly int _multiplierMax = 10;
		private readonly int _pointsPerFood = 20;

		private int _multiplier = 10;
		private int _points;

		public void AddScore()
		{
			_points += _pointsPerFood * _multiplier;
		}

		public void DecreaseMultiplier() => _multiplier = Math.Max(_multiplier - 1, 1);

		public void ResetMultipler() => _multiplier = _multiplierMax;

		public override string ToString()
		{
			return $"Score: {_points,-6} Multiplier {_multiplier,-2}X";
		}
	}
}