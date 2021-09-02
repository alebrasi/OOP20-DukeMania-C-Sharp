using System.Collections.Generic;
using System.Linq;

namespace DukeManiaLogic
{
    public class ColumnLogic
    {

        const int COLUMN_MAX_CAP = 8;
        const int COLUMN_MIN_CAP = 4;
        const int MAX_HEIGHT = 4;
        const int THREAD_SLEEP_TIME = 5;
        private int _columnNumber;
        private List<NoteRange> _noteRanges;
        private ScoreContext _context;

        public ColumnLogic(int columnNumber)
        {
            SetColumnNumber(columnNumber);
            this._noteRanges = new List<NoteRange>();
            ContextInit();
        }

        public int ColumnNumber => _columnNumber;

        public void SetColumnNumber(int columnNumber)
        {
            this._columnNumber = columnNumber <= COLUMN_MAX_CAP && columnNumber >= COLUMN_MIN_CAP ? columnNumber : COLUMN_MIN_CAP;
        }

        public void AddNoteRanges(Columns column, long start, long end)
        {
            this._noteRanges.Add(new NoteRange(column, start, end));
        }

        public void ContextInit()
        {
            this._context = new ScoreContext(new FullCalculator());
        }

        public int verifyNote(Columns column, long start, long end)
        {
            NoteRange currentRange = _noteRanges
                    .Where(x => x.Column.Equals(column))
                    .Where(x => start < x.End && end > x.Start)
                    //the player started pressing before the end of the note and ended pressing after the start of the note
                    .OrderBy(x => x.Start)
                    .DefaultIfEmpty(new NoteRange(column, 0, 1)) //take the first range of the compatible with the pressed note
                    .First();
            this._noteRanges.Remove(currentRange);
            return this._context.executeStrategy(column, start, end, currentRange, _columnNumber);
        }
    }
}
