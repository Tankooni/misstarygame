using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissTarryEditor
{
	public class OutputScene
	{
		public string Name { get; set; }
		public string Background { get; set; }
		public string Foreground { get; set; }
		public string Collision { get; set; }
		public string Perspective { get; set; }

		public List<OutputSceneObject> Objects { get; set; }
		public Dictionary<string, PointInfo> Entrances { get; set; }

		public OutputScene()
		{
			Objects = new List<OutputSceneObject>();
			Entrances = new Dictionary<string, PointInfo>();
		}
	}

	public class OutputSceneObject
	{
		public string Name { get; set; }
		public PointInfo Position { get; set; }
		public string DefaultAnimation { get; set; }
	}
}
