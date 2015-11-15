/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/23/2014
 * Time: 1:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace MissTaryGame.Json.Models
{
	/// <summary>
	/// Description of AnimationData.
	/// </summary>
	public class AnimationData
	{
		public string Name { set; get; }
		public int Frames { set; get; }
		public int FPS { set; get; }
        public int[] FootStepFrames = new int[0];
		
		public int MSPerFrame { 
			set {
				FPS = 1000 / value;
			}
			get {
				return 1000 / FPS;
			}
		}
	}
}
