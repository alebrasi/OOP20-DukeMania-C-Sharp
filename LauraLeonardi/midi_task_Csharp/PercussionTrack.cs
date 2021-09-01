using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midi_task_Csharp
{
	public class PercussionTrack : ParsedTrack
	{
		public PercussionTrack(List<AbstractNote> notes, int channel) : base(notes, channel) { }
	}
}
