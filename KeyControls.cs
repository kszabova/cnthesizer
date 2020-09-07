using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cnthesizer
{
	static class KeyControls
	{
		public static Frequency GetFrequencyFromKey(Keys key)
		{
			switch (key)
			{
				case Keys.A:
					return Frequency.C0;
				case Keys.S:
					return Frequency.D;
				case Keys.D:
					return Frequency.E;
				case Keys.F:
					return Frequency.F;
				case Keys.G:
					return Frequency.G;
				case Keys.H:
					return Frequency.A;
				case Keys.J:
					return Frequency.B;
				case Keys.K:
					return Frequency.C1;
				default:
					return Frequency.A;
			}
		}

		public static WavePlayer GetWavePlayerFromKey(Keys key)
			=> WavePlayers.WavePlayerList[(int)GetFrequencyFromKey(key)];
		public static WaveFileReader GetWaveFileReaderFromKey(Keys key)
			=> WaveFileReaders.WaveFileReaderList[(int)GetFrequencyFromKey(key)];
		public static WaveChannel32 GetWaveChannelFromKey(Keys key)
			=> WaveChannels.WaveChannelList[(int)GetFrequencyFromKey(key)];
	}
}
