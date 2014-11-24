/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/23/2014
 * Time: 1:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Newtonsoft.Json;
using MissTaryGame;
using MissTaryGame.Json.Models.Actions;

namespace MissTaryGame.Json.Models
{
	/// <summary>
	/// Description of CommandData.
	/// </summary>
	public class CommandData
	{
		public string Name { get; set; }
		public Action[] Actions { get; set; }
		public GameEvent[] Dependencies { get; set; }
		
		private InteractiveObject _parent;
		[JsonIgnore]
		public InteractiveObject parent { get { return _parent; } set {
				foreach( var a in Actions ) {
					a.Args["parent"] = value;
				}
				_parent = value;
			}
		}
	}
}
