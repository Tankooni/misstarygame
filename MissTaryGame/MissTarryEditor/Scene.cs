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
		public Dictionary<EditState,List<SceneObject>> SceneObjects { get; set; }
		public Dictionary<EditState, Panel> Panels { get; set; }

		public Scene()
		{
			Name = "DefaultName";
			SceneObjects = new Dictionary<EditState, List<SceneObject>>();
			Panels = new Dictionary<EditState, Panel>();
		}

		public Panel GetUpdatePanel(EditState state)
		{
			var target = Panels[state];
			target.Controls.Clear();
			foreach (var obj in SceneObjects[state])
			{
				var picture = obj.ObjectWrapper.Animations.First().Value.First().Item2;
				picture.Location = obj.Position;
				picture.ParentRef = obj;
				target.Controls.Add(picture);
			}
			return target;
		}
	}

	public class SceneObject
	{
		public ObjectWrapper ObjectWrapper { get; set; }
		public Point Position { get; set; }
		public string DefaultAnimation { get; set; }
	}
}
