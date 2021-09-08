using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DukeManiaLogic
{
    interface IColumnLogic
    {

        int GetColumnNumber();


        void SetColumnNumber(int columnNumber);

        /// <summary>
        /// Add a new NoteRange for score purposes
        /// </summary>
        void AddNoteRanges(Columns column, long start, long end);

        /// <summary>
        /// Call this method before playing a new track to reset combo variable
        /// </summary>
        void ContextInit();

        /// <summary>
        /// return the score for the current note
        /// </summary>
        int verifyNote(Columns column, long start, long end);
    }
}
