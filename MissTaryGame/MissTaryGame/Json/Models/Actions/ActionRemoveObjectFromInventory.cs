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
using Newtonsoft.Json;

namespace MissTaryGame.Json.Models.Actions
{
	/// <summary>
	/// Description of ActionRemoveObjectFromInventory.
	/// </summary>
	public class ActionRemoveObjectFromInventory : IAction
	{
		public override void run(Action[] remainingActions) {
			var inventory = ((DynamicSceneWorld) FP.World).VeryGenericInventorySystem;

			inventory.RemoveItem(parent);
			
			Action.runActions(remainingActions);
		}
	}
}
