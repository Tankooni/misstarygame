using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissTarryEditor
{
	public partial class SceneAdder : Form
	{
		public Scene NewScene = null;
		private ContextMenu PanelMenu = null;
        public SceneAdder(ContextMenu menu)
		{
			InitializeComponent();
			PanelMenu = menu;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			string name = "DefaultName";
			if (textBox1.Text != "" && textBox1.Text != null)
				name = textBox1.Text;
			NewScene = new Scene(name, GetNewPanel());
		}

		private SillyPanel GetNewPanel()
		{
			SillyPanel basePanel = new SillyPanel();
			basePanel.Location = new Point(126, 27);
			basePanel.Size = new Size(1136, 640);
			//var mouseDown = new MouseEventHandler(ParentForm.Form1_MouseDown);
			//basePanel.MouseDown += mouseDown;
			basePanel.ContextMenu = PanelMenu;
			basePanel.BackColor = Color.Transparent;
			return basePanel;
		}
	}
}
