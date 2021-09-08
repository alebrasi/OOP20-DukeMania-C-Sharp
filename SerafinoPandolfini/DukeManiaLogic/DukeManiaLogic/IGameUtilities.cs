using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DukeManiaLogic
{
    interface IGameUtilities
    {
        /// <summary>
        /// give a difficulty level at all playable tracks
        /// </summary>
        Dictionary<KeyboardTrack, DifficultyLevel> GenerateTracksDifficulty(List<KeyboardTrack> tracks);
    }
}
