using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DukeManiaLogic
{
    public class FullCalculator : IScoreStrategy
    {

        const int NOTE_POINT = 100;
        const int NOTE_TOLERANCE = 50;
        const int MAX_COMBO = 20;
        const int COMBO_POINT = 5;
        const int GIFT_POINT = 20;
        private int _combo;

        public FullCalculator()
        {
            this._combo = 0;
        }

        public int ScoreCalculation(
        Columns column, long start, long end, NoteRange currentRange, int columnNumber)
        {
            int normalPoint = (int)((double)(end - start - Math.Abs(currentRange.End - end)
                    - Math.Abs(currentRange.Start - start)) / (end - start) * NOTE_POINT);
            // NOTE_POINT multiplied by the percentage of match between the note and the range
            this._combo = normalPoint >= NOTE_POINT - NOTE_TOLERANCE ? this._combo < MAX_COMBO ? this._combo + 1 : this._combo : 0;
            //combo increase if you played a perfect note (100 - NOTE_TOLERANCE)%
            return (((normalPoint >= NOTE_POINT - NOTE_TOLERANCE
                    ? NOTE_POINT : (normalPoint + NOTE_TOLERANCE < 0
                            ? currentRange.Start <= start && currentRange.End >= end ? GIFT_POINT : 0
                            : normalPoint + NOTE_TOLERANCE)) + COMBO_POINT * _combo) * columnNumber);
        }
    }

}
