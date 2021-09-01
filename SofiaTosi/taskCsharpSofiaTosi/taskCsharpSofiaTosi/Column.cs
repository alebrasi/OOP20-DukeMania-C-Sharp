using System;
using System.Collections.Generic;

public sealed class Column
{
    public static readonly Column COLUMN_1 = new Column(1);
    public static readonly Column COLUMN_2 = new Column(2);
    public static readonly Column COLUMN_3 = new Column(3);
    public static readonly Column COLUMN_4 = new Column(4);
    public static readonly Column COLUMN_5 = new Column(5);
    public static readonly Column COLUMN_6 = new Column(6);
    public static readonly Column COLUMN_7 = new Column(7);
    public static readonly Column COLUMN_8 = new Column(8);

    public static IEnumerable<Column> getValues()
    {
        yield return Column.COLUMN_1;
        yield return Column.COLUMN_2;
        yield return Column.COLUMN_3;
        yield return Column.COLUMN_4;
        yield return Column.COLUMN_5;
        yield return Column.COLUMN_6;
        yield return Column.COLUMN_7;
        yield return Column.COLUMN_8;
    }


    private readonly int _value;


    public Column(int value)
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