namespace BasicCsharp.Lessons.Final.Games.Dice;

public class WrongDiceNumberException : Exception
{
    public WrongDiceNumberException(int value, int min, int max)
        : base($"Value {value} must be between {min} and {max}!")
    {
    }
}