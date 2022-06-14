public class PauseGameCommand : ICommand
{
	public void Execute(Game game)
	{
		game.Paused = !game.Paused;
	}
}