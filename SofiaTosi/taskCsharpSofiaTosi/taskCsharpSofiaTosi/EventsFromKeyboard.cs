using System;
using System.Collections.Generic;
using System.Linq;
using taskCsharpSofiaTosi;

public class EventsFromKeyboard : LibgdxInput, IEventsFromKeyboard
{
    readonly Column column;
    readonly IList<ConsoleKey> keys = new List<ConsoleKey> { ConsoleKey.A, ConsoleKey.S, ConsoleKey.D, ConsoleKey.F, ConsoleKey.H, ConsoleKey.J, ConsoleKey.K, ConsoleKey.L };

    public EventsFromKeyboard(Column column2)
    {
        column = column2;
    }

    public ConsoleKey AssociationKeyColumn(int column, int max)
    {
        List<ConsoleKey> usedKeys = keys.Take(max).ToList();

        return usedKeys[column - 1];
    }

    public bool IsButtonPressed(int key)
    {
        return LibgdxInput.IsButtonPressed(AssociationKeyColumn(column.GetNumericValue(), key));
    }

}