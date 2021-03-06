﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cnthesizer
{
	/// <summary>
	/// Contains methods to work with sound waves.
	/// </summary>
	public static class Wave
	{
		/// <summary>
		/// Converts an array of shorts to a binary array
		/// </summary>
		/// <param name="wave">Represents the sound wave</param>
		/// <returns>Array of bytes representing the same wave</returns>
		public static byte[] ConvertShortWaveToBytes(short[] wave)
		{
			byte[] binaryWave = new byte[wave.Length * sizeof(short)];
			Buffer.BlockCopy(wave, 0, binaryWave, 0, wave.Length * sizeof(short));
			return binaryWave;
		}

		/// <summary>
		/// Creates a sound wave of constant zero of specified length
		/// </summary>
		/// <param name="length">Length of the wave</param>
		/// <returns>Sound wave representing silence</returns>
		public static byte[] CreateEmptyWave(int length)
		{
			short[] wave = new short[length];
			byte[] binaryWave = new byte[length * sizeof(short)];

			for (int i = 0; i < length; ++i)
			{
				wave[i] = 0;
			}
			Buffer.BlockCopy(wave, 0, binaryWave, 0, wave.Length * sizeof(short));
			return binaryWave;
		}

		/// <summary>
		/// Writes a .wav file containing one pitch.
		/// </summary>
		/// <param name="filename">Filename</param>
		/// <param name="pitch">Pitch</param>
		/// <param name="waveForm">Wave transformation</param>
		/// <param name="sampleRate">Sample rate</param>
		public static void CreatePitchWaveFile(string filename, Pitch pitch, WaveFormEquation waveForm, int sampleRate)
		{
			short[] shortWave = SampleWaveForm(pitch, sampleRate, Shifts.Unison, waveForm, sampleRate);
			byte[] binaryWave = ConvertShortWaveToBytes(shortWave);

			using (FileStream fs = File.Create(filename))
			{
				WriteToStream(fs, binaryWave, sampleRate, sampleRate, 16, 1);
			}
		}

		/// <summary>
		/// Creates the sound wave of one beat with specified bpm
		/// </summary>
		/// <param name="bpm">Beats per minute</param>
		/// <returns></returns>
		public static short[] GenerateBeatWave(int bpm)
		{
			// 60 / bpm gives us the period of beat envelope
			// data loss from casting to int will be negligible
			int length = (int)(60f / bpm * Config.SAMPLE_RATE);

			// the beat is generated by mixing a sawtooth and a square wave
			short[] sawtooth = SampleWaveForm(Pitch.A3, length, x => x / 5, WaveForms.SawtoothWave, Config.SAMPLE_RATE);
			short[] square = SampleWaveForm(Pitch.A3, length, x => x / 7, WaveForms.SquareWave, Config.SAMPLE_RATE);
			short[] toneWave = Mixing.MixListOfWaves(new List<short[]> { sawtooth, square });

			// to get the right loudness progression, we multiply the tone wave by an exponential function
			short[] wave = new short[length];
			float frequency = 50;       // determined by trial and error
			for (int i = 0; i < length; ++i)
			{
				double expValue = i < length ? Math.Pow(0.0001, (double)i / length) : 0;
				wave[i] = Convert.ToInt16(expValue * toneWave[i]);
			}
			return wave;
		}

		/// <summary>
		/// Creates wave of given pitch with the right transformation
		/// </summary>
		/// <param name="pitch">Pitch</param>
		/// <param name="length">Length in milliseconds</param>
		/// <param name="shift">Interval shift from base pitch</param>
		/// <param name="waveForm">Wave transformation</param>
		/// <param name="sampleRate">Sample rate</param>
		/// <returns></returns>
		public static short[] SampleWaveForm(Pitch pitch, int length, Shift shift, WaveFormEquation waveForm, int sampleRate)
		{
			double baseFrequency = Frequency.GetFrequency(pitch);
			double frequency = shift(baseFrequency);
			short[] wave = waveForm(frequency, length, sampleRate);
			return wave;
		}

		/// <summary>
		/// Writes wave to stream
		/// </summary>
		/// <param name="stream">Destination stream</param>
		/// <param name="wave">Wave to be written</param>
		/// <param name="samples">Number of samples</param>
		/// <param name="sampleRate">Sample rate</param>
		/// <param name="bitsPerSample">Bits per sample</param>
		/// <param name="channels">Number of channels</param>
		public static void WriteToStream(Stream stream, byte[] wave, int samples, int sampleRate, short bitsPerSample, short channels)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
			{
				short blockAlign = (short)(channels * bitsPerSample / 8);
				int subchunkTwoSize = samples * blockAlign;

				// prepare .wav header
				binaryWriter.Write(new[] { 'R', 'I', 'F', 'F' });                           // 4B ChunkID
				binaryWriter.Write(36 + subchunkTwoSize);                                   // 4B ChunkSize
				binaryWriter.Write(new[] { 'W', 'A', 'V', 'E', 'f', 'm', 't', ' ' });       // 4B Format + 4B Subchunk1ID
				binaryWriter.Write(16);                                                     // 4B Subchunk1Size
				binaryWriter.Write((short)1);                                               // 2B AudioFormat
				binaryWriter.Write((short)channels);                                        // 2B NumChannels
				binaryWriter.Write(sampleRate);                                             // 4B SampleRate
				binaryWriter.Write(sampleRate * blockAlign);                                // 4B ByteRate
				binaryWriter.Write((short)(blockAlign));                                    // 2B BlockAlign
				binaryWriter.Write(bitsPerSample);											// 2B BitsPerSample
				binaryWriter.Write(new[] { 'd', 'a', 't', 'a' });                           // 4B Subchunk2Id
				binaryWriter.Write(subchunkTwoSize);                                        // 4B Subchunk2Size

				// write data to buffer
				binaryWriter.Write(wave);                                                   // xB Data

				// write data to stream
				memoryStream.Seek(0, SeekOrigin.Begin);
				byte[] buf = new byte[65536];
				int len = 0;
				while ((len = memoryStream.Read(buf, 0, 65536)) > 0)
				{
					stream.Write(buf, 0, len);
				}
			}
		}
	}
}