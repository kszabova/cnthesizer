using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnthesizer
{
	static class WaveFileReaders
	{
		public static readonly NAudio.Wave.WaveFileReader C0 = new NAudio.Wave.WaveFileReader("c0.wav");
		public static readonly NAudio.Wave.WaveFileReader D = new NAudio.Wave.WaveFileReader("d.wav");
		public static readonly NAudio.Wave.WaveFileReader E = new NAudio.Wave.WaveFileReader("e.wav");
		public static readonly NAudio.Wave.WaveFileReader F = new NAudio.Wave.WaveFileReader("f.wav");
		public static readonly NAudio.Wave.WaveFileReader G = new NAudio.Wave.WaveFileReader("g.wav");
		public static readonly NAudio.Wave.WaveFileReader A = new NAudio.Wave.WaveFileReader("a.wav");
		public static readonly NAudio.Wave.WaveFileReader B = new NAudio.Wave.WaveFileReader("b.wav");
		public static readonly NAudio.Wave.WaveFileReader C1 = new NAudio.Wave.WaveFileReader("c1.wav");
	}
}
