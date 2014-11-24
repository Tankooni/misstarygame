/*
 * Created by SharpDevelop.
 * User: Croanc
 * Date: 11/21/2014
 * Time: 10:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Indigo;
using Indigo.Inputs;

namespace MissTaryGame
{
	class Game : Engine
	{
		public static float Lol = 10;

		public static void Main(string[] args)
		{
			var game = new Game();
			game.Run();
	    }

		public Game() :
			base(1136, 641, 60)
		{
			FP.Console.Enable();
			
			Mouse.CursorVisible = false;
			//FP.World = new DynamicSceneWorld();
			FP.World = new StartScreenWorld();
			FP.Screen.ClearColor = FP.Color(0x000000);
			
			FP.Console.Enable();
			Mouse.CursorVisible = false;
		}

		public override void FocusLost()
		{
			base.FocusLost();
			this.Paused = true;
		}

		public override void FocusGained()
		{
			base.FocusGained();
			if(!FP.Console.IsOpen)
				this.Paused = false;
		}
	}
}