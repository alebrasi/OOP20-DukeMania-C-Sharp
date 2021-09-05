using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace TaskCSharp 
{
    public interface ISongSelectionWindowController 
    {
        ///<summary>Updates the track configurations</summary>
        ///<param name="names">The list of the track names</param>
        ///<param name="instruments">The list of the track instruments</param>
        void UpdateTracks(List<string> names, List<InstrumentType> instruments);
        
        ///<summary>Instruct the controller to switch window to the PlayScreen</summary>
        void PlaySong();

        ///<summary></summary>
        ///<returns>Return the information of a song</returns>
        SongInfo GetSongInfo();

        ///<summary>Returns all the MIDI instruments</summary>
        ///<returns>An array containing all the instruments</returns>
        String[] GetAllInstruments();
    }
}