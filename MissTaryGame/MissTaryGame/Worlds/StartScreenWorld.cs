/*
 * Created by SharpDevelop.
 * User: Croanc
 * Date: 11/21/2014
 * Time: 11:19 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Indigo;
using Indigo.Inputs;
using Indigo.Graphics;

namespace MissTaryGame
{
	/// <summary>
	/// Description of StartScreenGame.
	/// </summary>
	public class StartScreenWorld : World
	{
		private Text start;
        private Text instructions;
		public StartScreenWorld()
		{
            start = new Text("Start [Enter]");
            start.X = (FP.Width / 2) - (start.Width / 2);
            start.Y = (FP.Height / 3) + 25;

            instructions = new Text("Instructions [Space]");
            instructions.X = (FP.Width / 2) - (instructions.Width / 2);
            instructions.Y = (FP.Height / 3) + 50;

            AddGraphic(start);
            AddGraphic(instructions);
		}

		public override void Update()
		{
			base.Update();
//            if (Keyboard.Return.Pressed)
//                FP.World = new GameWorld();
//
//            if (Keyboard.Space.Pressed)
//                FP.World = new InstructionsScreenWorld();
		}
	}
}
