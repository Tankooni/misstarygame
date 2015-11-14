/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/23/2014
 * Time: 8:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using Indigo;
using Indigo.Graphics;
using Indigo.Inputs;
using Indigo.Content;

namespace MissTaryGame.UI
{
	/// <summary>
	/// Description of TextBox.
	/// </summary>
	public class TextBox : Entity
	{
		public delegate void OnRemove();
		public OnRemove onRemove;
		
		private Image box;
		private Font font;
		private int fontSize;
		private int vPadding, hPadding;
		
		private List<string> lines;
		
		public TextBox(string text, string fontPath = "./content/UI/Fonts/TektonPro-Bold.otf", int fontSize = 24)
		{
			font = Library.GetFont(fontPath);
			this.fontSize = fontSize;
			
			//padding
			vPadding = 5;
			hPadding = 12;
			
			//Load text box background
			box = new Image(Library.GetTexture("./content/UI/TextBox/TextBox.png"));
			Y = FP.Height - box.Height;
			
			// word wrap
			List<string> words = new List<string>(text.Split(' '));
			lines = new List<string>();
			lines.Add("");
			int current_width = 0;
			foreach( string s in words ) {
				int word_width = 0;
				foreach( char c in s ) {
					word_width += font.GetGlyphAdvance(c, fontSize, false);
				}
				current_width += word_width + font.GetGlyphAdvance(' ', fontSize, false);
				
				//add it to the current line if it is
				if(current_width < box.Width - hPadding) {
					lines[lines.Count-1] += ' ' + s;
				} else {
					lines.Add(s);
					current_width = word_width;
				}
			}
			
			AddComponent(box);
		}
		
		public void show() {
			int i;
			for(i = 0; i < lines.Count; i++ ) {
				if( (font.GetLineSpacing(fontSize) + vPadding) * (i+1) > box.Height ) {
					break;
				}
				
				var img_text = new Text(lines[i], hPadding, font.GetLineSpacing(fontSize)*i + vPadding);
				img_text.Font = Library.GetFont("./content/UI/Fonts/TektonPro-Bold.otf");
				img_text.Size = fontSize;
				AddComponent(img_text);
			}
			lines.RemoveRange(0, i);
		}
//		public void showFile(string path) {
//			show(Library.GetText(path));
//		}
		
		public override void Update() {
			base.Update();
			
			if(Mouse.Left.Pressed || Keyboard.Space.Pressed) {
				if(lines.Count == 0) {
					World.Remove(this);
				} else {
					foreach(var c in GetComponents(typeof(Text))) {
						RemoveComponent(c);
					}
					show();
				}
			}
		}
		
		public override void Removed()
		{
			base.Removed();
			onRemove();
		}
	}
}
