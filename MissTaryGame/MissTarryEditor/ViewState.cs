using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissTarryEditor
{
	[Flags]
	public enum ViewState
	{
		Foreground = 1,
		Background = 2,
		Collision = 4,
		Gradiant = 8
	}
}
