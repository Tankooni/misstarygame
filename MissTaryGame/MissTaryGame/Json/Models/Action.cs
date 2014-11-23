/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/23/2014
 * Time: 1:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Reflection;
using System.Runtime.Serialization;
using System.Collections.Generic;
using MissTaryGame.Json.Models.Actions;

namespace MissTaryGame.Json.Models
{
	/// <summary>
	/// Description of Action.
	/// </summary>
	public class Action
	{
		public string Name { get; set; }
		public Dictionary<string, Object> Args { get; set; }
		private IAction action;
		
		[OnDeserialized]
		internal void OnDeserializedMethod(StreamingContext context) {
			var T = Type.GetType("MissTaryGame.Json.Models.Actions.Action" + Name);
			
			if(T == null) {
				throw new Exception("Could not find action: " + Name);
			}
			
			action = (IAction)Activator.CreateInstance(T, Args);
		}
		
		public void run() {
			action.run();
		}
	}
}
