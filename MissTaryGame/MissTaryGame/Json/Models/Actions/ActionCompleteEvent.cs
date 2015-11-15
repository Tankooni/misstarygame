
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
	public class ActionCompleteEvent : IAction
	{
		public string eventName;
		
		public ActionCompleteEvent(Dictionary<string, Object> args)
		{
			eventName = (string)args["EventName"];
		}
		
		public void run(Action[] remainingActions) {
			var world = (DynamicSceneWorld)FP.World;
			GameEvent evt;

            if (world.uncompletedEvents.ContainsKey(eventName)) {
                evt = world.uncompletedEvents[eventName];

                // Make sure this event can be completed
                if (!GameEvent.checkDependanciesAndRestrictions(evt.Dependencies, evt.Restrictions)) {
                    return;
                }

                world.completedEvents[eventName] = evt;
                world.uncompletedEvents.Remove(eventName);

                if (remainingActions.Length > 0) {
                    var tempArray = new Action[remainingActions.Length + evt.Actions.Length - 1];
                    Array.Copy(evt.Actions, 0, tempArray, 0, evt.Actions.Length);
                    Array.Copy(remainingActions, 1, tempArray, evt.Actions.Length, remainingActions.Length - 1);

                    Action.runActions(tempArray);
                } else {
                    if(evt.Actions != null)
                        Action.runActions(evt.Actions);
                }
            } else {
                Action.runActions(remainingActions);
            }
		}
	}
}
