/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/24/2014
 * Time: 12:35 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Indigo;
using MissTaryGame.Json.Models;
using Action = MissTaryGame.Json.Models.Action;

namespace MissTaryGame.UI
{
	/// <summary>
	/// Description of CommandBubble.
	/// </summary>
	public class CommandBubble : Entity
	{
		private Action[] actions;
		private string name;
		
		public CommandBubble(CommandData data)
		{
			actions = data.Actions;
			name = data.Name;
		}
	}
}
