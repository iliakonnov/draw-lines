using Eto.Drawing;
using PluginInterfaces;

namespace DiagCell_plugin
{
	public class DiagCell_Plugin : IPlugin
	{
		public string Name { get { return "DiagCell"; } }
		public IGenerator GetGenerator()
		{
			return new DiagCell_Generator();
		}
	}

	public class DiagCell_Generator : IGenerator
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

				// Up left part, from right-up to left-down
				for (int i = 0; i < n; i++)
				{
					step = distance * i;
					a = new PointF(new Point(offset + step, offset));
					b = new PointF(new Point(offset, offset + step));
					canvas.DrawLine(fgColor, a, b);
				}

				// Right down part, from right-up to left-down
				for (int i = 0; i < n; i++)
				{
					step = distance * i;
					a = new PointF(new Point(bigOffset, offset + step));
					b = new PointF(new Point(offset + step, bigOffset));
					canvas.DrawLine(fgColor, a, b);
				}

				// Right up part, from left-up to right-down
				for (int i = 0; i < n; i++)
				{
					step = distance * i;
					a = new PointF(new Point(bigOffset - step, offset));
					b = new PointF(new Point(bigOffset, offset + step));
					canvas.DrawLine(fgColor, a, b);
				}

				// Left down part, from left-up to right-down
				for (int i = 0; i < n; i++)
				{
					step = distance * i;
					a = new PointF(new Point(offset, offset + step));
					b = new PointF(new Point(bigOffset - step, bigOffset));
					canvas.DrawLine(fgColor, a, b);
				}
			}
			return image;
		}
	}
}
