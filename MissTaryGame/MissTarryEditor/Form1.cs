using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
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

			//Viewstate MUST have SceneState.None
			ViewState = SceneStates.None | SceneStates.Foreground | SceneStates.Background | SceneStates.Objects;
			cbxForeground.Checked = true;
			cbxBackground.Checked = true;
			cbxObjects.Checked = true;
			//EditState = SceneStates.Foreground;
			radForeground.Checked = true;
			MasterObjectWrappers = new List<ObjectWrapper>();
			SceneList = new List<Scene>();

			RightClickMenu = new ContextMenu
				(
					new MenuItem[]
					{
						new MenuItem("Change background", ChangeBackground),
						new MenuItem("Change foreground", ChangeForeground),
						new MenuItem("Add object", AddObject),
						new MenuItem("Change collision map", ChangeCollision),
						new MenuItem("Change scaling gradiant", ChangeGradiant)
					}
				);
			//this.TransparencyKey = Color.Transparent;
			this.ContextMenu = RightClickMenu;
		}

		private void ChangeGradiant(object sender, EventArgs e)
		{
			if (CurrentScene == null)
				return;
			frmImageAdder newImageForm = new frmImageAdder(false, "Gradiant");
			var result = newImageForm.ShowDialog();
			if(result == DialogResult.OK)
			{
				if (newImageForm.SelectedImages.Count == 0)
					return;
				var newPictureBox = newImageForm.SelectedImages.First().Item2;
				CurrentScene.Gradiant = newPictureBox;
				UpdateViewState();
			}
		}

		private void ChangeCollision(object sender, EventArgs e)
		{
			if (CurrentScene == null)
				return;
			frmImageAdder newImageForm = new frmImageAdder(false, "Collision");
			var result = newImageForm.ShowDialog();
			if (result == DialogResult.OK)
			{
				if (newImageForm.SelectedImages.Count == 0)
					return;
				var newPictureBox = newImageForm.SelectedImages.First().Item2;
				CurrentScene.Collision = newPictureBox;
				UpdateViewState();
			}
		}

		private void AddObject(object sender, EventArgs e)
		{
			if (CurrentScene == null)
				return;

			frmObjects objectForm = new frmObjects(false, this.MasterObjectWrappers);
			if(objectForm.ShowDialog() == DialogResult.OK)
			{
				var selected = CurrentScene.AddSceneObject(objectForm.SelectedObject);
				CurrentScene.SetSelectedobject(selected);
				UpdateVision(CurrentScene);
			}
		}

		public SceneObject SelectedObject = null;

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			//if (CurrentScene == null || SelectedObject == null)
			//	return;

			//var coordinates = ((Control)sender).PointToClient(Cursor.Position);
			//SelectedObject.Position = coordinates;
		}

		public void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			//if (CurrentScene == null || SelectedObject == null)
			//	return;

			////var coordinates = ((Control)sender).PointToClient(Cursor.Position);
			//if (e.Button == MouseButtons.Left)
			//{
			//	SelectedObject = null;
			//}
		}

		private void ChangeBackground(object sender, EventArgs e)
		{
			//var panel = CurrentScene.GetPanel(EditState);
			//panel.Controls.Clear();
			if (CurrentScene == null)
				return;
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
			if (CurrentScene == null)
				return;
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

		private void cbxObjects_CheckedChanged(object sender, EventArgs e)
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
			frmObjects newForm = new frmObjects(true, MasterObjectWrappers);
			newForm.Show();
			//this.Hide();
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
			CurrentScene = newScene;
			foreach(Control control in this.Controls.Cast<Control>().ToArray())
			{
				if ((string)control.Tag == "Master")
					this.Controls.Remove(control);
			}
			this.Controls.Add(CurrentScene.GetUpdatedPanel(ViewState));

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

		private void exportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//MessageBox.Show("Exporting will overrite all scene and object files. Directories and files are deleted.");

			var folderDialog = new FolderBrowserDialog();
			folderDialog.Description = "Export Root";
			folderDialog.RootFolder = Environment.SpecialFolder.Desktop;
			folderDialog.ShowNewFolderButton = true;
			if(folderDialog.ShowDialog() == DialogResult.OK)
			{
				string objectRoot = Path.Combine(folderDialog.SelectedPath, "objects");
				string sceneRoot = Path.Combine(folderDialog.SelectedPath, "scenes");
				string eventRoot = Path.Combine(folderDialog.SelectedPath, "events");
				string musicRoot = Path.Combine(folderDialog.SelectedPath, "music");
				string soundRoot = Path.Combine(folderDialog.SelectedPath, "sounds");
				string UIroot = Path.Combine(folderDialog.SelectedPath, "UI");

				CheckDirectory(objectRoot);
				CheckDirectory(sceneRoot);

				CheckDirectory(eventRoot);
				CheckDirectory(musicRoot);
				CheckDirectory(soundRoot);
				CheckDirectory(UIroot);

				foreach (var scene in SceneList)
				{
					SaveScene(sceneRoot, scene);
				}

				foreach(var obj in MasterObjectWrappers)
				{
					SaveObjects(objectRoot, obj);
				}

				MessageBox.Show("Export Complete");
			}
		}

		private void SaveObjects(string objectRoot, ObjectWrapper obj)
		{
			var newRoot = Path.Combine(objectRoot, obj.ObjectInfo.Name);
			CheckDirectory(newRoot);

			foreach(var animKey in obj.Animations.Keys)
			{
				SaveObjectAnimation(newRoot, animKey, obj.Animations[animKey]);
			}

			var json = new JavaScriptSerializer().Serialize(obj.ObjectInfo);
			using (StreamWriter writter = new StreamWriter(Path.Combine(newRoot, "MetaData.json"), false))
			{
				writter.Write(json);
			}
		}

		private void SaveObjectAnimation(string parentRoot, string animKey, List<Tuple<string, SillyPictureBox>> images)
		{
			var newRoot = Path.Combine(parentRoot, animKey);
			CheckDirectory(newRoot);
			foreach(var anim in images)
			{
				string filename = anim.Item1 + ".png";
				string filePath = Path.Combine(newRoot, filename);
				anim.Item2.Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
			}
		}

		private void SaveScene(string sceneRoot, Scene scene)
		{
			
			var newRoot = Path.Combine(sceneRoot, scene.Name);
			CheckDirectory(newRoot);

			string backgroundPath = Path.Combine(newRoot, "Background.png");
			scene.Background.Image.Save(backgroundPath, System.Drawing.Imaging.ImageFormat.Png);
			string foregroundPath = Path.Combine(newRoot, "Foreground.png");
			scene.Foreground.Image.Save(foregroundPath, System.Drawing.Imaging.ImageFormat.Png);
			string collisionPath = Path.Combine(newRoot, "Collision.png");
			scene.Collision.Image.Save(collisionPath, System.Drawing.Imaging.ImageFormat.Png);
			string perspectivePath = Path.Combine(newRoot, "Perspective.png");
			scene.Gradiant.Image.Save(perspectivePath, System.Drawing.Imaging.ImageFormat.Png);

			OutputScene outputData = new OutputScene()
			{
				Name = scene.Name,
				Background = "Background.png",
				Foreground = "Foreground.png",
				Collision = "Collision.png",
				Perspective = "Perspective.png",
			};

			foreach(var obj in scene.SceneObjects)
			{
				outputData.Objects.Add(new OutputSceneObject()
				{
					Name = obj.ObjectWrapper.ObjectInfo.Name,
					DefaultAnimation = obj.ObjectWrapper.DefaultAnimation,
					Position = obj.Position
				});
			}
			//Need to add System.Web.Extensions inorder to get this in, which is sort of out of the way
			var json = new JavaScriptSerializer().Serialize(outputData);
			using (StreamWriter writter = new StreamWriter(Path.Combine(newRoot, "MetaData.json"), false))
			{
				writter.Write(json);
			}
		}

		private void CheckDirectory(string path)
		{
			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);
		}

		private void PurgeDirectory(string path)
		{
			if (Directory.Exists(path))
				Directory.Delete(path, true);
			Directory.CreateDirectory(path);
		}
	}
}
