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
			this.majMinSelector.Items.AddRange(new string[] { "Minor", "Major", "N/A" });
			this.scaleSelector.Items.AddRange(new string[]
			{
				"C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"
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

		private void stopButton_Click(object sender, EventArgs e)
		{
			recorder.StopPlayback(false);
		}

		private void scaleSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void majMinSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void manualHarmonyButton_Click(object sender, EventArgs e)
		{
			recorder.AddHarmony();
		}

		private void UpdateScale()
		{
			if ((string)scaleSelector.SelectedItem == "N/A" || (string)majMinSelector.SelectedItem == "N/A")
				recorder.UpdateScale(null);

			List<Pitch> scalePitches = new List<Pitch>
			{
				Pitch.C4, Pitch.Cm4, Pitch.D4, Pitch.Dm4, Pitch.E4, Pitch.F4, Pitch.Fm4,
				Pitch.G4, Pitch.Gm4, Pitch.A4, Pitch.Am4, Pitch.B4
			};

			bool major = majMinSelector.SelectedIndex == 1;
			Pitch baseTone = scalePitches[scaleSelector.SelectedIndex];

			recorder.UpdateScale(new Scale(major, baseTone));
		}
	}
}
