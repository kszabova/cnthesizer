﻿using NAudio.Wave;
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
		Shift Shift { get; set; }
		void StartRecording();
		void StopRecording();
		void AddNewEpoch(List<Pitch> frequencies);
		void Playback();
		void StopPlayback(bool dispose);
		void RegenerateRecording();
		void UpdateScale(Scale scale);
		void AddHarmony(bool manual);
		void AddChord(ChordName chord, long duration);
		void PlayChord(ChordName chord);
		void StopChord();
	}

	class Recorder : IRecorder
	{
		public bool IsActive => true;
		public bool IsPitchModified { get; set; }
		public string Filename { get; set; }
		private Session session { get; }
		private List<Epoch> melodyEpochs { get; }
		private Stopwatch stopwatch;
		private long lastStopwatchMillis;
		private WaveChannel32 recordingChannel;
		private DirectSoundOut recordingOutput;
		private MixingWaveProvider32 harmonyProvider;
		private DirectSoundOut harmonyOutput;
		private Chord lastChord = null;
		private int bpm;
		private short[] beatWave;
		private Scale scale;
		private List<Epoch> harmonyEpochs { get; set; }
		public Shift Shift { get; set; }

		private Recorder(Session session)
		{
			this.session = session;
			IsPitchModified = false;
			Filename = "recording.wav";
			melodyEpochs = new List<Epoch> { };
			harmonyEpochs = new List<Epoch> { };
			stopwatch = new Stopwatch();
			lastStopwatchMillis = 0;
			Shift = Shifts.Unison;
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
			melodyEpochs.Add(Epoch.CreateEpoch(duration, frequencies));
			lastStopwatchMillis = elapsedMilis;
		}

		public void Playback()
		{
			recordingChannel.Seek(0, SeekOrigin.Begin);
			recordingOutput.Play();
		}

		public void StopPlayback(bool dispose = false)
		{
			recordingOutput.Stop();
			if (dispose)
			{
				recordingOutput.Dispose();
				recordingChannel.Dispose();
			}
		}

		public void RegenerateRecording()
		{
			// dispose recording channel and recording output if they exist
			if (recordingOutput != null) recordingOutput.Dispose();
			if (recordingChannel != null) recordingChannel.Dispose();

			// generate waves from epochs
			short[] melody = ConcatWaves(melodyEpochs);
			short[] harmony = ConcatWaves(harmonyEpochs);
			harmony = harmony.MultiplyToLength(melody.Length);
			if (beatWave == null)
				beatWave = GenerateBeat(bpm, melody.Length);

			// mix melody, harmony and beat
			short[] combinedWave = Mixing.MixListOfWaves(new List<short[]> { melody, harmony, beatWave });
			byte[] binaryWave = Wave.ConvertShortWaveToBytes(combinedWave);

			// write the result into a file
			using (FileStream fs = File.Create(Filename))
			{
				Wave.WriteToStream(fs, binaryWave, melody.Length,
					session.SAMPLE_RATE, session.BITS_PER_SAMPLE, session.CHANNELS);
			}
			
			// create new channel and output for playing the recording
			recordingChannel = new WaveChannel32(new WaveFileReader(Filename));
			recordingChannel.Volume = 1.0f;
			recordingOutput = new DirectSoundOut();
			recordingOutput.Init(recordingChannel);
		}

		public void UpdateScale(Scale scale)
		{
			this.scale = scale;
		}

		public void AddHarmony(bool manual)
		{
			if (scale == null)
			{
				throw new ApplicationException("No scale selected");
			}

			// remove previously added harmony
			harmonyEpochs = new List<Epoch> { };
			RegenerateRecording();

			if (manual)
			{
				// adjust volume of recording
				recordingChannel.Volume = 2.5f;

				ManualHarmonyForm harmonyForm = new ManualHarmonyForm(this);

				harmonyProvider = new MixingWaveProvider32(new List<WaveChannel32> { PitchSelector.GetWavePlayer(Pitch.Empty, session.WaveForm).Channel });
				harmonyOutput = new DirectSoundOut();
				harmonyOutput.Init(harmonyProvider);
				harmonyOutput.Play();

				harmonyForm.ShowDialog();
				RegenerateRecording();
			}
		}

		public void AddChord(ChordName chordName, long duration)
		{
			Chord chord = new Chord(scale, chordName);
			harmonyEpochs.Add(Epoch.CreateEpoch(duration, chord.Tones));
		}

		public void PlayChord(ChordName chordName)
		{
			Chord chord = new Chord(scale, chordName);
			foreach (Pitch pitch in chord.Tones)
			{
				harmonyProvider.AddInputStream(PitchSelector.GetWavePlayer(pitch, session.WaveForm).Channel);
			}
			lastChord = chord;
		}

		public void StopChord()
		{
			if (lastChord != null)
			{
				foreach (Pitch pitch in lastChord.Tones)
				{
					harmonyProvider.RemoveInputStream(PitchSelector.GetWavePlayer(pitch, session.WaveForm).Channel);
				}
			}
			lastChord = null;
		}

		private void SaveRecording()
		{
			// get filename
			SaveRecordingForm saveRecording = new SaveRecordingForm(this);
			saveRecording.ShowDialog();

			RegenerateRecording();
		}

		private void ModifyRecording()
		{
			ModifyRecordingForm modifyRecording = new ModifyRecordingForm(this, bpm);
			modifyRecording.ShowDialog();
		}

		private short[] ConcatWaves(List<Epoch> waves)
		{
			List<short[]> shortWaves = new List<short[]> { };
			foreach (Epoch epoch in waves)
			{
				shortWaves.Add(epoch.ConvertToWave(session.SAMPLE_RATE, Shift, session.WaveForm));
			}
			short[] wave = shortWaves.SelectMany(w => w).ToArray();
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

		public Shift Shift { get; set; }

		public static RecorderPlaceholder Instance = new RecorderPlaceholder();

		static RecorderPlaceholder() { }

		private RecorderPlaceholder() { }

		public void AddNewEpoch(List<Pitch> frequencies) { }

		public void StartRecording() { }

		public void StopRecording() { }

		public void Playback() { }

		public void StopPlayback(bool dispose) { }

		public void RegenerateRecording() { }

		public void UpdateScale(Scale scale) { }

		public void AddHarmony(bool manual) { }

		public void AddChord(ChordName chordName, long duration) { }

		public void PlayChord(ChordName chordName) { }

		public void StopChord() { }
	}
}
