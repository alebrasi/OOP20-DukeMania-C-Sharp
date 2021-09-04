using System;
using System.Collections.Generic;

namespace TaskCSharp
{
    public class Song 
    {
        String _title;
        double _duration;
        List<ParsedTrack> _tracks;
        double _bpm;

        public string Title { get => _title; set => _title = value; }
        public double Duration { get => _duration; set => _duration = value; }
        public List<ParsedTrack> Tracks { get => _tracks; set => _tracks = value; }
        public double Bpm { get => _bpm; set => _bpm = value; }
    }
}