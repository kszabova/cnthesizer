namespace Cnthesizer
{
	partial class ModifyRecordingForm
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
			this.playButton = new System.Windows.Forms.Button();
			this.shiftSelectorComboBox = new System.Windows.Forms.ComboBox();
			this.stopButton = new System.Windows.Forms.Button();
			this.pitchShiftLabel = new System.Windows.Forms.Label();
			this.manualHarmonyButton = new System.Windows.Forms.Button();
			this.scaleSelector = new System.Windows.Forms.ComboBox();
			this.majMinSelector = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// playButton
			// 
			this.playButton.Location = new System.Drawing.Point(40, 34);
			this.playButton.Name = "playButton";
			this.playButton.Size = new System.Drawing.Size(140, 103);
			this.playButton.TabIndex = 0;
			this.playButton.Text = "Play";
			this.playButton.UseVisualStyleBackColor = true;
			this.playButton.Click += new System.EventHandler(this.playButton_Click);
			// 
			// shiftSelectorComboBox
			// 
			this.shiftSelectorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.shiftSelectorComboBox.FormattingEnabled = true;
			this.shiftSelectorComboBox.Location = new System.Drawing.Point(40, 208);
			this.shiftSelectorComboBox.Name = "shiftSelectorComboBox";
			this.shiftSelectorComboBox.Size = new System.Drawing.Size(180, 24);
			this.shiftSelectorComboBox.TabIndex = 1;
			this.shiftSelectorComboBox.SelectedIndexChanged += new System.EventHandler(this.shiftSelectorComboBox_SelectedIndexChanged);
			// 
			// stopButton
			// 
			this.stopButton.Location = new System.Drawing.Point(226, 34);
			this.stopButton.Name = "stopButton";
			this.stopButton.Size = new System.Drawing.Size(140, 103);
			this.stopButton.TabIndex = 2;
			this.stopButton.Text = "Stop";
			this.stopButton.UseVisualStyleBackColor = true;
			this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
			// 
			// pitchShiftLabel
			// 
			this.pitchShiftLabel.AutoSize = true;
			this.pitchShiftLabel.Location = new System.Drawing.Point(37, 175);
			this.pitchShiftLabel.Name = "pitchShiftLabel";
			this.pitchShiftLabel.Size = new System.Drawing.Size(111, 17);
			this.pitchShiftLabel.TabIndex = 3;
			this.pitchShiftLabel.Text = "Select pitch shift";
			// 
			// manualHarmonyButton
			// 
			this.manualHarmonyButton.Location = new System.Drawing.Point(40, 311);
			this.manualHarmonyButton.Name = "manualHarmonyButton";
			this.manualHarmonyButton.Size = new System.Drawing.Size(179, 64);
			this.manualHarmonyButton.TabIndex = 4;
			this.manualHarmonyButton.Text = "Add harmony";
			this.manualHarmonyButton.UseVisualStyleBackColor = true;
			// 
			// scaleSelector
			// 
			this.scaleSelector.FormattingEnabled = true;
			this.scaleSelector.Location = new System.Drawing.Point(476, 61);
			this.scaleSelector.Name = "scaleSelector";
			this.scaleSelector.Size = new System.Drawing.Size(128, 24);
			this.scaleSelector.TabIndex = 5;
			this.scaleSelector.SelectedIndexChanged += new System.EventHandler(this.scaleSelector_SelectedIndexChanged);
			// 
			// majMinSelector
			// 
			this.majMinSelector.FormattingEnabled = true;
			this.majMinSelector.Location = new System.Drawing.Point(639, 60);
			this.majMinSelector.Name = "majMinSelector";
			this.majMinSelector.Size = new System.Drawing.Size(108, 24);
			this.majMinSelector.TabIndex = 6;
			this.majMinSelector.SelectedIndexChanged += new System.EventHandler(this.majMinSelector_SelectedIndexChanged);
			// 
			// ModifyRecordingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.majMinSelector);
			this.Controls.Add(this.scaleSelector);
			this.Controls.Add(this.manualHarmonyButton);
			this.Controls.Add(this.pitchShiftLabel);
			this.Controls.Add(this.stopButton);
			this.Controls.Add(this.shiftSelectorComboBox);
			this.Controls.Add(this.playButton);
			this.Name = "ModifyRecordingForm";
			this.Text = "Modify recording";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ModifyRecordingForm_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button playButton;
		private System.Windows.Forms.ComboBox shiftSelectorComboBox;
		private System.Windows.Forms.Button stopButton;
		private System.Windows.Forms.Label pitchShiftLabel;
		private System.Windows.Forms.Button manualHarmonyButton;
		private System.Windows.Forms.ComboBox scaleSelector;
		private System.Windows.Forms.ComboBox majMinSelector;
	}
}