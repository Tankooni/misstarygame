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
		
		public CommandWheel()
		{
			wheel = new Image(Library.GetTexture("./content/UI/CommandWheel/Wheel.png"));
			wheel.CenterOO();
			
			wheel.X = Mouse.ScreenX;
			wheel.Y = Mouse.ScreenY;
			
			Layer = 1000;
			
			AddComponent(wheel);
		}
		
		public override void Update() {
			wheel.Angle += 2;
		}
	}
}
