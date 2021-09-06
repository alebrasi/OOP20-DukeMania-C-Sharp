using Microsoft.VisualStudio.TestTools.UnitTesting;
using midi_task_Csharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
	[TestClass]
    public class UnitTest1
	{

		[TestMethod]
		public void TestFactory()
		{
			Assert.IsInstanceOfType(FactoryConfigurator.GetFactory(1), typeof(Factory));
			Factory fact = (Factory) FactoryConfigurator.GetFactory(1);
			Assert.IsInstanceOfType(FactoryConfigurator.GetFactory(10), typeof(PercussionFactory));
			PercussionFactory pFact = (PercussionFactory)FactoryConfigurator.GetFactory(10);
			Assert.IsInstanceOfType(fact.CreateTrack(InstrumentType.ACCORDION, new List<AbstractNote>(), 1), typeof(KeyboardTrack));
			Assert.IsInstanceOfType(fact.CreateNote(1, 1, 60), typeof(Note));
			Assert.IsInstanceOfType(pFact.CreateTrack(InstrumentType.ACCORDION, new List<AbstractNote>(), 10), typeof(PercussionTrack));
			Assert.IsInstanceOfType(pFact.CreateNote(1, 1, 60), typeof(PercussionNote));
			Assert.ThrowsException<InvalidNoteException>(() => pFact.CreateNote(1, 1, 90));
		}

		public Song Settings()
		{
			List<ParsedTrack> tracks = new List<ParsedTrack>();
			for (int ch = 0; ch < 12; ch++)
			{
				IAbstractFactory fact = FactoryConfigurator.GetFactory(ch);
				List<AbstractNote> notes = new List<AbstractNote>() {
				fact.CreateNote(duration: 3, 1, 40),
				fact.CreateNote(duration: 3, 2, 69),
				fact.CreateNote(duration: 2, 1, 41),
				fact.CreateNote(duration: 1, 3, 40),
				};
				tracks.Add(fact.CreateTrack((InstrumentType)Enum.Parse(typeof(InstrumentType), Convert.ToString(ch + 10)), notes, ch));
			}
			return new Song("titolo", 32.0, tracks, 140.0);
		}

		[TestMethod]
		public void TestSongAndInstrument()
		{
			//ottengo song
			Song song = Settings();

			// test su song 
			Assert.AreEqual(song.Title, "titolo");
			Assert.AreEqual(song.Bpm, 140.0);
			Assert.AreEqual(song.Duration, 32.0);
			Assert.AreEqual(song.Tracks.Count, 12);


			//instrument test
			Instrument instrument1 = new Instrument(InstrumentType.CELESTA);
			Instrument instrument2 = new Instrument(InstrumentType.CLAVINET);
			Assert.AreEqual(instrument1.InstrumentName, InstrumentType.CELESTA);
			Assert.AreEqual(instrument1.Name, "Chromatic Percussion");
			Assert.AreEqual(instrument2.Name, "Piano");
			Assert.IsTrue(instrument2.AssociatedInstrumentType.Count == 8);
			Assert.IsTrue(instrument2.AssociatedInstrumentType.Contains(InstrumentType.ACOUSTIC_GRAND_PIANO));
			Assert.IsFalse(instrument2.AssociatedInstrumentType.Contains(InstrumentType.CELESTA));

		}

		[TestMethod]
		public void TestTracks()
		{
			//ottengo song e tracks
			Song song = Settings();
			List<ParsedTrack> tracks = song.Tracks;

			//test su tracce (canale, numero note, delete note)
			Assert.AreEqual(tracks.First().Channel, 0);
			tracks.ForEach(t => Assert.AreEqual(t.Notes.Count, 4));
			AbstractNote note = tracks.First().Notes.First();
			tracks.First().DeleteNote(note);
			Assert.AreEqual(tracks.First().Notes.Count, 3);
			tracks.First().Notes.Insert(0, note);
			Assert.AreEqual(tracks.First().Notes.Count, 4);

			//test su tipo tracce e presenza instrument e mappa per keyboard
			Assert.IsInstanceOfType(song.Tracks[10], typeof(PercussionTrack));
			PercussionTrack pTrack = (PercussionTrack)song.Tracks[10];
			Assert.AreEqual(tracks.OfType<KeyboardTrack>().ToList().Count, 11);
			List<KeyboardTrack> kTracks = tracks.OfType<KeyboardTrack>().ToList();
			kTracks.ForEach(t => Assert.IsNotNull(t.Instrument));
			Assert.AreEqual(kTracks[0].Instrument, InstrumentType.MUSIC_BOX);
			kTracks[0].Instrument = InstrumentType.ACCORDION;
			Assert.AreEqual(kTracks[0].Instrument, InstrumentType.ACCORDION);
			kTracks.ForEach(t => Assert.AreEqual(t.NotesMaxDuration.Count, 3));
			kTracks.ForEach(t => Assert.IsTrue(t.NotesMaxDuration.ContainsValue(3L)));
			kTracks.ForEach(t => Assert.IsTrue(t.NotesMaxDuration.ContainsValue(2L)));
			kTracks.ForEach(t => Assert.IsFalse(t.NotesMaxDuration.ContainsValue(1L)));
			kTracks.ForEach(t => Assert.IsTrue(t.NotesMaxDuration.ContainsKey(69)));
			kTracks.ForEach(t => Assert.IsTrue(t.NotesMaxDuration.ContainsKey(40)));
			kTracks.ForEach(t => Assert.IsTrue(t.NotesMaxDuration.ContainsKey(41)));

		}

		[TestMethod]
		public void TestNotes()
		{
			//ottengo song e tracks
			Song song = Settings();
			List<ParsedTrack> tracks = song.Tracks;
			PercussionTrack pTrack = (PercussionTrack)song.Tracks[10];
			List<KeyboardTrack> kTracks = tracks.OfType<KeyboardTrack>().ToList();

			//test sulle note (tipo, presenza instrument per percussion)
			kTracks.ForEach(t => t.Notes.ForEach(n => Assert.IsInstanceOfType(n, typeof(Note))));
			pTrack.Notes.ForEach(n => Assert.IsInstanceOfType(n, typeof(PercussionNote)));
			pTrack.Notes.ForEach(n => Assert.IsNotNull(((PercussionNote)n).Instrument));
			
			//ottengo due note campione
			Note a4 = (Note)kTracks[0].Notes[1];
			PercussionNote snare = (PercussionNote)pTrack.Notes[0];

			// test su Note e PercussionNote
			Assert.AreEqual(a4.Identifier, 69);
			Assert.AreEqual(a4.Duration, 3);
			Assert.AreEqual(a4.StartTime, 2);
			Assert.AreEqual(a4.Frequency, 440);
			Assert.AreEqual(a4.GetItem(), 69);
			Assert.AreEqual(snare.Identifier, 40);
			Assert.AreEqual(snare.Duration, 3);
			Assert.AreEqual(snare.StartTime, 1);
			Assert.AreEqual(snare.Instrument, Percussion.ELECTRIC_SNARE);
			Assert.AreEqual(snare.GetItem(), Percussion.ELECTRIC_SNARE);
			
		}
	}
}
