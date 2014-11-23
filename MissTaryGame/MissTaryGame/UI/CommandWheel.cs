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
using Indigo.Core;
using MissTaryGame.Json.Models;
using Action = MissTaryGame.Json.Models.Action;

namespace MissTaryGame.UI
{
	/// <summary>
	/// Description of CommandWheel.
	/// </summary>
	public class CommandWheel : Entity
	{
		public CommandData[] commands { get; set; }
		public Image wheel;
		
		private Graphiclist gcommands;
		private Point lastMouse;
		private CommandData lastc;
		
		private Dictionary<CommandData, Image> commandImages = new Dictionary<CommandData, Image>();
		
		public CommandWheel(CommandData[] commandData)
		{
			commands = commandData;
			lastMouse = new Point(Mouse.ScreenX, Mouse.ScreenY);
			
			//Make the wheel
			wheel = new Image(Library.GetTexture("./content/UI/CommandWheel/Wheel.png"));
			wheel.CenterOO();
			
			X = Mouse.ScreenX;
			Y = Mouse.ScreenY;
			
			Layer = Utility.WHEEL_UI_LAYER;
			
			AddComponent(wheel);
		
			//Add commands
			gcommands = new Graphiclist();
			
			if(commands != null && commands.Length > 0)
			{
				int deg = -90, deginc = 360 / commands.Length;
				
				foreach(var c in commands) {
					Image img = new Image(Library.GetTexture("./content/UI/CommandWheel/" + c.Name + ".png"));
					img.CenterOO();
					img.Y = -wheel.Height/2 + img.Height/2;
					FP.AngleXY(ref img.X, ref img.Y, deg, wheel.Height/2 - img.Height/2);
					
					commandImages.Add(c, img);
					deg += deginc;
					
					gcommands.Add(img);
				}
			}
			
			AddComponent(gcommands);
		}
		
		public override void Update() {
			//make the wheel spin
			wheel.Angle -= 1;
			
			//keep track of mouse movement direction
			Point cMouse = new Point(Mouse.ScreenX, Mouse.ScreenY);
			int angle = (int)FP.Angle(cMouse.X, cMouse.Y, lastMouse.X, lastMouse.Y);
			
			if(commands != null && commands.Length > 0)
			{
				if(lastMouse != cMouse) {
					//check which command is being selected
					int deginc = 360 / commands.Length;
					//turn angle to '0'
					angle += deginc/2 + 270;
					//find index of the command
					angle /= deginc;
					angle %= commands.Length;
					lastc = commands[angle];
		
					//clear the last update scaling
					foreach(var img in commandImages.Values) {
						img.Scale = 1;
					}
					// Make it bigger to show its selected
					commandImages[lastc].Scale = 2;
				}
			}
			//Fire it if clicked
			if(Mouse.Left.Pressed) {
				if(lastc != null && lastc.Actions != null && lastc.Actions.Length > 0) {
					Action.runActions(lastc.Actions);
					
					World.Remove(this);
				}
			} else if(Mouse.Right.Pressed) {
				World.Remove(this);
			}
			
			
			//update last mouse
			lastMouse = cMouse;
		}
	}
}
