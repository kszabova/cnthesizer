using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnthesizer
{
	public delegate float Shift(float frequency);

	public static class Shifts
	{
		public static float OctaveUp(float frequency) => frequency * 2;
		public static float MajSeventhUp(float frequency) => frequency / 8 * 15;
		public static float MinSeventhUp(float frequency) => frequency / 9 * 16;
		public static float MajSixthUp(float frequency) => frequency / 3 * 5;
		public static float MinSixthUp(float frequency) => frequency / 5 * 8;
		public static float PerfectFifthUp(float frequency) => frequency / 2 * 3;
		public static float TritoneUp(float frequency) => frequency / 32 * 45;
		public static float PerfectFourthUp(float frequency) => frequency / 3 * 4;
		public static float MajThirdUp(float frequency) => frequency / 4 * 5;
		public static float MinThirdUp(float frequency) => frequency / 5 * 6;
		public static float MajSecondUp(float frequency) => frequency / 8 * 9;
		public static float MinSecondUp(float frequency) => frequency / 15 * 16;
		public static float Unison(float frequency) => frequency;
		public static float MinSecondDown(float frequency) => frequency / 16 * 15;
		public static float MajSecondDown(float frequency) => frequency / 9 * 8;
		public static float MinThirdDown(float frequency) => frequency / 6 * 5;
		public static float MajThirdDown(float frequency) => frequency / 5 * 4;
		public static float PerfectFourthDown(float frequency) => frequency / 4 * 3;
		public static float TritoneDown(float frequency) => frequency / 45 * 32;
		public static float PerfectFifthDown(float frequency) => frequency / 3 * 2;
		public static float MinSixthDown(float frequency) => frequency / 8 * 5;
		public static float MajSixthDown(float frequency) => frequency / 5 * 3;
		public static float MinSeventhDown(float frequency) => frequency / 9 * 16;
		public static float MajSeventhDown(float frequency) => frequency / 8 * 15;
		public static float OctaveDown(float frequency) => frequency / 2;
	}
}
