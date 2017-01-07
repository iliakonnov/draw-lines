using Eto.Drawing;
using PluginInterfaces;

namespace Star_plugin
{
	public class Star_Plugin : IPlugin
	{
		public string Name { get { return "Star"; } }
		public IGenerator GetGenerator()
		{
			return new Star_Generator();
		}
	}

	public class Star_Generator : IGenerator
	{
		public Bitmap Generate(int distance, int n, Color fgColor, Color bgColor)
		{
			var image = new Bitmap(distance * n, distance * n, PixelFormat.Format24bppRgb);
			using (Graphics canvas = new Graphics(image))
			{
				canvas.Clear(bgColor);
				PointF a, b;
				var offset = distance / 2;
				var bigOffset = offset + distance * (n - 1);
				int step;

				// Up and down
				for (int i = 0; i < n; i++)
				{
					step = distance * i;
					a = new PointF(new Point(offset + step, offset));
					b = new PointF(new Point(bigOffset - step, bigOffset));
					canvas.DrawLine(fgColor, a, b);
				}

				// Left and right
				for (int i = 1; i < n - 1; i++)
				{
					step = distance * i;
					a = new PointF(new Point(offset, offset + step));
					b = new PointF(new Point(bigOffset, bigOffset - step));
					canvas.DrawLine(fgColor, a, b);
				}
			}
			return image;
		}
	}
}
