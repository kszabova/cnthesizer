using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnthesizer
{
	class Recording
	{
		private Session session { get; }
		private List<Epoch> epochs { get; }
		private bool recording = false;
		private Stopwatch stopwatch;
		private long lastStopwatchMillis;

		private Recording(Session session)
		{
			this.session = session;
			epochs = new List<Epoch> { };
			stopwatch = new Stopwatch();
			lastStopwatchMillis = 0;
		}

		public static Recording CreateRecording(Session session) => new Recording(session);

		public void StartRecording()
		{
			recording = true;
			stopwatch.Start();
		}

		public void StopRecording()
		{
			recording = false;
			stopwatch.Stop();
			SaveRecording();
		}

		public void AddNewEpoch(List<FrequenciesAvailable> frequencies)
		{
			long elaspsedMilis = stopwatch.ElapsedMilliseconds;
			epochs.Add(Epoch.CreateEpoch(elaspsedMilis - lastStopwatchMillis, frequencies));
			lastStopwatchMillis = elaspsedMilis;
		}

		private void SaveRecording()
		{
			short[] wave = ConcatWaves();
			byte[] binaryWave = Wave.ConvertShortWaveToBytes(wave);
			using (FileStream fs = File.Create("recording.wav"))
			{
				Wave.WriteToStream(fs, binaryWave, wave.Length, session.SAMPLE_RATE, session.BITS_PER_SAMPLE, session.CHANNELS);
			}
		}

		private void Playback()
		{
			// pull saved file
			// get IWaveOut or whatever from parent session
			// play recording on it
			throw new NotImplementedException();
		}

		private short[] ConcatWaves()
		{
			List<short[]> waves = new List<short[]> { };
			foreach (Epoch epoch in epochs)
			{
				waves.Add(epoch.ConvertToWave(session.SAMPLE_RATE));
			}
			short[] wave = waves.SelectMany(w => w).ToArray();
			return wave;
		}
	}
}
