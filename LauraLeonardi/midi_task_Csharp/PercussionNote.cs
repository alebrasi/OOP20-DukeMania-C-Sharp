using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midi_task_Csharp
{
	public class PercussionNote : Note
	{
        private const int OFFSET = 35;
        public Percussion Instrument { get; }

		///this is the constructor.
		public PercussionNote(long duration, long startTime, int identifier) : base(duration, startTime, identifier)
		{
			Instrument = (Percussion)Enum.Parse(typeof(Percussion), Convert.ToString(identifier - OFFSET));
		}
        

        ///this method returns the Percussion associated to the note.
        public Percussion GetItem()
            {
                return Instrument;
            }
    }
}
