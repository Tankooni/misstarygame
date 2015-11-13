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
		public frmObjects ParentForm = null;
		public frmImageAdder(frmObjects parent)
		{
			InitializeComponent();
			ParentForm = parent;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if(textBox2.Text == null || textBox2.Text == "")
			{
				MessageBox.Show("Please provide an animation name");
				return;
			}

			OpenFileDialog openDiag = new OpenFileDialog();
			openDiag.Filter = "All files (*.*)|*.*";
			openDiag.FilterIndex = 1;
			openDiag.RestoreDirectory = true;
			openDiag.Multiselect = true;
			openDiag.Title = "Image Browser";

			if(openDiag.ShowDialog() == DialogResult.OK)
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
						ParentForm.AddPictureBox(textBox2.Text, Path.GetFileNameWithoutExtension(file), pb);
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
				ParentForm.UpdateImageList();
				this.Close();
			}
		}
	}
}
