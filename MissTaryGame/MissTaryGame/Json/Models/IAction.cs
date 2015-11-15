/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/23/2014
 * Time: 5:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Newtonsoft.Json;

namespace MissTaryGame.Json.Models
{
	/// <summary>
	/// Description of IAction.
	/// </summary>
	public abstract class IAction 
    {
        [JsonIgnore]
        public InteractiveObject parent;

		public abstract void run(Action[] remainingActions);
	}
}
