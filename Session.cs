using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cnthesizer
{
	internal class Session
	{
		public int SAMPLE_RATE => 44100;
		public short BITS_PER_SAMPLE => 16;
		public short CHANNELS => 1;
		public MixingWaveProvider32 Mixer { get; }
		public DirectSoundOut Output { get; }
		public WaveRecorder Recorder { get; }
		public IWavePlayer WaveOut { get; }
		public bool[] CurrentlyPlaying { get; }
		public WavePlayer Beat { get; private set; }
		public bool BeatPlaying { get; private set; }

		private readonly string defaultBeatFilePath = "beat.wav";
		private Recording recording;

		private Session()
		{
			// set all frequencies as not-playing 
			CurrentlyPlaying = new bool[Enum.GetNames(typeof(FrequenciesAvailable)).Length];
			foreach (FrequenciesAvailable frequency in Enum.GetValues(typeof(FrequenciesAvailable)))
			{
				CurrentlyPlaying[(int)frequency] = false;
			}

			// initialize mixer with "silence" playing
			Mixer = new MixingWaveProvider32(new List<WaveChannel32> { WavePlayers.Empty.Channel });
			CurrentlyPlaying[(int)FrequenciesAvailable.Empty] = true;

			// initialize output
			Output = new DirectSoundOut();
			Output.Init(Mixer);
			Output.Play();

			// set beat as not-playing
			BeatPlaying = false;

			// initialize recorder
			recording = Recording.CreateRecording(this);
		}

		public static Session CreateSession() => new Session();

		public void StartPlayingFrequency(int frequencyIndex)
		{
			// do nothing if no tone is added
			if (frequencyIndex == (int)FrequenciesAvailable.Empty) return;

			if (!CurrentlyPlaying[frequencyIndex])
			{
				WavePlayer inputStream = WavePlayers.WavePlayerList[frequencyIndex];
				Mixer.AddInputStream(inputStream.Channel);
				CurrentlyPlaying[frequencyIndex] = true;
			}
		}

		public void StopPlayingFrequency(int frequencyIndex)
		{
			// do nothing if no tone was released
			if (frequencyIndex == (int)FrequenciesAvailable.Empty) return;

			WavePlayer inputStream = WavePlayers.WavePlayerList[frequencyIndex];
			Mixer.RemoveInputStream(inputStream.Channel);
			CurrentlyPlaying[frequencyIndex] = false;
		}

		public void StartPlayingBeat(int bpm)
		{
			byte[] beatWave = Wave.GenerateBeatWave(bpm);
			using (FileStream fs = File.Create(defaultBeatFilePath))
				Wave.WriteToStream(fs, beatWave, beatWave.Length / sizeof(short), SAMPLE_RATE, BITS_PER_SAMPLE, CHANNELS);
			Beat = new WavePlayer(defaultBeatFilePath);
			Mixer.AddInputStream(Beat.Channel);
			BeatPlaying = true;
		}

		public void StopPlayingBeat()
		{
			Mixer.RemoveInputStream(Beat.Channel);
			Beat.Dispose();
			Beat = null;
			BeatPlaying = false;
		}

		public void ChangeBeatFrequency(int bpm)
		{
			StopPlayingBeat();
			StartPlayingBeat(bpm);
		}

		public void StopPlaying()
		{
			Output.Stop();
			WaveOut.Stop();
			WaveOut.Dispose();
			Recorder.Dispose();
		}

		public void StartRecording() => recording.StartRecording();

		public void StopRecording() => recording.StopRecording();

		private List<FrequenciesAvailable> GetFrequenciesPlaying()
		{
			List<FrequenciesAvailable> frequenciesPlaying = new List<FrequenciesAvailable> { };
			foreach (FrequenciesAvailable frequency in Enum.GetValues(typeof(FrequenciesAvailable)))
			{
				if (CurrentlyPlaying[(int)frequency])
					frequenciesPlaying.Add(frequency);
			}
			return frequenciesPlaying;
		}
	}
}
