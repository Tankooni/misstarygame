using System;

namespace MissTarryEditor
{
	partial class frmObjects
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lbxObjects = new System.Windows.Forms.ListBox();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.btnNewObject = new System.Windows.Forms.Button();
			this.lvwAnimations = new System.Windows.Forms.ListView();
			this.btnAddImages = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnUseObject = new System.Windows.Forms.Button();
			this.btnRemoveImage = new System.Windows.Forms.Button();
			this.btnRemoveObject = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txtAnimation = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lbxObjects
			// 
			this.lbxObjects.FormattingEnabled = true;
			this.lbxObjects.Location = new System.Drawing.Point(626, 32);
			this.lbxObjects.Name = "lbxObjects";
			this.lbxObjects.Size = new System.Drawing.Size(137, 342);
			this.lbxObjects.TabIndex = 1;
			this.lbxObjects.SelectedIndexChanged += new System.EventHandler(this.lbxObjects_SelectedIndexChanged);
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.propertyGrid1.Location = new System.Drawing.Point(29, 32);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(265, 349);
			this.propertyGrid1.TabIndex = 2;
			this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
			// 
			// btnNewObject
			// 
			this.btnNewObject.Location = new System.Drawing.Point(626, 387);
			this.btnNewObject.Name = "btnNewObject";
			this.btnNewObject.Size = new System.Drawing.Size(113, 23);
			this.btnNewObject.TabIndex = 3;
			this.btnNewObject.Text = "Add New Object";
			this.btnNewObject.UseVisualStyleBackColor = true;
			this.btnNewObject.Click += new System.EventHandler(this.btnNewObject_Click);
			// 
			// lvwAnimations
			// 
			this.lvwAnimations.Location = new System.Drawing.Point(300, 32);
			this.lvwAnimations.Name = "lvwAnimations";
			this.lvwAnimations.Size = new System.Drawing.Size(320, 349);
			this.lvwAnimations.TabIndex = 4;
			this.lvwAnimations.UseCompatibleStateImageBehavior = false;
			// 
			// btnAddImages
			// 
			this.btnAddImages.Location = new System.Drawing.Point(300, 387);
			this.btnAddImages.Name = "btnAddImages";
			this.btnAddImages.Size = new System.Drawing.Size(113, 23);
			this.btnAddImages.TabIndex = 5;
			this.btnAddImages.Text = "Add Image(s)";
			this.btnAddImages.UseVisualStyleBackColor = true;
			this.btnAddImages.Click += new System.EventHandler(this.btnAddImages_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(623, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Object List";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(297, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Image List";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(26, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Object Properties";
			// 
			// btnUseObject
			// 
			this.btnUseObject.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnUseObject.Location = new System.Drawing.Point(29, 387);
			this.btnUseObject.Name = "btnUseObject";
			this.btnUseObject.Size = new System.Drawing.Size(113, 23);
			this.btnUseObject.TabIndex = 9;
			this.btnUseObject.Text = "Use Selected Object";
			this.btnUseObject.UseVisualStyleBackColor = true;
			this.btnUseObject.Click += new System.EventHandler(this.btnUseObject_Click);
			// 
			// btnRemoveImage
			// 
			this.btnRemoveImage.Location = new System.Drawing.Point(419, 387);
			this.btnRemoveImage.Name = "btnRemoveImage";
			this.btnRemoveImage.Size = new System.Drawing.Size(113, 23);
			this.btnRemoveImage.TabIndex = 10;
			this.btnRemoveImage.Text = "Remove Image";
			this.btnRemoveImage.UseVisualStyleBackColor = true;
			this.btnRemoveImage.Click += new System.EventHandler(this.btnRemoveImage_Click);
			// 
			// btnRemoveObject
			// 
			this.btnRemoveObject.Location = new System.Drawing.Point(626, 416);
			this.btnRemoveObject.Name = "btnRemoveObject";
			this.btnRemoveObject.Size = new System.Drawing.Size(113, 23);
			this.btnRemoveObject.TabIndex = 11;
			this.btnRemoveObject.Text = "Remove Object";
			this.btnRemoveObject.UseVisualStyleBackColor = true;
			this.btnRemoveObject.Click += new System.EventHandler(this.btnRemoveObject_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(297, 421);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(90, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Default Animation";
			// 
			// txtAnimation
			// 
			this.txtAnimation.Location = new System.Drawing.Point(393, 418);
			this.txtAnimation.Name = "txtAnimation";
			this.txtAnimation.Size = new System.Drawing.Size(139, 20);
			this.txtAnimation.TabIndex = 13;
			// 
			// frmObjects
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(775, 457);
			this.Controls.Add(this.txtAnimation);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnRemoveObject);
			this.Controls.Add(this.btnRemoveImage);
			this.Controls.Add(this.btnUseObject);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnAddImages);
			this.Controls.Add(this.lvwAnimations);
			this.Controls.Add(this.btnNewObject);
			this.Controls.Add(this.propertyGrid1);
			this.Controls.Add(this.lbxObjects);
			this.Name = "frmObjects";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Objects";
			this.Load += new System.EventHandler(this.frmObjects_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ListBox lbxObjects;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.Button btnNewObject;
		private System.Windows.Forms.ListView lvwAnimations;
		private System.Windows.Forms.Button btnAddImages;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnUseObject;
		private System.Windows.Forms.Button btnRemoveImage;
		private System.Windows.Forms.Button btnRemoveObject;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtAnimation;
	}
}