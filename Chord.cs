using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnthesizer
{
	public enum ChordName
	{
		ilowMaj, iiMaj, iiiMaj, ivMaj, vMaj, viMaj, viiMaj, ihighMaj,
		ilowMin, iiMin, iiiMin, ivMin, vMin, viMin, viiMin, ihighMin
	}

	class Chord
	{
		struct ChordShiftFromBase
		{
			public int first, second, third;
			public ChordShiftFromBase(int first, int second, int third)
				=> (this.first, this.second, this.third) = (first, second, third);
		}

		private Dictionary<ChordName, ChordShiftFromBase> chordShifts = new Dictionary<ChordName, ChordShiftFromBase>
		{
			{ChordName.ilowMaj, new ChordShiftFromBase(0, 4, 7) },
			{ChordName.iiMaj, new ChordShiftFromBase(2, 5, 9) },
			{ChordName.iiiMaj, new ChordShiftFromBase(4, 7, 11) },
			{ChordName.ivMaj, new ChordShiftFromBase(5, 9, 12) },
			{ChordName.vMaj, new ChordShiftFromBase(7, 11, 14) },
			{ChordName.viMaj, new ChordShiftFromBase(9, 12, 16) },
			{ChordName.viiMaj, new ChordShiftFromBase(11, 14, 17) },
			{ChordName.ihighMaj, new ChordShiftFromBase(12, 16, 19) },
			{ChordName.ilowMin, new ChordShiftFromBase(0, 3, 7) },
			{ChordName.iiMin, new ChordShiftFromBase(2, 5, 8) },
			{ChordName.iiiMin, new ChordShiftFromBase(3, 7, 10) },
			{ChordName.ivMin, new ChordShiftFromBase(5, 8, 12) },
			{ChordName.vMin, new ChordShiftFromBase(7, 10, 14) },
			{ChordName.viMin, new ChordShiftFromBase(8, 12, 15) },
			{ChordName.viiMin, new ChordShiftFromBase(10, 14, 17) },
			{ChordName.ihighMin, new ChordShiftFromBase(12, 15, 19) }
		};

		public List<Pitch> Tones { get; }
		private readonly Pitch scale;
		private readonly ChordName chordName;

		public Chord(Pitch scale, ChordName chordName)
		{
			this.scale = scale;
			this.chordName = chordName;
			Tones = GetChord();
		}

		public List<Pitch> GetChord()
		{
			List<Pitch> chord = new List<Pitch> { };
			chord.Add(PitchSelector.ShiftPitchBySemitones(scale, chordShifts[chordName].first));
			chord.Add(PitchSelector.ShiftPitchBySemitones(scale, chordShifts[chordName].third));
			chord.Add(PitchSelector.ShiftPitchBySemitones(scale, chordShifts[chordName].third));
			return chord;
		}
	}
}
