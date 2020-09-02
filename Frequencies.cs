using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnthesizer
{
	enum Frequency
	{
		C0, D, E, F, G, A, B, C1
	}

	public static class Frequencies
	{
		public const float C0 = 261.36f;
		public const float D = 293.66f;
		public const float E = 329.63f;
		public const float F = 349.23f;
		public const float G = 392f;
		public const float A = 440f;
		public const float B = 493.88f;
		public const float C1 = 523.25f;

		public static float[] Freqs = { C0, D, E, F, G, A, B, C1 };
	}
}
