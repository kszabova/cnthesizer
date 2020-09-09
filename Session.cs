using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnthesizer
{
	class Session
	{
		public int SAMPLE_RATE => 44100;
		public short BITS_PER_SAMPLE => sizeof(short);
		public MixingWaveProvider32 Mixer => mixer;
		public DirectSoundOut Output => output;
		public bool[] CurrentlyPlaying { get; }
		public WavePlayer Beat { get; internal set; }

		private readonly MixingWaveProvider32 mixer;
		private readonly DirectSoundOut output;

		private Session()
		{
			// set all frequencies as not-playing 
			CurrentlyPlaying = new bool[Enum.GetNames(typeof(FrequenciesAvailable)).Length];
			foreach (FrequenciesAvailable frequency in Enum.GetValues(typeof(FrequenciesAvailable)))
			{
				CurrentlyPlaying[(int)frequency] = false;
			}

			// initialize mixer with "silence" playing
			mixer = new MixingWaveProvider32(new List<WaveChannel32> { WavePlayers.Empty.Channel });
			CurrentlyPlaying[(int)FrequenciesAvailable.Empty] = true;

			// initialize output
			output = new DirectSoundOut();
			output.Init(mixer);
			output.Play();
		}

		public static Session CreateSession() => new Session();
	}
}
