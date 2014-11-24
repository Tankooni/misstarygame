using System;
using Indigo;
using Indigo.Graphics;
namespace MissTaryGame
{
	public class DynamicSceneWorld : World
	{
		public DynamicSceneWorld()
		{
			this.AddGraphic(new Image(Library.GetTexture("content/ExampleScene/ExampleScene_Perspective.png")));
			var avatar = new InteractiveObject();
			this.Add(avatar);
			var texture = new Image(Library.GetTexture("content/ExampleScene/ExampleScene_Perspective.png"));
			var s = new SFML.Graphics.Image("content/ExampleScene/ExampleScene_Perspective.png");
			float[,] perspectiveMap = new float[s.Size.X,s.Size.Y];
			for(uint i = 0; i < s.Size.X; i++)
			{
				for(uint j = 0; j < s.Size.Y; j++)
				{
					perspectiveMap[i,j] = (s.GetPixel(i,j).B / 255f) * 1.9f + 0.1f;
				}
			}
			avatar.PerspectiveMap = perspectiveMap;
			
			
		}
		
		public override void Update()
		{
			base.Update();
			
		}
	}
}