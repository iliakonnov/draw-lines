using Eto.Drawing;

namespace PluginInterfaces
{
	public interface IGenerator
	{
		Bitmap Generate(int distance, int n, Color fgColor, Color bgColor);
	}

	public interface IPlugin
	{
		string Name { get; }
		IGenerator GetGenerator();
	}
}
