namespace midi_task_Csharp
{
	public abstract class AbstractNote
	{
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

		/// this method depends on the type of the note and can return a percussion (for PercussonNote)
		/// or an integer representing the note identifier (for Note).
		public abstract object GetItem();
    }
}
