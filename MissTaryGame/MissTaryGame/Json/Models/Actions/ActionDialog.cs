/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/23/2014
 * Time: 2:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using Indigo;
using MissTaryGame.UI;
using System.Runtime.Serialization;

namespace MissTaryGame.Json.Models.Actions
{
	/// <summary>
	/// Description of ActionDialog.
	/// </summary>
	public class ActionDialog : IAction
	{
		public string Speaker { set; get; }
		public string Text { set; get; }
		
		[OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context) {
            if(Text == null) {
                throw new Exception("Wasn't able to satisfy dialog action");
            }
        }

        public override void run(Action[] remainingActions) {
			TextBox box = new TextBox(Text);
			FP.World.Add(box);
			
			box.show();
			
			box.onRemove = () => Action.runActions(remainingActions);
		}
	}
}
