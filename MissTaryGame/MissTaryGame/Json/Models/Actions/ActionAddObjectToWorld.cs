﻿/*
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
		public Dictionary<string, Object> args;
		
		public ActionAddObjectToWorld(Dictionary<string, Object> args)
		{
			this.args = args;
		}
		
		public void run(Action[] remainingActions) {
			var world = ((DynamicSceneWorld) FP.World);
			
			var parent = (InteractiveObject) args["parent"];
			world.Add(parent);
			
			Action.runActions(remainingActions);
		}
	}
}
