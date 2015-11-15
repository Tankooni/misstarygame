using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissTarryEditor
{
	public partial class frmImageAdder : Form
	{
		public List<Tuple<string, SillyPictureBox>> SelectedImages { get; set; }
		public string Animation { get; set; }

		public frmImageAdder(bool multiselect, string name)
		{
			InitializeComponent();
			if (name != null && name != "")
			{
				textBox2.Text = name;
				textBox2.Enabled = false;
			}
			SelectedImages = GetPictures(multiselect);

			ImageList imageList = new ImageList();
			int count = 0;
			foreach(var item in SelectedImages)
			{
				imageList.Images.Add(item.Item2.Image);
				ListViewItem listItem = new ListViewItem();
				listItem.ImageIndex = count;
				listItem.Text = item.Item1;
				lvwImages.Items.Add(listItem);
				count++;
			}
			lvwImages.LargeImageList = imageList;
			lvwImages.View = View.LargeIcon;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox2.Text == null || textBox2.Text == "")
			{
				MessageBox.Show("Please provide an animation name");
				return;
			}

			Animation = textBox2.Text;

			this.Close();
		}

		private List<Tuple<string, SillyPictureBox>> GetPictures(bool multiselect)
		{
			OpenFileDialog openDiag = new OpenFileDialog();
			openDiag.Filter = "All files (*.*)|*.*";
			openDiag.FilterIndex = 1;
			openDiag.RestoreDirectory = true;
			openDiag.Multiselect = multiselect;
			openDiag.Title = "Image Browser";

			List<Tuple<string, SillyPictureBox>> results = new List<Tuple<string, SillyPictureBox>>();

			if (openDiag.ShowDialog() == DialogResult.OK)
			{
				// Read the files
				foreach (String file in openDiag.FileNames)
				{
					// Create a PictureBox.
					try
					{
						SillyPictureBox pb = new SillyPictureBox();
						Image loadedImage = Image.FromFile(file);
						pb.Height = loadedImage.Height;
						pb.Width = loadedImage.Width;
						pb.Image = loadedImage;
						pb.BackColor = Color.Transparent;
						results.Add(new Tuple<string, SillyPictureBox>(Path.GetFileNameWithoutExtension(file),pb));
						//ParentForm.AddPictureBox(textBox2.Text, Path.GetFileNameWithoutExtension(file), pb);
						//flowLayoutPanel1.Controls.Add(pb);
					}
					catch (Exception ex)
					{
						// Could not load the image - probably related to Windows file system permissions.
						MessageBox.Show("Cannot load the image: " + file.Substring(file.LastIndexOf('\\'))
							+ ". You may not have permission to read the file, or " +
							"it may be corrupt.\n\nReported error: " + ex.Message);
					}
				}
				//ParentForm.UpdateImageList();
				//this.Close();
				
			}
			return results;
		}
	}
}
