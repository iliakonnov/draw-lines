using PluginSearch;
using PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Mono.Options;
using Eto.Drawing;

namespace CLI
{
	class MainClass
	{
		static Dictionary<string, IPlugin> plugins;
		static void Generate(string plugin,
							 int distance, int n, string fgColorString, string bgColorString,
							 string output)
		{
			Console.WriteLine("Working...");
			var application = new Eto.Forms.Application();
			var bgColor = Color.FromRgb(int.Parse(bgColorString, System.Globalization.NumberStyles.HexNumber));
			var fgColor = Color.FromRgb(int.Parse(fgColorString, System.Globalization.NumberStyles.HexNumber));
			var img = plugins[plugin].GetGenerator().Generate(distance, n, fgColor, bgColor);
			img.Save(output, ImageFormat.Png);
			Console.WriteLine("Done!");
		}
		static void ShowHelp(OptionSet p)
		{
			p.WriteOptionDescriptions(Console.Out);
		}
		static void ListPlugins()
		{
			foreach (string plugin in plugins.Keys)
			{
				Console.WriteLine(plugin);
			}
		}
		static string CheckArgs(string plugin, int distance, int n, string fgColorString, string bgColorString)
		{
			// Check strings are not NullOrEmpty
			if (string.IsNullOrEmpty(plugin)) { return "Plugin name is empty"; }
			if (string.IsNullOrEmpty(fgColorString)) { return "fgColor is empty"; }
			if (string.IsNullOrEmpty(bgColorString)) { return "bgColor is empty"; }

			// Check ints are more then zero
			if (distance <= 0) { return "Distance less or equal zero"; }
			if (n <= 0) { return "Distance less or equal zero"; }

			// Check length of colors is 6 (RRGGBB)
			if (fgColorString.Length != 6) { return "Invalid fgColor"; }
			if (bgColorString.Length != 6) { return "Invalid bgColor"; }
			//Check is colors are hex strings
			if (!Regex.IsMatch(fgColorString, @"\A\b[0-9a-fA-F]+\b\Z")) { return "Invalid fgColor"; }
			if (!Regex.IsMatch(bgColorString, @"\A\b[0-9a-fA-F]+\b\Z")) { return "Invalid bgColor"; }

			// Check is plugin in list
			if (!plugins.ContainsKey(plugin)) { return "Not such plugin"; }

			return "OK";
		}
		public static void Main(string[] args)
		{
			plugins = SearchPlugins.Search(
				string.Format("..{0}plugins{0}", System.IO.Path.DirectorySeparatorChar)
			);

			string plugin = null;
			int distance = 100;
			int n = 10;
			string fgColorString = "#0000FF";
			string bgColorString = "#000000";
			string output = "out.png";

			bool showHelp = false;
			bool listPlugins = false;

			var p = new OptionSet
			{
				{ "h|help", "help", v => showHelp = v != null },
				{ "l|list", "list plugins", v => listPlugins = v != null },
				{ "p|plugin=", "plugin name", v => { if (v != null) { plugin = v; } } },
				{ "d|distance=", "distance[100]", v => { if (v != null) { distance = int.Parse(v); } } },
				{ "n=", "n[10]", v => { if (v != null) { n = int.Parse(v); } } },
				{ "f|fgColor=", "foreground color (hex)[#0000FF]", v => { if (v != null) { fgColorString = v; } } },
				{ "b|bgColor=", "background color (hex)[#000000]", v => { if (v != null) { bgColorString = v; } } },
				{ "o|output=", "output file (png)[out.png]", v => { if (v != null) { output = v; } } }
			};

			try { p.Parse(args); }
			catch (OptionException) { showHelp = true; }

			// Normalize colors
			if (fgColorString[0] == '#') { fgColorString = fgColorString.Substring(1); }
			if (bgColorString[0] == '#') { bgColorString = bgColorString.Substring(1); }

			if (showHelp) { ShowHelp(p); }
			else if (listPlugins) { ListPlugins(); }
			else
			{
				var check = CheckArgs(plugin, distance, n, fgColorString, bgColorString);
				if (check != "OK")
				{
					Console.WriteLine("Error: " + check);
					ShowHelp(p);
				}
				else
				{
					Generate(plugin, distance, n, fgColorString, bgColorString, output);
				}
			}
		}
	}
}
