using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DukeManiaLogic
{
    using System;
    using System.Collections.Generic;

    public sealed class Columns
    {
        public static readonly Columns COLUMN_1 = new Columns(1);
        public static readonly Columns COLUMN_2 = new Columns(2);
        public static readonly Columns COLUMN_3 = new Columns(3);
        public static readonly Columns COLUMN_4 = new Columns(4);
        public static readonly Columns COLUMN_5 = new Columns(5);
        public static readonly Columns COLUMN_6 = new Columns(6);
        public static readonly Columns COLUMN_7 = new Columns(7);
        public static readonly Columns COLUMN_8 = new Columns(8);

        public static IEnumerable<Columns> getValues()
        {
            yield return Columns.COLUMN_1;
            yield return Columns.COLUMN_2;
            yield return Columns.COLUMN_3;
            yield return Columns.COLUMN_4;
            yield return Columns.COLUMN_5;
            yield return Columns.COLUMN_6;
            yield return Columns.COLUMN_7;
            yield return Columns.COLUMN_8;
        }


        private readonly int _value;


        public Columns(int value)
        {
            _value = value;
        }

        /// <summary>
        /// return the int value
        /// </summary>
        /// <returns></returns>
        public int GetNumericValue()
        {
            return _value;
        }

    }
}
