/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/24/2014
 * Time: 2:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using Indigo;

namespace MissTaryGame.Json.Models.Actions
{
	/// <summary>
	/// Description of ActionRemoveObject.
	/// </summary>
	public class ActionRemoveObject : IAction
	{
		public Dictionary<string, Object> args;
		
		public ActionRemoveObject(Dictionary<string, Object> args)
		{
			this.args = args;
		}
		
		public void run(Action[] remainingActions) {
			var world = ((DynamicSceneWorld) FP.World);
			
			var parent = (InteractiveObject) args["parent"];
			world.Remove(parent);
			
			if(remainingActions.Length > 0) {
				var action = remainingActions[0];
				var tempArray = new Action[remainingActions.Length-1];
				Array.Copy(remainingActions, 1, remainingActions, 0, tempArray.Length);
				
				action.run(tempArray);
			}
		}
	}
}
