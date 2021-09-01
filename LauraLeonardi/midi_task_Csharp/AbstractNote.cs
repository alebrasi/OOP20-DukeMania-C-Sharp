using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midi_task_Csharp
{
	public abstract class AbstractNote
	{
		private const int DEFAULT_DURATION = 0;
		public long StartTime { get; }
		public int Identifier { get; }
		public long Duration { get; }

		///  this is a constructor.  
		public AbstractNote(long duration, long startTime, int identifier)
        {
			Duration = duration;
			StartTime = startTime;
			Identifier = identifier;
        }
		public AbstractNote(long startTime, int identifier) : this(DEFAULT_DURATION, startTime, identifier) { }

		/// this method depends on the type of the note and can return a percussion (for PercussonNote)
		/// or an integer representing the note identifier (for Note).
		public abstract object GetItem();
    }
}
