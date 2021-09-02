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


        void AddNoteRanges(Columns column, long start, long end);

        void ContextInit();

        int verifyNote(Columns column, long start, long end);
    }
}
