/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/23/2014
 * Time: 2:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace MissTaryGame.Json.Models.Actions
{
	/// <summary>
	/// Description of ActionDialog.
	/// </summary>
	public class ActionDialog : IAction
	{
		public string Speaker { set; get; }
		public string Text { set; get; }
		
		public ActionDialog(Dictionary<string, Object> args) {
			try {
				Speaker = (string)args["Speaker"];
				Text = (string)args["Text"];
				
			} catch (Exception e) {
				throw new Exception("Wasn't able to satisfy dialog action");
			}
		}
		
		public void run() {
			// Need UI stuff for this part
		}
	}
}
