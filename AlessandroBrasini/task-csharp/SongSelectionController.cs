using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskCSharp
{
    public class SongSelectionWindowController : ISongSelectionWindowController
    {
        SongInfo _currentSong;
        List<SongInfo> _songsConfigurations;

        public string[] GetAllInstruments()
        {
            return Enum.GetValues(typeof(InstrumentType))
                        .Cast<InstrumentType>()
                        .Select(x => x.ToString())
                        .ToArray();
        }

        public SongInfo GetSongInfo()
        {
            return new SongInfo(_currentSong.Title,
                                "",
                                _currentSong.Duration,
                                _currentSong.Tracks
                                            .Where(x => x.TrackID != 10)
                                            .ToList(),
                                _currentSong.Bpm);
        }

        public void PlaySong()
        {
            Parser parser = new Parser();
            File1 file = new File1("file.mid");
            Song song = parser.Parse(file);
            _currentSong.Tracks.ForEach(x => {
                ParsedTrack track = song.Tracks
                                        .Where(t => t.Channel == x.TrackID)
                                        .First();

                track.Instrument = x.Instrument;
            });
        }

        public void UpdateTracks(List<string> names, List<InstrumentType> instruments)
        {
            _songsConfigurations.RemoveAt(_songsConfigurations.FindIndex(x => x.SongHash == _currentSong.SongHash));
            TrackInfo[] tracks = _currentSong.Tracks.ToArray();
            for (int i = 0; i < names.Count; i++) {
                tracks[i].TrackName = names[i];
                tracks[i].Instrument = instruments[i];
            }
            _songsConfigurations.Add(_currentSong);
        }
    }
}