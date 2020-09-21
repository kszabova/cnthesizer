namespace Cnthesizer
{
	partial class CnthesizerForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CnthesizerForm));
			this.bpmSlider = new System.Windows.Forms.TrackBar();
			this.beatButton = new System.Windows.Forms.Button();
			this.recordingButton = new System.Windows.Forms.Button();
			this.sineButton = new System.Windows.Forms.Button();
			this.squareButton = new System.Windows.Forms.Button();
			this.sawtoothButton = new System.Windows.Forms.Button();
			this.beatFreqLabel = new System.Windows.Forms.Label();
			this.setBpmLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.bpmSlider)).BeginInit();
			this.SuspendLayout();
			// 
			// bpmSlider
			// 
			this.bpmSlider.BackColor = System.Drawing.Color.LightSteelBlue;
			this.bpmSlider.Location = new System.Drawing.Point(84, 100);
			this.bpmSlider.Maximum = 360;
			this.bpmSlider.Minimum = 60;
			this.bpmSlider.Name = "bpmSlider";
			this.bpmSlider.Size = new System.Drawing.Size(322, 56);
			this.bpmSlider.SmallChange = 10;
			this.bpmSlider.TabIndex = 0;
			this.bpmSlider.TickFrequency = 2;
			this.bpmSlider.Value = 60;
			this.bpmSlider.ValueChanged += new System.EventHandler(this.bpmSlider_ValueChanged);
			// 
			// beatButton
			// 
			this.beatButton.BackColor = System.Drawing.Color.RoyalBlue;
			this.beatButton.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
			this.beatButton.FlatAppearance.BorderSize = 0;
			this.beatButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.beatButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.beatButton.ForeColor = System.Drawing.Color.White;
			this.beatButton.Location = new System.Drawing.Point(481, 84);
			this.beatButton.Name = "beatButton";
			this.beatButton.Size = new System.Drawing.Size(142, 53);
			this.beatButton.TabIndex = 1;
			this.beatButton.Text = "Play beat";
			this.beatButton.UseVisualStyleBackColor = false;
			this.beatButton.Click += new System.EventHandler(this.beatButton_Click);
			// 
			// recordingButton
			// 
			this.recordingButton.BackColor = System.Drawing.Color.RoyalBlue;
			this.recordingButton.FlatAppearance.BorderSize = 0;
			this.recordingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.recordingButton.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.recordingButton.ForeColor = System.Drawing.Color.White;
			this.recordingButton.Location = new System.Drawing.Point(95, 341);
			this.recordingButton.Name = "recordingButton";
			this.recordingButton.Size = new System.Drawing.Size(196, 81);
			this.recordingButton.TabIndex = 3;
			this.recordingButton.Text = "Start recording";
			this.recordingButton.UseVisualStyleBackColor = false;
			this.recordingButton.Click += new System.EventHandler(this.recordingButton_Click);
			// 
			// sineButton
			// 
			this.sineButton.BackColor = System.Drawing.Color.CornflowerBlue;
			this.sineButton.FlatAppearance.BorderSize = 0;
			this.sineButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.sineButton.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.sineButton.ForeColor = System.Drawing.Color.White;
			this.sineButton.Location = new System.Drawing.Point(94, 207);
			this.sineButton.Name = "sineButton";
			this.sineButton.Size = new System.Drawing.Size(93, 83);
			this.sineButton.TabIndex = 5;
			this.sineButton.Text = "Sine";
			this.sineButton.UseVisualStyleBackColor = false;
			this.sineButton.Click += new System.EventHandler(this.UpdateWaveForm);
			// 
			// squareButton
			// 
			this.squareButton.BackColor = System.Drawing.Color.RoyalBlue;
			this.squareButton.FlatAppearance.BorderSize = 0;
			this.squareButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.squareButton.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.squareButton.ForeColor = System.Drawing.Color.White;
			this.squareButton.Location = new System.Drawing.Point(193, 207);
			this.squareButton.Name = "squareButton";
			this.squareButton.Size = new System.Drawing.Size(93, 83);
			this.squareButton.TabIndex = 6;
			this.squareButton.Text = "Square";
			this.squareButton.UseVisualStyleBackColor = false;
			this.squareButton.Click += new System.EventHandler(this.UpdateWaveForm);
			// 
			// sawtoothButton
			// 
			this.sawtoothButton.BackColor = System.Drawing.Color.RoyalBlue;
			this.sawtoothButton.FlatAppearance.BorderSize = 0;
			this.sawtoothButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.sawtoothButton.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.sawtoothButton.ForeColor = System.Drawing.Color.White;
			this.sawtoothButton.Location = new System.Drawing.Point(292, 207);
			this.sawtoothButton.Name = "sawtoothButton";
			this.sawtoothButton.Size = new System.Drawing.Size(93, 83);
			this.sawtoothButton.TabIndex = 7;
			this.sawtoothButton.Text = "Sawtooth";
			this.sawtoothButton.UseVisualStyleBackColor = false;
			this.sawtoothButton.Click += new System.EventHandler(this.UpdateWaveForm);
			// 
			// beatFreqLabel
			// 
			this.beatFreqLabel.AutoSize = true;
			this.beatFreqLabel.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.beatFreqLabel.Location = new System.Drawing.Point(425, 100);
			this.beatFreqLabel.Name = "beatFreqLabel";
			this.beatFreqLabel.Size = new System.Drawing.Size(29, 20);
			this.beatFreqLabel.TabIndex = 8;
			this.beatFreqLabel.Text = "60";
			// 
			// setBpmLabel
			// 
			this.setBpmLabel.AutoSize = true;
			this.setBpmLabel.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.setBpmLabel.Location = new System.Drawing.Point(92, 66);
			this.setBpmLabel.Name = "setBpmLabel";
			this.setBpmLabel.Size = new System.Drawing.Size(62, 17);
			this.setBpmLabel.TabIndex = 9;
			this.setBpmLabel.Text = "Set bpm:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(91, 159);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(125, 17);
			this.label1.TabIndex = 10;
			this.label1.Text = "Select wave shape:";
			// 
			// CnthesizerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightSteelBlue;
			this.ClientSize = new System.Drawing.Size(728, 492);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.setBpmLabel);
			this.Controls.Add(this.beatFreqLabel);
			this.Controls.Add(this.sawtoothButton);
			this.Controls.Add(this.squareButton);
			this.Controls.Add(this.sineButton);
			this.Controls.Add(this.recordingButton);
			this.Controls.Add(this.beatButton);
			this.Controls.Add(this.bpmSlider);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "CnthesizerForm";
			this.Text = "#Cnthesizer";
			this.Load += new System.EventHandler(this.CnthesizerForm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CnthesizerForm_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CnthesizerForm_KeyUp);
			this.MouseEnter += new System.EventHandler(this.UpdateBeatButtonText);
			((System.ComponentModel.ISupportInitialize)(this.bpmSlider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TrackBar bpmSlider;
		private System.Windows.Forms.Button beatButton;
		private System.Windows.Forms.Button recordingButton;
		private System.Windows.Forms.Button sineButton;
		private System.Windows.Forms.Button squareButton;
		private System.Windows.Forms.Button sawtoothButton;
		private System.Windows.Forms.Label beatFreqLabel;
		private System.Windows.Forms.Label setBpmLabel;
		private System.Windows.Forms.Label label1;
	}
}