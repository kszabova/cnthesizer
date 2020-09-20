using System;
using System.Windows.Forms;

namespace Cnthesizer
{
	partial class SaveRecordingForm : Form
	{
		private IRecorder recorder;

		public SaveRecordingForm(IRecorder recorder)
		{
			this.recorder = recorder;
			InitializeComponent();
		}

		private void filenameTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Return) SaveFilename();
		}

		private void SaveFilename()
		{
			string filename = filenameTextBox.Text;
			if (filename.Length > 0) recorder.Filename = filename;
			Close();
		}

		private void saveFilenameButton_Click(object sender, EventArgs e) => SaveFilename();
	}
}