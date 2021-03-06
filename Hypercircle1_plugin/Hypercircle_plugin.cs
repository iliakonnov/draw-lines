﻿using System;
using PluginInterfaces;
using Eto.Drawing;

namespace Hypercircle_plugin
{
	public class Hypercircle_Plugin : IPlugin
	{
		public string Name { get { return "Hypercircle"; } }
		public IGenerator GetGenerator()
		{
			return new Hypercircle_Generator();
		}
	}

	public class Hypercircle_Generator : IGenerator
	{
		public Bitmap Generate(int distance, int n, Color fgColor, Color bgColor)
		{
			int size = Convert.ToInt32(Convert.ToDouble(distance) * (Convert.ToDouble(n) - 2.5)); // Looks more circle
			var image = new Bitmap(size, size, PixelFormat.Format24bppRgb);
			using (Graphics canvas = new Graphics(image))
			{
				canvas.Clear(bgColor);

				PointF a, b;
				n /= 2;
				int offset = distance / 2;
				int bigOffset = distance * (n - 1);
				int minus = 2 * offset; // Looks more circle
				int step;

				// Up left
				for (int i = 0; i < n; i++)
				{
					step = i * distance;
					a = new PointF(new Point(offset, offset + bigOffset - step));
					b = new PointF(new Point(offset + step, offset));
					canvas.DrawLine(fgColor, a, b);
				}

				// Up right
				for (int i = 0; i < n; i++)
				{
					step = i * distance;
					a = new PointF(new Point(bigOffset + step - minus, offset));
					b = new PointF(new Point(2 * bigOffset - minus, offset + step));
					canvas.DrawLine(fgColor, a, b);
				}

				// Down right
				for (int i = 0; i < n; i++)
				{
					step = i * distance;
					a = new PointF(new Point(2 * bigOffset - minus, bigOffset + step - minus));
					b = new PointF(new Point(2 * bigOffset - step - minus, 2 * bigOffset - minus));
					canvas.DrawLine(fgColor, a, b);
				}

				// Down left
				for (int i = 0; i < n; i++)
				{
					step = i * distance;
					a = new PointF(new Point(offset, bigOffset + step - minus));
					b = new PointF(new Point(offset + step, 2 * bigOffset - minus));
					canvas.DrawLine(fgColor, a, b);
				}
			}
			return image;
		}
	}
}
