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
		public WaveFormEquation WaveForm { get; private set; }
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
			WaveForm = WaveForms.SquareWave;

			// set all frequencies as not-playing 
			CurrentlyPlaying = new bool[Enum.GetNames(typeof(Pitch)).Length];
			foreach (Pitch frequency in Enum.GetValues(typeof(Pitch)))
			{
				CurrentlyPlaying[(int)frequency] = false;
			}

			// initialize mixer with "silence" playing
			Mixer = new MixingWaveProvider32(new List<WaveChannel32> { PitchSelector.GetWavePlayer(Pitch.Empty, WaveForm).Channel });
			CurrentlyPlaying[(int)Pitch.Empty] = true;

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

		public void StartPlayingPitch(Pitch pitch)
		{
			// do nothing if no tone is added
			if (pitch == Pitch.Empty) return;

			if (!CurrentlyPlaying[(int)pitch])
			{
				UpdateRecorder();

				WavePlayer inputStream = PitchSelector.GetWavePlayer(pitch, WaveForm);
				Mixer.AddInputStream(inputStream.Channel);
				CurrentlyPlaying[(int)pitch] = true;
			}
		}

		public void StopPlayingPitch(Pitch pitch)
		{
			UpdateRecorder();

			// do nothing if no tone was released
			if (pitch == Pitch.Empty) return;

			WavePlayer inputStream = PitchSelector.GetWavePlayer(pitch, WaveForm);
			Mixer.RemoveInputStream(inputStream.Channel);
			CurrentlyPlaying[(int)pitch] = false;
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
			if (Beat != null)
			{
				Mixer.RemoveInputStream(Beat.Channel);
				Beat.Dispose();
			}
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
			// reset beat
			if (Beat != null) Beat.Channel.Seek(0, SeekOrigin.Begin);
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

		private List<Pitch> GetFrequenciesPlaying()
		{
			List<Pitch> frequenciesPlaying = new List<Pitch> { };
			foreach (Pitch frequency in Enum.GetValues(typeof(Pitch)))
			{
				if (CurrentlyPlaying[(int)frequency])
					frequenciesPlaying.Add(frequency);
			}
			return frequenciesPlaying;
		}

		private void UpdateRecorder()
		{
			List<Pitch> freqs = GetFrequenciesPlaying();
			recorder.AddNewEpoch(freqs);
		}
	}
}
