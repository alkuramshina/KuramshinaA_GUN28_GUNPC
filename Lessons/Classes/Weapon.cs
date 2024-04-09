namespace BasicCsharp.Lessons.Classes;

public class Weapon
{
    public Weapon(string name)
    {
        Name = name;
    }

    public Weapon(string name, float minDamage, float maxDamage)
        : this(name)
    {
        SetDamageParams(maxDamage, minDamage);
    }

    public Weapon(float minDamage, float maxDamage)
        : this("Unnamed weapon")
    {
        SetDamageParams(maxDamage, minDamage);
    }

    private void SetDamageParams(float minDamage, float maxDamage)
    {
        if (minDamage > maxDamage)
        {
            (minDamage, maxDamage) = (maxDamage, minDamage);
            Console.WriteLine($"Данные для урона {Name} введены некорректно и были поменяны местами.");
        }

        if (minDamage < 1f)
        {
            minDamage = 1f;
            Console.WriteLine($"Минимальное значение установлено 1f.");
        }

        if (maxDamage > 10f)
        {
            maxDamage = 10f;
            Console.WriteLine($"Максимальное значение установлено 10f.");
        }

        MaxDamage = maxDamage;
        MinDamage = minDamage;
    }

    public float GetDamage() => (MinDamage + MaxDamage) / 2;

    public string Name { get; private set; }
    public float MinDamage { get; private set; }
    public float MaxDamage { get; private set; }
}