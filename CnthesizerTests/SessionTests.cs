using System.Collections.Generic;
using Cnthesizer;
using Xunit;

namespace CnthesizerTests
{
	public class SessionTests
	{
		[Fact]
		public void GetFrequenciesPlaying_NothingPlaying()
		{
			Session session = Session.CreateSession();
			List<Pitch> actual = session.GetFrequenciesPlaying();
			List<Pitch> expected = new List<Pitch> { Pitch.Empty };

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetFrequenciesPlaying_OnePlaying()
		{
			Session session = Session.CreateSession();
			session.StartPlayingPitch(Pitch.A3);
			List<Pitch> actual = session.GetFrequenciesPlaying();
			List<Pitch> expected = new List<Pitch> { Pitch.Empty, Pitch.A3 };

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetFrequenciesPlaying_TwoPlaying()
		{
			Session session = Session.CreateSession();
			session.StartPlayingPitch(Pitch.A3);
			session.StartPlayingPitch(Pitch.A4);
			List<Pitch> actual = session.GetFrequenciesPlaying();
			List<Pitch> expected = new List<Pitch> { Pitch.Empty, Pitch.A3, Pitch.A4 };

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetFrequenciesPlaying_OnePlayingThenDeleted()
		{
			Session session = Session.CreateSession();
			session.StartPlayingPitch(Pitch.A3);
			session.StopPlayingPitch(Pitch.A3);
			List<Pitch> actual = session.GetFrequenciesPlaying();
			List<Pitch> expected = new List<Pitch> { Pitch.Empty };

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetFrequenciesPlaying_TwoPlayingOneDeleted()
		{
			Session session = Session.CreateSession();
			session.StartPlayingPitch(Pitch.A3);
			session.StartPlayingPitch(Pitch.A4);
			session.StopPlayingPitch(Pitch.A3);
			List<Pitch> actual = session.GetFrequenciesPlaying();
			List<Pitch> expected = new List<Pitch> { Pitch.Empty, Pitch.A4 };

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void GetFrequenciesPlaying_AddSameAsAlreadyPlaying()
		{
			Session session = Session.CreateSession();
			session.StartPlayingPitch(Pitch.A3);
			session.StartPlayingPitch(Pitch.A3);
			List<Pitch> actual = session.GetFrequenciesPlaying();
			List<Pitch> expected = new List<Pitch> { Pitch.Empty, Pitch.A3 };

			Assert.Equal(expected, actual);
		}
	}
}