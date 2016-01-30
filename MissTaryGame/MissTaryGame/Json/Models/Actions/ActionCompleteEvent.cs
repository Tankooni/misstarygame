
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
		public string EventName;
		
		public override void run(Action[] remainingActions) {
			var world = (DynamicSceneWorld)FP.World;
			GameEvent evt;

            if (world.uncompletedEvents.ContainsKey(EventName)) {
                evt = world.uncompletedEvents[EventName];

                // Make sure this event can be completed
                if (!GameEvent.checkDependanciesAndRestrictions(evt.Dependencies, evt.Restrictions)) {
                    return;
                }

                world.completedEvents[EventName] = evt;
                world.uncompletedEvents.Remove(EventName);

                if (remainingActions.Length > 0) {
                    if(evt.Actions == null)
                    {
                        Action.runActions(remainingActions);
                        return;
                    }
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
