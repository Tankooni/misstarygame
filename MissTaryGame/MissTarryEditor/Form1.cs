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
		//public SceneStates EditState { get; set; }
		public SceneStates ViewState { get; set; }

		List<ObjectWrapper> MasterObjectWrappers { get; set; }

		List<Scene> SceneList { get; set; }
		Scene CurrentScene { get; set; }

		ContextMenu RightClickMenu = null;

		public Form1()
		{
			InitializeComponent();

			ViewState = SceneStates.None;
			//cbxForeground.Checked = true;
			//EditState = SceneStates.Foreground;
			radForeground.Checked = true;
			MasterObjectWrappers = new List<ObjectWrapper>();
			SceneList = new List<Scene>();

			RightClickMenu = new ContextMenu
				(
					new MenuItem[]
					{
						new MenuItem("Change background", ChangeBackground),
						new MenuItem("Change foreground", ChangeForeground)
					}
				);
			//this.TransparencyKey = Color.Transparent;
			this.ContextMenu = RightClickMenu;
		}

		private void ChangeBackground(object sender, EventArgs e)
		{
			//var panel = CurrentScene.GetPanel(EditState);
			//panel.Controls.Clear();

			frmImageAdder newImageForm = new frmImageAdder(false, "Background");
			var result = newImageForm.ShowDialog();
			if(result == DialogResult.OK)
			{
				if (newImageForm.SelectedImages.Count == 0)
					return;
				var newPictureBox = newImageForm.SelectedImages.First().Item2;
				CurrentScene.Background = newPictureBox;
				UpdateViewState();
			}
		}

		private void ChangeForeground(object sender, EventArgs e)
		{
			//var panel = CurrentScene.GetPanel(EditState);
			//panel.Controls.Clear();

			frmImageAdder newImageForm = new frmImageAdder(false, "Foreground");
			var result = newImageForm.ShowDialog();
			if (result == DialogResult.OK)
			{
				if (newImageForm.SelectedImages.Count == 0)
					return;
				var newPictureBox = newImageForm.SelectedImages.First().Item2;
				CurrentScene.Foreground = newPictureBox;
				UpdateViewState();
			}
		}

		private void PlaceObject(object sender, EventArgs e)
		{

		}

		internal void AddObjectWrapper(ObjectWrapper selectedObject)
		{
			//CurrentScene.SceneObjects[EditState].Add
			//	(
			//		new SceneObject()
			//		{
			//			ObjectWrapper = selectedObject,
			//			Position = new Point(0,0)
			//		}
			//	);

			//UpdateSceneView();
		}

		private void UpdateSceneView()
		{
			//var targetPanel = CurrentScene.GetUpdatePanel(EditState);
			//Delete all other panels
			//Show this panel
		}

		internal void UpdateObjectWrapperList(List<ObjectWrapper> objectWrappers)
		{
			MasterObjectWrappers = objectWrappers;
		}

		#region checkboxes
		private void cbxForeground_CheckedChanged(object sender, EventArgs e)
		{
			UpdateViewState();
		}

		private void cbxBackground_CheckedChanged(object sender, EventArgs e)
		{
			UpdateViewState();
		}

		private void cbxCollision_CheckedChanged(object sender, EventArgs e)
		{
			UpdateViewState();
		}

		private void cbxGradiant_CheckedChanged(object sender, EventArgs e)
		{
			UpdateViewState();
		}
		#endregion

		private void UpdateViewState()
		{
			if (cbxBackground.Checked)
			{
				if (!ViewState.HasFlag(SceneStates.Background))
					ViewState |= SceneStates.Background;
			}
			else
			{
				if (ViewState.HasFlag(SceneStates.Background))
					ViewState ^= SceneStates.Background;
			}

			if (cbxForeground.Checked)
			{
				if (!ViewState.HasFlag(SceneStates.Foreground))
					ViewState |= SceneStates.Foreground;
			}
			else
			{
				if (ViewState.HasFlag(SceneStates.Foreground))
					ViewState ^= SceneStates.Foreground;
			}

			if (cbxObjects.Checked)
			{
				if (!ViewState.HasFlag(SceneStates.Objects))
					ViewState |= SceneStates.Objects;
			}
			else
			{
				if (ViewState.HasFlag(SceneStates.Objects))
					ViewState ^= SceneStates.Objects;
			}

			if (cbxCollision.Checked)
			{
				if (!ViewState.HasFlag(SceneStates.Collision))
					ViewState |= SceneStates.Collision;
			}
			else
			{
				if (ViewState.HasFlag(SceneStates.Collision))
					ViewState ^= SceneStates.Collision;
			}

			if (cbxGradiant.Checked)
			{
				if (!ViewState.HasFlag(SceneStates.Gradiant))
					ViewState |= SceneStates.Gradiant;
			}
			else
			{
				if (ViewState.HasFlag(SceneStates.Gradiant))
					ViewState ^= SceneStates.Gradiant;
			}
			UpdateVision(CurrentScene);
		}

		#region RadioButtons
		private void radForeground_CheckedChanged(object sender, EventArgs e)
		{
			if (((RadioButton)sender).Checked)
			{
				//EditState = SceneStates.Foreground;
				UpdateVision(CurrentScene);
			}
		}

		private void radBackground_CheckedChanged(object sender, EventArgs e)
		{
			if (((RadioButton)sender).Checked)
			{
				//EditState = SceneStates.Background;
				UpdateVision(CurrentScene);
			}
		}

		private void radCollision_CheckedChanged(object sender, EventArgs e)
		{
			if (((RadioButton)sender).Checked)
			{
				//EditState = SceneStates.Collision;
				UpdateVision(CurrentScene);
			}
        }

		private void radGradiant_CheckedChanged(object sender, EventArgs e)
		{
			if (((RadioButton)sender).Checked)
			{
				//EditState = SceneStates.Gradiant;
				UpdateVision(CurrentScene);
			}
        }

		private void radObjects_CheckedChanged(object sender, EventArgs e)
		{
			if (((RadioButton)sender).Checked)
			{
				//EditState = SceneStates.Objects;
				UpdateVision(CurrentScene);
			}
		}
		#endregion

		private void addObjectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmObjects newForm = new frmObjects(this, true, MasterObjectWrappers);
			newForm.Show();
			//this.Hide();
		}

		public void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			if (CurrentScene == null)
				return;

			var coordinates = ((Control)sender).PointToClient(Cursor.Position);
			if (e.Button == MouseButtons.Right)
			{
				//if (EditState == SceneStates.Foreground)
				//	ForegroundContext.Show(CurrentScene.GetPanel(EditState), coordinates);
				//else if (EditState == SceneStates.Background)
				//	BackgroundContext.Show(CurrentScene.GetPanel(EditState), coordinates);
			}
		}

		private void addSceneToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SceneAdder sceneForm = new SceneAdder(RightClickMenu);
			if(sceneForm.ShowDialog() == DialogResult.OK)
			{
				SceneList.Add(sceneForm.NewScene);
				UpdateSceneList();
			}
		}

		private void UpdateSceneList()
		{
			lbxScenes.Items.Clear();
			foreach (var item in SceneList)
				lbxScenes.Items.Add(item);
		}

		private void lbxScenes_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateVision((Scene)lbxScenes.SelectedItem);
		}

		private void UpdateVision(Scene newScene)
		{
			if (newScene == null)
				return;
			
			//Clear previous
			//if(CurrentScene != null)
			//	if (this.Controls.Contains(CurrentScene.MasterPanel))
			//		this.Controls.Remove(CurrentScene.MasterPanel);
			//Do this first so that the one we're editting is on top (mouse events)
			//if (ViewState.HasFlag(EditState))
			//	this.Controls.Add(newScene.GetPanel(EditState));

			this.Controls.Add(newScene.GetUpdatedPanel(ViewState));

			//this.Invalidate();
			CurrentScene = newScene;
			CurrentScene.MasterPanel.Invalidate();
		}

		private void btnRemoveScene_Click(object sender, EventArgs e)
		{
			SceneList.Remove(CurrentScene);
			CurrentScene = null;
			UpdateSceneList();
		}
	}
}
