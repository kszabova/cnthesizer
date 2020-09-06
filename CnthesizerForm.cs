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
		//private WaveMixerStream32 mixer;
		private MixingWaveProvider32 mixer;
		private DirectSoundOut output;

		private bool[] currentlyPlayed;

		private WavePlayer A = new WavePlayer("a.wav");
		private WavePlayer C = new WavePlayer("c0.wav");

		public CnthesizerForm()
		{
			InitializeComponent();
		}

		private void CnthesizerForm_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.A:
					{
						//WaveFileReaders.A.Position = 0;
						//WaveChannels.A.Position = 0;
						//if (!currentlyPlayed[(int)Frequency.C0])
						//{
						//	mixer.AddInputStream(WaveChannels.C0);
						//	currentlyPlayed[(int)Frequency.C0] = true;
						//}
						//mixer.AddInputStream(A.Channel);
						if (!currentlyPlayed[0])
						{
							mixer.AddInputStream(A.Channel);
							currentlyPlayed[0] = true;
						}
						break;
					}
				case Keys.S:
					{
						//if (!currentlyPlayed[(int)Frequency.D])
						//{
						//	mixer.AddInputStream(WaveChannels.D);
						//	currentlyPlayed[(int)Frequency.D] = true;
						//}
						//mixer.AddInputStream(C.Channel);
						if (!currentlyPlayed[1])
						{
							mixer.AddInputStream(C.Channel);
							currentlyPlayed[1] = true;
						}
						break;
					}
				case Keys.D:
					{
						WaveFileReaders.E.Position = 0;
						WaveChannels.E.Position = 0;
						mixer.AddInputStream(WaveChannels.E);
						break;
					}
				case Keys.F:
					{
						WaveFileReaders.F.Position = 0;
						WaveChannels.F.Position = 0;
						mixer.AddInputStream(WaveChannels.F);
						break;
					}
				case Keys.G:
					{
						WaveFileReaders.G.Position = 0;
						WaveChannels.G.Position = 0;
						mixer.AddInputStream(WaveChannels.G);
						break;
					}
				case Keys.H:
					{
						WaveFileReaders.A.Position = 0;
						WaveChannels.A.Position = 0;
						mixer.AddInputStream(WaveChannels.A);
						break;
					}
				case Keys.J:
					{
						WaveFileReaders.B.Position = 0;
						WaveChannels.B.Position = 0;
						mixer.AddInputStream(WaveChannels.B);
						break;
					}
				case Keys.K:
					{
						WaveFileReaders.C1.Position = 0;
						WaveChannels.C1.Position = 0;
						mixer.AddInputStream(WaveChannels.C1);
						break;
					}
				default:
					{
						WaveFileReaders.A.Position = 0;
						WaveChannels.A.Position = 0;
						mixer.AddInputStream(WaveChannels.A);
						break;
					}
			}
			//if (mixer.Position >= mixer.Length - 1)
			//	mixer.Position = 0;
			//output.Play();

		}

		private void CnthesizerForm_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.A:
					{
						mixer.RemoveInputStream(A.Channel);
						currentlyPlayed[0] = false;
						//currentlyPlayed[(int)Frequency.C0] = false;
						//mixer.RemoveInputStream(WaveChannels.C0);
						break;
					}
				case Keys.S:
					{
						mixer.RemoveInputStream(C.Channel);
						currentlyPlayed[1] = false;
						//currentlyPlayed[(int)Frequency.D] = false;
						//mixer.RemoveInputStream(WaveChannels.D);
						break;
					}
				case Keys.D:
					{
						mixer.RemoveInputStream(WaveChannels.E);
						break;
					}
				case Keys.F:
					{
						mixer.RemoveInputStream(WaveChannels.F);
						break;
					}
				case Keys.G:
					{
						mixer.RemoveInputStream(WaveChannels.G);
						break;
					}
				case Keys.H:
					{
						mixer.RemoveInputStream(WaveChannels.A);
						break;
					}
				case Keys.J:
					{
						mixer.RemoveInputStream(WaveChannels.B);
						break;
					}
				case Keys.K:
					{
						mixer.RemoveInputStream(WaveChannels.C1);
						break;
					}
				default:
					{
						mixer.RemoveInputStream(WaveChannels.A);
						break;
					}
				
			}
			//output.Stop();
		}

		private void CnthesizerForm_Load(object sender, EventArgs e)
		{
			//currentlyPlayed = new bool[Enum.GetNames(typeof(Frequency)).Length];
			//foreach (Frequency frequency in Enum.GetValues(typeof(Frequency)))
			//{
			//	currentlyPlayed[(int)frequency] = false;
			//}

			currentlyPlayed = new bool[] { false, false };

			mixer = new MixingWaveProvider32();

			//mixer = new WaveMixerStream32();
			//mixer.AutoStop = false;
			output = new DirectSoundOut();
			output.Init(mixer);
			output.Play();
		}
	}

	public class WavePlayer
	{
		WaveFileReader Reader;
		public WaveChannel32 Channel { get; set; }

		string FileName { get; set; }

		public WavePlayer(string FileName)
		{
			this.FileName = FileName;
			Reader = new WaveFileReader(FileName);
			var loop = new LoopStream(Reader);
			Channel = new WaveChannel32(loop) { PadWithZeroes = false };
		}

		public void Dispose()
		{
			if (Channel != null)
			{
				Channel.Dispose();
				Reader.Dispose();
			}
		}

	}

	public class LoopStream : WaveStream
	{
		WaveStream sourceStream;

		/// <summary>
		/// Creates a new Loop stream
		/// </summary>
		/// <param name="sourceStream">The stream to read from. Note: the Read method of this stream should return 0 when it reaches the end
		/// or else we will not loop to the start again.</param>
		public LoopStream(WaveStream sourceStream)
		{
			this.sourceStream = sourceStream;
			this.EnableLooping = true;
		}

		/// <summary>
		/// Use this to turn looping on or off
		/// </summary>
		public bool EnableLooping { get; set; }

		/// <summary>
		/// Return source stream's wave format
		/// </summary>
		public override WaveFormat WaveFormat
		{
			get { return sourceStream.WaveFormat; }
		}

		/// <summary>
		/// LoopStream simply returns
		/// </summary>
		public override long Length
		{
			get { return sourceStream.Length; }
		}

		/// <summary>
		/// LoopStream simply passes on positioning to source stream
		/// </summary>
		public override long Position
		{
			get { return sourceStream.Position; }
			set { sourceStream.Position = value; }
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int totalBytesRead = 0;

			while (totalBytesRead < count)
			{
				int bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
				if (bytesRead == 0)
				{
					if (sourceStream.Position == 0 || !EnableLooping)
					{
						// something wrong with the source stream
						break;
					}
					// loop
					sourceStream.Position = 0;
				}
				totalBytesRead += bytesRead;
			}
			return totalBytesRead;
		}
	}
}
