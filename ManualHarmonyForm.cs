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

		private void ilow_MouseUp(object sender, MouseEventArgs e) => AddChord(ChordName.ilow);

		private void ii_MouseUp(object sender, MouseEventArgs e) => AddChord(ChordName.ii);

		private void iii_MouseUp(object sender, MouseEventArgs e) => AddChord(ChordName.iii);

		private void iv_MouseUp(object sender, MouseEventArgs e) => AddChord(ChordName.iv);

		private void v_MouseUp(object sender, MouseEventArgs e) => AddChord(ChordName.v);

		private void vi_MouseUp(object sender, MouseEventArgs e) => AddChord(ChordName.vi);

		private void vii_MouseUp(object sender, MouseEventArgs e) => AddChord(ChordName.vii);

		private void ihigh_MouseUp(object sender, MouseEventArgs e) => AddChord(ChordName.ihigh);

		private void AddEmptyChord(object sender, MouseEventArgs e) => AddChord(ChordName.None);

		private void AddChord(ChordName chordName)
		{
			long elapsed = stopwatch.ElapsedMilliseconds;
			long duration = elapsed - lastElapsedMillis;
			recorder.AddChord(chordName, duration);
			lastElapsedMillis = elapsed;
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
