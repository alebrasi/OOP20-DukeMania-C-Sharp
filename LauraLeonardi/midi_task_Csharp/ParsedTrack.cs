﻿using System.Collections.Generic;

namespace midi_task_Csharp
{
	public abstract class ParsedTrack
	{
		public List<AbstractNote> Notes { get; }
		public int Channel { get; }

		public ParsedTrack(List<AbstractNote> notes, int channel)
		{
			Notes = notes;
			Channel = channel;
		}

		public void DeleteNote(AbstractNote note)
		{
			Notes.Remove(note);
		}

	}
}
