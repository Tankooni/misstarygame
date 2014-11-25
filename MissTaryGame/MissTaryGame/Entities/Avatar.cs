
using System;
using System.Collections.Generic;
using Indigo;
using Indigo.Core;
using MissTaryGame.Json.Models;
using Action = MissTaryGame.Json.Models.Action;

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
		public List<InteractiveObject> Inventory = new List<InteractiveObject>();
		
		private Dictionary<Region, bool> wasInRegion = new Dictionary<Region, bool>();
		
		public Avatar(InteractiveObjectData metaData, string objectName, float[,] perspectiveMap)
			:base(metaData, objectName, perspectiveMap)
		{
		}
		
		public override void Added()
		{
			base.Added();
			
			var worldMetadata = ((DynamicSceneWorld)World).metaData;
			if(worldMetadata.Regions != null) {
				foreach(var r in worldMetadata.Regions) {
					wasInRegion.Add(r, false);
				}
			}
		}
		
		public override void Removed()
		{
			base.Removed();
			
			wasInRegion.Clear();
		}
		
		public override void Update()
		{
			base.Update();
			if(IsMoving)
			{
//				this.MoveToward(walkToX, walkToY, FP.Elapsed * this.MoveSpeedX);
				this.MoveToward(walkToX, walkToY, FP.Elapsed * this.MoveSpeedX, FP.Elapsed * this.MoveSpeedY);
				
				//Trigger event if needed
				var worldMetadata = ((DynamicSceneWorld)World).metaData;
				if(worldMetadata.Regions != null) {
					foreach(var r in worldMetadata.Regions) {
						if( r.Area.Contains( X, Y ) ) {
							if(!wasInRegion[r]) {
								//just entered, execute shit
								if(GameEvent.checkDependencies(r.Dependencies)) {
									Action.runActions(r.OnEnter);
								}
								wasInRegion[r] = true;
							}
						} else {
							if( wasInRegion[r] ) {
								//just left region, execute other shit
								if(GameEvent.checkDependencies(r.Dependencies)) {
									Action.runActions(r.OnExit);
								}
								wasInRegion[r] = false;
							}
						}
					}
				}
				
				//Animation stuff
				var currentAnimaion = this.CheckAnimation();
				List<int> footFallFrameNumbers;
				footFallFrames.TryGetValue(currentAnimaion, out footFallFrameNumbers);
				if(footFallFrameNumbers != null && footFallFrameNumbers.Contains(sprite.Frame) && lastFootFrame != sprite.Frame)
				{
					lastFootFrame = sprite.Frame;
					SoundManager.PlaySoundVariations("footstepL", .8f, .9f);
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
