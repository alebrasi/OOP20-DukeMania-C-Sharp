using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace TaskCSharp 
{
    public interface ISongSelectionWindowController 
    {
        void UpdateTracks(List<string> names, List<InstrumentType> instruments);
        void PlaySong();
        SongInfo GetSongInfo();
        String[] GetAllInstruments();
    }
}