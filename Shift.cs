namespace Cnthesizer
{
	public delegate double Shift(double frequency);

	public static class Shifts
	{
		public static double OctaveUp(double frequency) => frequency * 2;

		public static double MajSeventhUp(double frequency) => frequency / 8 * 15;

		public static double MinSeventhUp(double frequency) => frequency / 9 * 16;

		public static double MajSixthUp(double frequency) => frequency / 3 * 5;

		public static double MinSixthUp(double frequency) => frequency / 5 * 8;

		public static double PerfectFifthUp(double frequency) => frequency / 2 * 3;

		public static double TritoneUp(double frequency) => frequency / 32 * 45;

		public static double PerfectFourthUp(double frequency) => frequency / 3 * 4;

		public static double MajThirdUp(double frequency) => frequency / 4 * 5;

		public static double MinThirdUp(double frequency) => frequency / 5 * 6;

		public static double MajSecondUp(double frequency) => frequency / 8 * 9;

		public static double MinSecondUp(double frequency) => frequency / 15 * 16;

		public static double Unison(double frequency) => frequency;

		public static double MinSecondDown(double frequency) => frequency / 16 * 15;

		public static double MajSecondDown(double frequency) => frequency / 9 * 8;

		public static double MinThirdDown(double frequency) => frequency / 6 * 5;

		public static double MajThirdDown(double frequency) => frequency / 5 * 4;

		public static double PerfectFourthDown(double frequency) => frequency / 4 * 3;

		public static double TritoneDown(double frequency) => frequency / 45 * 32;

		public static double PerfectFifthDown(double frequency) => frequency / 3 * 2;

		public static double MinSixthDown(double frequency) => frequency / 8 * 5;

		public static double MajSixthDown(double frequency) => frequency / 5 * 3;

		public static double MinSeventhDown(double frequency) => frequency / 16 * 9;

		public static double MajSeventhDown(double frequency) => frequency / 15 * 7;

		public static double OctaveDown(double frequency) => frequency / 2;

		public static Shift[] shifts = new Shift[]
		{
			OctaveUp, MajSeventhUp, MinSeventhUp, MajSixthUp, MinSixthUp,
			PerfectFifthUp, TritoneUp, PerfectFourthUp, MajThirdUp, MinThirdUp,
			MajSecondUp, MinSecondUp, Unison, MinSecondDown, MajSecondDown,
			MinThirdDown, MajThirdDown, PerfectFourthDown, TritoneDown, PerfectFifthDown,
			MinSixthDown, MajSixthDown, MinSeventhDown, MajSeventhDown, OctaveDown
		};
	}
}