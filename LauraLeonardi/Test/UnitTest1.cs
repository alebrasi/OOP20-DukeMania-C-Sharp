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
		public void TestMethod1()
		{
			Assert.IsTrue(1 == 1);
		}
		[TestMethod]
		public void TestMethod2()
		{
			
			List<ParsedTrack> tracks = new List<ParsedTrack>();
			for (int ch = 0; ch < 12; ch++)
			{
				IAbstractFactory fact = FactoryConfigurator.GetFactory(ch);
				List<AbstractNote> notes = new List<AbstractNote>() {
				fact.CreateNote(duration: 1, 1, 40),
				fact.CreateNote(duration: 1, 2, 38),
				fact.CreateNote(duration: 2, 1, 41),
				fact.CreateNote(duration: 1, 3, 40),
				};
				tracks.Add(fact.CreateTrack((InstrumentType)Enum.Parse(typeof(InstrumentType), Convert.ToString(ch + 10)), notes, ch));
			}

			Song song = new Song("titolo", 32.0, tracks, 140.0);
			Assert.AreEqual(song.Tracks.Count, 12);
			song.Tracks.ForEach(t => Assert.AreEqual(t.Notes.Count, 4));
			Assert.IsInstanceOfType(song.Tracks[10], typeof(PercussionTrack));
			Assert.AreEqual(song.Tracks.OfType<KeyboardTrack>().ToList().Count, 11);
			song.Tracks.OfType<KeyboardTrack>().ToList().ForEach(t => Assert.IsNotNull(t.Instrument));
			song.Tracks[10].Notes.ForEach(n=> Assert.IsInstanceOfType(n, typeof(PercussionNote)));
			song.Tracks[10].Notes.ForEach(n => Assert.IsNotNull(((PercussionNote)n).Instrument));


		}
	}
}
