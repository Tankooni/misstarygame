﻿/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/23/2014
 * Time: 1:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

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
		public Combination[] Combinations { get; set; }
	}
}
