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
			Pitch pitch = KeyControls.GetPitchFromKey(e.KeyCode);
			session.StartPlayingPitch(pitch);
		}

		private void CnthesizerForm_KeyUp(object sender, KeyEventArgs e)
		{
			Pitch pitch = KeyControls.GetPitchFromKey(e.KeyCode);
			session.StopPlayingPitch(pitch);
		}

		private void CnthesizerForm_Load(object sender, EventArgs e)
		{
			session = Session.CreateSession();
		}

		private void beatButton_Click(object sender, EventArgs e)
		{
			if (!session.BeatPlaying)
			{
				beatButton.Text = "Generating...";
				int bpm = bpmSlider.Value;
				session.StartPlayingBeat(bpm);
				beatButton.Text = "Stop beat";
			}
			else
			{
				session.StopPlayingBeat();
				beatButton.Text = "Play beat";
			}
		}

		private void bpmSlider_ValueChanged(object sender, EventArgs e)
		{
			bpmValueTextBox.Text = bpmSlider.Value.ToString();

			// re-generate beat if it is playing
			if (session.BeatPlaying)
				session.ChangeBeatFrequency(bpmSlider.Value);
		}

		private void startRecordingBtn_Click(object sender, EventArgs e)
		{
			session.StartRecording();
		}

		private void stopRecordingBtn_Click(object sender, EventArgs e)
		{
			session.StopRecording();
		}

		private void UpdateBeatButtonText(object sender, EventArgs e)
		{
			beatButton.Text = session.BeatPlaying ? "Stop beat" : "Play beat";
		}

		private void UpdateWaveForm(object sender, EventArgs e)
		{
			Button buttonClicked = (Button)sender;
			switch (buttonClicked.Name)
			{
				case "sineButton":
					{
						session.ChangeWaveForm(WaveForms.SineWave);
						break;
					}
				case "squareButton":
					{
						session.ChangeWaveForm(WaveForms.SquareWave);
						break;
					}
				case "sawtoothButton":
					{
						session.ChangeWaveForm(WaveForms.SawtoothWave);
						break;
					}
			}
		}
	}
}
