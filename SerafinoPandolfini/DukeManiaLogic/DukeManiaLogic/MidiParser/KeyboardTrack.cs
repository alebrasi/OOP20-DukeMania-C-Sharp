using midi_task_Csharp;
using System.Collections.Generic;
using System.Linq;

namespace DukeManiaLogic
{
	public class KeyboardTrack : ParsedTrack
	{
		public InstrumentType Instrument { get; set; }
		public Dictionary<int, long> NotesMaxDuration { get; }

		public KeyboardTrack(InstrumentType instrument, List<AbstractNote> notes, int channel) : base(notes, channel)
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