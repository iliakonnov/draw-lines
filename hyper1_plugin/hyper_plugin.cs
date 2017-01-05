using gui;
using Eto.Drawing;

namespace hyper_plugin
{
	public class Hyper_Plugin : SearchPlugins.IPlugin
	{
		public string Name { get { return "Hyper"; } }
		public SearchPlugins.IGenerator GetGenerator()
		{
			return new Hyper_Generator();
		}
	}

	public class Hyper_Generator : SearchPlugins.IGenerator
	{
		public Bitmap Generate(int distance, int n, Color fgColor, Color bgColor)
		{
			var image = new Bitmap(distance * n, distance * n, PixelFormat.Format32bppRgb);
			using (Graphics canvas = new Graphics(image))
			{
				canvas.Clear(bgColor);

				PointF a, b;
				int ii;
				int offset = distance / 2;
				int bigOffset = distance * (n - 1);
				for (int i = 0; i < n; i++)
				{
					ii = offset + i * distance;
					a = new PointF(new Point(ii, offset + bigOffset));
					b = new PointF(new Point(offset, ii));
					canvas.DrawLine(fgColor, a, b);
				}
			}
			return image;
		}
	}
}
