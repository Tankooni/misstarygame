using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Indigo;
using Indigo.Core;
using Indigo.Graphics;

namespace MissTaryGame
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
		//int itemSlots = 9;
		private int itemSlots
		{
			get
			{
				return itemPostions.Count;
			}
		}
		int itemPage = 0;
		
		bool active = false;
		public bool IsActive
		{
			get
			{
				return active;
			}
			set
			{
				tabBackground.Y = value ? 0 : -tabBackground.Height + 32;
				rightArrow.Visible = leftArrow.Visible = active = value;
				SetItemsActive(value);
				itemPage = 0;
			}
		}
		
		Avatar avatar;
		DynamicSceneWorld DSW;
		public Inventory(Avatar avatar, DynamicSceneWorld dsw)
		{
			this.avatar = avatar;
			this.DSW = dsw;
			tabBackground = new Image(Library.GetTexture("content/UI/Inventory/InventoryTab.png"));
			leftArrow = new Image(Library.GetTexture("content/UI/Inventory/InventoryButtonLeft.png"));
			rightArrow = new Image(Library.GetTexture("content/UI/Inventory/InventoryButtonRight.png"));
			
			AddComponent(tabBackground);
			
			this.Layer = Utility.MIDDLE_UI_LAYER;
			
			itemPostions.Add(new Point(77, 72));
			itemPostions.Add(new Point(206, 72));
			itemPostions.Add(new Point(332, 72));
			itemPostions.Add(new Point(452, 72));
			itemPostions.Add(new Point(576, 72));
			itemPostions.Add(new Point(693, 72));
			itemPostions.Add(new Point(809, 72));
			itemPostions.Add(new Point(925, 72));
			itemPostions.Add(new Point(1046, 72));
			
			this.IsActive = false;
		}
		
		public override void Update()
		{
			base.Update();
			int start = itemPage * itemSlots;
			for(int i = start; i < avatar.Inventory.Count && i < start + itemSlots; i++)
			{
				avatar.Inventory[i].X = itemPostions[i-start].X;
				avatar.Inventory[i].Y = itemPostions[i-start].Y;
			}
		}
		
		public override void Added()
		{
			base.Added();
			foreach(var interactiveObject in avatar.Inventory)
			{
				DSW.Add(interactiveObject);
				interactiveObject.InventoryObject = true;
				interactiveObject.Layer = Utility.MIDDLE_UI_LAYER-1;
			}
		}
		
		public override void Removed()
		{
			base.Removed();
			foreach(var interactiveObject in avatar.Inventory)
				DSW.Remove(interactiveObject);
			//World.RemoveList(avatar.Inventory.Cast<Entity>().ToArray());
		}
		
		public void NextPage()
		{
			if((itemPage + 1) * itemSlots >= avatar.Inventory.Count)
				itemPage = 0;
			else
				itemPage++;
		}
		
		public void PrevPage()
		{
			if(itemPage <= 0)
				itemPage = avatar.Inventory.Count / itemSlots;
			else
				itemPage--;
		}
		
		public void SetItemsActive(bool active)
		{
			int start = itemPage * itemSlots;
			for(int i = start; i < avatar.Inventory.Count && i < start + itemSlots; i++)
				avatar.Inventory[i].sprite.Visible = active;
		}
		
		public void AddItem(InteractiveObject interactiveObject)
		{
			if(!avatar.Inventory.Contains(interactiveObject))
			{
				interactiveObject.InventoryObject = true;
				interactiveObject.Layer = Utility.MIDDLE_UI_LAYER-1;
				avatar.Inventory.Add(interactiveObject);
				World.Add(interactiveObject);
				IsActive = IsActive;
			}
//			interactiveObject.Scale = 
		}
		
		public void RemoveItem(InteractiveObject interactiveObject)
		{
			if(avatar.Inventory.Contains(interactiveObject))
			{
				interactiveObject.InventoryObject = false;
				avatar.Inventory.Remove(interactiveObject);
				World.Remove(interactiveObject);
			}
		}
		
		public bool IsInInventory(InteractiveObject interactiveObject)
		{
			return avatar.Inventory.Contains(interactiveObject);
		}
	}
}
