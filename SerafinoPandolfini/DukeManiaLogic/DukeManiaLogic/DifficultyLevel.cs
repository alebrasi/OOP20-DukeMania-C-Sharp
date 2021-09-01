using System;
using System.Collections.Generic;

public sealed class DifficultyLevel
{
    public static readonly DifficultyLevel UNKNOWN = new DifficultyLevel("???",0);
    public static readonly DifficultyLevel VERY_EASY = new DifficultyLevel("Very Easy",1);
    public static readonly DifficultyLevel EASY = new DifficultyLevel("Easy",2);
    public static readonly DifficultyLevel NORMAL = new DifficultyLevel("Normal",3);
    public static readonly DifficultyLevel DIFFICULT = new DifficultyLevel("Difficult",4);
    public static readonly DifficultyLevel VERY_DIFFICULT = new DifficultyLevel("Very Difficult",5);

    public static IEnumerable<DifficultyLevel> getValues()
    {
        yield return DifficultyLevel.UNKNOWN;
        yield return DifficultyLevel.VERY_EASY;
        yield return DifficultyLevel.EASY;
        yield return DifficultyLevel.NORMAL;
        yield return DifficultyLevel.DIFFICULT;
        yield return DifficultyLevel.VERY_DIFFICULT;
    }

    private readonly int _value;
    private readonly string _effectiveName;

    public DifficultyLevel(string effectiveName, int value)
    {
        _value = value;
        _effectiveName = effectiveName;
    }

    public int GetNumericValue()
    {
        return _value;
    }
    public string GetEffectiveName()
    {
        return _effectiveName;
    }

}