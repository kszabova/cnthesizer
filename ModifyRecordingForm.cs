using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cnthesizer
{
	partial class ModifyRecordingForm : Form
	{
		private IRecorder recorder;

		public ModifyRecordingForm(IRecorder recorder)
		{
			this.recorder = recorder;
			InitializeComponent();
			this.shiftSelectorComboBox.Items.AddRange(new string[]
			{
				"Octave up", "Major seventh up", "Minor seventh up", "Major sixth up", "Minor sixth up",
				"Perfect fifth up", "Tritone up", "Perfect fourth up", "Major third up", "Minor third up",
				"Major second up", "Minor second up", "Unison", "Minor second down", "Major second down",
				"Minor third down", "Major third down", "Perfect fourth down", "Tritone down", "Perfect fifth down",
				"Minor sixth down", "Major sixth down", "Minor seventh down", "Major seventh down", "Octave down"
			});
		}

		private void playButton_Click(object sender, EventArgs e)
		{
			recorder.Playback();
		}

		private void ModifyRecordingForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			recorder.StopPlayback(true);
		}

		private void shiftSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			recorder.StopPlayback(false);
			Shift shift = Shifts.shifts[shiftSelectorComboBox.SelectedIndex];
			recorder.RegenerateRecording(shift);
		}
	}
}
