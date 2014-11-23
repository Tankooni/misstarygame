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
		SceneData metaData;
		InteractiveObject avatar;
		Cursor cursor;
		Point walkTo;
		float[,] perspectiveMap;
		bool[,] clickMap;
		
		public DynamicSceneWorld()
		{
			string sceneName = "LivingRoom";
			metaData = JsonLoader.Load<SceneData>("scenes/" + sceneName + "/MetaData");
			perspectiveMap = Utility.LoadAndProcessPerspectiveMap("content/scenes/" + sceneName + "/" + metaData.Perspective, 0.1f, 0.9f);
			clickMap = Utility.LoadAndProcessClickMap("content/scenes/" + sceneName + "/" + metaData.Collision);
			var background = new Entity{ Layer = Utility.BACKGROUND_LAYER };
			background.AddComponent(new Image(Library.GetTexture("content/scenes/" + sceneName + "/" + metaData.Background)));
			Add(background);
			//this.AddGraphic(new Image(Library.GetTexture("content/scenes/" + sceneName + "/" + metaData.Collision)));
			
			foreach(var sceneObject in metaData.Objects)
			{
				var interactiveObject = new InteractiveObject(JsonLoader.Load<InteractiveObjectData>(@"objects/" + sceneObject.Name + @"/MetaData"), sceneObject.Name, perspectiveMap);
				interactiveObject.X = sceneObject.Position.X;
				interactiveObject.Y = sceneObject.Position.Y;
				interactiveObject.PlayAnimation(sceneObject.defaultAnimation);
				this.Add(interactiveObject);
			}
			
			avatar = new InteractiveObject(JsonLoader.Load<InteractiveObjectData>("objects/Avatar/MetaData"), "Avatar", perspectiveMap);
			this.Add(avatar);
			
			var foreground = new Entity{ Layer = Utility.FOREGROUND_LAYER };
			foreground.AddComponent(new Image(Library.GetTexture("content/scenes/" + sceneName + "/" + metaData.Foreground)));
			Add(foreground);
			
			//this.AddGraphic(new Image(Library.GetTexture("content/scenes/" + sceneName + "/" + metaData.Foreground)));
			this.Add(cursor = new Cursor());
		}
		
		public override void Update()
		{
			base.Update();
			
			if(Mouse.ScreenX >= 0 && Mouse.ScreenX <= clickMap.GetLength(0)-1 && Mouse.ScreenY >= 0 && Mouse.ScreenY <= clickMap.GetLength(1)-1)
			{
				if(Mouse.Left.Pressed && clickMap[(int)Mouse.ScreenX, (int)Mouse.ScreenY])
					walkTo = new Point(Mouse.ScreenX, Mouse.ScreenY);
			}
			
				
			avatar.MoveTowards(walkTo.X, walkTo.Y, FP.Elapsed * avatar.MoveSpeedX);
			
			var currentAnimaion = avatar.CheckAnimation();
			if(currentAnimaion.Contains("Walk") && (int)avatar.X == (int)walkTo.X && (int)avatar.Y == (int)walkTo.Y)
				avatar.PlayAnimation("Idle");
			else if((int)avatar.X != (int)walkTo.X && (int)avatar.Y != (int)walkTo.Y)
			{
				var walkAngle = FP.Angle(avatar.X, avatar.Y, walkTo.X, walkTo.Y);
				
				//Console.WriteLine("Angle: " + walkAngle);
				bool flip = walkAngle >= 90 && walkAngle <= 270;
				if(avatar.Flipped != flip)
					avatar.Flipped = flip;
				if(currentAnimaion != "WalkUp" &&  walkAngle<= 180)
					avatar.PlayAnimation("WalkUp");
				else if(currentAnimaion != "WalkDown" && walkAngle > 180)
					avatar.PlayAnimation("WalkDown");
			}
			
			
			
		}
	}
}