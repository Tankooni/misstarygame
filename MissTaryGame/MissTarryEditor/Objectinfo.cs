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
		public PointInfo FramSize { get; set; }
		public PointInfo HotSpot { get; set; }
		public bool Scaling { get; set; }
		public bool Moving { get; set; }

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public List<AnimationData> Animations { get; set; }
		[TypeConverter(typeof(ExpandableObjectConverter))]
		public List<CommandData> Commands { get; set; }

		public ObjectInfo()
		{
			FramSize = new PointInfo();
			HotSpot = new PointInfo();
			Animations = new List<AnimationData>();
			Commands = new List<CommandData>();
		}

		public override string ToString()
		{
			return Name;
		}
	}

	public struct PointInfo
	{
		public int X { get; set; }
		public int Y { get; set; }
	}
}
