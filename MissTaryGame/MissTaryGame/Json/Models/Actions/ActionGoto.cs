/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/24/2014
 * Time: 12:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Indigo;
using MissTaryGame;

namespace MissTaryGame.Json.Models.Actions
{
	/// <summary>
	/// Description of ActionGoto.
	/// </summary>
	public class ActionGoto : IAction
	{
		public string Scene;
		public string Entrance;

        public ActionGoto() { }
		
		public override void run(Action[] remainingActions) {
			var world = (DynamicSceneWorld) FP.World;
			world.LoadScene(Scene, Entrance);
			
			Action.runActions(remainingActions);
		}
	}
}
