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
		public static FrequenciesAvailable GetFrequencyFromKey(Keys key)
		{
			switch (key)
			{
				case Keys.A:
					return FrequenciesAvailable.C0;
				case Keys.S:
					return FrequenciesAvailable.D;
				case Keys.D:
					return FrequenciesAvailable.E;
				case Keys.F:
					return FrequenciesAvailable.F;
				case Keys.G:
					return FrequenciesAvailable.G;
				case Keys.H:
					return FrequenciesAvailable.A;
				case Keys.J:
					return FrequenciesAvailable.B;
				case Keys.K:
					return FrequenciesAvailable.C1;
				default:
					return FrequenciesAvailable.Empty;
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
