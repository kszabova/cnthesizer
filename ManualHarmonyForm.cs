using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cnthesizer
{
	partial class ManualHarmonyForm : Form
	{
		private IRecorder recorder;
		private Stopwatch stopwatch;
		private long lastElapsedMillis = 0;

		public ManualHarmonyForm(IRecorder recorder)
		{
			this.recorder = recorder;
			stopwatch = new Stopwatch();
			InitializeComponent();
			this.recorder.Playback();
			stopwatch.Start();
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

		private void closeButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void AddChord(ChordName chordName)
		{
			long elapsed = stopwatch.ElapsedMilliseconds;
			long duration = elapsed - lastElapsedMillis;
			recorder.AddChord(chordName, duration);
			lastElapsedMillis = elapsed;
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
	}
}
