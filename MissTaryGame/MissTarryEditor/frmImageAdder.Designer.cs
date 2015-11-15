namespace MissTarryEditor
{
	partial class frmImageAdder
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.lvwImages = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Animation:";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(74, 21);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(252, 20);
			this.textBox2.TabIndex = 2;
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(224, 184);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(102, 23);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.button1_Click);
			// 
			// lvwImages
			// 
			this.lvwImages.Location = new System.Drawing.Point(12, 47);
			this.lvwImages.Name = "lvwImages";
			this.lvwImages.Size = new System.Drawing.Size(314, 131);
			this.lvwImages.TabIndex = 4;
			this.lvwImages.UseCompatibleStateImageBehavior = false;
			// 
			// frmImageAdder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(338, 219);
			this.Controls.Add(this.lvwImages);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label1);
			this.Name = "frmImageAdder";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "frmImageAdder";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.ListView lvwImages;
	}
}