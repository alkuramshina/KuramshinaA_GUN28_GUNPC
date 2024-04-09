using BasicCsharp.Lessons.Memory;

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
        SetDamageParams(minDamage, maxDamage);
    }

    public Weapon(float minDamage, float maxDamage)
        : this("Unnamed weapon")
    {
        SetDamageParams(minDamage, maxDamage);
    }

    private void SetDamageParams(float minDamage, float maxDamage)
    {
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

        Damage = new Interval(minDamage, maxDamage);
    }

    public float GetDamage() => Damage.Average();

    public string Name { get; private set; }
    private Interval Damage { get; set; }
}