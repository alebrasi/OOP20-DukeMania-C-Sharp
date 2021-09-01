using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midi_task_Csharp
{
	class PercussionFactory : IAbstractFactory
	{
		private static PercussionFactory instance;
		private const int MIN = 35;
		private const int MAX = 81;

		///this is a private constructor.
		private PercussionFactory() { }

		///this method returns an instance of PercussionFactoryImpl, making sure that only one is istanciated.
		public static PercussionFactory GetInstance()
        {
			if (instance == null)
			{
				instance = new PercussionFactory();
			}
			return instance;
		}

		public AbstractNote CreateNote(long duration, long startTime, int identifier)
		{
			return identifier >= MIN && identifier <= MAX
				? new PercussionNote(duration, startTime, identifier)
				: throw new InvalidNoteException();
		}

		public ParsedTrack CreateTrack(InstrumentType instrument, List<AbstractNote> notes, int channel)
		{
			return new PercussionTrack(notes, channel);
		}
	}
}
