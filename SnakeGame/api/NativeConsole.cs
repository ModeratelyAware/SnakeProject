using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

public class NativeConsole
{
	[DllImport("Kernel32.dll")]
	public static extern IntPtr GetConsoleWindow();

	[DllImport("Kernel32.dll")]
	public static extern IntPtr GetStdHandle();

	[DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
	public static extern SafeFileHandle CreateFile(
		string fileName,
		[MarshalAs(UnmanagedType.U4)] uint fileAccess,
		[MarshalAs(UnmanagedType.U4)] uint fileShare,
		IntPtr securityAttributes,
		[MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
		[MarshalAs(UnmanagedType.U4)] int flags,
		IntPtr template);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool WriteConsoleOutputW(
		SafeFileHandle hConsoleOutput,
		CharInfo[] lpBuffer,
		Coord dwBufferSize,
		Coord dwBufferCoord,
		ref SmallRect lpWriteRegion);
}

[StructLayout(LayoutKind.Sequential)]
public struct Coord
{
	public short X;
	public short Y;

	public Coord(short X, short Y)
	{
		this.X = X;
		this.Y = Y;
	}
};

[StructLayout(LayoutKind.Explicit, Size = 1)]
public struct CharUnion
{
	[FieldOffset(0)] public ushort UnicodeChar;
	[FieldOffset(0)] public byte AsciiChar;
}

[StructLayout(LayoutKind.Explicit)]
public struct CharInfo
{
	[FieldOffset(0)] public CharUnion Char;
	[FieldOffset(2)] public short Attributes;
}

[StructLayout(LayoutKind.Sequential)]
public struct SmallRect
{
	public short Left;
	public short Top;
	public short Right;
	public short Bottom;
}