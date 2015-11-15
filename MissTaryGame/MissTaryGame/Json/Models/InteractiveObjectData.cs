/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/23/2014
 * Time: 1:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using Indigo.Core;

namespace MissTaryGame.Json.Models
{
	/// <summary>
	/// Description of InteractiveObjectData.
	/// </summary>
	public class InteractiveObjectData
	{
		public string Name { get; set; }
		public AnimationData[] Animations { get; set; }
		public CommandData[] Commands { get; set; }
        public Dictionary<string, int> Attributes { get; set; }
		//public Combination[] Combinations { get; set; }
		public Point FrameSize { get; set; }
		public Point HotSpot { get; set; }
		public bool Scaling { get; set; }
		public bool Moving { get; set; }
	}
}
