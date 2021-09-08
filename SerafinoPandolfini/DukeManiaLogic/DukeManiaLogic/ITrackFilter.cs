using System.Collections.Generic;

namespace DukeManiaLogic
{
    interface ITrackFilter
    {
        /// <summary>
        /// delete from all tracks of a song all unplayable notes
        /// </summary>
        List<KeyboardTrack> ReduceTrack(Song song);
    }

}
