namespace BasicCsharp.Lessons.Memory;

public struct Interval
{
    private float MinValue { get; }
    public float MaxValue { get; }

    public Interval(int minValue, int maxValue)
        : this((float)minValue, (float)maxValue)
    {
    }

    public Interval(float value)
        : this(value, value)
    {
    }

    public Interval(float minValue, float maxValue)
    {
        if (minValue > maxValue)
        {
            (minValue, maxValue) = (maxValue, minValue);
            Console.WriteLine($"Данные введены некорректно и были поменяны местами.");
        }

        MinValue = minValue;
        MaxValue = maxValue;
    }

    public float Min() => MinValue;
    public float Max() => MaxValue;
    public float Average() => (MinValue + MaxValue) / 2;

    public float Get()
    {
        var random = new Random();
        return random.NextSingle() * (MaxValue - MinValue);
    }
}