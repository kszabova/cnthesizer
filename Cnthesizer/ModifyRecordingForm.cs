﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cnthesizer
{
	partial class ModifyRecordingForm : Form
	{
		private int bpm;
		private IModifier recorder;
		private bool showMessageWhenHarmonyGenerated = true;
		private bool showMessageWhenPitchChanged = true;

		public ModifyRecordingForm(IModifier recorder, int bpm)
		{
			this.recorder = recorder;
			this.bpm = bpm;
			InitializeComponent();

			// set ComboBox elements
			shiftSelectorComboBox.Items.AddRange(new string[]
			{
				"Octave up", "Major seventh up", "Minor seventh up", "Major sixth up", "Minor sixth up",
				"Perfect fifth up", "Tritone up", "Perfect fourth up", "Major third up", "Minor third up",
				"Major second up", "Minor second up", "Unison", "Minor second down", "Major second down",
				"Minor third down", "Major third down", "Perfect fourth down", "Tritone down", "Perfect fifth down",
				"Minor sixth down", "Major sixth down", "Minor seventh down", "Major seventh down", "Octave down"
			});
			majMinSelector.Items.AddRange(new string[] { "Minor", "Major", "N/A" });
			scaleSelector.Items.AddRange(new string[]
			{
				"C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B", "N/A"
			});
			chordProgSelector.Items.AddRange(new string[]
			{
				"ii - v - i", "i - iv - v", "i - v - vi - iv", "i - vi - iv - v", "i - v - i - iv", "vi - v - iv - iii", "N/A"
			});
		}

		private void automaticHarmonyButton_Click(object sender, EventArgs e)
		{
			// automatic harmony can only be added when beat was specified
			// (otherwise there is no way to know the correct placement of chords)
			if (bpm == 0)
			{
				MessageBox.Show("You can't add harmony automatically if there is no beat!");
				return;
			}

			// user must specify which progression they want generated
			if (chordProgSelector.SelectedIndex == -1 || (string)chordProgSelector.SelectedItem == "N/A")
			{
				MessageBox.Show("You must select a chord progression!");
				return;
			}

			// reset harmony and check if it is possible to add a new one
			try
			{
				recorder.AddHarmony(false);
			}
			catch (ApplicationException)
			{
				MessageBox.Show("You must select a scale first!");
				return;
			}

			// get the correct chords from the given chord progression
			List<ChordName> chords = new List<ChordName> { };
			switch ((string)chordProgSelector.SelectedItem)
			{
				case "ii - v - i":
					{
						chords.Add(ChordName.ii);
						chords.Add(ChordName.v);
						chords.Add(ChordName.ilow);
						break;
					}
				case "i - iv - v":
					{
						chords.Add(ChordName.ilow);
						chords.Add(ChordName.iv);
						chords.Add(ChordName.v);
						break;
					}
				case "i - v - vi - iv":
					{
						chords.Add(ChordName.ilow);
						chords.Add(ChordName.v);
						chords.Add(ChordName.vi);
						chords.Add(ChordName.iv);
						break;
					}
				case "i - vi - iv - v":
					{
						chords.Add(ChordName.ilow);
						chords.Add(ChordName.vi);
						chords.Add(ChordName.iv);
						chords.Add(ChordName.v);
						break;
					}
				case "i - v - i - iv":
					{
						chords.Add(ChordName.ilow);
						chords.Add(ChordName.v);
						chords.Add(ChordName.ihigh);
						chords.Add(ChordName.iv);
						break;
					}
				case "vi - v - iv - iii":
					{
						chords.Add(ChordName.vi);
						chords.Add(ChordName.v);
						chords.Add(ChordName.iv);
						chords.Add(ChordName.iii);
						break;
					}
				default:
					{
						chords.Add(ChordName.None);
						break;
					}
			}

			// a new chord is to be played on every chordFreqTrackBar.Value-th beat
			int chordFrequency = bpm / chordFreqTrackBar.Value;
			int oneChordDuration = Convert.ToInt32(1 / ((float)chordFrequency / 60) * 1000);	// milliseconds

			// add all chords with the correct duration to harmony
			foreach (ChordName chord in chords)
			{
				recorder.AddChord(chord, oneChordDuration);
			}

			// generate recording with new harmony
			recorder.RegenerateRecording();

			// alert user that the process has finished
			if (showMessageWhenHarmonyGenerated)
				MessageBox.Show("Done! Hear the result by clicking Play.");
		}

		private void chordFreqTrackBar_ValueChanged(object sender, EventArgs e)
		{
			// update chord frequency label
			chordFreqLabel.Text = chordFreqTrackBar.Value.ToString();
		}

		private void majMinSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void manualHarmonyButton_Click(object sender, EventArgs e)
		{
			try
			{
				recorder.AddHarmony(true);
			}
			catch (ApplicationException)
			{
				MessageBox.Show("You must select a scale first!");
				return;
			}
		}

		private void ModifyRecordingForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			recorder.StopPlayback(true);
		}

		private void playButton_Click(object sender, EventArgs e)
		{
			recorder.Playback();
		}
		private void scaleSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateScale();
		}

		private void shiftRecordingByPitchButton_Click(object sender, EventArgs e)
		{
			recorder.StopPlayback(false);
			Shift shift = Shifts.shifts[shiftSelectorComboBox.SelectedIndex];
			recorder.Shift = shift;
			recorder.RegenerateRecording();

			if (showMessageWhenPitchChanged)
				MessageBox.Show("Done! Hear the result by clicking Play.");
		}

		private void showMessageCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			showMessageWhenHarmonyGenerated = showMessageHarmonyCheckBox.Checked;
		}

		private void showMessageShiftCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			showMessageWhenPitchChanged = showMessageShiftCheckBox.Checked;
		}

		private void stopButton_Click(object sender, EventArgs e)
		{
			recorder.StopPlayback(false);
		}
		private void UpdateScale()
		{
			// if no scale has been selected, set the recorder's value of scale to null
			if ((string)scaleSelector.SelectedItem == "N/A" || (string)majMinSelector.SelectedItem == "N/A"
				|| scaleSelector.SelectedIndex == -1 || majMinSelector.SelectedIndex == -1)
			{
				recorder.UpdateScale(null);
				return;
			}

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