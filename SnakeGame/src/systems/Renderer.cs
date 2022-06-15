using Microsoft.Win32.SafeHandles;

public class Renderer
{
	private static readonly short _height = (short)Console.WindowHeight;
	private static readonly short _width = (short)Console.WindowWidth;
	private readonly CharInfo[] _buffer = new CharInfo[_width * _height];
	private readonly SafeFileHandle _consoleHandle = NativeConsole.CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
	private readonly CharInfo[] _lastBuffer = new CharInfo[_width * _height];

	private SmallRect _rect = new SmallRect()
	{
		Left = 0,
		Top = 0,
		Right = _width,
		Bottom = _height
	};

	public void Update()
	{
		//Do not update if the buffer has not changed.
		//This heavily impacts the performance and is not useful in a realtime game.
		//if (Buffer.SequenceEqual(LastBuffer)) return;

		_buffer.CopyTo(_lastBuffer, 0);
		NativeConsole.WriteConsoleOutputW(
			_consoleHandle,
			_buffer,
			new Coord() { X = _width, Y = _height },
			new Coord() { X = 0, Y = 0 },
			ref _rect);
	}

	public void Write(string text, int x, int y, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
	{
		for (int i = 0; i < text.Length; i++)
		{
			var position = x + i + y * _width;
			AppendToBuffer(text[i], position, foregroundColor, backgroundColor);
		}
	}

	public void Write(char c, int x, int y, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
	{
		var position = x + y * _width;
		AppendToBuffer(c, position, foregroundColor, backgroundColor);
	}

	public void Erase(int x, int y)
	{
		var position = x + y * _width;
		AppendToBuffer(' ', position);
	}

	private void AppendToBuffer(char c, int position, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
	{
		_buffer[position].Attributes = (short)foregroundColor;
		_buffer[position].Attributes |= (short)((short)backgroundColor << 4);
		_buffer[position].Char.UnicodeChar = c;
	}

	private void AppendToBuffer(char c, int position)
	{
		_buffer[position].Char.UnicodeChar = c;
	}
}