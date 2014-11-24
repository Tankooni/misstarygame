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
	public class ActionRemoveObjectFromInventory
	{
		public InteractiveObject parent;
		
		public ActionRemoveObjectFromInventory(Dictionary<string, Object> args)
		{
			parent = (InteractiveObject) args["parent"];
		}
		
		public void run(Action[] remainingActions) {
			var player = ((DynamicSceneWorld) FP.World).avatar;
			
			player.Inventory.Remove(parent);
			
			if(remainingActions.Length > 0) {
				var action = remainingActions[0];
				var tempArray = new Action[remainingActions.Length-1];
				Array.Copy(remainingActions, 1, remainingActions, 0, tempArray.Length);
				
				action.run(tempArray);
			}
		}
	}
}
