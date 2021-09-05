using System;

namespace TaskCSharp
{
    public class ParsedTrack 
    {
        int _channel;
        InstrumentType _instrument;
        
        public int Channel { get => _channel; set => _channel = value; }
        public InstrumentType Instrument { get => _instrument; set => _instrument = value; }
    }
}