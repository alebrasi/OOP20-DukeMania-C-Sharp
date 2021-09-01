using System;
using System.Collections.Generic;
using System.Text;

namespace taskCsharpSofiaTosi
{
    interface IEventsFromKeyboard
    {
        /// <summary>
        /// return true if the button related to key is pressed
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool IsButtonPressed(int key);

        /// <summary>
        /// return the key associated to the given column
        /// </summary>
        /// <param name="column"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        ConsoleKey AssociationKeyColumn(int column, int max);
    }


}