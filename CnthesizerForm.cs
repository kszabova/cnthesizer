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
using NAudio.Mixer;

namespace Cnthesizer
{
	public partial class CnthesizerForm : Form
	{
		private WaveMixerStream32 mixer;
		private DirectSoundOut output;

		public CnthesizerForm()
		{
			InitializeComponent();
		}

		private void CnthesizerForm_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.A:
					{
						//WaveChannels.A.Position = 0;
						WaveFileReaders.A.Position = 0;
						mixer.AddInputStream(WaveChannels.C0);
						//output.Init(new WaveChannel32(WaveFileReaders.A));
						break;
					}
				case Keys.S:
					{
						WaveFileReaders.D.Position = 0;
						mixer.AddInputStream(WaveChannels.D);
						break;
					}
				case Keys.D:
					{
						WaveFileReaders.E.Position = 0;
						mixer.AddInputStream(WaveChannels.E);
						break;
					}
				case Keys.F:
					{
						WaveFileReaders.F.Position = 0;
						mixer.AddInputStream(WaveChannels.F);
						break;
					}
				case Keys.G:
					{
						WaveFileReaders.G.Position = 0;
						mixer.AddInputStream(WaveChannels.G);
						break;
					}
				case Keys.H:
					{
						WaveFileReaders.A.Position = 0;
						mixer.AddInputStream(WaveChannels.A);
						break;
					}
				case Keys.J:
					{
						WaveFileReaders.B.Position = 0;
						mixer.AddInputStream(WaveChannels.B);
						break;
					}
				case Keys.K:
					{
						WaveFileReaders.C1.Position = 0;
						mixer.AddInputStream(WaveChannels.C1);
						break;
					}
				default:
					{
						WaveFileReaders.A.Position = 0;
						mixer.AddInputStream(WaveChannels.A);
						break;
					}
			}

			//output.Play();

		}

		private void CnthesizerForm_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.A:
					{
						mixer.RemoveInputStream(WaveChannels.C0);
						break;
					}
				case Keys.S:
					{
						mixer.RemoveInputStream(WaveChannels.D);
						break;
					}
				case Keys.D:
					{
						mixer.RemoveInputStream(WaveChannels.E);
						break;
					}
				case Keys.F:
					{
						mixer.RemoveInputStream(WaveChannels.F);
						break;
					}
				case Keys.G:
					{
						mixer.RemoveInputStream(WaveChannels.G);
						break;
					}
				case Keys.H:
					{
						mixer.RemoveInputStream(WaveChannels.A);
						break;
					}
				case Keys.J:
					{
						mixer.RemoveInputStream(WaveChannels.B);
						break;
					}
				case Keys.K:
					{
						mixer.RemoveInputStream(WaveChannels.C1);
						break;
					}
				default:
					{
						mixer.RemoveInputStream(WaveChannels.A);
						break;
					}
				
			}
			//output.Stop();
		}

		private void CnthesizerForm_Load(object sender, EventArgs e)
		{
			mixer = new WaveMixerStream32();
			mixer.AutoStop = false;
			output = new DirectSoundOut();
			output.Init(mixer);
			output.Play();
		}
	}
}
