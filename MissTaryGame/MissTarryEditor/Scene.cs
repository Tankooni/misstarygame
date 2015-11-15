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

		public Scene(string name, SillyPanel panel)
		{
			Name = name;
			MasterPanel = panel;
			SceneObjects = new List<SceneObject>();
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
			foreach (var obj in SceneObjects)
			{
				var picture = obj.ObjectWrapper.Animations.First().Value.First().Item2;
				picture.Location = obj.Position;
				picture.ParentRef = obj;
				MasterPanel.Controls.Add(picture);
			}
			if (viewState.HasFlag(SceneStates.Foreground))
				if (Foreground != null)
				{
					Foreground.Visible = false;
					MasterPanel.Controls.Add(Foreground);
				}
			return MasterPanel;
		}

		public override string ToString()
		{
			return Name;
		}
	}

	public class SceneObject
	{
		public ObjectWrapper ObjectWrapper { get; set; }
		public Point Position { get; set; }
		public string DefaultAnimation { get; set; }
	}
}
