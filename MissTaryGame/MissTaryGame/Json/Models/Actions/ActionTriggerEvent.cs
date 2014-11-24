
using System;
using System.Collections.Generic;
using Indigo;
using MissTaryGame;
using System.Linq;

namespace MissTaryGame.Json.Models.Actions
{
	/// <summary>
	/// Description of ActionTriggerEvent.
	/// </summary>
	public class ActionTriggerEvent : IAction
	{
		public string eventName;
		
		public ActionTriggerEvent(Dictionary<string, Object> args)
		{
			eventName = (string)args["Event"];
		}
		
		public void run(Action[] remainingActions) {
			var world = (DynamicSceneWorld)FP.World;
			GameEvent evt;
			
			if(world.uncompletedEvents.ContainsKey(eventName)) {
				evt = world.uncompletedEvents[eventName];
				
				world.completedEvents[eventName] = evt;
				world.uncompletedEvents.Remove(eventName);
				
				var action = remainingActions[0];
				var tempArray = new Action[remainingActions.Length-1];
				Array.Copy(remainingActions, 1, remainingActions, 0, tempArray.Length);
				action.run(tempArray);
			}
			
			Action.runActions(remainingActions);
		}
	}
}
