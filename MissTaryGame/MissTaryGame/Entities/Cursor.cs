using System;
using Indigo;
using Indigo.Graphics;
using Indigo.Inputs;

namespace MissTaryGame
{
	/// <summary>
	/// Description of Cursor.
	/// </summary>
	public class Cursor : Entity
	{
		Image cursorUp;
		Image cursorDown;
		
		public bool PointUp
		{
			get
			{
				return cursorUp.Visible;
			}
			set
			{
				cursorDown.Visible = !(cursorUp.Visible = value);
			}
		}
		
		public Cursor()
		{
			cursorUp = new Image(Library.GetTexture("content/UI/Cursor/Cursor01.png"));
			cursorDown = new Image(Library.GetTexture("content/UI/Cursor/Cursor02.png")){
				Visible = false
			};
			this.AddComponent(cursorUp);
			this.AddComponent(cursorDown);
		}
		
		public override void Update()
		{
			base.Update();
			this.X = Mouse.ScreenX;
			this.Y = Mouse.ScreenY;
		}
	}
}
