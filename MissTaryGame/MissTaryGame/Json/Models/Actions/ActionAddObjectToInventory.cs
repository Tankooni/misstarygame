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
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace MissTaryGame.Json.Models.Actions
{
	/// <summary>
	/// Description of ActionAddObjectToInventory.
	/// </summary>
	public class ActionAddObjectToInventory : IAction
	{
        public bool RemoveParent = true;
        public string ObjectPickedUp = "";
		
		public override void run(Action[] remainingActions) {
			var inventory = ((DynamicSceneWorld) FP.World).VeryGenericInventorySystem;
            
            if (RemoveParent) {
                ((DynamicSceneWorld)FP.World).RemoveObjectFromScene(parent, false);
            }

            inventory.AddItem(parent);
			
			Action.runActions(remainingActions);
		}
	}
}
