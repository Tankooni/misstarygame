using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissTaryGame.Json.Models.Actions {
    class ActionPlayAnimation : IAction {
        public string AnimationName;

        public override void run(Action[] remainingActions) {
            parent.PlayAnimation(AnimationName);

            Action.runActions(remainingActions);
        }
    }
}
