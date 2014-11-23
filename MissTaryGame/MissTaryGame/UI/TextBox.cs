/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/23/2014
 * Time: 8:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Indigo;
using Indigo.Graphics;
using Indigo.Inputs;

namespace MissTaryGame.UI
{
	/// <summary>
	/// Description of TextBox.
	/// </summary>
	public class TextBox : Entity
	{
		private Image box;
		
		public TextBox()
		{
			//Load text box background
			box = new Image(Library.GetTexture("./content/UI/TextBox/TextBox.png"));
			Y = FP.Height - box.Height;
			
			AddComponent(box);
		}
		
		public void show(string text) {
			var img_text = new Text(text, 10, 4);
			img_text.Font = Library.GetFont("./content/UI/Fonts/TektonPro-Bold.otf");
			img_text.Size = 18;
		
			AddComponent(img_text);
		}
		public void showFile(string path) {
			show(Library.GetText(path));
		}
		
		public override void Update() {
			base.Update();
			
			if(Mouse.Left.Pressed || Keyboard.Space.Pressed) {
				this.World.Remove(this);
			}
		}
	}
}
