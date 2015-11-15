using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissTarryEditor
{
	public class SillyPanel : Panel
	{
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			try
			{
				e.Graphics.FillRectangle(Brushes.White, this.ClientRectangle);

				using (Bitmap masterImage = new Bitmap(1136, 640))
				{
					int count = 0;
					using (var canvas = Graphics.FromImage(masterImage))
					{
						canvas.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

						foreach (PictureBox picture in this.Controls)
						{
							canvas.DrawImage(picture.Image, picture.Location);
							count++;
						}
						canvas.Save();
					}
					if (count > 0)
						e.Graphics.DrawImage(masterImage, new Point(0, 0));
				}
				//else
				//	e.Graphics.FillRectangle(Brushes.White, this.ClientRectangle);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Drawing Error: " + ex.Message);
			}
		}
	}
}
