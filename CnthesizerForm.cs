using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

using NAudio.Wave;

namespace Cnthesizer
{
	public partial class CnthesizerForm : Form
	{
		private Session session;

		public CnthesizerForm()
		{
			InitializeComponent();
		}

		private void CnthesizerForm_KeyDown(object sender, KeyEventArgs e)
		{
			int snippetIndex = (int)KeyControls.GetFrequencyFromKey(e.KeyCode);
			// we don't want to do anything if a default was returned
			if (snippetIndex == (int)FrequenciesAvailable.Empty) return;

			if (!session.CurrentlyPlaying[snippetIndex])
			{
				WavePlayer inputStream = KeyControls.GetWavePlayerFromKey(e.KeyCode);
				session.Mixer.AddInputStream(inputStream.Channel);
				session.CurrentlyPlaying[snippetIndex] = true;
			}
		}

		private void CnthesizerForm_KeyUp(object sender, KeyEventArgs e)
		{
			int snippetIndex = (int)KeyControls.GetFrequencyFromKey(e.KeyCode);
			if (snippetIndex == (int)FrequenciesAvailable.Empty) return;

			WavePlayer inputStream = KeyControls.GetWavePlayerFromKey(e.KeyCode);
			session.Mixer.RemoveInputStream(inputStream.Channel);
			session.CurrentlyPlaying[snippetIndex] = false;


		}

		private void CnthesizerForm_Load(object sender, EventArgs e)
		{
			session = Session.CreateSession();
		}

		private void beatButton_Click(object sender, EventArgs e)
		{
			if (beatButton.Text == "Play beat")
			{
				beatButton.Text = "Generating...";
				int bpm = bpmSlider.Value;
				byte[] beatWave = Wave.GenerateBeatWave(bpm);
				using (FileStream fs = File.Create("beat.wav"))
					Wave.WriteToStream(fs, beatWave, beatWave.Length / sizeof(short), 44100, 16, 1);
				session.Beat = new WavePlayer("beat.wav");
				session.Mixer.AddInputStream(session.Beat.Channel);
				beatButton.Text = "Stop beat";
			}
			else if (beatButton.Text == "Stop beat")
			{
				session.Mixer.RemoveInputStream(session.Beat.Channel);
				session.Beat.Dispose();
				session.Beat = null;
				beatButton.Text = "Play beat";
			}
		}

		private void bpmSlider_ValueChanged(object sender, EventArgs e)
		{
			bpmValueTextBox.Text = bpmSlider.Value.ToString();
		}
	}
}
