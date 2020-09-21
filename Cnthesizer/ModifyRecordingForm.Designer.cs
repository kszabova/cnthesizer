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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyRecordingForm));
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
			this.showMessageHarmonyCheckBox = new System.Windows.Forms.CheckBox();
			this.shiftRecordingByPitchButton = new System.Windows.Forms.Button();
			this.showMessageShiftCheckBox = new System.Windows.Forms.CheckBox();
			this.selectScaleLabel = new System.Windows.Forms.Label();
			this.manualHarmonyLabel = new System.Windows.Forms.Label();
			this.chordProgLabel = new System.Windows.Forms.Label();
			this.beatSliderLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.chordFreqTrackBar)).BeginInit();
			this.SuspendLayout();
			// 
			// playButton
			// 
			this.playButton.BackColor = System.Drawing.Color.RoyalBlue;
			this.playButton.FlatAppearance.BorderSize = 0;
			this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.playButton.Font = new System.Drawing.Font("Roboto", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.playButton.ForeColor = System.Drawing.Color.White;
			this.playButton.Location = new System.Drawing.Point(40, 34);
			this.playButton.Name = "playButton";
			this.playButton.Size = new System.Drawing.Size(140, 103);
			this.playButton.TabIndex = 0;
			this.playButton.Text = "Play";
			this.playButton.UseVisualStyleBackColor = false;
			this.playButton.Click += new System.EventHandler(this.playButton_Click);
			// 
			// shiftSelectorComboBox
			// 
			this.shiftSelectorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.shiftSelectorComboBox.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.shiftSelectorComboBox.FormattingEnabled = true;
			this.shiftSelectorComboBox.Location = new System.Drawing.Point(296, 295);
			this.shiftSelectorComboBox.Name = "shiftSelectorComboBox";
			this.shiftSelectorComboBox.Size = new System.Drawing.Size(180, 23);
			this.shiftSelectorComboBox.TabIndex = 1;
			// 
			// stopButton
			// 
			this.stopButton.BackColor = System.Drawing.Color.RoyalBlue;
			this.stopButton.FlatAppearance.BorderSize = 0;
			this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.stopButton.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.stopButton.ForeColor = System.Drawing.Color.White;
			this.stopButton.Location = new System.Drawing.Point(218, 34);
			this.stopButton.Name = "stopButton";
			this.stopButton.Size = new System.Drawing.Size(140, 103);
			this.stopButton.TabIndex = 2;
			this.stopButton.Text = "Stop";
			this.stopButton.UseVisualStyleBackColor = false;
			this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
			// 
			// pitchShiftLabel
			// 
			this.pitchShiftLabel.AutoSize = true;
			this.pitchShiftLabel.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.pitchShiftLabel.Location = new System.Drawing.Point(294, 261);
			this.pitchShiftLabel.Name = "pitchShiftLabel";
			this.pitchShiftLabel.Size = new System.Drawing.Size(110, 17);
			this.pitchShiftLabel.TabIndex = 3;
			this.pitchShiftLabel.Text = "Select pitch shift";
			// 
			// manualHarmonyButton
			// 
			this.manualHarmonyButton.BackColor = System.Drawing.Color.RoyalBlue;
			this.manualHarmonyButton.FlatAppearance.BorderSize = 0;
			this.manualHarmonyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.manualHarmonyButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.manualHarmonyButton.ForeColor = System.Drawing.Color.White;
			this.manualHarmonyButton.Location = new System.Drawing.Point(39, 520);
			this.manualHarmonyButton.Name = "manualHarmonyButton";
			this.manualHarmonyButton.Size = new System.Drawing.Size(179, 53);
			this.manualHarmonyButton.TabIndex = 4;
			this.manualHarmonyButton.Text = "Add harmony";
			this.manualHarmonyButton.UseVisualStyleBackColor = false;
			this.manualHarmonyButton.Click += new System.EventHandler(this.manualHarmonyButton_Click);
			// 
			// scaleSelector
			// 
			this.scaleSelector.BackColor = System.Drawing.SystemColors.Window;
			this.scaleSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.scaleSelector.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.scaleSelector.FormattingEnabled = true;
			this.scaleSelector.Location = new System.Drawing.Point(39, 295);
			this.scaleSelector.Name = "scaleSelector";
			this.scaleSelector.Size = new System.Drawing.Size(128, 23);
			this.scaleSelector.TabIndex = 5;
			this.scaleSelector.SelectedIndexChanged += new System.EventHandler(this.scaleSelector_SelectedIndexChanged);
			// 
			// majMinSelector
			// 
			this.majMinSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.majMinSelector.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.majMinSelector.FormattingEnabled = true;
			this.majMinSelector.Location = new System.Drawing.Point(39, 334);
			this.majMinSelector.Name = "majMinSelector";
			this.majMinSelector.Size = new System.Drawing.Size(128, 23);
			this.majMinSelector.TabIndex = 6;
			this.majMinSelector.SelectedIndexChanged += new System.EventHandler(this.majMinSelector_SelectedIndexChanged);
			// 
			// chordProgSelector
			// 
			this.chordProgSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.chordProgSelector.FormattingEnabled = true;
			this.chordProgSelector.Location = new System.Drawing.Point(296, 478);
			this.chordProgSelector.Name = "chordProgSelector";
			this.chordProgSelector.Size = new System.Drawing.Size(153, 24);
			this.chordProgSelector.TabIndex = 7;
			// 
			// chordFreqTrackBar
			// 
			this.chordFreqTrackBar.Location = new System.Drawing.Point(469, 478);
			this.chordFreqTrackBar.Maximum = 4;
			this.chordFreqTrackBar.Minimum = 1;
			this.chordFreqTrackBar.Name = "chordFreqTrackBar";
			this.chordFreqTrackBar.Size = new System.Drawing.Size(162, 56);
			this.chordFreqTrackBar.TabIndex = 8;
			this.chordFreqTrackBar.Value = 1;
			this.chordFreqTrackBar.ValueChanged += new System.EventHandler(this.chordFreqTrackBar_ValueChanged);
			// 
			// automaticHarmonyButton
			// 
			this.automaticHarmonyButton.BackColor = System.Drawing.Color.RoyalBlue;
			this.automaticHarmonyButton.FlatAppearance.BorderSize = 0;
			this.automaticHarmonyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.automaticHarmonyButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.automaticHarmonyButton.ForeColor = System.Drawing.Color.White;
			this.automaticHarmonyButton.Location = new System.Drawing.Point(297, 520);
			this.automaticHarmonyButton.Name = "automaticHarmonyButton";
			this.automaticHarmonyButton.Size = new System.Drawing.Size(125, 53);
			this.automaticHarmonyButton.TabIndex = 9;
			this.automaticHarmonyButton.Text = "Generate";
			this.automaticHarmonyButton.UseVisualStyleBackColor = false;
			this.automaticHarmonyButton.Click += new System.EventHandler(this.automaticHarmonyButton_Click);
			// 
			// chordFreqLabel
			// 
			this.chordFreqLabel.AutoSize = true;
			this.chordFreqLabel.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.chordFreqLabel.Location = new System.Drawing.Point(637, 485);
			this.chordFreqLabel.Name = "chordFreqLabel";
			this.chordFreqLabel.Size = new System.Drawing.Size(16, 17);
			this.chordFreqLabel.TabIndex = 10;
			this.chordFreqLabel.Text = "1";
			// 
			// showMessageHarmonyCheckBox
			// 
			this.showMessageHarmonyCheckBox.AutoSize = true;
			this.showMessageHarmonyCheckBox.Checked = true;
			this.showMessageHarmonyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showMessageHarmonyCheckBox.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.showMessageHarmonyCheckBox.Location = new System.Drawing.Point(297, 579);
			this.showMessageHarmonyCheckBox.Name = "showMessageHarmonyCheckBox";
			this.showMessageHarmonyCheckBox.Size = new System.Drawing.Size(195, 21);
			this.showMessageHarmonyCheckBox.TabIndex = 11;
			this.showMessageHarmonyCheckBox.Text = "Show message when done";
			this.showMessageHarmonyCheckBox.UseVisualStyleBackColor = true;
			this.showMessageHarmonyCheckBox.CheckedChanged += new System.EventHandler(this.showMessageCheckBox_CheckedChanged);
			// 
			// shiftRecordingByPitchButton
			// 
			this.shiftRecordingByPitchButton.BackColor = System.Drawing.Color.RoyalBlue;
			this.shiftRecordingByPitchButton.FlatAppearance.BorderSize = 0;
			this.shiftRecordingByPitchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.shiftRecordingByPitchButton.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.shiftRecordingByPitchButton.ForeColor = System.Drawing.Color.White;
			this.shiftRecordingByPitchButton.Location = new System.Drawing.Point(496, 280);
			this.shiftRecordingByPitchButton.Name = "shiftRecordingByPitchButton";
			this.shiftRecordingByPitchButton.Size = new System.Drawing.Size(113, 51);
			this.shiftRecordingByPitchButton.TabIndex = 12;
			this.shiftRecordingByPitchButton.Text = "Shift";
			this.shiftRecordingByPitchButton.UseVisualStyleBackColor = false;
			this.shiftRecordingByPitchButton.Click += new System.EventHandler(this.shiftRecordingByPitchButton_Click);
			// 
			// showMessageShiftCheckBox
			// 
			this.showMessageShiftCheckBox.AutoSize = true;
			this.showMessageShiftCheckBox.Checked = true;
			this.showMessageShiftCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showMessageShiftCheckBox.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.showMessageShiftCheckBox.Location = new System.Drawing.Point(496, 336);
			this.showMessageShiftCheckBox.Name = "showMessageShiftCheckBox";
			this.showMessageShiftCheckBox.Size = new System.Drawing.Size(195, 21);
			this.showMessageShiftCheckBox.TabIndex = 13;
			this.showMessageShiftCheckBox.Text = "Show message when done";
			this.showMessageShiftCheckBox.UseVisualStyleBackColor = true;
			this.showMessageShiftCheckBox.CheckedChanged += new System.EventHandler(this.showMessageShiftCheckBox_CheckedChanged);
			// 
			// selectScaleLabel
			// 
			this.selectScaleLabel.AutoSize = true;
			this.selectScaleLabel.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.selectScaleLabel.Location = new System.Drawing.Point(36, 261);
			this.selectScaleLabel.Name = "selectScaleLabel";
			this.selectScaleLabel.Size = new System.Drawing.Size(83, 17);
			this.selectScaleLabel.TabIndex = 14;
			this.selectScaleLabel.Text = "Select scale:";
			// 
			// manualHarmonyLabel
			// 
			this.manualHarmonyLabel.AutoSize = true;
			this.manualHarmonyLabel.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.manualHarmonyLabel.Location = new System.Drawing.Point(36, 499);
			this.manualHarmonyLabel.Name = "manualHarmonyLabel";
			this.manualHarmonyLabel.Size = new System.Drawing.Size(171, 17);
			this.manualHarmonyLabel.TabIndex = 15;
			this.manualHarmonyLabel.Text = "Create harmony manually:";
			// 
			// chordProgLabel
			// 
			this.chordProgLabel.AutoSize = true;
			this.chordProgLabel.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.chordProgLabel.Location = new System.Drawing.Point(294, 458);
			this.chordProgLabel.Name = "chordProgLabel";
			this.chordProgLabel.Size = new System.Drawing.Size(164, 17);
			this.chordProgLabel.TabIndex = 16;
			this.chordProgLabel.Text = "Select chord progression:";
			// 
			// beatSliderLabel
			// 
			this.beatSliderLabel.AutoSize = true;
			this.beatSliderLabel.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.beatSliderLabel.Location = new System.Drawing.Point(466, 458);
			this.beatSliderLabel.Name = "beatSliderLabel";
			this.beatSliderLabel.Size = new System.Drawing.Size(305, 17);
			this.beatSliderLabel.TabIndex = 17;
			this.beatSliderLabel.Text = "Select after how many beats the chord changes:";
			// 
			// ModifyRecordingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightSteelBlue;
			this.ClientSize = new System.Drawing.Size(800, 673);
			this.Controls.Add(this.beatSliderLabel);
			this.Controls.Add(this.chordProgLabel);
			this.Controls.Add(this.manualHarmonyLabel);
			this.Controls.Add(this.selectScaleLabel);
			this.Controls.Add(this.showMessageShiftCheckBox);
			this.Controls.Add(this.shiftRecordingByPitchButton);
			this.Controls.Add(this.showMessageHarmonyCheckBox);
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
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ModifyRecordingForm";
			this.ShowInTaskbar = false;
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
		private System.Windows.Forms.CheckBox showMessageHarmonyCheckBox;
		private System.Windows.Forms.Button shiftRecordingByPitchButton;
		private System.Windows.Forms.CheckBox showMessageShiftCheckBox;
		private System.Windows.Forms.Label selectScaleLabel;
		private System.Windows.Forms.Label manualHarmonyLabel;
		private System.Windows.Forms.Label chordProgLabel;
		private System.Windows.Forms.Label beatSliderLabel;
	}
}