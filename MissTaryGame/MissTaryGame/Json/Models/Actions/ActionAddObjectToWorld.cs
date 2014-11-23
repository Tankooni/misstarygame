/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/24/2014
 * Time: 2:36 PM
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
	/// Description of ActionAddObjectToWorld.
	/// </summary>
	public class ActionAddObjectToWorld : IAction
	{
		public InteractiveObject parent;
		
		public ActionAddObjectToWorld(Dictionary<string, Object> args)
		{
			parent = (InteractiveObject) args["parent"];
		}
		
		public void run(Action[] remainingActions) {
			var world = ((DynamicSceneWorld) FP.World);
			
			world.Add(parent);
			
			if(remainingActions.Length > 0) {
				var action = remainingActions[0];
				var tempArray = new Action[remainingActions.Length-1];
				Array.Copy(remainingActions, 1, remainingActions, 0, tempArray.Length);
				
				action.run(tempArray);
			}
		}
	}
}
