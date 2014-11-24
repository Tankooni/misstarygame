/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/24/2014
 * Time: 2:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using Indigo;
using MissTaryGame;

namespace MissTaryGame.Json.Models.Actions
{
	/// <summary>
	/// Description of ActionAddObjectToInventory.
	/// </summary>
	public class ActionAddObjectToInventory : IAction
	{
		public InteractiveObject parent;
		
		public ActionAddObjectToInventory(Dictionary<string, Object> args)
		{
			parent = (InteractiveObject) args["parent"];
			
			if(args.ContainsKey("Object")) {
				//parent = new InteractiveObject(JsonLoader.Load(""), ;
			}
		}
		
		public void run(Action[] remainingActions) {
			var player = ((DynamicSceneWorld) FP.World).avatar;
			
			player.Inventory.Add(parent);
			
			Action.runActions(remainingActions);
		}
	}
}
