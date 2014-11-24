﻿/*
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
			FP.Screen.ClearColor = FP.Color(0x000000);
			Mouse.CursorVisible = false;
			
			//SoundManager.Init(0.8f);
			SoundManager.Init(0);
			FP.World = new DynamicSceneWorld();
			//FP.World = new StartScreenWorld();

			SoundManager.PlayMusic();
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