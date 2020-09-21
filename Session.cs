using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;

namespace Cnthesizer
{
	/// <summary>
	/// Instance contains information about
	/// a Cnthesizer session.
	/// </summary>
	public class Session
	{
		private readonly string defaultBeatFilePath = "beat.wav";
		private IRecorder recorder;
		private Session()
		{
			WaveForm = WaveForms.SineWave;

			// set all frequencies as not-playing
			CurrentlyPlayingPitches = new bool[Enum.GetNames(typeof(Pitch)).Length];
			foreach (Pitch frequency in Enum.GetValues(typeof(Pitch)))
			{
				CurrentlyPlayingPitches[(int)frequency] = false;
			}

			// initialize mixer with "silence" playing
			SoundMixer = new MixingWaveProvider32(new List<WaveChannel32> { PitchSelector.GetWavePlayer(Pitch.Empty, WaveForm).Channel });
			CurrentlyPlayingPitches[(int)Pitch.Empty] = true;

			// initialize output
			SoundOutput = new DirectSoundOut();
			SoundOutput.Init(SoundMixer);
			SoundOutput.Play();

			// set beat as not-playing
			BeatPlaying = false;

			// initialize recording to placeholder instance
			recorder = RecorderPlaceholder.Instance;
			IsRecording = false;
		}

		public WavePlayer Beat { get; private set; }
		public bool BeatPlaying { get; private set; }
		public int CurrentBpm { get; private set; }
		public bool[] CurrentlyPlayingPitches { get; }
		public bool IsRecording { get; private set; }
		public MixingWaveProvider32 SoundMixer { get; private set; }
		public DirectSoundOut SoundOutput { get; private set; }
		public WaveFormEquation WaveForm { get; private set; }
		public static Session CreateSession() => new Session();

		/// <summary>
		/// Update beat frequency and play the new beat
		/// </summary>
		/// <param name="bpm">Beats per minute</param>
		public void ChangeBeatFrequency(int bpm)
		{
			StopPlayingBeat();
			StartPlayingBeat(bpm);
		}

		/// <summary>
		/// Change the shape of wave
		/// </summary>
		/// <param name="waveForm">Method to generate a wave</param>
		public void ChangeWaveForm(WaveFormEquation waveForm)
		{
			WaveForm = waveForm;
			ResetOutput();
		}

		/// <summary>
		/// Starts playing beat with the specified bpm.
		/// </summary>
		/// <param name="bpm">Beats per minute</param>
		public void StartPlayingBeat(int bpm)
		{
			// generate beat wave
			byte[] beatWave = Wave.ConvertShortWaveToBytes(Wave.GenerateBeatWave(bpm));

			// write the wave into a file
			using (FileStream fs = File.Create(defaultBeatFilePath))
				Wave.WriteToStream(fs, beatWave, beatWave.Length / sizeof(short),
					Config.SAMPLE_RATE, Config.BITS_PER_SAMPLE, Config.CHANNELS);

			// play the file
			Beat = new WavePlayer(defaultBeatFilePath);
			SoundMixer.AddInputStream(Beat.Channel);
			BeatPlaying = true;
			CurrentBpm = bpm;
		}

		/// <summary>
		/// Starts playing the specified pitch
		/// </summary>
		/// <param name="pitch">Pitch</param>
		public void StartPlayingPitch(Pitch pitch)
		{
			// do nothing if no tone is added
			if (pitch == Pitch.Empty) return;

			if (!CurrentlyPlayingPitches[(int)pitch])
			{
				UpdateRecorder();

				WavePlayer inputStream = PitchSelector.GetWavePlayer(pitch, WaveForm);
				SoundMixer.AddInputStream(inputStream.Channel);
				CurrentlyPlayingPitches[(int)pitch] = true;
			}
		}

		/// <summary>
		/// Starts recording what is being played.
		/// Resets beat so that it starts immediately after releasing the button.
		/// </summary>
		public void StartRecording()
		{
			// do nothing if we are already recording
			if (recorder.IsActive) return;

			IsRecording = true;
			recorder = Recorder.CreateRecording(this);

			// reset beat
			if (Beat != null)
				Beat.Channel.Seek(0, SeekOrigin.Begin);

			recorder.StartRecording();
		}

		/// <summary>
		/// Stop playing any sound
		/// </summary>
		public void StopPlaying()
		{
			SoundOutput.Stop();
		}

		/// <summary>
		/// Stop playing beat
		/// </summary>
		public void StopPlayingBeat()
		{
			if (Beat != null)
			{
				SoundMixer.RemoveInputStream(Beat.Channel);
				Beat.Dispose();
			}
			Beat = null;
			BeatPlaying = false;
		}

		/// <summary>
		/// Stop playing given pitch
		/// </summary>
		/// <param name="pitch">Pitch</param>
		public void StopPlayingPitch(Pitch pitch)
		{
			// alert recorder that a change has been made
			UpdateRecorder();

			// do nothing if no tone was released
			if (pitch == Pitch.Empty) return;

			WavePlayer inputStream = PitchSelector.GetWavePlayer(pitch, WaveForm);
			SoundMixer.RemoveInputStream(inputStream.Channel);
			CurrentlyPlayingPitches[(int)pitch] = false;
		}

		/// <summary>
		/// Stop recording. Pass control to the recorder.
		/// </summary>
		public void StopRecording()
		{
			if (!recorder.IsActive) return;

			IsRecording = false;
			StopPlayingBeat();
			UpdateRecorder();
			recorder.StopRecording();
			recorder = RecorderPlaceholder.Instance;
		}

		private List<Pitch> GetFrequenciesPlaying()
		{
			List<Pitch> frequenciesPlaying = new List<Pitch> { };
			foreach (Pitch frequency in PitchSelector.EnumeratePitches())
			{
				if (CurrentlyPlayingPitches[(int)frequency])
					frequenciesPlaying.Add(frequency);
			}
			return frequenciesPlaying;
		}

		private void ResetOutput()
		{
			SoundOutput.Dispose();

			SoundMixer = new MixingWaveProvider32(new List<WaveChannel32> { PitchSelector.GetWavePlayer(Pitch.Empty, WaveForm).Channel });
			SoundOutput = new DirectSoundOut();
			SoundOutput.Init(SoundMixer);
			SoundOutput.Play();
		}

		private void UpdateRecorder()
		{
			List<Pitch> freqs = GetFrequenciesPlaying();
			recorder.AddNewEpoch(freqs);
		}
	}
}