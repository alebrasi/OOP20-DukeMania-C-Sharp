using System;

namespace midi_task_Csharp
{
	public class Note : AbstractNote
	{
		private const int NUM_A4 = 69;
		private const int NUM_NOTE = 12;
		private const double FREQ_A4 = 440;
		private const int DEFAULT_DURATION = 0;
		public double Frequency { get; }

		public Note(long duration, long startTime, int identifier) : base(duration, startTime, identifier)
		{
			Frequency = (double)Math.Pow(2, (double)(identifier - NUM_A4) / NUM_NOTE) * FREQ_A4;
		}

		///this method returns an integer representing the note identifier.
		public override object GetItem()
		{
			return Identifier;
		}
	}
}