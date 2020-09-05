using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio.Wave;

namespace Cnthesizer
{
	static class WaveFileReaders
	{
		public static readonly WaveFileReader C0 = new WaveFileReader("c0.wav");
		public static readonly WaveFileReader D = new WaveFileReader("d.wav");
		public static readonly WaveFileReader E = new WaveFileReader("e.wav");
		public static readonly WaveFileReader F = new WaveFileReader("f.wav");
		public static readonly WaveFileReader G = new WaveFileReader("g.wav");
		public static readonly WaveFileReader A = new WaveFileReader("a.wav");
		public static readonly WaveFileReader B = new WaveFileReader("b.wav");
		public static readonly WaveFileReader C1 = new WaveFileReader("c1.wav");
	}
}
