using System;
using System.IO;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace gui
{
	public class ImageDialog : Dialog
	{
		Image image;
		ImageView image_imgView;
		Button save_btn;
		Button close_btn;
		Label imgSize_label;

		void Save_Btn_Click(object sender, EventArgs e)
		{
			var save_dialog = new SaveFileDialog
			{
				Filters = {
					new FileDialogFilter("png", new string[] { ".png" })
				}
			};
			save_dialog.ShowDialog(this);
			var bm = new Bitmap(image);
			bm.Save(save_dialog.FileName, ImageFormat.Png);
			Close();
		}

		public ImageDialog(Image img)
		{
			Title = "Preview";

			// buttons
			save_btn = new Button { Text = "Save" };
			save_btn.Click += Save_Btn_Click;

			close_btn = new Button { Text = "Close" };
			close_btn.Click += (sender, e) => Close();

			image = img;
			if (img.Width > gui.maxWidth || img.Height > gui.maxHeight)  // Big image
			{
				var size = img.Size.FitTo(new Size(gui.maxWidth, gui.maxHeight));
				var bmImg = new Bitmap(img, size.Width, size.Height, ImageInterpolation.None);
				var position = new Point(bmImg.Width - 16, 16);
				var checkPixel = bmImg.GetPixel(position);
				double darkness = 0.299 * checkPixel.R + 0.587 * checkPixel.G + 0.114 * checkPixel.B;

				Bitmap resizeImg;
				resizeImg = darkness < 0.5 ? gui.resizeImg_dark : gui.resizeImg_light;
				using (Graphics canvasImg = new Graphics(bmImg))
				{
					canvasImg.DrawImage(resizeImg, new PointF(new Point(bmImg.Width-32, 0)));
				}
				img = bmImg;
			}
			imgSize_label = new Label { Text = String.Format("{0}x{1}", img.Width, img.Height) };
			image_imgView = new ImageView() { Image = img };

			Content = new StackLayout
			{
				Items =
				{
					image_imgView,
					new StackLayout
					{
						Orientation = Orientation.Horizontal,
						Items = { save_btn, close_btn, imgSize_label }
					}
				}
			};
		}
	}
}
