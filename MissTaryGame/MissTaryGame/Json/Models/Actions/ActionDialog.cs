/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/23/2014
 * Time: 2:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace MissTaryGame.Json.Models.Actions
{
	/// <summary>
	/// Description of ActionDialog.
	/// </summary>
	public class ActionDialog : Action
	{
		public string Speaker { set; get; }
		public string Text { set; get; }
		
		public void run() {
			// Need UI stuff for this part
		}
	}
}
