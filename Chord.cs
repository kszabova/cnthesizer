using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnthesizer
{
	public enum ChordName
	{
		Ilow, ii, iii, IV, V, vi, vii, Ihigh
	}

	class Chord
	{
		private readonly Pitch scale;
		private readonly ChordName chordName;
		private Pitch baseFirst;
		private Pitch baseSecond;
		private Pitch baseThird;

		public Chord(Pitch scale, ChordName chordName)
		{
			this.scale = scale;
			this.chordName = chordName;
			GetBaseChord();
		}

		public void GetBaseChord()
		{
			switch (chordName)
			{
				case ChordName.Ilow:
					{
						baseFirst = Pitch.C0;
						baseSecond = Pitch.E;
						baseThird = Pitch.G;
						break;
					}
				case ChordName.ii:
					{
						baseFirst = Pitch.D;
						baseSecond = Pitch.F;
						baseThird = Pitch.A;
						break;
					}
				case ChordName.iii:
					{
						baseFirst = Pitch.E;
						baseSecond = Pitch.G;
						baseThird = Pitch.B;
						break;
					}
				case ChordName.IV:
					{
						baseFirst = Pitch.F;
						baseSecond = Pitch.A;
						baseThird = Pitch.C1;
						break;
					}
				case ChordName.V:
					{
						baseFirst = Pitch.G;
						baseSecond = Pitch.B;
						baseThird = Pitch.D1;
						break;
					}
				case ChordName.vi:
					{
						baseFirst = Pitch.A;
						baseSecond = Pitch.C1;
						baseThird = Pitch.E1;
						break;
					}
				case ChordName.vii:
					{
						baseFirst = Pitch.B;
						baseSecond = Pitch.D1;
						baseThird = Pitch.F1;
						break;
					}
				case ChordName.Ihigh:
					{
						baseFirst = Pitch.C1;
						baseSecond = Pitch.E1;
						baseThird = Pitch.G1;
						break;
					}	
			}
		}

		public void GetChordPitch()
		{

		}
	}
}
