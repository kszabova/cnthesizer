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
		}

		private void playButton_Click(object sender, EventArgs e)
		{
			recorder.Playback();
		}

		private void ModifyRecordingForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			recorder.StopPlayback();
		}
	}
}
