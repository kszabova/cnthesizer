using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Cnthesizer
{
	/// <summary>
	/// Provides methods to record audio.
	/// </summary>
	internal interface IRecorder
	{
		string Filename { get; set; }
		bool IsActive { get; }

		void AddNewEpoch(List<Pitch> frequencies);

		void Playback();

		void StartRecording();

		void StopPlayback(bool dispose);

		void StopRecording();
	}


	/// <summary>
	/// Provides methods to modify audio.
	/// </summary>
	internal interface IModifier
	{
		Shift Shift { get; set; }

		void AddChord(ChordName chord, long duration);

		void AddHarmony(bool manual);

		void Playback();

		void PlayChord(ChordName chord);

		void RegenerateRecording();

		void StopPlayback(bool dispose);

		void StopChord();

		void UpdateScale(Scale scale);

	}

	/// <summary>
	/// Class that can record and modify audio.
	/// </summary>
	internal class Recorder : IRecorder, IModifier
	{
		private short[] beatWave;
		private int bpm;
		private DirectSoundOut harmonyOutput;
		private MixingWaveProvider32 harmonyProvider;
		private Chord lastChord;
		private long lastStopwatchMillis;
		private WaveChannel32 recordingChannel;
		private DirectSoundOut recordingOutput;
		private Scale scale;
		private Stopwatch stopwatch;
		private Recorder(Session session)
		{
			// initialize values
			this.session = session;
			IsPitchModified = false;
			Filename = "recording.wav";
			melodyEpochs = new List<Epoch> { };
			harmonyEpochs = new List<Epoch> { };
			stopwatch = new Stopwatch();
			lastStopwatchMillis = 0;
			Shift = Shifts.Unison;
		}

		public string Filename { get; set; }
		public bool IsActive => true;
		public bool IsPitchModified { get; set; }
		public Shift Shift { get; set; }
		private List<Epoch> harmonyEpochs { get; set; }
		private List<Epoch> melodyEpochs { get; }
		private Session session { get; }
		public static Recorder CreateRecording(Session session) => new Recorder(session);

		/// <summary>
		/// Adds recorded or generated harmony to pre-recorded melody and beat.
		/// Stores the result in the original file.
		/// </summary>
		/// <param name="manual">Should harmony be added manually (as opposed to automatic generation)</param>
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

		/// <summary>
		/// Add one chord and its duration to harmony.
		/// </summary>
		/// <param name="chordName">Name of chord played</param>
		/// <param name="duration">Length of chord in milliseconds</param>
		public void AddChord(ChordName chordName, long duration)
		{
			Chord chord = new Chord(scale, chordName);
			harmonyEpochs.Add(Epoch.CreateEpoch(duration, chord.Tones));
		}

		/// <summary>
		/// Adds list of tones being played and sets their duration
		/// to the difference since the last change.
		/// </summary>
		/// <param name="frequencies">List of Pitches played</param>
		public void AddNewEpoch(List<Pitch> frequencies)
		{
			long elapsedMilis = stopwatch.ElapsedMilliseconds;
			long duration = elapsedMilis - lastStopwatchMillis;
			melodyEpochs.Add(Epoch.CreateEpoch(duration, frequencies));
			lastStopwatchMillis = elapsedMilis;
		}

		/// <summary>
		/// Play recorded audio.
		/// </summary>
		public void Playback()
		{
			recordingChannel.Seek(0, SeekOrigin.Begin);
			recordingOutput.Play();
		}

		/// <summary>
		/// Plays given chord.
		/// </summary>
		/// <param name="chordName">Name of chord played</param>
		public void PlayChord(ChordName chordName)
		{
			Chord chord = new Chord(scale, chordName);
			foreach (Pitch pitch in chord.Tones)
			{
				harmonyProvider.AddInputStream(PitchSelector.GetWavePlayer(pitch, session.WaveForm).Channel);
			}
			lastChord = chord;
		}

		/// <summary>
		/// Generates a new recording from all the changes that have been made
		/// (e.g. added harmony, shifted scale).
		/// </summary>
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
					Config.SAMPLE_RATE, Config.BITS_PER_SAMPLE, Config.CHANNELS);
			}

			// create new channel and output for playing the recording
			recordingChannel = new WaveChannel32(new WaveFileReader(Filename));
			recordingChannel.Volume = 1.0f;
			recordingOutput = new DirectSoundOut();
			recordingOutput.Init(recordingChannel);
		}

		/// <summary>
		/// Starts recording.
		/// </summary>
		public void StartRecording()
		{
			stopwatch.Start();
			bpm = session.BeatPlaying ? session.CurrentBpm : 0;
		}

		/// <summary>
		/// Stops playing currently played chord.
		/// </summary>
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

		/// <summary>
		/// Stops playing recording.
		/// </summary>
		/// <param name="dispose"></param>
		public void StopPlayback(bool dispose = false)
		{
			recordingOutput.Stop();
			if (dispose)
			{
				recordingOutput.Dispose();
				recordingChannel.Dispose();
			}
		}

		/// <summary>
		/// Stops recording. Prompts user to save it (specify filename)
		/// and then to modify it.
		/// </summary>
		public void StopRecording()
		{
			stopwatch.Stop();
			SaveRecording();
			ModifyRecording();
		}

		/// <summary>
		/// Updates scale of recording.
		/// </summary>
		/// <param name="scale">New scale</param>
		public void UpdateScale(Scale scale)
		{
			this.scale = scale;
		}

		private short[] ConcatWaves(List<Epoch> waves)
		{
			List<short[]> shortWaves = new List<short[]> { };
			foreach (Epoch epoch in waves)
			{
				shortWaves.Add(epoch.ConvertToWave(Config.SAMPLE_RATE, Shift, session.WaveForm));
			}
			short[] wave = shortWaves.SelectMany(w => w).ToArray();
			return wave;
		}

		private short[] GenerateBeat(int bpm, int samples)
		{
			// beat frequency of 0 means there was no beat
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

		private void ModifyRecording()
		{
			ModifyRecordingForm modifyRecording = new ModifyRecordingForm(this, bpm);
			modifyRecording.ShowDialog();
		}

		private void SaveRecording()
		{
			SaveRecordingForm saveRecording = new SaveRecordingForm(this);
			saveRecording.ShowDialog();

			RegenerateRecording();
		}
	}

	/// <summary>
	/// Placeholder IRecorder to be used when we actually don't 
	/// want to record anything.
	/// </summary>
	internal class RecorderPlaceholder : IRecorder
	{
		public static RecorderPlaceholder Instance = new RecorderPlaceholder();
		static RecorderPlaceholder()
		{
		}

		private RecorderPlaceholder()
		{
		}

		public string Filename
		{
			get => "";
			set { }
		}

		public bool IsActive => false;

		public void AddNewEpoch(List<Pitch> frequencies)
		{
		}

		public void Playback()
		{
		}

		public void StartRecording()
		{
		}

		public void StopPlayback(bool dispose)
		{
		}

		public void StopRecording()
		{
		}
	}
}