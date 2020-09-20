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
			this.chordProgSelector = new System.Windows.Forms.ComboBox();
			this.chordFreqTrackBar = new System.Windows.Forms.TrackBar();
			this.automaticHarmonyButton = new System.Windows.Forms.Button();
			this.chordFreqLabel = new System.Windows.Forms.Label();
			this.showMessageCheckBox = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.chordFreqTrackBar)).BeginInit();
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
			this.manualHarmonyButton.Click += new System.EventHandler(this.manualHarmonyButton_Click);
			// 
			// scaleSelector
			// 
			this.scaleSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.scaleSelector.FormattingEnabled = true;
			this.scaleSelector.Location = new System.Drawing.Point(476, 61);
			this.scaleSelector.Name = "scaleSelector";
			this.scaleSelector.Size = new System.Drawing.Size(128, 24);
			this.scaleSelector.TabIndex = 5;
			this.scaleSelector.SelectedIndexChanged += new System.EventHandler(this.scaleSelector_SelectedIndexChanged);
			// 
			// majMinSelector
			// 
			this.majMinSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.majMinSelector.FormattingEnabled = true;
			this.majMinSelector.Location = new System.Drawing.Point(639, 60);
			this.majMinSelector.Name = "majMinSelector";
			this.majMinSelector.Size = new System.Drawing.Size(108, 24);
			this.majMinSelector.TabIndex = 6;
			this.majMinSelector.SelectedIndexChanged += new System.EventHandler(this.majMinSelector_SelectedIndexChanged);
			// 
			// chordProgSelector
			// 
			this.chordProgSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.chordProgSelector.FormattingEnabled = true;
			this.chordProgSelector.Location = new System.Drawing.Point(323, 318);
			this.chordProgSelector.Name = "chordProgSelector";
			this.chordProgSelector.Size = new System.Drawing.Size(153, 24);
			this.chordProgSelector.TabIndex = 7;
			// 
			// chordFreqTrackBar
			// 
			this.chordFreqTrackBar.Location = new System.Drawing.Point(314, 362);
			this.chordFreqTrackBar.Maximum = 4;
			this.chordFreqTrackBar.Minimum = 1;
			this.chordFreqTrackBar.Name = "chordFreqTrackBar";
			this.chordFreqTrackBar.Size = new System.Drawing.Size(162, 56);
			this.chordFreqTrackBar.TabIndex = 8;
			this.chordFreqTrackBar.Value = 1;
			this.chordFreqTrackBar.Scroll += new System.EventHandler(this.chordFreqTrackBar_Scroll);
			// 
			// automaticHarmonyButton
			// 
			this.automaticHarmonyButton.Location = new System.Drawing.Point(528, 319);
			this.automaticHarmonyButton.Name = "automaticHarmonyButton";
			this.automaticHarmonyButton.Size = new System.Drawing.Size(125, 53);
			this.automaticHarmonyButton.TabIndex = 9;
			this.automaticHarmonyButton.Text = "Generate";
			this.automaticHarmonyButton.UseVisualStyleBackColor = true;
			this.automaticHarmonyButton.Click += new System.EventHandler(this.automaticHarmonyButton_Click);
			// 
			// chordFreqLabel
			// 
			this.chordFreqLabel.AutoSize = true;
			this.chordFreqLabel.Location = new System.Drawing.Point(320, 401);
			this.chordFreqLabel.Name = "chordFreqLabel";
			this.chordFreqLabel.Size = new System.Drawing.Size(16, 17);
			this.chordFreqLabel.TabIndex = 10;
			this.chordFreqLabel.Text = "1";
			// 
			// showMessageCheckBox
			// 
			this.showMessageCheckBox.AutoSize = true;
			this.showMessageCheckBox.Checked = true;
			this.showMessageCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showMessageCheckBox.Location = new System.Drawing.Point(534, 387);
			this.showMessageCheckBox.Name = "showMessageCheckBox";
			this.showMessageCheckBox.Size = new System.Drawing.Size(198, 21);
			this.showMessageCheckBox.TabIndex = 11;
			this.showMessageCheckBox.Text = "Show message when done";
			this.showMessageCheckBox.UseVisualStyleBackColor = true;
			this.showMessageCheckBox.CheckedChanged += new System.EventHandler(this.showMessageCheckBox_CheckedChanged);
			// 
			// ModifyRecordingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.showMessageCheckBox);
			this.Controls.Add(this.chordFreqLabel);
			this.Controls.Add(this.automaticHarmonyButton);
			this.Controls.Add(this.chordFreqTrackBar);
			this.Controls.Add(this.chordProgSelector);
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
			((System.ComponentModel.ISupportInitialize)(this.chordFreqTrackBar)).EndInit();
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
		private System.Windows.Forms.ComboBox chordProgSelector;
		private System.Windows.Forms.TrackBar chordFreqTrackBar;
		private System.Windows.Forms.Button automaticHarmonyButton;
		private System.Windows.Forms.Label chordFreqLabel;
		private System.Windows.Forms.CheckBox showMessageCheckBox;
	}
}