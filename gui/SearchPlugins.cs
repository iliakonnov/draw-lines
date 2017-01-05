using System;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Eto.Drawing;


namespace gui
{
	public static class SearchPlugins
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

		public static void Search(MainForm form, string path = "plugins/")
		{
			// https://code.msdn.microsoft.com/windowsdesktop/Creating-a-simple-plugin-b6174b62
			string[] dllFileNames = null;
			if (Directory.Exists(path))
			{
				dllFileNames = Directory.GetFiles(path, "*.dll");
			}

			var assemblies = new List<Assembly>(dllFileNames.Length);
			foreach (string dllFile in dllFileNames)
			{
				var an = AssemblyName.GetAssemblyName(dllFile);
				var assembly = Assembly.Load(an);
				assemblies.Add(assembly);
			}

			var pluginType = typeof(IPlugin);
			var pluginTypes = new List<Type>();
			foreach (Assembly assembly in assemblies)
			{
				if (assembly != null)
				{
					var types = assembly.GetExportedTypes();
					foreach (Type type in types)
					{
						if (type.IsInterface || type.IsAbstract)
						{
							continue;
						}
						else
						{
							if (type.GetInterfaces().Contains(pluginType))
							{
								pluginTypes.Add(type);
							}
						}
					}
				}
			}

			var plugins = new List<IPlugin>(pluginTypes.Count);
			foreach (Type type in pluginTypes)
			{
				var plugin = (IPlugin)Activator.CreateInstance(type);
				plugins.Add(plugin);
			}

			//

			var pluginNames = new Dictionary<string, IPlugin>();
			string name;
			var nameSuffix = 1;
			foreach (IPlugin p in plugins)
			{
				name = p.Name;
				while (pluginNames.ContainsKey(name))
				{
					name = String.Format("{0} ({1})", p.Name, nameSuffix.ToString());
				}
				pluginNames.Add(name, p);
			}

			form.plugins = pluginNames;
		}
	}
}
