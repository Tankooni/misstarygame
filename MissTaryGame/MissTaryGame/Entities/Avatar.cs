
using System;
using System.Collections.Generic;
using Indigo;
using Indigo.Core;
using MissTaryGame.Json.Models;

namespace MissTaryGame
{
	/// <summary>
	/// Description of Avatar.
	/// </summary>
	public class Avatar : InteractiveObject
	{
		private float walkToX = 0;
		private float walkToY = 0;
		private bool IsMoving = false;
		private int lastFootFrame = 0;
		
		public Avatar(InteractiveObjectData metaData, string objectName)
			:base(metaData, objectName)
		{
		}
		
		public override void Update()
		{
			base.Update();
			if(IsMoving)
			{
				this.MoveTowards(walkToX, walkToY, FP.Elapsed * this.MoveSpeedX);
				
				var currentAnimaion = this.CheckAnimation();
				List<int> footFallFrameNumbers;
				footFallFrames.TryGetValue(currentAnimaion, out footFallFrameNumbers);
				if(footFallFrameNumbers != null && footFallFrameNumbers.Contains(sprite.Frame) && lastFootFrame != sprite.Frame)
				{
					lastFootFrame = sprite.Frame;
					SoundManager.PlaySound("footstep");
				}
				
				if(currentAnimaion.Contains("Walk") && (int)this.X == (int)walkToX && (int)this.Y == (int)walkToY)
				{
					this.PlayAnimation("Idle");
					IsMoving = false;
				}
				else if((int)this.X != (int)walkToX && (int)this.Y != (int)walkToY)
				{
					var walkAngle = FP.Angle(this.X, this.Y, walkToX, walkToY);
					
					//Console.WriteLine("Angle: " + walkAngle);
					bool flip = walkAngle >= 90 && walkAngle <= 270;
					if(this.Flipped != flip)
						this.Flipped = flip;
					if(currentAnimaion != "WalkUp" &&  walkAngle<= 180)
					{
						this.PlayAnimation("WalkUp");
					}
					else if(currentAnimaion != "WalkDown" && walkAngle > 180)
					{
						this.PlayAnimation("WalkDown");
					}
				}
			}
		}
		
		public void SetWalkTo(float x, float y)
		{
			walkToX = x;
			walkToY = y;
			IsMoving = true;
		}
	}
}
