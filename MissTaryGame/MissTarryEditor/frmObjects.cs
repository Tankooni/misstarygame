﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissTarryEditor
{
	public partial class frmObjects : Form
	{
		List<ObjectWrapper> ObjectWrappers { get; set; }
		ObjectWrapper SelectedObject = null;
		Form1 ParentForm = null;

		public frmObjects(Form1 parent, List<ObjectWrapper> wrappers)
		{
			InitializeComponent();
			ParentForm = parent;
			ObjectWrappers = wrappers;

			UpdateObjectList();
		}

		private void frmObjects_Load(object sender, EventArgs e)
		{

		}

		internal void AddPictureBox(string animation, string filename, SillyPictureBox pb)
		{
			if (SelectedObject != null)
				SelectedObject.AddAnimation(animation, filename, pb);
			else
				MessageBox.Show("Selected object is null, images not added. Please select an object");
		}

		internal void UpdateImageList()
		{
			lvwAnimations.Items.Clear();
			if (SelectedObject == null)
				return;

			lvwAnimations.View = View.LargeIcon;
			ImageList imageListThing = new ImageList();
			foreach (var key in SelectedObject.Animations.Keys)
			{
				foreach (var item in SelectedObject.Animations[key].OrderBy(x => x.Item1))
				{
					imageListThing.Images.Add(item.Item2.Image);
				}
			}
			//var images = SelectedObject.Animations.SelectMany(x => x.Value).OrderBy(x=>x.Item1).Select(x => x.Item2.Image);
			//foreach (var image in images)
			//	imageListThing.Images.Add(image);
			lvwAnimations.LargeImageList = imageListThing;
			int count = 0;
			foreach(var key in SelectedObject.Animations.Keys)
			{
				foreach(var item in SelectedObject.Animations[key].OrderBy(x=>x.Item1))
				{
					ListViewItem listItem = new ListViewItem();
					listItem.ImageIndex = count;
					listItem.Text = key + " : " + item.Item1;
					lvwAnimations.Items.Add(listItem);
					count++;
				}
			}
		}

		private void btnNewObject_Click(object sender, EventArgs e)
		{
			ObjectWrapper wrapper = new ObjectWrapper();
			wrapper.ObjectInfo.Name = "DefaultName";
			ObjectWrappers.Add(wrapper);
			SelectedObject = wrapper;

			UpdateObjectList();
		}

		private void lbxObjects_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListBox box = (ListBox)sender;
			if (box.SelectedItem == null)
				return;
			var selectedInfo = (ObjectWrapper)box.SelectedItem;
			SelectedObject = selectedInfo;

			propertyGrid1.SelectedObject = SelectedObject;
		}

		private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			UpdateObjectList();
		}

		private void UpdateObjectList()
		{
			lbxObjects.Items.Clear();
			foreach (var obj in ObjectWrappers)
				lbxObjects.Items.Add(obj);
		}

		private void btnUseObject_Click(object sender, EventArgs e)
		{
			if (SelectedObject != null)
			{
				ParentForm.AddObjectWrapper(SelectedObject);
				ParentForm.UpdateObjectWrapperList(ObjectWrappers);
				this.Close();
			}
			else
				MessageBox.Show("Please select an object");
		}

		private void btnAddImages_Click(object sender, EventArgs e)
		{
			if (SelectedObject == null)
				return;
			frmImageAdder newForm = new frmImageAdder(this);
			newForm.Show();
		}

		private void btnRemoveObject_Click(object sender, EventArgs e)
		{
			var item = (ObjectWrapper)lbxObjects.SelectedItem;
			if (item == null)
				return;
			if (MessageBox.Show("Are you sure you want to remove the object: " + item.ToString(), "Remove Object", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				SelectedObject = null;
				ObjectWrappers.Remove(item);
				UpdateImageList();
				propertyGrid1.SelectedObject = null;
				lbxObjects.Items.Clear();
			}
        }

		private void btnRemoveImage_Click(object sender, EventArgs e)
		{
			List<int> removeIndexes = new List<int>();
			foreach (int item in lvwAnimations.SelectedIndices)
			{
				removeIndexes.Add(item);
			}

			int count = 0;
			foreach (var key in SelectedObject.Animations.Keys.ToArray())
			{
				foreach (var item in SelectedObject.Animations[key].OrderBy(x => x.Item1).ToArray())
				{
					if (removeIndexes.Contains(count))
						SelectedObject.Animations[key].Remove(item);
					if (SelectedObject.Animations[key].Count == 0)
						SelectedObject.Animations.Remove(key);
					count++;
				}
			}

			UpdateImageList();
		}
	}
}
