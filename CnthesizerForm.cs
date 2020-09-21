using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cnthesizer
{
	public partial class CnthesizerForm : Form
	{
		private Session session;

		public CnthesizerForm()
		{
			InitializeComponent();
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
			beatFreqLabel.Text = bpmSlider.Value.ToString();

			// re-generate beat if it is playing
			if (session.BeatPlaying)
				session.ChangeBeatFrequency(bpmSlider.Value);
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
		private void recordingButton_Click(object sender, EventArgs e)
		{
			if (session.IsRecording)
			{
				session.StopRecording();
				recordingButton.Text = "Start recording";
			}
			else
			{
				session.StartRecording();
				recordingButton.Text = "Stop recording";
			}
		}

		private void UpdateBeatButtonText(object sender, EventArgs e)
		{
			beatButton.Text = session.BeatPlaying ? "Stop beat" : "Play beat";
			recordingButton.Text = session.IsRecording ? "Stop recording" : "Start recording";
		}

		private void UpdateWaveForm(object sender, EventArgs e)
		{
			Button buttonClicked = (Button)sender;
			switch (buttonClicked.Name)
			{
				case "sineButton":
					{
						session.ChangeWaveForm(WaveForms.SineWave);
						sineButton.BackColor = Color.CornflowerBlue;
						squareButton.BackColor = Color.RoyalBlue;
						sawtoothButton.BackColor = Color.RoyalBlue;
						break;
					}
				case "squareButton":
					{
						session.ChangeWaveForm(WaveForms.SquareWave);
						squareButton.BackColor = Color.CornflowerBlue;
						sineButton.BackColor = Color.RoyalBlue;
						sawtoothButton.BackColor = Color.RoyalBlue;
						break;
					}
				case "sawtoothButton":
					{
						session.ChangeWaveForm(WaveForms.SawtoothWave);
						sawtoothButton.BackColor = Color.CornflowerBlue;
						squareButton.BackColor = Color.RoyalBlue;
						sineButton.BackColor = Color.RoyalBlue;
						break;
					}
			}
		}
	}
}