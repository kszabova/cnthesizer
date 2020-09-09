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
		private MixingWaveProvider32 mixer;
		private DirectSoundOut output;

		private bool[] currentlyPlayed;
		private WavePlayer beat = null;

		public CnthesizerForm()
		{
			InitializeComponent();
		}

		private void CnthesizerForm_KeyDown(object sender, KeyEventArgs e)
		{
			int snippetIndex = (int)KeyControls.GetFrequencyFromKey(e.KeyCode);
			// we don't want to do anything if a default was returned
			if (snippetIndex == (int)FrequenciesAvailable.Empty) return;

			if (!currentlyPlayed[snippetIndex])
			{
				WavePlayer inputStream = KeyControls.GetWavePlayerFromKey(e.KeyCode);
				mixer.AddInputStream(inputStream.Channel);
				currentlyPlayed[snippetIndex] = true;
			}
		}

		private void CnthesizerForm_KeyUp(object sender, KeyEventArgs e)
		{
			int snippetIndex = (int)KeyControls.GetFrequencyFromKey(e.KeyCode);
			if (snippetIndex == (int)FrequenciesAvailable.Empty) return;

			WavePlayer inputStream = KeyControls.GetWavePlayerFromKey(e.KeyCode);
			mixer.RemoveInputStream(inputStream.Channel);
			currentlyPlayed[snippetIndex] = false;


		}

		private void CnthesizerForm_Load(object sender, EventArgs e)
		{
			currentlyPlayed = new bool[Enum.GetNames(typeof(FrequenciesAvailable)).Length];
			foreach (FrequenciesAvailable frequency in Enum.GetValues(typeof(FrequenciesAvailable)))
			{
				currentlyPlayed[(int)frequency] = false;
			}

			mixer = new MixingWaveProvider32(new List<WaveChannel32> { WavePlayers.Empty.Channel });
			currentlyPlayed[(int)FrequenciesAvailable.Empty] = true;
			output = new DirectSoundOut();
			output.Init(mixer);
			output.Play();
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
				beat = new WavePlayer("beat.wav");
				mixer.AddInputStream(beat.Channel);
				beatButton.Text = "Stop beat";
			}
			else if (beatButton.Text == "Stop beat")
			{
				mixer.RemoveInputStream(beat.Channel);
				beat.Dispose();
				beat = null;
				beatButton.Text = "Play beat";
			}
		}
	}
}
