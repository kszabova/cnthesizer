using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cnthesizer
{
	interface IRecorder
	{
		bool IsActive { get; }
		string Filename { get; set; }
		void StartRecording();
		void StopRecording();
		void AddNewEpoch(List<Pitch> frequencies);
		void Playback();
		void StopPlayback(bool dispose);
		void RegenerateRecording(Shift shift);
	}

	class Recorder : IRecorder
	{
		public bool IsActive => true;
		public bool IsPitchModified { get; set; }
		public string Filename { get; set; }
		private Session session { get; }
		private List<Epoch> epochs { get; }
		private Stopwatch stopwatch;
		private long lastStopwatchMillis;
		private WaveChannel32 recording;
		private DirectSoundOut output;
		private int bpm;
		private short[] beatWave;

		private Recorder(Session session)
		{
			this.session = session;
			IsPitchModified = false;
			Filename = "recording.wav";
			epochs = new List<Epoch> { };
			stopwatch = new Stopwatch();
			lastStopwatchMillis = 0;
		}

		public static Recorder CreateRecording(Session session) => new Recorder(session);

		public void StartRecording()
		{
			stopwatch.Start();
			bpm = session.BeatPlaying ? session.CurrentBpm : 0;
		}

		public void StopRecording()
		{
			stopwatch.Stop();
			SaveRecording();
			ModifyRecording();
		}

		public void AddNewEpoch(List<Pitch> frequencies)
		{
			long elapsedMilis = stopwatch.ElapsedMilliseconds;
			long duration = elapsedMilis - lastStopwatchMillis;
			epochs.Add(Epoch.CreateEpoch(duration, frequencies));
			lastStopwatchMillis = elapsedMilis;
		}

		public void Playback()
		{
			recording.Seek(0, SeekOrigin.Begin);
			output.Play();
		}

		public void StopPlayback(bool dispose = false)
		{
			output.Stop();
			if (dispose)
			{
				output.Dispose();
				recording.Dispose();
			}
		}

		public void RegenerateRecording(Shift shift)
		{
			output.Dispose();
			recording.Dispose();

			short[] wave = ConcatWaves(shift);
			short[] combinedWave = Mixing.MixTwoWaves(wave, beatWave);
			byte[] binaryWave = Wave.ConvertShortWaveToBytes(combinedWave);

			using (FileStream fs = File.Create(Filename))
			{
				Wave.WriteToStream(fs, binaryWave, wave.Length,
					session.SAMPLE_RATE, session.BITS_PER_SAMPLE, session.CHANNELS);
			}
			
			recording = new WaveChannel32(new WaveFileReader(Filename));
			output = new DirectSoundOut();
			output.Init(recording);
		}

		private void SaveRecording()
		{
			// generate recorded wave
			short[] wave = ConcatWaves(Shifts.Unison);
			beatWave = GenerateBeat(bpm, wave.Length);
			short[] combinedWave = Mixing.MixTwoWaves(wave, beatWave);
			byte[] binaryWave = Wave.ConvertShortWaveToBytes(combinedWave);

			// save recording to file
			SaveRecordingForm saveRecording = new SaveRecordingForm(this);
			saveRecording.ShowDialog();
			using (FileStream fs = File.Create(Filename))
			{
				Wave.WriteToStream(fs, binaryWave, wave.Length,
					session.SAMPLE_RATE, session.BITS_PER_SAMPLE, session.CHANNELS);
			}

			// initialize output with recording
			recording = new WaveChannel32(new WaveFileReader(Filename));
			output = new DirectSoundOut();
			output.Init(recording);
		}

		private void ModifyRecording()
		{
			ModifyRecordingForm modifyRecording = new ModifyRecordingForm(this);
			modifyRecording.ShowDialog();
		}

		private short[] ConcatWaves(Shift shift)
		{
			List<short[]> waves = new List<short[]> { };
			foreach (Epoch epoch in epochs)
			{
				waves.Add(epoch.ConvertToWave(session.SAMPLE_RATE, shift));
			}
			short[] wave = waves.SelectMany(w => w).ToArray();
			return wave;
		}

		private short[] GenerateBeat(int bpm, int samples)
		{
			if (bpm != 0)
			{
				short[] beat = Wave.GenerateBeatWave(bpm);
				return beat.MultiplyToLength(samples);
			}
			else
			{
				return new short[samples];
			}
		}
	}

	class RecorderPlaceholder : IRecorder
	{
		public bool IsActive => false;

		public string Filename
		{
			get => "";
			set { }
		}

		public static RecorderPlaceholder Instance = new RecorderPlaceholder();

		static RecorderPlaceholder() { }

		private RecorderPlaceholder() { }

		public void AddNewEpoch(List<Pitch> frequencies) { }

		public void StartRecording() { }

		public void StopRecording() { }

		public void Playback() { }

		public void StopPlayback(bool dispose) { }

		public void RegenerateRecording(Shift shift) { }
	}
}
