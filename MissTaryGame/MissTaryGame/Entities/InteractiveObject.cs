using System;
using Indigo;
using Indigo.Graphics;

namespace MissTaryGame
{
	public class InteractiveObject : Entity
	{
		/// <summary>
		/// 2D array representitive of how to scale the object, each value should be between 0 to 1
		/// Should be the same size as the scene
		/// </summary>
		public int[,] PerspectiveMap { get; set; }
		public Image sprite { get; set; }
		public InteractiveObject()
		{
			sprite = new Indigo.Graphics.Spritemap(Library.GetTexture("content/Avatar/Idle/Idle1.png"), 148, 332);
			foreach(string path in Utility.RetrieveFilePathForFilesInDirectory(@".\content\music", "*.png"))
			{
				
			}
//			sprite.OriginX = 74;
//			sprite.OriginY = 166;
			this.OriginX = 74;
			this.OriginY = 166;
			AddComponent(sprite);
		}
		
		public override void Update()
		{
			base.Update();
		}
		
		public override void Render()
		{
			sprite.Scale = PerspectiveMap[(int)this.X, (int)this.Y];
			base.Render();
		}
	}
}
