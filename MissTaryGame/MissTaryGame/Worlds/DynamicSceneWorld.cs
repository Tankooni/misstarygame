using System;
using Indigo;
using Indigo.Core;
using Indigo.Inputs;
using Indigo.Graphics;
using MissTaryGame.Json;
using MissTaryGame.Json.Models;
namespace MissTaryGame
{
	public class DynamicSceneWorld : World
	{
		InteractiveObject avatar;
		Point walkTo;
		float[,] perspectiveMap;
		bool[,] clickMap;
		
		public DynamicSceneWorld()
		{
//			this.AddGraphic(new Image(Library.GetTexture("content/ExampleScene/ExampleScene_Perspective.png")));
			this.AddGraphic(new Image(Library.GetTexture("content/ExampleScene/ExampleScene_Background.png")));
			avatar = new InteractiveObject(JsonLoader.Load<InteractiveObjectData>("Avatar/MetaData"));
			var texture = new Image(Library.GetTexture("content/ExampleScene/ExampleScene_Perspective.png"));
			perspectiveMap = avatar.PerspectiveMap = Utility.LoadAndProcessPerspectiveMap("content/ExampleScene/ExampleScene_Perspective.png", 0.1f, 0.9f);
			clickMap = Utility.LoadAndProcessClickMap("content/ExampleScene/ExampleScene_Collision.png");
			this.Add(avatar);
		}
		
		public override void Update()
		{
			base.Update();
			
			
			if(Mouse.Left.Pressed && clickMap[(int)Mouse.ScreenX, (int)Mouse.ScreenY])
				walkTo = new Point(Mouse.ScreenX, Mouse.ScreenY);
			avatar.MoveTowards(walkTo.X, walkTo.Y, FP.Elapsed * avatar.MoveSpeedX);
//			
//			if(Keyboard.W.Down)
//				avatar.Y -= FP.Elapsed * avatar.MoveSpeedY;
//			if(/*butts == butts*/Keyboard.S.Down)
//				avatar.Y += FP.Elapsed * avatar.MoveSpeedY;
//			if(Keyboard.D.Down)
//				avatar.X += FP.Elapsed * avatar.MoveSpeedX;
//			if(Keyboard.A.Down)
//				avatar.X -= FP.Elapsed * avatar.MoveSpeedX;
		}
	}
}