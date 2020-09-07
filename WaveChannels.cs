using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio.Wave;

namespace Cnthesizer
{
	static class WaveChannels
	{
		public static readonly WaveChannel32 Empty = new WaveChannel32(WaveFileReaders.Empty);
		public static readonly WaveChannel32 C0 = new WaveChannel32(WaveFileReaders.C0);
		public static readonly WaveChannel32 D = new WaveChannel32(WaveFileReaders.D);
		public static readonly WaveChannel32 E = new WaveChannel32(WaveFileReaders.E);
		public static readonly WaveChannel32 F = new WaveChannel32(WaveFileReaders.F);
		public static readonly WaveChannel32 G = new WaveChannel32(WaveFileReaders.G);
		public static readonly WaveChannel32 A = new WaveChannel32(WaveFileReaders.A);
		public static readonly WaveChannel32 B = new WaveChannel32(WaveFileReaders.B);
		public static readonly WaveChannel32 C1 = new WaveChannel32(WaveFileReaders.C1);

		public static readonly WaveChannel32[] WaveChannelList =
			new WaveChannel32[] { Empty, C0, D, E, F, G, A, B, C1 };
	}
}
