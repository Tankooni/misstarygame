using System;
using System.Collections.Generic;

namespace MissTarryEditor
{
	partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.objectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cbxForeground = new System.Windows.Forms.CheckBox();
			this.radForeground = new System.Windows.Forms.RadioButton();
			this.cbxBackground = new System.Windows.Forms.CheckBox();
			this.cbxCollision = new System.Windows.Forms.CheckBox();
			this.cbxGradiant = new System.Windows.Forms.CheckBox();
			this.radBackground = new System.Windows.Forms.RadioButton();
			this.radCollision = new System.Windows.Forms.RadioButton();
			this.radGradiant = new System.Windows.Forms.RadioButton();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.sceneToolStripMenuItem,
            this.objectsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1269, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			// 
			// sceneToolStripMenuItem
			// 
			this.sceneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSceneToolStripMenuItem});
			this.sceneToolStripMenuItem.Name = "sceneToolStripMenuItem";
			this.sceneToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
			this.sceneToolStripMenuItem.Text = "Scene";
			// 
			// addSceneToolStripMenuItem
			// 
			this.addSceneToolStripMenuItem.Name = "addSceneToolStripMenuItem";
			this.addSceneToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
			this.addSceneToolStripMenuItem.Text = "Add Scene";
			// 
			// objectsToolStripMenuItem
			// 
			this.objectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addObjectToolStripMenuItem});
			this.objectsToolStripMenuItem.Name = "objectsToolStripMenuItem";
			this.objectsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.objectsToolStripMenuItem.Text = "Objects";
			// 
			// addObjectToolStripMenuItem
			// 
			this.addObjectToolStripMenuItem.Name = "addObjectToolStripMenuItem";
			this.addObjectToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.addObjectToolStripMenuItem.Text = "Add Object";
			this.addObjectToolStripMenuItem.Click += new System.EventHandler(this.addObjectToolStripMenuItem_Click);
			// 
			// cbxForeground
			// 
			this.cbxForeground.AutoSize = true;
			this.cbxForeground.Location = new System.Drawing.Point(12, 67);
			this.cbxForeground.Name = "cbxForeground";
			this.cbxForeground.Size = new System.Drawing.Size(15, 14);
			this.cbxForeground.TabIndex = 2;
			this.cbxForeground.UseVisualStyleBackColor = true;
			this.cbxForeground.CheckedChanged += new System.EventHandler(this.cbxForeground_CheckedChanged);
			// 
			// radForeground
			// 
			this.radForeground.AutoSize = true;
			this.radForeground.Checked = true;
			this.radForeground.Location = new System.Drawing.Point(37, 64);
			this.radForeground.Name = "radForeground";
			this.radForeground.Size = new System.Drawing.Size(79, 17);
			this.radForeground.TabIndex = 3;
			this.radForeground.TabStop = true;
			this.radForeground.Text = "Foreground";
			this.radForeground.UseVisualStyleBackColor = true;
			this.radForeground.CheckedChanged += new System.EventHandler(this.radForeground_CheckedChanged);
			// 
			// cbxBackground
			// 
			this.cbxBackground.AutoSize = true;
			this.cbxBackground.Location = new System.Drawing.Point(12, 90);
			this.cbxBackground.Name = "cbxBackground";
			this.cbxBackground.Size = new System.Drawing.Size(15, 14);
			this.cbxBackground.TabIndex = 5;
			this.cbxBackground.UseVisualStyleBackColor = true;
			this.cbxBackground.CheckedChanged += new System.EventHandler(this.cbxBackground_CheckedChanged);
			// 
			// cbxCollision
			// 
			this.cbxCollision.AutoSize = true;
			this.cbxCollision.Location = new System.Drawing.Point(12, 113);
			this.cbxCollision.Name = "cbxCollision";
			this.cbxCollision.Size = new System.Drawing.Size(15, 14);
			this.cbxCollision.TabIndex = 6;
			this.cbxCollision.UseVisualStyleBackColor = true;
			this.cbxCollision.CheckedChanged += new System.EventHandler(this.cbxCollision_CheckedChanged);
			// 
			// cbxGradiant
			// 
			this.cbxGradiant.AutoSize = true;
			this.cbxGradiant.Location = new System.Drawing.Point(12, 136);
			this.cbxGradiant.Name = "cbxGradiant";
			this.cbxGradiant.Size = new System.Drawing.Size(15, 14);
			this.cbxGradiant.TabIndex = 7;
			this.cbxGradiant.UseVisualStyleBackColor = true;
			this.cbxGradiant.CheckedChanged += new System.EventHandler(this.cbxGradiant_CheckedChanged);
			// 
			// radBackground
			// 
			this.radBackground.AutoSize = true;
			this.radBackground.Location = new System.Drawing.Point(37, 87);
			this.radBackground.Name = "radBackground";
			this.radBackground.Size = new System.Drawing.Size(83, 17);
			this.radBackground.TabIndex = 9;
			this.radBackground.Text = "Background";
			this.radBackground.UseVisualStyleBackColor = true;
			this.radBackground.CheckedChanged += new System.EventHandler(this.radBackground_CheckedChanged);
			// 
			// radCollision
			// 
			this.radCollision.AutoSize = true;
			this.radCollision.Location = new System.Drawing.Point(37, 110);
			this.radCollision.Name = "radCollision";
			this.radCollision.Size = new System.Drawing.Size(63, 17);
			this.radCollision.TabIndex = 10;
			this.radCollision.Text = "Collision";
			this.radCollision.UseVisualStyleBackColor = true;
			this.radCollision.CheckedChanged += new System.EventHandler(this.radCollision_CheckedChanged);
			// 
			// radGradiant
			// 
			this.radGradiant.AutoSize = true;
			this.radGradiant.Location = new System.Drawing.Point(37, 133);
			this.radGradiant.Name = "radGradiant";
			this.radGradiant.Size = new System.Drawing.Size(65, 17);
			this.radGradiant.TabIndex = 11;
			this.radGradiant.Text = "Gradiant";
			this.radGradiant.UseVisualStyleBackColor = true;
			this.radGradiant.CheckedChanged += new System.EventHandler(this.radGradiant_CheckedChanged);
			// 
			// pictureBox3
			// 
			this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.pictureBox3.Image = global::MissTarryEditor.Properties.Resources.Pencil_Small;
			this.pictureBox3.Location = new System.Drawing.Point(33, 41);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(20, 20);
			this.pictureBox3.TabIndex = 8;
			this.pictureBox3.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(8, 41);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(20, 20);
			this.pictureBox2.TabIndex = 4;
			this.pictureBox2.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(126, 27);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1136, 640);
			this.panel1.TabIndex = 12;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1269, 679);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.radGradiant);
			this.Controls.Add(this.radCollision);
			this.Controls.Add(this.radBackground);
			this.Controls.Add(this.pictureBox3);
			this.Controls.Add(this.cbxGradiant);
			this.Controls.Add(this.cbxCollision);
			this.Controls.Add(this.cbxBackground);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.radForeground);
			this.Controls.Add(this.cbxForeground);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sceneToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addSceneToolStripMenuItem;
		private System.Windows.Forms.CheckBox cbxForeground;
		private System.Windows.Forms.RadioButton radForeground;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.CheckBox cbxBackground;
		private System.Windows.Forms.CheckBox cbxCollision;
		private System.Windows.Forms.CheckBox cbxGradiant;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.RadioButton radBackground;
		private System.Windows.Forms.RadioButton radCollision;
		private System.Windows.Forms.RadioButton radGradiant;
		private System.Windows.Forms.ToolStripMenuItem objectsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addObjectToolStripMenuItem;
		private System.Windows.Forms.Panel panel1;
	}
}

