using System;
using System.Collections.Generic;
using System.Linq;

namespace DukeManiaLogic
{
    public class GameUtilities : IGameUtilities
    {
        private List<DifficultyLevel> GetDifficulties() => DifficultyLevel.GetValues().ToList();

        public Dictionary<KeyboardTrack, DifficultyLevel> GenerateTracksDifficulty(List<KeyboardTrack> tracks)
        {
            return tracks.ToDictionary(x => x, x =>
            {
                int numberOfDifficulties = DifficultyLevel.GetValues().Count() - 1;
                return GetDifficulties()
                .Where(y => x.Notes.Count() <= TrackFilter.MAX_NOTE / numberOfDifficulties * y.GetNumericValue())
                .DefaultIfEmpty(DifficultyLevel.UNKNOWN)
                .First();
            });
        }
    }
}
