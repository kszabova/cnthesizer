namespace Cnthesizer
{
	partial class ManualHarmonyForm
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
			this.ilow = new System.Windows.Forms.Button();
			this.ii = new System.Windows.Forms.Button();
			this.iii = new System.Windows.Forms.Button();
			this.iv = new System.Windows.Forms.Button();
			this.v = new System.Windows.Forms.Button();
			this.vi = new System.Windows.Forms.Button();
			this.vii = new System.Windows.Forms.Button();
			this.ihigh = new System.Windows.Forms.Button();
			this.closeButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ilow
			// 
			this.ilow.Location = new System.Drawing.Point(40, 150);
			this.ilow.Name = "ilow";
			this.ilow.Size = new System.Drawing.Size(72, 65);
			this.ilow.TabIndex = 0;
			this.ilow.Text = "I";
			this.ilow.UseVisualStyleBackColor = true;
			this.ilow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChordButtonMouseDown);
			this.ilow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChordButtonMouseUp);
			// 
			// ii
			// 
			this.ii.Location = new System.Drawing.Point(130, 150);
			this.ii.Name = "ii";
			this.ii.Size = new System.Drawing.Size(72, 65);
			this.ii.TabIndex = 1;
			this.ii.Text = "ii";
			this.ii.UseVisualStyleBackColor = true;
			this.ii.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChordButtonMouseDown);
			this.ii.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChordButtonMouseUp);
			// 
			// iii
			// 
			this.iii.Location = new System.Drawing.Point(221, 150);
			this.iii.Name = "iii";
			this.iii.Size = new System.Drawing.Size(72, 65);
			this.iii.TabIndex = 2;
			this.iii.Text = "iii";
			this.iii.UseVisualStyleBackColor = true;
			this.iii.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChordButtonMouseDown);
			this.iii.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChordButtonMouseUp);
			// 
			// iv
			// 
			this.iv.Location = new System.Drawing.Point(310, 150);
			this.iv.Name = "iv";
			this.iv.Size = new System.Drawing.Size(72, 65);
			this.iv.TabIndex = 3;
			this.iv.Text = "IV";
			this.iv.UseVisualStyleBackColor = true;
			this.iv.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChordButtonMouseDown);
			this.iv.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChordButtonMouseUp);
			// 
			// v
			// 
			this.v.Location = new System.Drawing.Point(399, 150);
			this.v.Name = "v";
			this.v.Size = new System.Drawing.Size(72, 65);
			this.v.TabIndex = 4;
			this.v.Text = "V";
			this.v.UseVisualStyleBackColor = true;
			this.v.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChordButtonMouseDown);
			this.v.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChordButtonMouseUp);
			// 
			// vi
			// 
			this.vi.Location = new System.Drawing.Point(486, 150);
			this.vi.Name = "vi";
			this.vi.Size = new System.Drawing.Size(72, 65);
			this.vi.TabIndex = 5;
			this.vi.Text = "vi";
			this.vi.UseVisualStyleBackColor = true;
			this.vi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChordButtonMouseDown);
			this.vi.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChordButtonMouseUp);
			// 
			// vii
			// 
			this.vii.Location = new System.Drawing.Point(575, 150);
			this.vii.Name = "vii";
			this.vii.Size = new System.Drawing.Size(72, 65);
			this.vii.TabIndex = 6;
			this.vii.Text = "vii";
			this.vii.UseVisualStyleBackColor = true;
			this.vii.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChordButtonMouseDown);
			this.vii.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChordButtonMouseUp);
			// 
			// ihigh
			// 
			this.ihigh.Location = new System.Drawing.Point(663, 150);
			this.ihigh.Name = "ihigh";
			this.ihigh.Size = new System.Drawing.Size(72, 65);
			this.ihigh.TabIndex = 7;
			this.ihigh.Text = "I";
			this.ihigh.UseVisualStyleBackColor = true;
			this.ihigh.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChordButtonMouseDown);
			this.ihigh.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChordButtonMouseUp);
			// 
			// closeButton
			// 
			this.closeButton.Location = new System.Drawing.Point(586, 328);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(148, 63);
			this.closeButton.TabIndex = 8;
			this.closeButton.Text = "Close";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// ManualHarmonyForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.ihigh);
			this.Controls.Add(this.vii);
			this.Controls.Add(this.vi);
			this.Controls.Add(this.v);
			this.Controls.Add(this.iv);
			this.Controls.Add(this.iii);
			this.Controls.Add(this.ii);
			this.Controls.Add(this.ilow);
			this.Name = "ManualHarmonyForm";
			this.Text = "Add Harmony";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button ilow;
		private System.Windows.Forms.Button ii;
		private System.Windows.Forms.Button iii;
		private System.Windows.Forms.Button iv;
		private System.Windows.Forms.Button v;
		private System.Windows.Forms.Button vi;
		private System.Windows.Forms.Button vii;
		private System.Windows.Forms.Button ihigh;
		private System.Windows.Forms.Button closeButton;
	}
}