using System;
using System.Collections.Generic;
using System.Linq;

namespace midi_task_Csharp
{
	public class KeyboardTrack : ParsedTrack
	{
		public Instrument Instrument { get; }
		public Dictionary<int, long> NotesMaxDuration { get; }

		public KeyboardTrack(Instrument instrument, List<AbstractNote> notes, int channel) : base(notes, channel)
		{
			Instrument = instrument;
			NotesMaxDuration = CalcMaxDuration();
		}

		private Dictionary<int, long> CalcMaxDuration()
		{
			return Notes.GroupBy(n => n.Identifier).Select(n => n.OrderByDescending(d => d.Duration).FirstOrDefault()).ToDictionary(n => n.Identifier, n => n.Duration);
		}
	}
}