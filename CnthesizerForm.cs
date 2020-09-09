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
			int frequencyIndex = (int)KeyControls.GetFrequencyFromKey(e.KeyCode);
			session.StartPlayingFrequency(frequencyIndex);
		}

		private void CnthesizerForm_KeyUp(object sender, KeyEventArgs e)
		{
			int frequencyIndex = (int)KeyControls.GetFrequencyFromKey(e.KeyCode);
			session.StopPlayingFrequency(frequencyIndex);
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
		}
	}
}
