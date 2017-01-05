using gui;
using Eto.Drawing;

namespace connectAll_plugin
{
	public class ConnectAll_Plugin : SearchPlugins.IPlugin
	{
		public string Name { get { return "connect all"; } }
		public SearchPlugins.IGenerator GetGenerator()
		{
			return new ConnectAll_Generator();
		}
	}

	class ConnectAll_Generator : SearchPlugins.IGenerator
	{
		Point[] _GetPositions(int distance, int n)
		{
			var positions = new Point[(n - 1) * 4];
			int offset = distance / 2;
			int bigOffset = distance * (n - 1);
			int nPos = 0;

			// Up and down
			for (int x = 0; x < n; x++)
			{
				int xx = x * distance + offset;
				positions[nPos] = new Point(xx, offset); nPos++;
				positions[nPos] = new Point(xx, bigOffset + offset); nPos++;
			}

			// Left center and right center
			for (int y = 1; y < n - 1; y++)
			{
				int yy = y * distance + offset;
				positions[nPos] = new Point(offset, yy); nPos++;
				positions[nPos] = new Point(bigOffset + offset, yy); nPos++;
			}

			return positions;
		}
		
		public Bitmap Generate(int distance, int n, Color fgColor, Color bgColor)
		{
			Point[] positions = _GetPositions(distance, n);
			var image = new Bitmap(distance * n, distance * n, PixelFormat.Format32bppRgb);
			using (Graphics canvas = new Graphics(image))
			{
				canvas.Clear(bgColor);
				for (int a = 0; a < positions.Length; a++)
				{
					for (int b = a; b < positions.Length; b++)
					{
						canvas.DrawLine(fgColor, new PointF(positions[a]), new PointF(positions[b]));
					}
				}
			}
			return image;
		}
	}
}
