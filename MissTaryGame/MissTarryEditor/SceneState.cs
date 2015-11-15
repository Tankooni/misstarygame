using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissTarryEditor
{
	[Flags]
	public enum SceneStates
	{
		None = 1,
		Foreground = 2,
		Background  = 4,
		Objects = 8,
		Collision = 16,
		Gradiant = 32,
	}
}
