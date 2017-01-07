using Eto.Drawing;
using PluginInterfaces;

namespace Cell_plugin
{
	public class Cell_Plugin : IPlugin
	{
		public string Name { get { return "Cell"; } }
		public IGenerator GetGenerator()
		{
			return new Cell_Generator();
		}
	}

	public class Cell_Generator : IGenerator
	{
		public Bitmap Generate(int distance, int n, Color fgColor, Color bgColor)
		{
			var image = new Bitmap(distance * n, distance * n, PixelFormat.Format24bppRgb);
			using (Graphics canvas = new Graphics(image))
			{
				canvas.Clear(bgColor);
				int step;
				int offset = distance / 2;
				int bigOffset = offset + distance * (n - 1);
				PointF a, b;

				for (int i = 0; i < n; i++)
				{
					step = distance * i;
					a = new PointF(new Point(offset + step, offset));
					b = new PointF(new Point(offset + step, bigOffset));
					canvas.DrawLine(fgColor, a, b);
				}

				for (int i = 0; i < n; i++)
				{
					step = distance * i;
					a = new PointF(new Point(offset, offset + step));
					b = new PointF(new Point(bigOffset, offset + step));
					canvas.DrawLine(fgColor, a, b);
				}
			}
			return image;
		}
	}
}
