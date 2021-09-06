using System.Collections.Generic;

namespace midi_task_Csharp
{
	public class PercussionTrack : ParsedTrack
	{
		public PercussionTrack(List<AbstractNote> notes, int channel) : base(notes, channel) { }
	}
}
