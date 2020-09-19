using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnthesizer
{
	public enum Pitch
	{
		Empty, C0, D, E, F, G, A, B, C1
	}

	public class Frequency
	{
		public static readonly float Empty = 0f;
		public static readonly float C0 = 261.36f;
		public static readonly float D = 293.66f;
		public static readonly float E = 329.63f;
		public static readonly float F = 349.23f;
		public static readonly float G = 392f;
		public static readonly float A = 440f;
		public static readonly float B = 493.88f;
		public static readonly float C1 = 523.25f;

		public static float[] Freqs = { Empty, C0, D, E, F, G, A, B, C1 };
	}
}
