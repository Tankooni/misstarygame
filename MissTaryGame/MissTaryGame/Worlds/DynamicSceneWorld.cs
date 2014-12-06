using System;
using System.Collections.Generic;
using Indigo;
using Indigo.Core;
using Indigo.Inputs;
using Indigo.Graphics;
using MissTaryGame.UI;
using MissTaryGame.Json;
using MissTaryGame.Json.Models;

namespace MissTaryGame
{
	public class DynamicSceneWorld : World
	{
		public SceneData metaData;
		public Avatar avatar;
		Cursor cursor;
		public Inventory VeryGenericInventorySystem;
		//List<InteractiveObject> sceneObjects = new List<InteractiveObject>();
		
		bool[,] clickMap;
		
		public Dictionary<string, GameEvent> uncompletedEvents;
		public Dictionary<string, GameEvent> completedEvents = new Dictionary<string, GameEvent>();
		
		public DynamicSceneWorld()
		{
			avatar = new Avatar(JsonLoader.Load<InteractiveObjectData>("objects/Avatar/MetaData"), "Avatar", new float[1,1]{{1}});
			avatar.PlayAnimation("Idle");
			
			cursor = new Cursor();
			VeryGenericInventorySystem = new Inventory(avatar, this);
			
			uncompletedEvents = GameEvent.loadGameEvents("./content/events/");
			
			LoadScene("LivingRoom", "Spawn");
		}
		
		public override void Update()
		{
			base.Update();
			
			if(Mouse.ScreenX >= 0 && Mouse.ScreenX <= clickMap.GetLength(0)-1 && Mouse.ScreenY >= 0 && Mouse.ScreenY <= clickMap.GetLength(1)-1)
				if(Mouse.Left.Pressed && clickMap[(int)Mouse.ScreenX, (int)Mouse.ScreenY])
					avatar.SetWalkTo(Mouse.ScreenX, Mouse.ScreenY);
			
			if(Mouse.Right.Pressed)
			{
				var clickedObject = (InteractiveObject)this.CollidePoint(InteractiveObject.INTERACTIVE_ENTITY_TYPE, Mouse.ScreenX, Mouse.ScreenY);
				if(clickedObject != null)
				{
					Add(new CommandWheel(clickedObject.MetaData.Commands));
//					if(!inventory.IsInInventory(clickedObject))
//					{
//						Remove(clickedObject);
//						inventory.AddItem(clickedObject);
//					}
				}
//				Console.WriteLine(clickedObject);
			}
			
			if(Keyboard.I.Pressed)
				VeryGenericInventorySystem.Active = !VeryGenericInventorySystem.Active;
			
			if(Keyboard.Q.Pressed)
				LoadScene("ExampleScene", "Spawn");
			if(Keyboard.E.Pressed)
				LoadScene("LivingRoom", "Spawn");
		}
		
		public void LoadScene(string sceneName, string entrance)
		{
			this.RemoveAll();
			
			metaData = JsonLoader.Load<SceneData>("scenes/" + sceneName + "/MetaData");
			float[,] perspectiveMap = avatar.PerspectiveMap = Utility.LoadAndProcessPerspectiveMap("content/scenes/" + sceneName + "/" + metaData.Perspective, 0.1f, 0.9f);
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
			
			
			//put the player at an entrance
			var entryPoint = metaData.Entrances[entrance];
			avatar.X = entryPoint.X;
			avatar.Y = entryPoint.Y;
			this.Add(avatar);
			this.Add(cursor);
			this.Add(VeryGenericInventorySystem);
			
			if(metaData.Foreground != null)
		   	{
			   	var foreground = new Entity{ Layer = Utility.FOREGROUND_LAYER };
				foreground.AddComponent(new Image(Library.GetTexture("content/scenes/" + sceneName + "/" + metaData.Foreground)));
				Add(foreground);
		   }
		}
	}
}