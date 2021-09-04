using System;

namespace TaskCSharp 
{
    public class TrackInfo {
        String _trackName;
        InstrumentType _instrument;
        int _trackID;
        DifficultyLevel _difficulty;

        public TrackInfo(int channel, String trackName, InstrumentType instrument, DifficultyLevel difficulty) {
            this._trackName = trackName;
            this._instrument = instrument;
            this._trackID = channel;
            this._difficulty = difficulty;
        }

        public string TrackName { get => _trackName; set => _trackName = value; }
        public InstrumentType Instrument { get => _instrument; set => _instrument = value; }
        public DifficultyLevel Difficulty { get => _difficulty; set => _difficulty = value; }
        public int TrackID { get => _trackID; set => _trackID = value; }
    }
}