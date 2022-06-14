using Microsoft.Win32.SafeHandles;

public class Renderer
{
	public const short HEIGHT = 50;
	public const short WIDTH = 200;
	private CharInfo[] Buffer = new CharInfo[WIDTH * HEIGHT];
	private SafeFileHandle ConsoleHandle = NativeConsole.CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
	private CharInfo[] LastBuffer = new CharInfo[WIDTH * HEIGHT];

	private SmallRect Rect = new SmallRect()
	{
		Left = 0,
		Top = 0,
		Right = WIDTH,
		Bottom = HEIGHT
	};

	public void Update()
	{
		//Do not update if the buffer has not changed.
		//if (Buffer.SequenceEqual(LastBuffer)) return;

		Buffer.CopyTo(LastBuffer, 0);
		NativeConsole.WriteConsoleOutputW(ConsoleHandle, Buffer,
			new Coord() { X = WIDTH, Y = HEIGHT },
			new Coord() { X = 0, Y = 0 },
			ref Rect);
	}

	public void Write(string text, int x, int y, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
	{
		for (int i = 0; i < text.Length; i++)
		{
			var position = x + i + y * WIDTH;
			AppendToBuffer(text[i], position, foregroundColor, backgroundColor);
		}
	}

	private void AppendToBuffer(char c, int position, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
	{
		Buffer[position].Attributes = (short)foregroundColor;
		Buffer[position].Attributes |= (short)((short)backgroundColor << 4);
		Buffer[position].Char.UnicodeChar = c;
	}
}