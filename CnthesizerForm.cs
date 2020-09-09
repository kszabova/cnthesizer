using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

using NAudio.Wave;

namespace Cnthesizer
{
	public partial class CnthesizerForm : Form
	{
		private MixingWaveProvider32 mixer;
		private DirectSoundOut output;

		private bool[] currentlyPlayed;

		public CnthesizerForm()
		{
			InitializeComponent();
		}

		private void CnthesizerForm_KeyDown(object sender, KeyEventArgs e)
		{
			int snippetIndex = (int)KeyControls.GetFrequencyFromKey(e.KeyCode);
			// we don't want to do anything if a default was returned
			if (snippetIndex == (int)FrequenciesAvailable.Empty) return;		

			if (!currentlyPlayed[snippetIndex])
			{
				WavePlayer inputStream = KeyControls.GetWavePlayerFromKey(e.KeyCode);
				mixer.AddInputStream(inputStream.Channel);
				currentlyPlayed[snippetIndex] = true;
			}
		}

		private void CnthesizerForm_KeyUp(object sender, KeyEventArgs e)
		{
			int snippetIndex = (int)KeyControls.GetFrequencyFromKey(e.KeyCode);
			if (snippetIndex == (int)FrequenciesAvailable.Empty) return;

			WavePlayer inputStream = KeyControls.GetWavePlayerFromKey(e.KeyCode);
			mixer.RemoveInputStream(inputStream.Channel);
			currentlyPlayed[snippetIndex] = false;


		}

		private void CnthesizerForm_Load(object sender, EventArgs e)
		{
			currentlyPlayed = new bool[Enum.GetNames(typeof(FrequenciesAvailable)).Length];
			foreach (FrequenciesAvailable frequency in Enum.GetValues(typeof(FrequenciesAvailable)))
			{
				currentlyPlayed[(int)frequency] = false;
			}

			mixer = new MixingWaveProvider32(new List<WaveChannel32> { WavePlayers.Empty.Channel });
			currentlyPlayed[(int)FrequenciesAvailable.Empty] = true;
			output = new DirectSoundOut();
			output.Init(mixer);
			output.Play();

			byte[] wave = Wave.GenerateBeatWave(180);
			using (FileStream fs = File.Create("beat.wav"))
				Wave.WriteToStream(fs, wave, wave.Length / 2, 44100, 16, 1);

			//int SAMPLE_RATE = 44100;
			//short BITS_PER_SAMPLE = 16;
			//byte[] wave = Wave.GenerateBeatWave(120);
			//using (MemoryStream memoryStream = new MemoryStream())
			//using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
			//{
			//	short blockAlign = (short) (BITS_PER_SAMPLE / 8);
			//	int subchunkTwoSize = SAMPLE_RATE;
			//	binaryWriter.Write(new[] { 'R', 'I', 'F', 'F' });
			//	binaryWriter.Write(36 + subchunkTwoSize);
			//	binaryWriter.Write(new[] { 'W', 'A', 'V', 'E', 'f', 'm', 't', ' ' });
			//	binaryWriter.Write(16);
			//	binaryWriter.Write((short)1);
			//	binaryWriter.Write((short)1);
			//	binaryWriter.Write(SAMPLE_RATE);
			//	binaryWriter.Write(SAMPLE_RATE * blockAlign);
			//	binaryWriter.Write(blockAlign);
			//	binaryWriter.Write(BITS_PER_SAMPLE);
			//	binaryWriter.Write(new[] { 'd', 'a', 't', 'a' });
			//	binaryWriter.Write(subchunkTwoSize);
			//	binaryWriter.Write(wave);
			//	memoryStream.Seek(0, SeekOrigin.Begin);
			//	FileStream fs = File.Create("beat.wav");
			//	byte[] buf = new byte[65536];
			//	int len = 0;
			//	while ((len = memoryStream.Read(buf, 0, 65536)) > 0)
			//	{
			//		fs.Write(buf, 0, len);
			//	}
			//	fs.Close();
			//}
		}

		private void beatButton_Click(object sender, EventArgs e)
		{
			int bpm = bpmSlider.Value;
			byte[] beatWave = Wave.GenerateBeatWave(bpm);
			using (FileStream fs = File.Create("beat.wav"))
				Wave.WriteToStream(fs, beatWave, beatWave.Length / sizeof(short), 44100, 16, 1);
			mixer.AddInputStream(new WaveChannel32(new LoopStream(new WaveFileReader("beat.wav"))) { PadWithZeroes = false });
		}
	}	
}
