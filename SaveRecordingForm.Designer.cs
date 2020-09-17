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
			this.filenameTextBox = new System.Windows.Forms.TextBox();
			this.saveFilenameButton = new System.Windows.Forms.Button();
			this.filenameLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// filenameTextBox
			// 
			this.filenameTextBox.Location = new System.Drawing.Point(59, 108);
			this.filenameTextBox.Name = "filenameTextBox";
			this.filenameTextBox.Size = new System.Drawing.Size(285, 22);
			this.filenameTextBox.TabIndex = 0;
			this.filenameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.filenameTextBox_KeyPress);
			// 
			// saveFilenameButton
			// 
			this.saveFilenameButton.Location = new System.Drawing.Point(363, 100);
			this.saveFilenameButton.Name = "saveFilenameButton";
			this.saveFilenameButton.Size = new System.Drawing.Size(87, 39);
			this.saveFilenameButton.TabIndex = 1;
			this.saveFilenameButton.Text = "Confirm";
			this.saveFilenameButton.UseVisualStyleBackColor = true;
			this.saveFilenameButton.Click += new System.EventHandler(this.saveFilenameButton_Click);
			// 
			// filenameLabel
			// 
			this.filenameLabel.AutoSize = true;
			this.filenameLabel.Location = new System.Drawing.Point(56, 79);
			this.filenameLabel.Name = "filenameLabel";
			this.filenameLabel.Size = new System.Drawing.Size(307, 17);
			this.filenameLabel.TabIndex = 2;
			this.filenameLabel.Text = "Please enter file name (leave blank for default):";
			// 
			// SaveRecordingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(498, 239);
			this.Controls.Add(this.filenameLabel);
			this.Controls.Add(this.saveFilenameButton);
			this.Controls.Add(this.filenameTextBox);
			this.Name = "SaveRecordingForm";
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