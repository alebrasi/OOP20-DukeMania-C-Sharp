using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DukeManiaLogic
{
    public class ScoreContext
    {

        private IScoreStrategy strategy;

    public ScoreContext(IScoreStrategy strategy)
        {
            this.strategy = strategy;
        }

        public int executeStrategy(
                Columns column, long start, long end, NoteRange currentRange, int columnNumber)
        {
            return strategy.ScoreCalculation(column, start, end, currentRange, columnNumber);
        }
    }
}
