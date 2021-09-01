using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DukeManiaLogic
{
    interface ITrackFilter
    {
        List<KeyboardTrack> ReduceTrack(Song song);
    }

}
