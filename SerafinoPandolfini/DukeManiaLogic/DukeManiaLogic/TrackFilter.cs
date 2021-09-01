using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DukeManiaLogic
{
    public class TrackFilter : ITrackFilter 
    {
        public const int MAX_NOTE = 600;
        const int PERCUSSION_CHANNEL = 10;
        const long MIN_DURATION = 125_000;

        public List<KeyboardTrack> ReduceTrack(Song song)
        {
            return song.GetTracks.Where(x => x.GetChannel != PERCUSSION_CHANNEL)
                .Select(x => new KeyboardTrack(x.GetInstrument(), x.GetNotes()
                            .Where(y => y.GetDuration >= MIN_DURATION)
                            .ToList(), x.GetChannel()))
                .Select(x => {
                    int numberOfNotes = x.GetNotes().count();
                    List<Note> notePos = x.GetNotes();
                    return new KeyboardTrack(x.GetInstrument(), x.GetNotes()
                            .Where(y => (notePos.IndexOf(y) % Math.Ceiling((double)numberOfNotes / MAX_NOTE) == 0))
                            .ToList(), x.GetChannel());
                })
                .OrderBy(x => x.GetNotes.Count)
                .ToList();
        }
    }
}
