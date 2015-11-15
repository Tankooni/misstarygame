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

namespace MissTaryGame.Json.Models.Actions {
    /// <summary>
    /// Description of ActionGoto.
    /// </summary>
    public class ActionChangeAttribute : IAction {
        public string ObjectName;
        public string AttributeName;
        public string Operation;
        public int Value;

        public override void run(Action[] remainingActions) {
            //Use the parent for now
            switch(Operation) {
                case "*": parent.InteractiveObjectRef.Attributes["AttributeName"] *= Value; break;
                case "/": parent.InteractiveObjectRef.Attributes["AttributeName"] /= Value; break;
                case "+": parent.InteractiveObjectRef.Attributes["AttributeName"] += Value; break;
                case "-": parent.InteractiveObjectRef.Attributes["AttributeName"] -= Value; break;
                case "=": parent.InteractiveObjectRef.Attributes["AttributeName"] = Value; break;
                default: throw new Exception("Invalid operator");
            }
            

            Action.runActions(remainingActions);
        }
    }
}
