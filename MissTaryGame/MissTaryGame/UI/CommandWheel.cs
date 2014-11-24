/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/23/2014
 * Time: 9:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using Indigo;
using Indigo.Graphics;
using Indigo.Inputs;
using MissTaryGame.Json.Models;

namespace MissTaryGame.UI
{
	/// <summary>
	/// Description of CommandWheel.
	/// </summary>
	public class CommandWheel : Entity
	{
		public List<CommandData> commands { get; set; }
		public Image wheel;
		
		private Graphiclist gcommands;
		
		public CommandWheel(List<CommandData> commandData)
		{
			commands = commandData;
			
			//Make the wheel
			wheel = new Image(Library.GetTexture("./content/UI/CommandWheel/Wheel.png"));
			wheel.CenterOO();
			
			X = Mouse.ScreenX;
			Y = Mouse.ScreenY;
			
			Layer = 1000;
			
			AddComponent(wheel);
		
			//Add commands
			gcommands = new Graphiclist();
			
			int deg = 0, deginc = 360 / commands.Count;
			
			foreach(var c in commands) {
				Image img = new Image(Library.GetTexture("./content/UI/CommandWheel/" + c.Name + ".png"));
				img.CenterOO();
				img.Y = -wheel.Height/2 + img.Height/2;
				
				gcommands.Add(img);
			}
			
			AddComponent(gcommands);
		}
		
		public override void Update() {
			wheel.Angle -= 1;
			
			//check if mouse is hovering over a command
			/*foreach( Image c in gcommands ) {
				//c.
			}*/
		}
	}
}
