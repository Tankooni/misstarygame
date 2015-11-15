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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace MissTaryGame.Json.Models
{
	/// <summary>
	/// Description of Action.
	/// </summary>
	public class Action
	{
		public string Name { get; set; }
		public JObject Args { get; set; }
		private IAction action;
        public InteractiveObject parent {
            set { action.parent = value; }
            get { return action.parent; }
        } 
		
		[OnDeserialized]
		internal void OnDeserializedMethod(StreamingContext context) {
			var T = Type.GetType("MissTaryGame.Json.Models.Actions.Action" + Name);
			
			if(T == null) {
				throw new Exception("Could not find action: " + Name);
			}

            //action = (IAction)Activator.CreateInstance(T, Args);

            // This should deserialize the action after finding the correct action to decode
            MethodInfo[] DeserializeMethods = typeof(JsonConvert).GetMethods();
            MethodInfo DeserializeMethod = DeserializeMethods.First(x => x.Name == "DeserializeObject" &&
                                                                         x.IsGenericMethod &&
                                                                         x.GetParameters()
                                                                            .Zip(new[] { typeof(string) },
                                                                                (first, second) => first.ParameterType == second)
                                                                            .All(y => y));
           MethodInfo DeserializeAction = DeserializeMethod.MakeGenericMethod(T);

           action = (IAction)DeserializeAction.Invoke(null, new Object[] { Args.ToString() });
		}
		
		public void run(Action[] remainingActions) {
			action.run(remainingActions);
		}
		
		public static void runActions(Action[] actions) {
			if(actions.Length > 0) {
				var action = actions[0];
				var tempArray = new Action[actions.Length-1];
				Array.Copy(actions, 1, tempArray, 0, tempArray.Length);
				
				action.run(tempArray);
			}
		}
	}
}
