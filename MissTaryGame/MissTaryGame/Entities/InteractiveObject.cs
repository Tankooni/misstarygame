using System;
using System.Collections.Generic;
using Indigo;
using Indigo.Inputs;
using Indigo.Graphics;
using System.Linq;
using MissTaryGame.Json.Models;

namespace MissTaryGame
{
	public class InteractiveObject : Entity
	{
		/// <summary>
		/// 2D array representitive of how to scale the object, each value should be between 0 to 1
		/// Should be the same size as the scene
		/// </summary>
		public float[,] PerspectiveMap { get; set; }
		public Flipbook sprite { get; set; }
		
		public InteractiveObjectData MetaData { get; set; }
		List<Image> images;
		private bool flipped = false;
		public bool Flipped
		{
			get
			{
				return flipped;
			}
			set
			{
				flipped = value;
				foreach(var image in images)
					image.FlippedX = flipped;
			}
		}
		private float scale = .5f;
		public float Scale
		{
			get
			{
				return scale;
			}
			set
			{
				scale = value;
				foreach(var image in images)
					image.Scale = scale;
				this.OriginX = MetaData.HotSpot.X * scale;
				this.OriginY = MetaData.HotSpot.Y * scale;
				SetHitbox((int)(MetaData.FrameSize.X * scale), (int)(MetaData.FrameSize.Y * scale), (int)this.OriginX, (int)this.OriginY);
				this.Layer = (int)(1000 - 1000 * scale / 2);
			}
		}
		
		private float moveSpeed = 50;
		public float MoveSpeedX
		{
			get
			{
				return moveSpeed * (1.3f + scale);
			}
		}
		public float MoveSpeedY
		{
			get
			{
				return moveSpeed * (.5f + scale);
			}
		}
		
		protected Dictionary<string, List<int>> footFallFrames = new Dictionary<string, List<int>>();
		
		public InteractiveObject(InteractiveObjectData metaData, string objectName, float[,] perspectiveMap)
			:this(metaData, objectName)
		{
			this.PerspectiveMap = perspectiveMap;
		}
		public InteractiveObject(InteractiveObjectData metaData, string objectName)
		{
			//sprite = new Indigo.Graphics.Spritemap(Library.GetTexture("content/Avatar/Idle/Idle1.png"), 148, 332);
			images = new List<Image>();
			MetaData = metaData;
			
			int totalFrames = 0;
			foreach(var animation in MetaData.Animations)
			{
				int frameNumber = 0;
				foreach(string path in Utility.RetrieveFilePathForFilesInDirectory(@".\content\objects\" + objectName + @"\" + animation.Name, "*.png"))
				{
					images.Add(new Image(Library.GetTexture(path)){ Scale = scale , OriginX = MetaData.HotSpot.X, OriginY = MetaData.HotSpot.Y});
					if(animation.FootStepFrames != null && animation.FootStepFrames.Contains(frameNumber))
					{
						int frame = frameNumber + totalFrames - 1;
						if(!footFallFrames.ContainsKey(animation.Name))
							footFallFrames.Add(animation.Name, new List<int>{frame});
						else
							footFallFrames[animation.Name].Add(frame);
					}
					frameNumber++;
				}
				totalFrames += frameNumber;
			}
//			foreach(string path in Utility.RetrieveFilePathForFilesInDirectory(@".\content\Avatar\WalkDown", "*.png"))
//				images.Add(new Image(Library.GetTexture(path)));
			sprite = new Flipbook(images.Cast<Graphic>().ToArray());
			
			int currentTotalFrames = 0;
			foreach(var animation in MetaData.Animations)
				sprite.Add(animation.Name, FP.MakeFrames(currentTotalFrames, (currentTotalFrames += animation.Frames)-1), animation.FPS, true);
			sprite.Play("Idle");
			AddComponent(sprite);
			this.SetHitbox((int)(MetaData.FrameSize.X * scale), (int)(MetaData.FrameSize.Y * scale));
			this.Y = 150;
		}
		
		public override void Update()
		{
			base.Update();
			this.Scale = PerspectiveMap[(int)this.X, (int)this.Y];
		}
		
		public void PlayAnimation(string animation)
		{
			sprite.Play(animation);
		}
		
		public string CheckAnimation()
		{
			return sprite.CurrentAnim;
		}
	}
}
