public class Segment : GameObject
{
	public Symbol Symbol { get; init; }
	public bool IsHead { get; init; }
	public Segment? Behind { get; set; }
	public Segment? Ahead { get; set; }
}