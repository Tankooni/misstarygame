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
using Indigo;
using MissTaryGame;

namespace MissTaryGame.Json.Models.Actions
{
	/// <summary>
	/// Description of ActionGoto.
	/// </summary>
	public class ActionGoto : IAction
	{
		string nextScene;
		string toEntrance;
		
		public ActionGoto(Dictionary<string, Object> args)
		{
			nextScene = (string)args["Scene"];
			toEntrance = (string)args["Entrance"];
		}
		
		public void run() {
			var world = (DynamicSceneWorld) FP.World;
			world.LoadScene(nextScene, toEntrance);
		}
	}
}
