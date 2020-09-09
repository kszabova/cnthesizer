using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cnthesizer
{
	class Session
	{
		public int SAMPLE_RATE => 44100;
		public short BITS_PER_SAMPLE => 16;
		public short CHANNELS => 1;
		public MixingWaveProvider32 Mixer => mixer;
		public DirectSoundOut Output => output;
		public bool[] CurrentlyPlaying { get; }
		public WavePlayer Beat { get; private set; }
		public bool BeatPlaying { get; private set; }

		private readonly MixingWaveProvider32 mixer;
		private readonly DirectSoundOut output;
		private readonly string defaultBeatFilePath = "beat.wav";

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

			// set beat as not-playing
			BeatPlaying = false;
		}

		public static Session CreateSession() => new Session();

		public void StartPlayingFrequency(int frequencyIndex)
		{
			// do nothing if no tone is added
			if (frequencyIndex == (int)FrequenciesAvailable.Empty) return;

			if (!CurrentlyPlaying[frequencyIndex])
			{
				WavePlayer inputStream = WavePlayers.WavePlayerList[frequencyIndex];
				mixer.AddInputStream(inputStream.Channel);
				CurrentlyPlaying[frequencyIndex] = true;
			}
		}

		public void StopPlayingFrequency(int frequencyIndex)
		{
			// do nothing if no tone was released
			if (frequencyIndex == (int)FrequenciesAvailable.Empty) return;

			WavePlayer inputStream = WavePlayers.WavePlayerList[frequencyIndex];
			mixer.RemoveInputStream(inputStream.Channel);
			CurrentlyPlaying[frequencyIndex] = false;
		}

		public void StartPlayingBeat(int bpm)
		{
			byte[] beatWave = Wave.GenerateBeatWave(bpm);
			using (FileStream fs = File.Create(defaultBeatFilePath))
				Wave.WriteToStream(fs, beatWave, beatWave.Length / sizeof(short), SAMPLE_RATE, BITS_PER_SAMPLE, CHANNELS);
			Beat = new WavePlayer(defaultBeatFilePath);
			mixer.AddInputStream(Beat.Channel);
			BeatPlaying = true;
		}

		public void StopPlayingBeat()
		{
			mixer.RemoveInputStream(Beat.Channel);
			Beat.Dispose();
			Beat = null;
			BeatPlaying = false;
		}

		public void ChangeBeatFrequency(int bpm)
		{
			StopPlayingBeat();
			StartPlayingBeat(bpm);
		}
	}
}
