/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/23/2014
 * Time: 1:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Indigo.Core;

namespace MissTaryGame.Json.Models
{
	/// <summary>
	/// Description of InteractiveObjectRef.
	/// </summary>
	public class InteractiveObjectRef
	{
		public string Name { get; set; }
		public Point Position { get; set; }
		public string defaultAnimation { get; set; }
	}
}
