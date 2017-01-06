using System;
using Eto.Forms;
using Eto.Drawing;
using PluginSearch;

namespace gui
{
	public class gui
	{
		public static int maxWidth;
		public static int maxHeight;
		public static Bitmap resizeImg_dark;
		public static Bitmap resizeImg_light;

		[STAThread]
		public static void Main(string[] args)
		{
			var application = new Eto.Forms.Application();
			var form = new MainForm();

			// Screen size
			var screenSize = Screen.DisplayBounds;
			maxWidth = Convert.ToInt32(screenSize.Width / 1.5);
			maxHeight = Convert.ToInt32(screenSize.Height / 1.5);
			// Images for resize
			resizeImg_light = new Bitmap(
				System.Reflection.Assembly.GetEntryAssembly().
				GetManifestResourceStream("gui.res.resized-light.png")
			);
			resizeImg_dark = new Bitmap(
				System.Reflection.Assembly.GetEntryAssembly().
				GetManifestResourceStream("gui.res.resized-dark.png")
			);
			// Load plugins
			var plugins = SearchPlugins.Search("plugins");
			form.plugins = plugins;

			application.Run(form);
		}
	}
}
