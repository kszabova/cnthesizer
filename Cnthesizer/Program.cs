using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

[assembly: InternalsVisibleTo("CnthesizerTests")]

namespace Cnthesizer
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new CnthesizerForm());
		}
	}
}