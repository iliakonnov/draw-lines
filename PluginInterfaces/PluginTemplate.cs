using Eto.Drawing;
using PluginInterfaces;

namespace TemplateName_plugin
{
	// Replace "TemplateName" with plugin name
	public class TemplateName_Plugin : IPlugin
	{
		public string Name { get { return "TemplateName"; } }
		public IGenerator GetGenerator()
		{
			return new TemplateName_Generator();
		}
	}

	public class TemplateName_Generator : IGenerator
	{
		public Bitmap Generate(int distance, int n, Color fgColor, Color bgColor)
		{
			var image = new Bitmap(distance * n, distance * n, PixelFormat.Format24bppRgb);
			using (Graphics canvas = new Graphics(image))
			{
				canvas.Clear(bgColor);

				// Generate here
				/*
				int offset = distance / 2;
				PointF a, b;
				for (int i = 0; i < n; i++)
				{
					canvas.DrawLine(fgColor, a, b);
				}
				*/

			}
			return image;
		}
	}
}
