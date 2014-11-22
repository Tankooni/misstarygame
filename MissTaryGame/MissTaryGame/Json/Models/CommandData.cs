/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/23/2014
 * Time: 1:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace MissTaryGame.Json.Models
{
	/// <summary>
	/// Description of CommandData.
	/// </summary>
	public class CommandData
	{
		public string Name { get; set; }
		public Action[] Actions { get; set; }
		public Dependency[] Dependencies { get; set; }
	}
}
