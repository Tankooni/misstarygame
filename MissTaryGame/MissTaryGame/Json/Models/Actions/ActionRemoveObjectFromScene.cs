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
using Newtonsoft.Json;

namespace MissTaryGame.Json.Models.Actions
{
	/// <summary>
	/// Description of ActionRemoveObject.
	/// </summary>
	public class ActionRemoveObjectFromScene : IAction
	{		
		public override void run(Action[] remainingActions) {
			var world = ((DynamicSceneWorld) FP.World);
			
			world.Remove(parent);
			
			Action.runActions(remainingActions);
		}
	}
}