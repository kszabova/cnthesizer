using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnthesizer
{
	class Recording
	{
		private Session session { get; }
		private List<Epoch> epochs { get; }
		private bool recording = false;

		private Recording(Session session)
		{
			this.session = session;
			epochs = new List<Epoch> { };
		}

		public static Recording CreateRecording(Session session) => new Recording(session);

		public void StartRecording() => recording = true;

		public void StopRecording() => recording = false;

		public void AddNewEpoch(Epoch epoch) => epochs.Add(epoch);

		private void SaveRecording()
		{
			throw new NotImplementedException();
		}

		private void Playback()
		{
			throw new NotImplementedException();
		}
	}
}
