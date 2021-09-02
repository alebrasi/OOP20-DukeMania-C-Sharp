using System.Collections.Generic;

namespace midi_task_Csharp
{
	public class Song
	{
		public string Title { get; }
		public double Duration { get; }
		public List<ParsedTrack> Tracks { get; }
		public double Bpm { get; }
		///this is the constructor
		public Song(string title, double duration, List<ParsedTrack> tracks, double bpm)
		{
			Title = title;
			Duration = duration;
			Bpm = bpm;
			Tracks = tracks;
		}


	}
}