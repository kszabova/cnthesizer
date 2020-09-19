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
		public static Pitch GetPitchFromKey(Keys key)
		{
			switch (key)
			{
				//case Keys.A:
				//	return Pitch.C0;
				//case Keys.S:
				//	return Pitch.D;
				//case Keys.D:
				//	return Pitch.E;
				//case Keys.F:
				//	return Pitch.F;
				//case Keys.G:
				//	return Pitch.G;
				//case Keys.H:
				//	return Pitch.A;
				//case Keys.J:
				//	return Pitch.B;
				//case Keys.K:
				//	return Pitch.C1;
				default:
					return Pitch.Empty;
			}
		}

		public static WavePlayer GetWavePlayerFromKey(Keys key)
			=> PitchSelector.GetWavePlayer(GetPitchFromKey(key));
		public static WaveFileReader GetWaveFileReaderFromKey(Keys key)
			=> PitchSelector.GetWaveFileReader(GetPitchFromKey(key));
		public static WaveChannel32 GetWaveChannelFromKey(Keys key)
			=> PitchSelector.GetWaveChannel(GetPitchFromKey(key));
	}
}
