using System;
using System.Collections.Generic;
using Indigo;
using Indigo.Core;
using Indigo.Inputs;
using Indigo.Graphics;
using Indigo.Masks;
using MissTaryGame.Pathing;
using MissTaryGame.UI;
using MissTaryGame.Json;
using MissTaryGame.Json.Models;

namespace MissTaryGame
{
	public class DynamicSceneWorld : World
	{
		public SceneData metaData;
		public readonly Avatar avatar;
		private readonly Cursor cursor;
		public Inventory VeryGenericInventorySystem;
		//List<InteractiveObject> sceneObjects = new List<InteractiveObject>();
		
		private bool[,] clickMap;
		private readonly PathNode[,] pathNodes;
		private readonly int TileSize = 16;
		private readonly Grid nodeGrid;
		private readonly Entity nodeGridEntity;
		
		public Dictionary<string, GameEvent> uncompletedEvents;
		public Dictionary<string, GameEvent> completedEvents = new Dictionary<string, GameEvent>();
		
		public DynamicSceneWorld()
		{
			avatar = new Avatar(JsonLoader.Load<InteractiveObjectData>("objects/Avatar/MetaData"), "Avatar", new float[1,1]{{1}});
			avatar.PlayAnimation("Idle");
			
			cursor = new Cursor();
			VeryGenericInventorySystem = new Inventory(avatar, this);

			pathNodes = new PathNode[FP.Width / TileSize, FP.Height / TileSize];
			for(int x = 0; x < pathNodes.GetLength(0); x++)
				for(int y = 0; y < pathNodes.GetLength(1); y++)
					pathNodes[x,y] = new PathNode(null, x * TileSize + TileSize / 2, y * TileSize + TileSize / 2, false);
			for(int x = 0; x < pathNodes.GetLength(0); x++)
				for(int y = 0; y < pathNodes.GetLength(1); y++)
					PathNode.ConnectedNodes[pathNodes[x,y]] = Utility.SelectTilesAroundTile(x, y, pathNodes);
			nodeGridEntity = new Entity();
			nodeGridEntity.AddComponent<Grid>(nodeGrid = new Grid(FP.Width, FP.Height, TileSize, TileSize));
			nodeGridEntity.Type = "ClickMap";
			Add(nodeGridEntity);
			
			uncompletedEvents = GameEvent.loadGameEvents("./content/events/");
			
			LoadScene("LivingRoom", "Spawn");
		}
		
		public override void Update()
		{
			base.Update();
			
			if(Mouse.ScreenX >= 0 && Mouse.ScreenX <= FP.Width && Mouse.ScreenY >= 0 && Mouse.ScreenY <= FP.Height)
			{
				if(!CommandWheel.IsOpen && Mouse.Left.Pressed && CollidePoint("ClickMap", MouseX, MouseY) != null)
				{					
//					Console.WriteLine("Start " + (int)(avatar.X / TileSize) + " " + (int)(avatar.Y / TileSize) 
//					                  + (int)(Mouse.ScreenX / TileSize) + " " + (int)(Mouse.ScreenY / TileSize));
					avatar.SetWalkTo(Utility.SelectAstarPath(/*pathNodes[33,25], pathNodes[42,15], pathNodes*/
										pathNodes[(int)(Mouse.ScreenX / TileSize),(int)(Mouse.ScreenY / TileSize)], 
										pathNodes[(int)(avatar.X / TileSize),(int)(avatar.Y / TileSize)],
										pathNodes));
//					Console.WriteLine("End " + (int)(avatar.X / TileSize) + " " + (int)(avatar.Y / TileSize) 
//					                  + (int)(Mouse.ScreenX / TileSize) + " " + (int)(Mouse.ScreenY / TileSize));
				}
			}
			if(Mouse.Right.Pressed)
			{
				var clickedObject = (InteractiveObject)this.CollidePoint(InteractiveObject.INTERACTIVE_ENTITY_TYPE, Mouse.ScreenX, Mouse.ScreenY);
				if(clickedObject != null)
					Add(new CommandWheel(clickedObject.MetaData.Commands));
			}
			
			if(Keyboard.I.Pressed)
				VeryGenericInventorySystem.IsActive = !VeryGenericInventorySystem.IsActive;
			
			if(Keyboard.Q.Pressed)
				LoadScene("ExampleScene", "Spawn");
			if(Keyboard.E.Pressed)
				LoadScene("LivingRoom", "Spawn");
		}
		
		public void LoadScene(string sceneName, string entrance)
		{
			RemoveAll();
			
			metaData = JsonLoader.Load<SceneData>("scenes/" + sceneName + "/MetaData");
			float[,] perspectiveMap = avatar.PerspectiveMap = Utility.LoadAndProcessPerspectiveMap("content/scenes/" + sceneName + "/" + metaData.Perspective, 0.1f, 0.9f);
			
			Utility.LoadAndProcessClickMap("content/scenes/" + sceneName + "/" + metaData.Collision, pathNodes, nodeGrid, TileSize);
			Add(nodeGridEntity);
			
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

			var foreground = new Entity{ Layer = Utility.FOREGROUND_LAYER };
			if(metaData.Foreground != null)
				foreground.AddComponent(new Image(Library.GetTexture("content/scenes/" + sceneName + "/" + metaData.Foreground)));
			Add(foreground);
		}
	}
}