namespace Cnthesizer
{
	partial class SaveRecordingForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveRecordingForm));
			this.filenameTextBox = new System.Windows.Forms.TextBox();
			this.saveFilenameButton = new System.Windows.Forms.Button();
			this.filenameLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// filenameTextBox
			// 
			this.filenameTextBox.Location = new System.Drawing.Point(59, 108);
			this.filenameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.filenameTextBox.Name = "filenameTextBox";
			this.filenameTextBox.Size = new System.Drawing.Size(285, 22);
			this.filenameTextBox.TabIndex = 0;
			this.filenameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.filenameTextBox_KeyPress);
			// 
			// saveFilenameButton
			// 
			this.saveFilenameButton.BackColor = System.Drawing.Color.RoyalBlue;
			this.saveFilenameButton.FlatAppearance.BorderSize = 0;
			this.saveFilenameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.saveFilenameButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.saveFilenameButton.ForeColor = System.Drawing.Color.White;
			this.saveFilenameButton.Location = new System.Drawing.Point(363, 100);
			this.saveFilenameButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.saveFilenameButton.Name = "saveFilenameButton";
			this.saveFilenameButton.Size = new System.Drawing.Size(87, 39);
			this.saveFilenameButton.TabIndex = 1;
			this.saveFilenameButton.Text = "Confirm";
			this.saveFilenameButton.UseVisualStyleBackColor = false;
			this.saveFilenameButton.Click += new System.EventHandler(this.saveFilenameButton_Click);
			// 
			// filenameLabel
			// 
			this.filenameLabel.AutoSize = true;
			this.filenameLabel.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.filenameLabel.Location = new System.Drawing.Point(56, 80);
			this.filenameLabel.Name = "filenameLabel";
			this.filenameLabel.Size = new System.Drawing.Size(296, 17);
			this.filenameLabel.TabIndex = 2;
			this.filenameLabel.Text = "Please enter file name (leave blank for default):";
			// 
			// SaveRecordingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightSteelBlue;
			this.ClientSize = new System.Drawing.Size(499, 239);
			this.Controls.Add(this.filenameLabel);
			this.Controls.Add(this.saveFilenameButton);
			this.Controls.Add(this.filenameTextBox);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "SaveRecordingForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Save recording";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox filenameTextBox;
		private System.Windows.Forms.Button saveFilenameButton;
		private System.Windows.Forms.Label filenameLabel;
	}
}