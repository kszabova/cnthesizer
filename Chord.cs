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
						baseFirst = Pitch.C4;
						baseSecond = Pitch.E4;
						baseThird = Pitch.G4;
						break;
					}
				case ChordName.ii:
					{
						baseFirst = Pitch.D4;
						baseSecond = Pitch.F4;
						baseThird = Pitch.A4;
						break;
					}
				case ChordName.iii:
					{
						baseFirst = Pitch.E4;
						baseSecond = Pitch.G4;
						baseThird = Pitch.B4;
						break;
					}
				case ChordName.IV:
					{
						baseFirst = Pitch.F4;
						baseSecond = Pitch.A4;
						baseThird = Pitch.C5;
						break;
					}
				case ChordName.V:
					{
						baseFirst = Pitch.G4;
						baseSecond = Pitch.B4;
						baseThird = Pitch.D5;
						break;
					}
				case ChordName.vi:
					{
						baseFirst = Pitch.A4;
						baseSecond = Pitch.C5;
						baseThird = Pitch.E5;
						break;
					}
				case ChordName.vii:
					{
						baseFirst = Pitch.B4;
						baseSecond = Pitch.D5;
						baseThird = Pitch.F5;
						break;
					}
				case ChordName.Ihigh:
					{
						baseFirst = Pitch.C5;
						baseSecond = Pitch.E5;
						baseThird = Pitch.G5;
						break;
					}	
			}
		}

		public void GetChordPitch()
		{

		}
	}
}
