using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissTarryEditor
{
	public class ObjectInfo
	{
		public string Name { get; set; }
		public Point FramSize { get; set; }
		public Point HotSpot { get; set; }
		public bool Scaling { get; set; }
		public bool Moving { get; set; }

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public List<AnimationData> Animations { get; set; }
		[TypeConverter(typeof(ExpandableObjectConverter))]
		public List<CommandData> Commands { get; set; }

		public ObjectInfo()
		{
			FramSize = new Point();
			HotSpot = new Point();
			Animations = new List<AnimationData>();
			Commands = new List<CommandData>();
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
