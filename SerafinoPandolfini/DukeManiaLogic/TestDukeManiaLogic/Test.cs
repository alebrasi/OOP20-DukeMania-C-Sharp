using Microsoft.VisualStudio.TestTools.UnitTesting;
using DukeManiaLogic;
using System.Collections.Generic;
using System;
using System.Linq;
using midi_task_Csharp;

namespace TestDukeManiaLogic
{
    [TestClass]
    public class Test
    {
        private TrackFilter _trackFilter;
        private GameUtilities _gameUtilities;
        private ColumnLogic _columnLogic;

        private List<AbstractNote> createNotes(int quantity)
        {
            //generate notes for testing
            List<AbstractNote> testNotes = new List<AbstractNote>();
            for (int i = 0; i < quantity; i++)
            {
                testNotes.Add(new Note(2_000_000L, i, 0));
            }
            return testNotes;
        }

        [TestInitialize]
        public void Init()
        {
            this._trackFilter = new TrackFilter();
            this._gameUtilities = new GameUtilities();
            this._columnLogic = new ColumnLogic(4);
        }

        [TestMethod]
        public void TestTrackFilter()
        {
            List<ParsedTrack> testTracks = new List<ParsedTrack>();
            List<AbstractNote> testNotes = createNotes(TrackFilter.MAX_NOTE);
            testTracks.Add(new KeyboardTrack(InstrumentType.ACCORDION, testNotes, 0));

            //test with MAX_NOTE notes
            Assert.IsTrue(this._trackFilter.ReduceTrack(new Song("title", 0, testTracks, 0)).Count == 1);
            Assert.IsTrue(this._trackFilter.ReduceTrack(new Song("title", 0, testTracks, 0))[0]
                    .Notes.Count == TrackFilter.MAX_NOTE);

            //test with MAX_NOTE + 1 notes
            testNotes.Add(new Note(1L, 1, 1));
            Assert.IsTrue(this._trackFilter.ReduceTrack(new Song("title", 0, testTracks, 0))[0]
                    .Notes.Count <= TrackFilter.MAX_NOTE);

            //test with 2 tracks (10 and MAX_NOTE + 1 notes)
            testTracks.Add(new KeyboardTrack(InstrumentType.ACCORDION, testNotes.GetRange(0, 10), 0));
            List<KeyboardTrack> filteredTracks = this._trackFilter.ReduceTrack(new Song("title", 0, testTracks, 0));
            Assert.IsTrue(filteredTracks[0].Notes.Count == 10);
            Assert.IsTrue(filteredTracks[1].Notes.Count <= TrackFilter.MAX_NOTE);
        }

        [TestMethod]
        public void TestGameUtilities()
        {
            int difficulties = 5;
            List<KeyboardTrack> testTracksDiff = new List<KeyboardTrack>();

            //test for every difficultylevel
            testTracksDiff.Add(new KeyboardTrack(InstrumentType.ACCORDION,
                createNotes(TrackFilter.MAX_NOTE / difficulties * DifficultyLevel.VERY_EASY.GetNumericValue()), 0));
            testTracksDiff.Add(new KeyboardTrack(InstrumentType.ACCORDION,
                createNotes(TrackFilter.MAX_NOTE / difficulties * DifficultyLevel.EASY.GetNumericValue()), 0));
            testTracksDiff.Add(new KeyboardTrack(InstrumentType.ACCORDION,
                createNotes(TrackFilter.MAX_NOTE / difficulties * DifficultyLevel.NORMAL.GetNumericValue()), 0));
            testTracksDiff.Add(new KeyboardTrack(InstrumentType.ACCORDION,
                createNotes(TrackFilter.MAX_NOTE / difficulties * DifficultyLevel.DIFFICULT.GetNumericValue()), 0));
            testTracksDiff.Add(new KeyboardTrack(InstrumentType.ACCORDION,
                createNotes(TrackFilter.MAX_NOTE / difficulties * DifficultyLevel.VERY_DIFFICULT.GetNumericValue()), 0));
            //test special case: track with more notes than MAX_NOTE
            testTracksDiff.Add(new KeyboardTrack(InstrumentType.ACCORDION,
                createNotes(TrackFilter.MAX_NOTE + 1), 0));
            Dictionary<KeyboardTrack, DifficultyLevel> trackmap = this._gameUtilities.generateTracksDifficulty(testTracksDiff);
            Assert.AreEqual(trackmap.GetValueOrDefault(testTracksDiff[0]), DifficultyLevel.VERY_EASY);
            Assert.AreEqual(trackmap.GetValueOrDefault(testTracksDiff[1]), DifficultyLevel.EASY);
            Assert.AreEqual(trackmap.GetValueOrDefault(testTracksDiff[2]), DifficultyLevel.NORMAL);
            Assert.AreEqual(trackmap.GetValueOrDefault(testTracksDiff[3]), DifficultyLevel.DIFFICULT);
            Assert.AreEqual(trackmap.GetValueOrDefault(testTracksDiff[4]), DifficultyLevel.VERY_DIFFICULT);
            Assert.AreEqual(trackmap.GetValueOrDefault(testTracksDiff[5]), DifficultyLevel.UNKNOWN);
        }

        [TestMethod]
        public void TestScoreCalculation()
        {
            this._columnLogic.AddNoteRanges(Columns.COLUMN_1, 10, 15);
            this._columnLogic.AddNoteRanges(Columns.COLUMN_1, 16, 20);
            this._columnLogic.AddNoteRanges(Columns.COLUMN_2, 11, 16);
            this._columnLogic.AddNoteRanges(Columns.COLUMN_2, 21, 25);
            this._columnLogic.AddNoteRanges(Columns.COLUMN_2, 30, 40);
            this._columnLogic.AddNoteRanges(Columns.COLUMN_2, 50, 70);
            this._columnLogic.AddNoteRanges(Columns.COLUMN_3, 10, 30);

            //test ranges with the same note
            Assert.IsTrue(this._columnLogic.verifyNote(Columns.COLUMN_1, 9, 15) > 0);
            // match with first added range, partial match
            Assert.IsTrue(this._columnLogic.verifyNote(Columns.COLUMN_1, 9, 15) == 0);
            // match with second added range, complete mismatch
            Assert.IsTrue(this._columnLogic.verifyNote(Columns.COLUMN_1, 9, 15) == 0);
            //match with orElse value, complete mismatch

            //test perfect note and combo 
            Assert.IsTrue(this._columnLogic.verifyNote(Columns.COLUMN_2, 11, 16) == (100 + 1 * 5) * 4);
            //perfect socre, 1 combo, 4 colums
            Assert.IsTrue(this._columnLogic.verifyNote(Columns.COLUMN_2, 21, 25) == (100 + 2 * 5) * 4);
            //perfect socre, 2 combo, 4 colums
            this._columnLogic.SetColumnNumber(8);
            Assert.IsTrue(this._columnLogic.verifyNote(Columns.COLUMN_2, 30, 40) == (100 + 3 * 5) * 8);
            //perfect socre, 3 combo, 8 colums
            Assert.IsTrue(this._columnLogic.verifyNote(Columns.COLUMN_2, 50, 60) != (100 + 4 * 5) * 8);
            //not perfect note, reset combo

            //test tolerance
            Assert.IsTrue(this._columnLogic.verifyNote(Columns.COLUMN_3, 10, 29) == (100 + 1 * 5) * 8);
            //not perfect but considered as perfect         
        }


    }
}
