using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DukeManiaLogic
{
    public class NoteRange
    {
        private Columns _column;
        private long _start;
        private long _end;

            public NoteRange(Columns column, long start, long end)
            {
                this._column = column;
                this._start = start;
                this._end = end;
            }

        public Columns Column => _column;

        public long Start => _start;

        public long End => _end;

    }
}
