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
		public InteractiveObject parent;
		
		public ActionRemoveObjectFromInventory(Dictionary<string, Object> args)
		{
			parent = (InteractiveObject) args["parent"];
		}
		
		public void run(Action[] remainingActions) {
			var player = ((DynamicSceneWorld) FP.World).avatar;
			
			player.Inventory.Remove(parent);
			
			Action.runActions(remainingActions);
		}
	}
}
