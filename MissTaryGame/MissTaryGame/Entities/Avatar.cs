
using System;
using System.Collections.Generic;
using Indigo;
using MissTaryGame.Pathing;
using MissTaryGame.Json.Models;
using Action = MissTaryGame.Json.Models.Action;
using Indigo.Inputs;

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
		private IEnumerator<PathNode> pathNodes;
		
		private Dictionary<Region, bool> wasInRegion = new Dictionary<Region, bool>();
		
		public Avatar(InteractiveObjectData metaData, string objectName, float[,] perspectiveMap, InteractiveObjectRef interactiveObjectRef)
			:base(metaData, objectName, perspectiveMap, interactiveObjectRef)
		{
            if (!interactiveObjectRef.Attributes.ContainsKey("AvatarSpriteState"))
                interactiveObjectRef.Attributes.Add("AvatarSpriteState", 0);
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
            var currentAnimaion = this.CheckAnimation();

            if (Keyboard.Space.Pressed)
            {
                if (InteractiveObjectRef.Attributes["AvatarSpriteState"] == 0)
                    InteractiveObjectRef.Attributes["AvatarSpriteState"] = 1;
                else
                    InteractiveObjectRef.Attributes["AvatarSpriteState"] = 0;
            }
            
            if (InventoryObject)
            {
                if (currentAnimaion != "Idle" + InteractiveObjectRef.Attributes["AvatarSpriteState"])
                    PlayAnimation("Idle" + InteractiveObjectRef.Attributes["AvatarSpriteState"]);
                return;
            }

			if(IsMoving)
			{
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
				
				List<int> footFallFrameNumbers;
				footFallFrames.TryGetValue(currentAnimaion, out footFallFrameNumbers);
				if(footFallFrameNumbers != null && footFallFrameNumbers.Contains(sprite.Frame) && lastFootFrame != sprite.Frame)
				{
					lastFootFrame = sprite.Frame;
					SoundManager.PlaySoundVariations("footstepL", .8f, .9f);
				}
				
				if(pathNodes != null)
				{
					if((int)X == (int)walkToX && (int)Y == (int)walkToY)
					{
						if(pathNodes.MoveNext())
						{
							walkToX = pathNodes.Current.X;
							walkToY = pathNodes.Current.Y;
						}
						else
						{
							PlayAnimation("Idle" + InteractiveObjectRef.Attributes["AvatarSpriteState"]);
                            pathNodes = null;
							IsMoving = false;
							return;
						}

					}
					
					var walkAngle = FP.Angle(this.X, this.Y, walkToX, walkToY);
					bool flip = walkAngle >= 90 && walkAngle <= 270;
					if(Flipped != flip)
						Flipped = flip;

                    if (currentAnimaion != ("WalkDown" + InteractiveObjectRef.Attributes["AvatarSpriteState"]) && (walkAngle >= 0 && walkAngle <= 180))
                        PlayAnimation("WalkDown" + InteractiveObjectRef.Attributes["AvatarSpriteState"]);
                    else if (currentAnimaion != ("WalkUp" + +InteractiveObjectRef.Attributes["AvatarSpriteState"]) && walkAngle > 180 && walkAngle < 360)
                        PlayAnimation("WalkUp" + InteractiveObjectRef.Attributes["AvatarSpriteState"]);
				}
			}
		}
		
		public void SetWalkTo(IEnumerable<PathNode> nodes)
		{
			pathNodes = nodes.GetEnumerator();
			if(!pathNodes.MoveNext())
			{
				PlayAnimation("Idle" + InteractiveObjectRef.Attributes["AvatarSpriteState"]);
				IsMoving = false;
				pathNodes= null;
				return;
			}
			walkToX = pathNodes.Current.X;
			walkToY = pathNodes.Current.Y;
			IsMoving = true;
		}
	}
}
