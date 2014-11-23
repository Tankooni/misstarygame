/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/23/2014
 * Time: 1:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace MissTaryGame.Json.Models
{
	/// <summary>
	/// Data for a scene.
	/// </summary>
	public class SceneData
	{
		public string Name { get; set; }
		public List<InteractiveObjectRef> Objects { get; set; }
		public List<Region> Regions { get; set; }
	}
}
