using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Eto.Forms;
using Eto.Drawing;

namespace gui
{
	public class MainForm : Form
	{
		ColorPicker fgColor_ColorPicker;
		ColorPicker bgColor_ColorPicker;
		NumericUpDown distance_NumUpDown;
		NumericUpDown n_NumUpDown;
		Button generate_btn;
		ComboBox plugins_combobox;
		ProgressBar loading_PBar;
		Dictionary<string, SearchPlugins.IPlugin> _plugins;
		public Dictionary<string, SearchPlugins.IPlugin> plugins
		{
			get 
			{
				return _plugins;
			}
			set
			{
				_plugins = value;
				foreach (KeyValuePair<string, SearchPlugins.IPlugin> pair in value)
				{
					AddPlugin(pair.Key);
				}
			}
		}

		void Generate_Btn_Click(object sender, EventArgs e)
		{
			fgColor_ColorPicker.Enabled = false;
			bgColor_ColorPicker.Enabled = false;
			distance_NumUpDown.Enabled = false;
			n_NumUpDown.Enabled = false;
			generate_btn.Visible = false;
			generate_btn.Enabled = false;
			plugins_combobox.Enabled = false;
			loading_PBar.Enabled = true;
			loading_PBar.Visible = true;
			Invalidate();

			var fgColor = fgColor_ColorPicker.Value;
			var bgColor = bgColor_ColorPicker.Value;
			var distance = Convert.ToInt32(distance_NumUpDown.Value);
			var n = Convert.ToInt32(n_NumUpDown.Value);
			var plugin = plugins_combobox.SelectedValue.ToString();

			var p = plugins[plugin].GetGenerator();

			Task.Factory.StartNew<Image>(() => p.Generate(distance, n, fgColor, bgColor))
			    .ContinueWith(tsk => LoadingEnd(tsk));
		}

		void LoadingEnd(Task<Image> task)
		{
			fgColor_ColorPicker.Enabled = true;
			bgColor_ColorPicker.Enabled = true;
			distance_NumUpDown.Enabled = true;
			n_NumUpDown.Enabled = true;
			generate_btn.Visible = true;
			generate_btn.Enabled = true;
			plugins_combobox.Enabled = true;
			loading_PBar.Enabled = false;
			loading_PBar.Visible = false;
			Invalidate();
			if (task.Status == TaskStatus.RanToCompletion)
			{
				Image image = task.Result;
				var image_dialog = new ImageDialog(image);
				image_dialog.ShowModalAsync();
			}
		}

		void AddPlugin(string plugin)
		{
			plugins_combobox.Items.Add(plugin);
			plugins_combobox.Text = plugin;
		}

		public MainForm()
		{
			fgColor_ColorPicker = new ColorPicker { Value = Eto.Drawing.Colors.Blue };
			bgColor_ColorPicker = new ColorPicker { Value = Eto.Drawing.Colors.Black };
			distance_NumUpDown = new NumericUpDown { DecimalPlaces = 0, Value = 100 };
			n_NumUpDown = new NumericUpDown { DecimalPlaces = 0, Value = 10 };
			plugins_combobox = new ComboBox() { ReadOnly = true};
			generate_btn = new Button { Text = "Generate" };
			generate_btn.Click += Generate_Btn_Click;
			loading_PBar = new ProgressBar { Indeterminate = true, Visible = false, Enabled = false };
			Title = "Line drawer";

			Content = new StackLayout
			{
				// Main
				Items =
				{
					//plugins
					plugins_combobox,

					//fgColor
					new StackLayout
					{
						Orientation = Orientation.Horizontal,
						Items =
						{
							new Label
							{
								TextAlignment = TextAlignment.Center,
								Text = "fgColor: "
							},
							fgColor_ColorPicker
						}
					},
					// bgColor
					new StackLayout
					{
						Orientation = Orientation.Horizontal,
						Items =
						{
							new Label
							{
								TextAlignment = TextAlignment.Center,
								Text = "bgColor: "
							},
							bgColor_ColorPicker
						}
					},
					// distance
					new StackLayout
					{
						Orientation = Orientation.Horizontal,
						Items =
						{
							new Label
							{
								TextAlignment = TextAlignment.Center,
								Text = "distance: "
							},
							distance_NumUpDown
						}
					},
					// n
					new StackLayout
					{
						Orientation = Orientation.Horizontal,
						Items =
						{
							new Label
							{
								TextAlignment = TextAlignment.Center,
								Text = "n: "
							},
							n_NumUpDown
						}
					},
					// Generate button
					generate_btn,
					// Loading
					loading_PBar
				}
			};
		}
	}
}
