using gui;
using Eto.Drawing;
using PluginInterfaces;

namespace TemplateName_plugin
{
	// Replace "TemplateName" with plugin name
	public class TemplateName_Plugin : SearchPlugins.IPlugin
	{
		public string Name { get { return "TemplateName"; } }
		public SearchPlugins.IGenerator GetGenerator()
		{
			return new TemplateName_Generator();
		}
	}

	public class TemplateName_Generator : SearchPlugins.IGenerator
	{
		public Bitmap Generate(int distance, int n, Color fgColor, Color bgColor)
		{
			var image = new Bitmap(distance * n, distance * n, PixelFormat.Format32bppRgb);
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
