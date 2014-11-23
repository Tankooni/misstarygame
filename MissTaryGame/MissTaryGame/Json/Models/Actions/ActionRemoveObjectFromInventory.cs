/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/24/2014
 * Time: 2:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using Indigo;

namespace MissTaryGame.Json.Models.Actions
{
	/// <summary>
	/// Description of ActionRemoveObjectFromInventory.
	/// </summary>
	public class ActionRemoveObjectFromInventory : IAction
	{
		public Dictionary<string, Object> args;
		
		public ActionRemoveObjectFromInventory(Dictionary<string, Object> args)
		{
			this.args = args;
		}
		
		public void run(Action[] remainingActions) {
			var inventory = ((DynamicSceneWorld) FP.World).VeryGenericInventorySystem;
			
			var parent = (InteractiveObject) args["parent"];
			inventory.RemoveItem(parent);
			
			Action.runActions(remainingActions);
		}
	}
}
