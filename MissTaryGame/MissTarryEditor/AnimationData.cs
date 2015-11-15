using System.Collections.Generic;

namespace MissTarryEditor
{
	public class AnimationData
	{
		public string Name { get; set; }
		public int Frames { get; set; }
		public int FPS { get; set; }
		public List<int> FootStepFrames { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}