using System;
using System.Collections.Generic;
using System.Linq;

namespace DukeManiaLogic
{
    public class TrackFilter : ITrackFilter
    {
        public const int MAX_NOTE = 600;
        const int PERCUSSION_CHANNEL = 10;
        const long MIN_DURATION = 125_000;

        public List<KeyboardTrack> ReduceTrack(Song song)
        {
            return song.Tracks.Where(x => x.Channel != PERCUSSION_CHANNEL)
                .Select(x => new KeyboardTrack(((KeyboardTrack)x).Instrument, x.Notes
                            .Where(y => y.Duration >= MIN_DURATION)
                            .ToList(), x.Channel))
                .Select(x => {
                    int numberOfNotes = x.Notes.Count();
                    List<AbstractNote> notePos = x.Notes;
                    return new KeyboardTrack(((KeyboardTrack)x).Instrument, x.Notes
                            .Where(y => (notePos.IndexOf(y) % Math.Ceiling((double)numberOfNotes / MAX_NOTE) == 0))
                            .ToList(), x.Channel);
                })
                .OrderBy(x => x.Notes.Count)
                .ToList();
        }
    }
}
