using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Cnthesizer
{
	internal class Session
	{
		public int SAMPLE_RATE => 44100;
		public short BITS_PER_SAMPLE => 16;
		public short CHANNELS => 1;
		public MixingWaveProvider32 Mixer { get; }
		public DirectSoundOut Output { get; }
		public bool[] CurrentlyPlaying { get; }
		public WavePlayer Beat { get; private set; }
		public bool BeatPlaying { get; private set; }
		public int CurrentBpm { get; private set; }

		private readonly string defaultBeatFilePath = "beat.wav";
		private IRecorder recorder;

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

			// initialize recording to placeholder instance
			recorder = RecorderPlaceholder.Instance;
		}

		public static Session CreateSession() => new Session();

		public void StartPlayingFrequency(int frequencyIndex)
		{
			// do nothing if no tone is added
			if (frequencyIndex == (int)FrequenciesAvailable.Empty) return;

			if (!CurrentlyPlaying[frequencyIndex])
			{
				UpdateRecorder();

				WavePlayer inputStream = WavePlayers.WavePlayerList[frequencyIndex];
				Mixer.AddInputStream(inputStream.Channel);
				CurrentlyPlaying[frequencyIndex] = true;
			}
		}

		public void StopPlayingFrequency(int frequencyIndex)
		{
			UpdateRecorder();

			// do nothing if no tone was released
			if (frequencyIndex == (int)FrequenciesAvailable.Empty) return;

			WavePlayer inputStream = WavePlayers.WavePlayerList[frequencyIndex];
			Mixer.RemoveInputStream(inputStream.Channel);
			CurrentlyPlaying[frequencyIndex] = false;
		}

		public void StartPlayingBeat(int bpm)
		{
			byte[] beatWave = Wave.ConvertShortWaveToBytes(Wave.GenerateBeatWave(bpm));
			using (FileStream fs = File.Create(defaultBeatFilePath))
				Wave.WriteToStream(fs, beatWave, beatWave.Length / sizeof(short),
					SAMPLE_RATE, BITS_PER_SAMPLE, CHANNELS);
			Beat = new WavePlayer(defaultBeatFilePath);
			Mixer.AddInputStream(Beat.Channel);
			BeatPlaying = true;
			CurrentBpm = bpm;
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
		}

		public void StartRecording()
		{
			if (recorder.IsActive) return;

			recorder = Recorder.CreateRecording(this);
			Beat.Channel.Seek(0, SeekOrigin.Begin);
			recorder.StartRecording();
		}

		public void StopRecording()
		{
			if (!recorder.IsActive) return;

			StopPlayingBeat();
			UpdateRecorder();
			recorder.StopRecording();
			recorder = RecorderPlaceholder.Instance;
		}

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

		private void UpdateRecorder()
		{
			List<FrequenciesAvailable> freqs = GetFrequenciesPlaying();
			recorder.AddNewEpoch(freqs);
		}
	}
}
