/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/23/2014
 * Time: 1:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using Indigo.Core;

namespace MissTaryGame.Json.Models
{
	/// <summary>
	/// Description of Region.
	/// </summary>
	public class Region
	{
		public Point Position { get; set; }
		public Action[] OnEnter { get; set; }
		public Action[] OnExit { get; set; }
	}
}
