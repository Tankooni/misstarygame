using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissTarryEditor
{
	public class Scene
	{
		public string Name { get; set; }
		public List<SceneObject> SceneObjects { get; set; }
		public SillyPanel MasterPanel { get; set; }
		public PictureBox Foreground { get; set; }
		public PictureBox Background { get; set; }
		public PictureBox Collision { get; set; }
		public PictureBox Gradiant { get; set; }

		public Scene(string name, SillyPanel panel)
		{
			Name = name;
			MasterPanel = panel;
			SceneObjects = new List<SceneObject>();
			MasterPanel.MouseMove += Form1_MouseMove;
			MasterPanel.MouseDown += Form1_MouseDown;
			MasterPanel.Tag = "Master";
		}

		public Panel GetUpdatedPanel(SceneStates viewState)
		{	
			MasterPanel.Controls.Clear();
			if (viewState.HasFlag(SceneStates.Background))
				if (Background != null)
				{
					Background.Visible = false;
					MasterPanel.Controls.Add(Background);
				}
			if (viewState.HasFlag(SceneStates.Objects))
			{
				foreach (var obj in SceneObjects)
				{
					//var picture = obj.ObjectWrapper.Animations.First().Value.First().Item2;
					//picture.Location = obj.Position;
					//picture.ParentRef = obj;
					MasterPanel.Controls.Add(obj.DisplayImage);
				}
			}
			if (viewState.HasFlag(SceneStates.Foreground))
				if (Foreground != null)
				{
					Foreground.Visible = false;
					MasterPanel.Controls.Add(Foreground);
				}
			if(viewState.HasFlag(SceneStates.Collision))
				if(Collision != null)
				{
					Collision.Visible = false;
					MasterPanel.Controls.Add(Collision);
				}
			if (viewState.HasFlag(SceneStates.Gradiant))
				if (Gradiant != null)
				{
					Gradiant.Visible = false;
					MasterPanel.Controls.Add(Gradiant);
				}
			return MasterPanel;
		}

		public SceneObject AddSceneObject(ObjectWrapper wrapper)
		{
			var newObj = new SceneObject(wrapper);
			SceneObjects.Add(newObj);
			return newObj;
		}

		public SceneObject SelectedObject = null;

		public void SetSelectedobject(SceneObject obj)
		{
			SelectedObject = obj;
			SelectedObject.DisplayImage.MouseDown += Form1_MouseDown;
		}
		//private int invalidateCount = 0;
		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			if (SelectedObject == null)
				return;

			var coordinates = ((Control)sender).PointToClient(Cursor.Position);
			SelectedObject.Position = coordinates;
			//if (invalidateCount >= 3)
			//{
				this.MasterPanel.Invalidate();
			//	invalidateCount = 0;
			//}
			//else
			//	invalidateCount++;
		}

		public void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			
			if (e.Button == MouseButtons.Left)
			{
				if (SelectedObject != null)
				{
					SelectedObject = null;
					this.MasterPanel.Invalidate();
				}
				else
				{
					var coordinates = ((Control)sender).PointToClient(Cursor.Position);
					if (sender.GetType() == typeof(PictureBox))
					{
						SelectedObject = SceneObjects.FirstOrDefault(x => x.DisplayImage == ((PictureBox)sender));
					}
					else if(sender == MasterPanel)
					{
						foreach(var obj in SceneObjects)
						{
							var newRect = new Rectangle(obj.Position, obj.DisplayImage.Image.Size);
							var clickRect = new Rectangle(coordinates, new Size(1, 1));
							if (newRect.IntersectsWith(clickRect))
								SelectedObject = obj;
						}
						//SelectedObject = SceneObjects.Where(x=>x.DisplayImage.ClientRectangle
						//	.IntersectsWith(new Rectangle(x.DisplayImage.PointToClient(Cursor.Position), new Size(1, 1)))).FirstOrDefault();
					}
				}
			}
		}


		public override string ToString()
		{
			return Name;
		}
	}

	public class SceneObject
	{
		public SceneObject(ObjectWrapper wrapper)
		{
			ObjectWrapper = wrapper;
		}

		public ObjectWrapper ObjectWrapper { get; set; }
		public Point Position
		{
			get
			{
				return new Point
					(
						DisplayImage.Location.X /*+ ObjectWrapper.ObjectInfo.HotSpot.X*/,
						DisplayImage.Location.Y /*+ ObjectWrapper.ObjectInfo.HotSpot.Y*/
					);
			}
			set
			{
				if (DisplayImage != null)
					DisplayImage.Location = new Point
						(
							value.X - ObjectWrapper.ObjectInfo.HotSpot.X,
							value.Y - ObjectWrapper.ObjectInfo.HotSpot.Y
							);
			}
		}
		private SillyPictureBox m_DisplayImage;
		public SillyPictureBox DisplayImage
		{
			get
			{
				if (m_DisplayImage == null)
				{
					m_DisplayImage = new SillyPictureBox();
					m_DisplayImage.Location = ObjectWrapper.Animations.First().Value.First().Item2.Location;
					m_DisplayImage.Image = ObjectWrapper.Animations.First().Value.First().Item2.Image;
					m_DisplayImage.ParentRef = this;
				}
				return m_DisplayImage;
            }
			set
			{
				m_DisplayImage = value;
			}
		}
	}
}
