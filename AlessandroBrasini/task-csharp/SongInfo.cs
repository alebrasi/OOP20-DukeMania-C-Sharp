using System;
using System.Collections.Generic;

namespace TaskCSharp
{
    public class SongInfo {
        String _title;
        double _duration;
        List<TrackInfo> _tracks;
        double _bpm;
        String _songHash;

        public SongInfo(String title, String songHash, double duration, List<TrackInfo> tracks, double bpm) 
        {
            this._title = title;
            this._duration = duration;
            this._tracks = tracks;
            this._bpm = bpm;
            this._songHash = songHash;
        }

        public string Title { get => _title; }
        public double Duration { get => _duration; }
        public List<TrackInfo> Tracks { get => _tracks; }
        public double Bpm { get => _bpm; }
        public string SongHash { get => _songHash; }
    }
}