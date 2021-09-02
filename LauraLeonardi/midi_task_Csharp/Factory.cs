using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midi_task_Csharp
{
	public class Factory : IAbstractFactory
	{
		private static Factory instance;

		private Factory() { }

		public static Factory GetInstance()
		{
			if (instance == null)
			{
				instance = new Factory();
			}
			return instance;
		}
		public AbstractNote CreateNote(long duration, long startTime, int identifier)
		{
			return new Note(duration, startTime, identifier);
		}

		public ParsedTrack CreateTrack(InstrumentType instrument, List<AbstractNote> notes, int channel)
		{
			return new KeyboardTrack(instrument, notes, channel);
		}
	}
}
