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
using Newtonsoft.Json;

namespace MissTaryGame.Json.Models.Actions
{
	/// <summary>
	/// Description of ActionAddObjectToWorld.
	/// </summary>
	public class ActionAddObjectToScene : IAction
	{
        public int X, Y;
		
		public override void run(Action[] remainingActions) {
			var world = ((DynamicSceneWorld) FP.World);
			
			world.Add(parent);
			
			Action.runActions(remainingActions);
		}
	}
}
