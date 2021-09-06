using System;
using System.Collections.Generic;
using System.Linq;

namespace DukeManiaLogic
{
    public class GameUtilities : IGameUtilities
    {
        private List<DifficultyLevel> getDifficulties()
        {
            return Enum.GetValues(typeof(DifficultyLevel))
                        .Cast<DifficultyLevel>()
                        .OrderBy(x => x.GetNumericValue())
                        .ToList();
        }
            public Dictionary<KeyboardTrack, DifficultyLevel> generateTracksDifficulty(List<KeyboardTrack> tracks)
        {
            return tracks.ToDictionary(x => x, x =>
            {
                int numberOfDifficulties = DifficultyLevel.getValues().Count() - 1;
                return getDifficulties()
                .Where(y => x.Notes.Count() <= TrackFilter.MAX_NOTE / numberOfDifficulties * y.GetNumericValue())
                .DefaultIfEmpty(DifficultyLevel.UNKNOWN)
                .First();
            });
        }
    }
}
