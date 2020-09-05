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

namespace Cnthesizer
{
	public partial class CnthesizerForm : Form
	{
		private const int SAMPLE_RATE = 44100;
		private const short BITS_PER_SAMPLE = 16;

		private NAudio.Wave.WaveFileReader wave;
		private NAudio.Wave.DirectSoundOut output;

		public CnthesizerForm()
		{
			InitializeComponent();
		}

		private void CnthesizerForm_KeyDown(object sender, KeyEventArgs e)
		{
			wave = new NAudio.Wave.WaveFileReader("output.wav");
			output = new NAudio.Wave.DirectSoundOut();
			output.Init(new NAudio.Wave.WaveChannel32(wave));
			output.Play();
			//byte[] wave = Wave.A;
			//switch (e.KeyCode)
			//{
			//	case Keys.A: { wave = Wave.Waves[0]; break; }
			//}

			//short[] wave = new short[SAMPLE_RATE];
			//byte[] binaryWave = new byte[SAMPLE_RATE * sizeof(short)];
			//float frequency = 440f;

			//for (int i = 0; i<SAMPLE_RATE; ++i)
			//{
			//	wave[i] = Convert.ToInt16(short.MaxValue * Math.Sin(((Math.PI * 2 * frequency) / SAMPLE_RATE) * i));
			//}
			//Buffer.BlockCopy(wave, 0, binaryWave, 0, wave.Length * sizeof(short));

			//using (MemoryStream memoryStream = new MemoryStream())
			//using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
			//{
			//	short blockAlign = BITS_PER_SAMPLE / 8;
			//	int subchunkTwoSize = SAMPLE_RATE * blockAlign;
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
			//	memoryStream.Position = 0;
			//	soundPlayer.Stream = memoryStream;
			//	soundPlayer.Load();
			//	soundPlayer.Play();
			//	memoryStream.Seek(0, SeekOrigin.Begin);
			//	FileStream fs = File.Create("output.wav");
			//	byte[] buf = new byte[65536];
			//	int len = 0;
			//	while ((len = memoryStream.Read(buf, 0, 65536)) > 0)
			//	{
			//		fs.Write(buf, 0, len);
			//	}
			//	fs.Close();
			//}

			//soundPlayer.SoundLocation = "output.wav";
			//soundPlayer.Play();
		}
	}
}
