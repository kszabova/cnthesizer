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
			this.bpmSlider = new System.Windows.Forms.TrackBar();
			this.beatButton = new System.Windows.Forms.Button();
			this.bpmValueTextBox = new System.Windows.Forms.TextBox();
			this.recordingButton = new System.Windows.Forms.Button();
			this.sineButton = new System.Windows.Forms.Button();
			this.squareButton = new System.Windows.Forms.Button();
			this.sawtoothButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.bpmSlider)).BeginInit();
			this.SuspendLayout();
			// 
			// bpmSlider
			// 
			this.bpmSlider.Location = new System.Drawing.Point(29, 39);
			this.bpmSlider.Maximum = 360;
			this.bpmSlider.Minimum = 60;
			this.bpmSlider.Name = "bpmSlider";
			this.bpmSlider.Size = new System.Drawing.Size(353, 56);
			this.bpmSlider.SmallChange = 10;
			this.bpmSlider.TabIndex = 0;
			this.bpmSlider.Value = 60;
			this.bpmSlider.ValueChanged += new System.EventHandler(this.bpmSlider_ValueChanged);
			// 
			// beatButton
			// 
			this.beatButton.Location = new System.Drawing.Point(439, 24);
			this.beatButton.Name = "beatButton";
			this.beatButton.Size = new System.Drawing.Size(322, 70);
			this.beatButton.TabIndex = 1;
			this.beatButton.Text = "Play beat";
			this.beatButton.UseVisualStyleBackColor = true;
			this.beatButton.Click += new System.EventHandler(this.beatButton_Click);
			// 
			// bpmValueTextBox
			// 
			this.bpmValueTextBox.Location = new System.Drawing.Point(29, 105);
			this.bpmValueTextBox.Name = "bpmValueTextBox";
			this.bpmValueTextBox.Size = new System.Drawing.Size(111, 22);
			this.bpmValueTextBox.TabIndex = 2;
			this.bpmValueTextBox.Text = "60";
			// 
			// recordingButton
			// 
			this.recordingButton.Location = new System.Drawing.Point(40, 196);
			this.recordingButton.Name = "recordingButton";
			this.recordingButton.Size = new System.Drawing.Size(196, 81);
			this.recordingButton.TabIndex = 3;
			this.recordingButton.Text = "Start recording";
			this.recordingButton.UseVisualStyleBackColor = true;
			this.recordingButton.Click += new System.EventHandler(this.recordingButton_Click);
			// 
			// sineButton
			// 
			this.sineButton.Location = new System.Drawing.Point(46, 326);
			this.sineButton.Name = "sineButton";
			this.sineButton.Size = new System.Drawing.Size(93, 83);
			this.sineButton.TabIndex = 5;
			this.sineButton.Text = "Sine";
			this.sineButton.UseVisualStyleBackColor = true;
			this.sineButton.Click += new System.EventHandler(this.UpdateWaveForm);
			// 
			// squareButton
			// 
			this.squareButton.Location = new System.Drawing.Point(167, 326);
			this.squareButton.Name = "squareButton";
			this.squareButton.Size = new System.Drawing.Size(93, 83);
			this.squareButton.TabIndex = 6;
			this.squareButton.Text = "Square";
			this.squareButton.UseVisualStyleBackColor = true;
			this.squareButton.Click += new System.EventHandler(this.UpdateWaveForm);
			// 
			// sawtoothButton
			// 
			this.sawtoothButton.Location = new System.Drawing.Point(289, 326);
			this.sawtoothButton.Name = "sawtoothButton";
			this.sawtoothButton.Size = new System.Drawing.Size(93, 83);
			this.sawtoothButton.TabIndex = 7;
			this.sawtoothButton.Text = "Sawtooth";
			this.sawtoothButton.UseVisualStyleBackColor = true;
			this.sawtoothButton.Click += new System.EventHandler(this.UpdateWaveForm);
			// 
			// CnthesizerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.sawtoothButton);
			this.Controls.Add(this.squareButton);
			this.Controls.Add(this.sineButton);
			this.Controls.Add(this.recordingButton);
			this.Controls.Add(this.bpmValueTextBox);
			this.Controls.Add(this.beatButton);
			this.Controls.Add(this.bpmSlider);
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
		private System.Windows.Forms.TextBox bpmValueTextBox;
		private System.Windows.Forms.Button recordingButton;
		private System.Windows.Forms.Button sineButton;
		private System.Windows.Forms.Button squareButton;
		private System.Windows.Forms.Button sawtoothButton;
	}
}