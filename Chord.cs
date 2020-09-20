using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnthesizer
{
	public enum ChordName
	{
		ilow, ii, iii, iv, v, vi, vii, ihigh, None
	}

	public class Scale
	{
		public bool Major;
		public Pitch Base;
		public Scale(bool major, Pitch baseTone)
			=> (Major, Base) = (major, baseTone);
	}

	public class Chord
	{
		struct ChordShiftFromBase
		{
			public int first, second, third;
			public ChordShiftFromBase(int first, int second, int third)
				=> (this.first, this.second, this.third) = (first, second, third);
		}

		private Dictionary<ChordName, ChordShiftFromBase> MajChordShifts = new Dictionary<ChordName, ChordShiftFromBase>
		{
			{ChordName.ilow, new ChordShiftFromBase(0, 4, 7) },
			{ChordName.ii, new ChordShiftFromBase(2, 5, 9) },
			{ChordName.iii, new ChordShiftFromBase(4, 7, 11) },
			{ChordName.iv, new ChordShiftFromBase(5, 9, 12) },
			{ChordName.v, new ChordShiftFromBase(7, 11, 14) },
			{ChordName.vi, new ChordShiftFromBase(9, 12, 16) },
			{ChordName.vii, new ChordShiftFromBase(11, 14, 17) },
			{ChordName.ihigh, new ChordShiftFromBase(12, 16, 19) }
		};

		private Dictionary<ChordName, ChordShiftFromBase> MinChordShifts = new Dictionary<ChordName, ChordShiftFromBase>
		{
			{ChordName.ilow, new ChordShiftFromBase(0, 3, 7) },
			{ChordName.ii, new ChordShiftFromBase(2, 5, 8) },
			{ChordName.iii, new ChordShiftFromBase(3, 7, 10) },
			{ChordName.iv, new ChordShiftFromBase(5, 8, 12) },
			{ChordName.v, new ChordShiftFromBase(7, 10, 14) },
			{ChordName.vi, new ChordShiftFromBase(8, 12, 15) },
			{ChordName.vii, new ChordShiftFromBase(10, 14, 17) },
			{ChordName.ihigh, new ChordShiftFromBase(12, 15, 19) }
		};

		public List<Pitch> Tones { get; }
		private readonly Scale scale;
		private readonly ChordName chordName;

		public Chord(Scale scale, ChordName chordName)
		{
			this.scale = scale;
			this.chordName = chordName;
			Tones = GetChord();
		}

		public List<Pitch> GetChord()
		{
			if (chordName == ChordName.None) return new List<Pitch> { Pitch.Empty };

			Dictionary<ChordName, ChordShiftFromBase> chordShifts = scale.Major ? MajChordShifts : MinChordShifts;

			List<Pitch> chord = new List<Pitch> { };
			chord.Add(PitchSelector.ShiftPitchBySemitones(scale.Base, chordShifts[chordName].first));
			chord.Add(PitchSelector.ShiftPitchBySemitones(scale.Base, chordShifts[chordName].second));
			chord.Add(PitchSelector.ShiftPitchBySemitones(scale.Base, chordShifts[chordName].third));
			return chord;
		}
	}
}
