using System.Collections.Generic;

namespace midi_task_Csharp
{
	public interface IAbstractFactory
	{
		///this method create a new note.
		AbstractNote CreateNote(long duration, long startTime, int identifier);

		///this method create a new a track.
		ParsedTrack CreateTrack(InstrumentType instrument, List<AbstractNote> notes, int channel);
    }
}
