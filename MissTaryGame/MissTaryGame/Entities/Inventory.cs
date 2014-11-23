using System;
using System.IO;
using System.Collections.Generic;
using Indigo;
using Indigo.Core;
using Indigo.Graphics;

namespace MissTaryGame.Entities
{
	/// <summary>
	/// Description of Inventory.
	/// </summary>
	public class Inventory : Entity
	{
//		Dictionary<string, Image> images = new Dictionary<string, Image>();
		Image tabBackground;
		Image leftArrow;
		Image rightArrow;
		
		List<Point> itemPostions = new List<Point>();
		int itemSlots = 9;
		int itemPage = 0;
		
		bool active = false;
		public bool Active
		{
			get
			{
				return active;
			}
			set
			{
				tabBackground.X = -tabBackground.Height + 32;
				rightArrow.Visible = leftArrow.Visible = active;
				active = value;
			}
		}
		
		Avatar avatar;
		public Inventory(Avatar avatar)
		{
			this.avatar = avatar;
			tabBackground = new Image(Library.GetTexture("ontent/UI/Inventory/InventoryTab.png"));
			leftArrow = new Image(Library.GetTexture("ontent/UI/Inventory/InventoryButtonLeft.png"));
			rightArrow = new Image(Library.GetTexture("ontent/UI/Inventory/InventoryButtonRight.png"));
			
			itemPostions.Add(new Point(77, 72));
			itemPostions.Add(new Point(206, 72));
			itemPostions.Add(new Point(332, 72));
			itemPostions.Add(new Point(452, 72));
			itemPostions.Add(new Point(576, 72));
			itemPostions.Add(new Point(693, 72));
			itemPostions.Add(new Point(809, 72));
			itemPostions.Add(new Point(925, 72));
			itemPostions.Add(new Point(1046, 72));
			
//			foreach(string path in Utility.RetrieveFilePathForFilesInDirectory("content/UI/Inventory"))
//			{
//				images.Add(Path.GetFileNameWithoutExtension(path), new Image(Library.GetTexture(path)));
//			}
		}
		
		public override void Update()
		{
			base.Update();
			
		}
	}
}
