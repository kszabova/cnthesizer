using Cnthesizer;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CnthesizerTests
{
	public class ChordTests
	{
		[Fact] 
		public void GetChord_iMajScale1()
		{
			Chord chord = new Chord(new Scale(true, Pitch.C4), ChordName.ilow);
			List<Pitch> actual = chord.GetChord();
			List<Pitch> expected = new List<Pitch> { Pitch.C4, Pitch.E4, Pitch.G4 };

			Assert.Equal(expected, actual);
		}

		[Fact] 
		public void GetChord_iMajScale2()
		{
			Chord chord = new Chord(new Scale(true, Pitch.Fm4), ChordName.ilow);
			List<Pitch> actual = chord.GetChord();
			List<Pitch> expected = new List<Pitch> { Pitch.Fm4, Pitch.Am4, Pitch.Cm5 };

			Assert.Equal(expected, actual);
		}

		[Fact] 
		public void GetChord_vMajScale1()
		{
			Chord chord = new Chord(new Scale(true, Pitch.C4), ChordName.v);
			List<Pitch> actual = chord.GetChord();
			List<Pitch> expected = new List<Pitch> { Pitch.G4, Pitch.B4, Pitch.D5 };

			Assert.Equal(expected, actual);
		}

		[Fact] 
		public void GetChord_vMajScale2()
		{
			Chord chord = new Chord(new Scale(true, Pitch.Fm4), ChordName.v);
			List<Pitch> actual = chord.GetChord();
			List<Pitch> expected = new List<Pitch> { Pitch.Cm5, Pitch.F5, Pitch.Gm5 };

			Assert.Equal(expected, actual);
		}

		[Fact] 
		public void GetChord_iMinScale1()
		{
			Chord chord = new Chord(new Scale(false, Pitch.A4), ChordName.ilow);
			List<Pitch> actual = chord.GetChord();
			List<Pitch> expected = new List<Pitch> { Pitch.A4, Pitch.C5, Pitch.E5 };

			Assert.Equal(expected, actual);
		}

		[Fact] 
		public void GetChord_iMinScale2()
		{
			Chord chord = new Chord(new Scale(false, Pitch.Fm4), ChordName.ilow);
			List<Pitch> actual = chord.GetChord();
			List<Pitch> expected = new List<Pitch> { Pitch.Fm4, Pitch.A4, Pitch.Cm5 };

			Assert.Equal(expected, actual);
		}

		[Fact] 
		public void GetChord_vMinScale1()
		{
			Chord chord = new Chord(new Scale(false, Pitch.A4), ChordName.v);
			List<Pitch> actual = chord.GetChord();
			List<Pitch> expected = new List<Pitch> { Pitch.E5, Pitch.G5, Pitch.B5 };

			Assert.Equal(expected, actual);
		}

		[Fact] 
		public void GetChord_vMinScale2()
		{
			Chord chord = new Chord(new Scale(false, Pitch.Fm4), ChordName.v);
			List<Pitch> actual = chord.GetChord();
			List<Pitch> expected = new List<Pitch> { Pitch.Cm5, Pitch.E5, Pitch.Gm5 };

			Assert.Equal(expected, actual);
		}
	}
}
