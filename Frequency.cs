using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;

namespace Cnthesizer
{
	public enum Pitch
	{
		Empty,
		A3, Am3, B3, C4, Cm4, D4, Dm4, E4, F4, Fm4, G4, Gm4,
		A4, Am4, B4, C5, Cm5, D5, Dm5, E5, F5, Fm5, G5, Gm5,
		A5, Am5, B5, C6, Cm6, D6, Dm6, E6, F6, Fm6, G6, Gm6,
		A6
	}

	public static class Frequency
	{
		private static readonly double Empty = 0;
		private static readonly double A3 = 220;
		private static readonly double Am3 = 233.082;
		private static readonly double B3 = 246.942;
		private static readonly double C4 = 261.626;
		private static readonly double Cm4 = 277.183;
		private static readonly double D4 = 293.655;
		private static readonly double Dm4 = 311.127;
		private static readonly double E4 = 329.628;
		private static readonly double F4 = 349.228;
		private static readonly double Fm4 = 369.994;
		private static readonly double G4 = 391.995;
		private static readonly double Gm4 = 415.305;
		private static readonly double A4 = 440;
		private static readonly double Am4 = 466.164;
		private static readonly double B4 = 493.883;
		private static readonly double C5 = 523.251;
		private static readonly double Cm5 = 554.365;
		private static readonly double D5 = 587.330;
		private static readonly double Dm5 = 622.254;
		private static readonly double E5 = 659.255;
		private static readonly double F5 = 698.456;
		private static readonly double Fm5 = 739.989;
		private static readonly double G5 = 783.991;
		private static readonly double Gm5 = 830.609;
		private static readonly double A5 = 880;
		private static readonly double Am5 = 932.328;
		private static readonly double B5 = 987.767;
		private static readonly double C6 = 1046.502;
		private static readonly double Cm6 = 1108.731;
		private static readonly double D6 = 1174.659;
		private static readonly double Dm6 = 1244.508;
		private static readonly double E6 = 1318.510;
		private static readonly double F6 = 1396.913;
		private static readonly double Fm6 = 1479.978;
		private static readonly double G6 = 1567.982;
		private static readonly double Gm6 = 1661.219;
		private static readonly double A6 = 1760;

		private static double[] Freqs = {
			Empty,
			A3, Am3, B3, C4, Cm4, D4, Dm4, E4, F4, Fm4, G4, Gm4,
			A4, Am4, B4, C5, Cm5, D5, Dm5, E5, F5, Fm5, G5, Gm5,
			A5, Am5, B5, C6, Cm6, D6, Dm6, E6, F6, Fm6, G6, Gm6,
			A6
		};

		public static double GetFrequency(Pitch pitch) => Freqs[(int)pitch];
	}

	public static class PitchSelector
	{
		public static readonly List<double> Frequencies;

		private static readonly List<WaveFileReader> SawtoothWaveFileReaders = new List<WaveFileReader> { };
		private static readonly List<WavePlayer> SawtoothWavePlayers = new List<WavePlayer> { };
		private static readonly List<WaveFileReader> SineWaveFileReaders = new List<WaveFileReader> { };
		private static readonly List<WavePlayer> SineWavePlayers = new List<WavePlayer> { };
		private static readonly List<WaveFileReader> SquareWaveFileReaders = new List<WaveFileReader> { };
		private static readonly List<WavePlayer> SquareWavePlayers = new List<WavePlayer> { };

		private static List<(string, WaveFormEquation)> prefixFormPairs = new List<(string, WaveFormEquation)>
		{
			(sinePrefix, WaveForms.SineWave),
			(squarePrefix, WaveForms.SquareWave),
			(sawtoothPrefix, WaveForms.SawtoothWave)
		};

		private static string sawtoothPrefix = "saw_";

		private static string sinePrefix = "sine_";

		private static string squarePrefix = "square_";

		private static List<string> waveFileNames = new List<string>
		{
			"empty.wav",
			"a3.wav", "am3.wav", "b3.wav", "c4.wav", "cm4.wav", "d4.wav", "dm4.wav", "e4.wav", "f4.wav", "fm4.wav", "g4.wav", "gm4.wav",
			"a4.wav", "am4.wav", "b4.wav", "c5.wav", "cm5.wav", "d5.wav", "dm5.wav", "e5.wav", "f5.wav", "fm5.wav", "g5.wav", "gm5.wav",
			"a5.wav", "am5.wav", "b5.wav", "c6.wav", "cm6.wav", "d6.wav", "dm6.wav", "e6.wav", "f6.wav", "fm6.wav", "g6.wav", "gm6.wav",
			"a6.wav"
		};

		static PitchSelector()
		{
			foreach (Pitch pitch in EnumeratePitches())
			{
				foreach ((string, WaveFormEquation) waveForm in prefixFormPairs)
				{
					List<WaveFileReader> wfrs = GetFileReaderByWaveForm(waveForm.Item2);
					List<WavePlayer> wps = GetPlayerByWaveForm(waveForm.Item2);

					string filename = waveForm.Item1 + GetWaveFilename(pitch);
					try
					{
						wfrs.Add(new WaveFileReader(filename));
					}
					catch (FileNotFoundException)
					{
						Wave.CreateWaveFile(filename, pitch, waveForm.Item2, 44100);
						wfrs.Add(new WaveFileReader(filename));
					}
					wps.Add(new WavePlayer(filename));
				}
			}
		}

		public static IEnumerable<Pitch> EnumeratePitches()
		{
			foreach (Pitch pitch in Enum.GetValues(typeof(Pitch))) yield return pitch;
		}

		public static string GetWaveFilename(Pitch pitch) => waveFileNames[(int)pitch];

		public static WaveFileReader GetWaveFileReader(Pitch pitch, WaveFormEquation waveForm)
		{
			string filename = GetWaveFilename(pitch);
			int index = waveFileNames.IndexOf(filename);
			var fileReader = GetFileReaderByWaveForm(waveForm);
			return fileReader[index];
		}

		public static WavePlayer GetWavePlayer(Pitch pitch, WaveFormEquation waveForm)
		{
			string filename = GetWaveFilename(pitch);
			int index = waveFileNames.IndexOf(filename);
			var wavePlayer = GetPlayerByWaveForm(waveForm);
			return wavePlayer[index];
		}

		public static Pitch ShiftPitchBySemitones(Pitch pitch, int semitones)
		{
			int oldIndex = (int)pitch;
			int newIndex = oldIndex + semitones;
			if (newIndex < 1 || newIndex >= Enum.GetNames(typeof(Pitch)).Length)
				throw new ApplicationException("Invalid number of semitones");
			else
				return (Pitch)newIndex;
		}

		private static List<WaveFileReader> GetFileReaderByWaveForm(WaveFormEquation waveForm)
		{
			if (waveForm == WaveForms.SineWave)
				return SineWaveFileReaders;
			else if (waveForm == WaveForms.SquareWave)
				return SquareWaveFileReaders;
			else if (waveForm == WaveForms.SawtoothWave)
				return SawtoothWaveFileReaders;
			else
				throw new ApplicationException("Unknow wave form");
		}

		private static List<WavePlayer> GetPlayerByWaveForm(WaveFormEquation waveForm)
		{
			if (waveForm == WaveForms.SineWave)
				return SineWavePlayers;
			else if (waveForm == WaveForms.SquareWave)
				return SquareWavePlayers;
			else if (waveForm == WaveForms.SawtoothWave)
				return SawtoothWavePlayers;
			else
				throw new ApplicationException((waveForm == null).ToString());
		}
	}
}