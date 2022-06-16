using SnakeProject.Common;

namespace SnakeProject.Graphics
{
	public class DrawableRectangle : Rectangle
	{
		private readonly BorderStyle _borderStyle;

		public DrawableRectangle(int borderThickness, Color color)
		{
			_borderStyle = BorderStyle.CreateBorderStyle(borderThickness);
			Color = color;
		}

		public Color Color { get; }

		public void Draw(Renderer renderer)
		{
			//Draw corners.
			renderer.Write(_borderStyle.TopLeft, Left, Top, Color.Front, Color.Back);
			renderer.Write(_borderStyle.TopRight, Right, Top, Color.Front, Color.Back);
			renderer.Write(_borderStyle.BottomLeft, Left, Bottom, Color.Front, Color.Back);
			renderer.Write(_borderStyle.BottomRight, Right, Bottom, Color.Front, Color.Back);

			//Draw top and bottom sides.
			for (int i = 1; i < Width - 1; i++)
			{
				renderer.Write(_borderStyle.TopBottom, Left + i, Top, Color.Front, Color.Back);
				renderer.Write(_borderStyle.TopBottom, Left + i, Bottom, Color.Front, Color.Back);
			}

			//Draw left and right sides.
			for (int i = 1; i < Height - 1; i++)
			{
				renderer.Write(_borderStyle.LeftRight, Left, Top + i, Color.Front, Color.Back);
				renderer.Write(_borderStyle.LeftRight, Right, Top + i, Color.Front, Color.Back);
			}

			//Fill rectangle.
			for (int x = 1; x < Width - 1; x++)
			{
				for (int y = 1; y < Height - 1; y++)
				{
					renderer.Write(' ', Left + x, Top + y, Color.Front, Color.Back);
				}
			}
		}

		public struct BorderStyle
		{
			public char BottomLeft { get; set; }
			public char BottomRight { get; set; }
			public char LeftRight { get; set; }
			public char TopBottom { get; set; }
			public char TopLeft { get; set; }
			public char TopRight { get; set; }

			public static BorderStyle CreateBorderStyle(int borderThickness)
			{
				return borderThickness switch
				{
					1 => new BorderStyle
					{
						TopLeft = '┌',
						TopRight = '┐',
						BottomLeft = '└',
						BottomRight = '┘',
						TopBottom = '─',
						LeftRight = '│'
					},

					2 => new BorderStyle
					{
						TopLeft = '╔',
						TopRight = '╗',
						BottomLeft = '╚',
						BottomRight = '╝',
						TopBottom = '═',
						LeftRight = '║'
					},

					3 => new BorderStyle
					{
						TopLeft = '█',
						TopRight = '█',
						BottomLeft = '█',
						BottomRight = '█',
						TopBottom = '█',
						LeftRight = '█'
					},

					_ => CreateBorderStyle(3),
				};
			}
		}
	}
}