using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissTarryEditor
{
	public class ObjectWrapper
	{
		[TypeConverter(typeof(ExpandableObjectConverter))]
		public ObjectInfo ObjectInfo { get; set; }
		[Browsable(false)]
		public Dictionary<string, List<Tuple<string,SillyPictureBox>>> Animations { get; set; }
		[Browsable(false)]
		public string DefaultAnimation { get; set; }

		public ObjectWrapper()
		{
			ObjectInfo = new ObjectInfo();
			Animations = new Dictionary<string, List<Tuple<string, SillyPictureBox>>>();
		}

		public void AddAnimation(string name, string fileName, SillyPictureBox picture)
		{
			if (!Animations.ContainsKey(name))
				Animations.Add(name, new List<Tuple<string, SillyPictureBox>>());
			Animations[name].Add(new Tuple<string, SillyPictureBox>(fileName, picture));

			var anim = ObjectInfo.Animations.FirstOrDefault(x => x.Name == name);
			if (anim == null)
			{
				ObjectInfo.Animations.Add(new AnimationData()
				{
					Name = name,
					Frames = 1
				});
			}
			else
				anim.Frames = Animations[name].Count;
		}

		public override string ToString()
		{
			return ObjectInfo.Name;
		}
	}
}
