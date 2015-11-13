using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissTarryEditor
{
	public partial class Form1 : Form
	{
		public EditState Edit { get; set; }
		public ViewState View { get; set; }

		List<ObjectWrapper> MasterObjectWrappers { get; set; }

		Scene CurrentScene { get; set; }

		public Form1()
		{
			InitializeComponent();

			View = ViewState.Foreground;
			cbxForeground.Checked = true;
			Edit = EditState.Foreground;
			radForeground.Checked = true;
			MasterObjectWrappers = new List<ObjectWrapper>();
		}

		internal void AddObjectWrapper(ObjectWrapper selectedObject)
		{
			CurrentScene.SceneObjects[Edit].Add
				(
					new SceneObject()
					{
						ObjectWrapper = selectedObject,
						Position = new Point(0,0)
					}
				);

			UpdateSceneView();
		}

		private void UpdateSceneView()
		{
			var targetPanel = CurrentScene.GetUpdatePanel(Edit);
			//Delete all other panels
			//Show this panel
		}

		internal void UpdateObjectWrapperList(List<ObjectWrapper> objectWrappers)
		{
			MasterObjectWrappers = objectWrappers;
		}

		private void cbxForeground_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void cbxBackground_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void cbxCollision_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void cbxGradiant_CheckedChanged(object sender, EventArgs e)
		{

		}

		#region RadioButtons
		private void radForeground_CheckedChanged(object sender, EventArgs e)
		{
			if (((RadioButton)sender).Checked)
				Edit = EditState.Foreground;
		}

		private void radBackground_CheckedChanged(object sender, EventArgs e)
		{
			if(((RadioButton)sender).Checked)
				Edit = EditState.Background;
		}

		private void radCollision_CheckedChanged(object sender, EventArgs e)
		{
			if (((RadioButton)sender).Checked)
				Edit = EditState.Collision;
        }

		private void radGradiant_CheckedChanged(object sender, EventArgs e)
		{
			if (((RadioButton)sender).Checked)
				Edit = EditState.Gradiant;
        }
		#endregion

		private void addObjectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmObjects newForm = new frmObjects(this, MasterObjectWrappers);
			newForm.Show();
			//this.Hide();
		}
	}
}
