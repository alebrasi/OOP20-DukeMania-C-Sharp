using Microsoft.VisualStudio.TestTools.UnitTesting;
using DukeManiaLogic;
using System.Collections.Generic;

namespace TestDukeManiaLogic
{
    [TestClass]
    public class Test
    {
        private TrackFilter _trackFilter;
        private GameUtilities _gameUtilities;
        private ScoreContext _scoreContext;

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
            this._scoreContext = new ScoreContext(new FullCalculator());
        }
        
        [TestMethod]
        public void TestTrackFilter()
        {
        }

        [TestMethod]
        public void TestGameUtilities()
        {
        }

        [TestMethod]
        public void TestScoreCalculation()
        {
            NoteRange testRange = new NoteRange(Columns.COLUMN_1,10,20);
            Assert.IsTrue(_scoreContext.executeStrategy(Columns.COLUMN_1, 10, 20, testRange, 4) == 420);
            Assert.IsTrue(_scoreContext.executeStrategy(Columns.COLUMN_1, 30, 40, testRange, 4) == 0);
            Assert.IsTrue(_scoreContext.executeStrategy(Columns.COLUMN_1, 10, 20, testRange, 8) == 840);
            Assert.IsTrue(_scoreContext.executeStrategy(Columns.COLUMN_1, 10, 20, testRange, 8) == 880);
            Assert.IsTrue(_scoreContext.executeStrategy(Columns.COLUMN_1, 19, 20, testRange, 4) > 0);           
        }


    }
}
