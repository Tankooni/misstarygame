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
using Indigo.Core;

namespace MissTaryGame.Json.Models
{
	/// <summary>
	/// Data for a scene.
	/// </summary>
	public class SceneData
	{
        public string Name { get; set; }
        public string FolderName { get; set; }
        public string Background { get; set; }
		public string Foreground { get; set; }
		public string Collision { get; set; }
		public string Perspective { get; set; }
		public List<InteractiveObjectRef> Objects { get; set; }
		public List<Region> Regions { get; set; }
		public Dictionary<string, Point> Entrances { get; set; }
	}
}
