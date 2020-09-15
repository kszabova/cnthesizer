using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnthesizer
{
	class Mixing
	{
		public static short[] MixTwoWaves(short[] a, short[] b)
		{
			short[] shorter = a.Length < b.Length ? a : b;
			short[] longer = a.Length < b.Length ? b : a;

			short[] mixed = new short[longer.Length];
			for (int i = 0; i < shorter.Length; i++)
			{
				mixed[i] = (short)((shorter[i] + longer[i]) / 2);
			}

			for (int i = shorter.Length; i < longer.Length; i++)
			{
				mixed[i] = longer[i];
			}

			return mixed;
		}
	}
}
