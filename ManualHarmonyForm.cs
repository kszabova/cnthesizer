using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Cnthesizer
{
	partial class ManualHarmonyForm : Form
	{
		private long lastElapsedMillis = 0;
		private IRecorder recorder;
		private Stopwatch stopwatch;
		public ManualHarmonyForm(IRecorder recorder)
		{
			this.recorder = recorder;
			stopwatch = new Stopwatch();
			InitializeComponent();
			this.recorder.Playback();
			stopwatch.Start();
		}

		private void AddChord(ChordName chordName)
		{
			long elapsed = stopwatch.ElapsedMilliseconds;
			long duration = elapsed - lastElapsedMillis;
			lastElapsedMillis = elapsed;
			recorder.AddChord(chordName, duration);
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private ChordName GetChordNameFromButton(Button button)
		{
			switch (button.Name)
			{
				case "ilow": return ChordName.ilow;
				case "ii": return ChordName.ii;
				case "iii": return ChordName.iii;
				case "iv": return ChordName.iv;
				case "v": return ChordName.v;
				case "vi": return ChordName.vi;
				case "vii": return ChordName.vii;
				case "ihigh": return ChordName.ihigh;
				default: throw new ApplicationException("Unrecognized button");
			}
		}

		private void ChordButtonMouseDown(object sender, MouseEventArgs e)
		{
			recorder.StopChord();
			ChordName chord = GetChordNameFromButton((Button)sender);
			recorder.PlayChord(chord);
			AddChord(ChordName.None);
		}

		private void ChordButtonMouseUp(object sender, MouseEventArgs e)
		{
			recorder.StopChord();
			ChordName chord = GetChordNameFromButton((Button)sender);
			AddChord(chord);
		}
	}
}