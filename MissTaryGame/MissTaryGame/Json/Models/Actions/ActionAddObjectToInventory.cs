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
		public Dictionary<string, Object> args;
		
		public ActionAddObjectToInventory(Dictionary<string, Object> args)
		{
			this.args = args;
			
			if(args.ContainsKey("Object")) {
				//parent = new InteractiveObject(JsonLoader.Load(""), ;
			}
		}
		
		public void run(Action[] remainingActions) {
			var inventory = ((DynamicSceneWorld) FP.World).VeryGenericInventorySystem;
			
			var parent = (InteractiveObject) args["parent"];
			inventory.AddItem(parent);
			
			if(remainingActions.Length > 0) {
				var action = remainingActions[0];
				var tempArray = new Action[remainingActions.Length-1];
				Array.Copy(remainingActions, 1, remainingActions, 0, tempArray.Length);
				
				action.run(tempArray);
			}
		}
	}
}
