using Microsoft.Win32.SafeHandles;

public class Renderer
{
	private static readonly short _height = (short)Console.WindowHeight;
	private static readonly short _width = (short)Console.WindowWidth;
	private CharInfo[] Buffer = new CharInfo[_width * _height];
	private SafeFileHandle ConsoleHandle = NativeConsole.CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
	private CharInfo[] LastBuffer = new CharInfo[_width * _height];

	private SmallRect Rect = new SmallRect()
	{
		Left = 0,
		Top = 0,
		Right = _width,
		Bottom = _height
	};

	public void Update()
	{
		//Do not update if the buffer has not changed.
		//if (Buffer.SequenceEqual(LastBuffer)) return;

		Buffer.CopyTo(LastBuffer, 0);
		NativeConsole.WriteConsoleOutputW(
			ConsoleHandle,
			Buffer,
			new Coord() { X = _width, Y = _height },
			new Coord() { X = 0, Y = 0 },
			ref Rect);
	}

	public void Write(string text, int x, int y, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
	{
		for (int i = 0; i < text.Length; i++)
		{
			var position = x + i + y * _width;
			AppendToBuffer(text[i], position, foregroundColor, backgroundColor);
		}
	}

	//public void WriteMultiple(string text, int x, int y, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
	//{
	//	var offset = 0;
	//	for (int i = 0; i < text.Length; i++)
	//	{
	//		if (text[i] == '\n')
	//		{
	//			offset = i + 2;
	//			y += 1;
	//			continue;
	//		}
	//		var position = x + i - offset + y * _width;
	//		AppendToBuffer(text[i], position, foregroundColor, backgroundColor);
	//	}
	//}

	private void AppendToBuffer(char c, int position, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
	{
		Buffer[position].Attributes = (short)foregroundColor;
		Buffer[position].Attributes |= (short)((short)backgroundColor << 4);
		Buffer[position].Char.UnicodeChar = c;
	}
}