using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DukeManiaLogic
{
    public interface IScoreStrategy
    {
        /// <summary>
        /// use the current strategy to calculae the score
        /// </summary>
        int ScoreCalculation(Columns column, long start, long end, NoteRange currentRange, int columnNumber);
    }
}
