
using System;
using System.Collections.Generic;
using Indigo;
using Newtonsoft.Json;
using MissTaryGame;
using System.Linq;

namespace MissTaryGame.Json.Models.Actions {
    /// <summary>
    /// Description of ActionTriggerEvent.
    /// </summary>
    public class ActionCheckEvent : IAction {
        public string EventName;
        public Action[] ElseActions;

        /*public ActionCheckEvent(Dictionary<string, Object> args) {
            eventName = (string)args["EventName"];
            if(args.ContainsKey("ElseActions")) {
                var dictElseActions = (Newtonsoft.Json.Linq.JArray)args["ElseActions"];
                elseActions = new Action[dictElseActions.Count];
                for (int i = 0; i < dictElseActions.Count; i++) {
                    elseActions[i] = JsonLoader.LoadStream<Action>(JsonConvert.SerializeObject(dictElseActions[i]));
                }
            }
        }*/

        public override void run(Action[] remainingActions) {
            var world = (DynamicSceneWorld)FP.World;

            if (world.completedEvents.ContainsKey(EventName)) {
                Action.runActions(remainingActions);
            } else if(world.uncompletedEvents.ContainsKey(EventName)) {
                if(ElseActions != null)
                    Action.runActions(ElseActions);
            } else {
                throw new Exception("FUCK YOU FOR TRYING TO REFERENCE A GAME EVENT THAT DOESN'T EXIST");
            }
        }
    }
}
