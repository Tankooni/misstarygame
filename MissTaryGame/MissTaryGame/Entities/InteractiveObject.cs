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
		public float scale = .5f;
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
				SetHitbox((int)(MetaData.FrameSize.X * scale), (int)(MetaData.FrameSize.Y * scale));
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
		
		public InteractiveObject(InteractiveObjectData metaData)
		{
			//sprite = new Indigo.Graphics.Spritemap(Library.GetTexture("content/Avatar/Idle/Idle1.png"), 148, 332);
			images = new List<Image>();
			MetaData = metaData;
			
			foreach(var animation in MetaData.Animations)
				foreach(string path in Utility.RetrieveFilePathForFilesInDirectory(@".\content\Avatar\" + animation.Name, "*.png"))
					images.Add(new Image(Library.GetTexture(path)){ Scale = scale , OriginX = MetaData.HotSpot.X, OriginY = MetaData.HotSpot.Y});
//			foreach(string path in Utility.RetrieveFilePathForFilesInDirectory(@".\content\Avatar\WalkDown", "*.png"))
//				images.Add(new Image(Library.GetTexture(path)));
			sprite = new Flipbook(images.Cast<Graphic>().ToArray());
			
			int currentTotalFrames = 0;
			foreach(var animation in MetaData.Animations)
				sprite.Add(animation.Name, FP.MakeFrames(currentTotalFrames, (currentTotalFrames += animation.Frames)-1), animation.FPS, true);
			sprite.Play("WalkDown");
			AddComponent(sprite);
			this.SetHitbox((int)(MetaData.FrameSize.X * scale), (int)(MetaData.FrameSize.Y * scale));
			this.Y = 150;
		}
		
		public override void Update()
		{
			base.Update();
			this.Scale = PerspectiveMap[(int)this.X, (int)this.Y];
		}
		
		
		
		public override void Render()
		{
			//sprite.Scale = PerspectiveMap[(int)this.X, (int)this.Y];
			base.Render();
		}
	}
}
