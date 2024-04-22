namespace BasicCsharp.Lessons.Final.Games.Dice;

public sealed class Dice
{
    private readonly int _minValue;
    private readonly int _maxValue;
    
    public Dice(int minValue, int maxValue)
    {
        _minValue = minValue;
        if (minValue < 1 || minValue > maxValue)
        {
            throw new WrongDiceNumberException(minValue, 1, maxValue);
        }
        
        _maxValue = maxValue;
        if (maxValue < minValue)
        {
            throw new WrongDiceNumberException(maxValue, minValue, maxValue);
        }
    }

    private static readonly Random Randomizer = new();
    public int Roll() => Randomizer.Next(_minValue, _maxValue);
}