using System;
using System.Collections.Generic;
using Indigo;
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
		public float Scale = .5f;
		
		public InteractiveObject()
		{
			//sprite = new Indigo.Graphics.Spritemap(Library.GetTexture("content/Avatar/Idle/Idle1.png"), 148, 332);
			images = new List<Image>();
			foreach(string path in Utility.RetrieveFilePathForFilesInDirectory(@".\content\Avatar\WalkDown", "*.png"))
				images.Add(new Image(Library.GetTexture(path)));
			sprite = new Flipbook(images.Cast<Graphic>().ToArray());
			sprite.Add("idle", FP.MakeFrames(0, 8), 15, true);
			sprite.Play("idle");
//			sprite.OriginX = 74;
//			sprite.OriginY = 166;
			this.OriginX = 74;
			this.OriginY = 166;
			AddComponent(sprite);
			this.SetHitbox(148, 332);
			this.Y = 150;
		}
		
		public override void Update()
		{
			base.Update();
			this.Y += FP.Elapsed * 20;
			this.X += FP.Elapsed * 7;
			this.Scale = PerspectiveMap[(int)this.X, (int)this.Y];
		}
		
		public override void Render()
		{
			//sprite.Scale = PerspectiveMap[(int)this.X, (int)this.Y];
			foreach(var image in images)
				image.Scale = Scale;
			base.Render();
		}
	}
}
