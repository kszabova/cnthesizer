using NAudio.Wave;
using System.Windows.Forms;

namespace Cnthesizer
{
	internal static class KeyControls
	{
		public static Pitch GetPitchFromKey(Keys key)
		{
			switch (key)
			{
				case Keys.Q: return Pitch.A3;
				case Keys.D2: return Pitch.Am3;
				case Keys.W: return Pitch.B3;
				case Keys.E: return Pitch.C4;
				case Keys.D4: return Pitch.Cm4;
				case Keys.R: return Pitch.D4;
				case Keys.D5: return Pitch.Dm4;
				case Keys.T: return Pitch.E4;
				case Keys.Y: return Pitch.F4;
				case Keys.D7: return Pitch.Fm4;
				case Keys.U: return Pitch.G4;
				case Keys.D8: return Pitch.Gm4;
				case Keys.I: return Pitch.A4;
				case Keys.D9: return Pitch.Am4;
				case Keys.O: return Pitch.B4;
				case Keys.P: return Pitch.C5;
				case Keys.OemMinus: return Pitch.Cm5;
				case Keys.OemOpenBrackets: return Pitch.D5;
				case Keys.Oemplus: return Pitch.Dm5;
				case Keys.OemCloseBrackets: return Pitch.E5;
				case Keys.Z: return Pitch.F5;
				case Keys.S: return Pitch.Fm5;
				case Keys.X: return Pitch.G5;
				case Keys.D: return Pitch.Gm5;
				case Keys.C: return Pitch.A5;
				case Keys.F: return Pitch.Am5;
				case Keys.V: return Pitch.B5;
				case Keys.B: return Pitch.C6;
				case Keys.H: return Pitch.Cm6;
				case Keys.N: return Pitch.D6;
				case Keys.J: return Pitch.Dm6;
				case Keys.M: return Pitch.E6;
				case Keys.Oemcomma: return Pitch.F6;
				case Keys.L: return Pitch.Fm6;
				case Keys.OemPeriod: return Pitch.G6;
				case Keys.OemSemicolon: return Pitch.Gm6;
				case Keys.OemQuestion: return Pitch.A6;
				default:
					return Pitch.Empty;
			}
		}

		public static WavePlayer GetWavePlayerFromKey(Keys key, WaveFormEquation waveForm)
			=> PitchSelector.GetWavePlayer(GetPitchFromKey(key), waveForm);

		public static WaveFileReader GetWaveFileReaderFromKey(Keys key, WaveFormEquation waveForm)
			=> PitchSelector.GetWaveFileReader(GetPitchFromKey(key), waveForm);
	}
}