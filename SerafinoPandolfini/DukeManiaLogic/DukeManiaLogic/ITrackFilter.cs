using System.Collections.Generic;

namespace DukeManiaLogic
{
    interface ITrackFilter
    {
        List<KeyboardTrack> ReduceTrack(Song song);
    }

}
