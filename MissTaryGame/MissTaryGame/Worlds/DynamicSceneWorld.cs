using System;
using Indigo;
using Indigo.Graphics;
namespace MissTaryGame
{
	public class DynamicSceneWorld : World
	{
		public DynamicSceneWorld()
		{
			var avatar = new InteractiveObject();
			this.Add(avatar);
			var texture = Library.GetTexture("content/ExampleScene/ExampleScene_Perspective.png");
			
		}
		
		public override void Update()
		{
			base.Update();
			
		}
	}
}