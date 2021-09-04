using System;

namespace TaskCSharp
{
    public class ParsedTrack 
    {
        private int _channel;
        private InstrumentType _instrument;
        public int Channel { get => _channel; set => _channel = value; }
        public InstrumentType Instrument { get => _instrument; set => _instrument = value; }
    }
}