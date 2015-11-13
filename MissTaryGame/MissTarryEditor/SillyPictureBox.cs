using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissTarryEditor
{
	public class SillyPictureBox : PictureBox
	{
		public SceneObject ParentRef { get; set; }
		public SillyPictureBox()
		{
			ParentRef = null;
		}
	}
}
