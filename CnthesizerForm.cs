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
			switch (e.KeyCode)
			{
				case Keys.A:
					{
						if (!currentlyPlayed[(int)Frequency.C0])
						{
							mixer.AddInputStream(WavePlayers.C0.Channel);
							currentlyPlayed[(int)Frequency.C0] = true;
						}
						break;
					}
				case Keys.S:
					{
						if (!currentlyPlayed[(int)Frequency.D])
						{
							mixer.AddInputStream(WavePlayers.D.Channel);
							currentlyPlayed[(int)Frequency.D] = true;
						}
						break;
					}
				case Keys.D:
					{
						if (!currentlyPlayed[(int)Frequency.E])
						{
							mixer.AddInputStream(WavePlayers.E.Channel);
							currentlyPlayed[(int)Frequency.E] = true;
						}
						break;
					}
				case Keys.F:
					{
						if (!currentlyPlayed[(int)Frequency.F])
						{
							mixer.AddInputStream(WavePlayers.F.Channel);
							currentlyPlayed[(int)Frequency.F] = true;
						}
						break;
					}
				case Keys.G:
					{
						if (!currentlyPlayed[(int)Frequency.G])
						{
							mixer.AddInputStream(WavePlayers.G.Channel);
							currentlyPlayed[(int)Frequency.G] = true;
						}
						break;
					}
				case Keys.H:
					{
						if (!currentlyPlayed[(int)Frequency.A])
						{
							mixer.AddInputStream(WavePlayers.A.Channel);
							currentlyPlayed[(int)Frequency.A] = true;
						}
						break;
					}
				case Keys.J:
					{
						if (!currentlyPlayed[(int)Frequency.B])
						{
							mixer.AddInputStream(WavePlayers.B.Channel);
							currentlyPlayed[(int)Frequency.B] = true;
						}
						break;
					}
				case Keys.K:
					{
						if (!currentlyPlayed[(int)Frequency.C1])
						{
							mixer.AddInputStream(WavePlayers.C1.Channel);
							currentlyPlayed[(int)Frequency.C1] = true;
						}
						break;
					}
				default:
					{
						if (!currentlyPlayed[(int)Frequency.A])
						{
							mixer.AddInputStream(WavePlayers.A.Channel);
							currentlyPlayed[(int)Frequency.A] = true;
						}
						break;
					}
			}

		}

		private void CnthesizerForm_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.A:
					{
						mixer.RemoveInputStream(WavePlayers.C0.Channel);
						currentlyPlayed[(int)Frequency.C0] = false;
						break;
					}
				case Keys.S:
					{
						mixer.RemoveInputStream(WavePlayers.D.Channel);
						currentlyPlayed[(int)Frequency.D] = false;
						break;
					}
				case Keys.D:
					{
						mixer.RemoveInputStream(WavePlayers.E.Channel);
						currentlyPlayed[(int)Frequency.E] = false;
						break;
					}
				case Keys.F:
					{
						mixer.RemoveInputStream(WavePlayers.F.Channel);
						currentlyPlayed[(int)Frequency.F] = false;
						break;
					}
				case Keys.G:
					{
						mixer.RemoveInputStream(WavePlayers.G.Channel);
						currentlyPlayed[(int)Frequency.G] = false;
						break;
					}
				case Keys.H:
					{
						mixer.RemoveInputStream(WavePlayers.A.Channel);
						currentlyPlayed[(int)Frequency.A] = false;
						break;
					}
				case Keys.J:
					{
						mixer.RemoveInputStream(WavePlayers.B.Channel);
						currentlyPlayed[(int)Frequency.B] = false;
						break;
					}
				case Keys.K:
					{
						mixer.RemoveInputStream(WavePlayers.C1.Channel);
						currentlyPlayed[(int)Frequency.C1] = false;
						break;
					}
				default:
					{
						mixer.RemoveInputStream(WavePlayers.A.Channel);
						currentlyPlayed[(int)Frequency.A] = false;
						break;
					}
			}
		}

		private void CnthesizerForm_Load(object sender, EventArgs e)
		{
			currentlyPlayed = new bool[Enum.GetNames(typeof(Frequency)).Length];
			foreach (Frequency frequency in Enum.GetValues(typeof(Frequency)))
			{
				currentlyPlayed[(int)frequency] = false;
			}

			mixer = new MixingWaveProvider32();
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
