using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskCSharp
{
    public class SongSelectionWindowController : ISongSelectionWindowController
    {
        private SongInfo currentSong;
        private List<SongInfo> songsConfigurations;

        public string[] GetAllInstruments()
        {
            return Enum.GetValues(typeof(InstrumentType))
                        .Cast<InstrumentType>()
                        .Select(x => x.ToString())
                        .ToArray();
        }

        public SongInfo GetSongInfo()
        {
            return new SongInfo(currentSong.Title,
                                "",
                                currentSong.Duration,
                                currentSong.Tracks
                                            .Where(x => x.TrackID != 10)
                                            .ToList(),
                                currentSong.Bpm);
        }

        public void PlaySong()
        {
            Parser parser = new Parser();
            File1 file = new File1("file.mid");
            Song song = parser.Parse(file);
            currentSong.Tracks.ForEach(x => {
                ParsedTrack track = song.Tracks
                                        .Where(t => t.Channel == x.TrackID)
                                        .First();

                track.Instrument = x.Instrument;
            });
        }

        public void UpdateTracks(List<string> names, List<InstrumentType> instruments)
        {
            songsConfigurations.RemoveAt(songsConfigurations.FindIndex(x => x.SongHash == currentSong.SongHash));
            TrackInfo[] tracks = currentSong.Tracks.ToArray();
            for (int i = 0; i < names.Count; i++) {
                tracks[i].TrackName = names[i];
                tracks[i].Instrument = instruments[i];
            }
            songsConfigurations.Add(currentSong);
        }
    }
}