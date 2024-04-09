using BasicCsharp.Lessons.Classes;

namespace BasicCsharp.Lessons.Memory;

public struct Rate
{
    public Unit Unit { get; }
    public int Damage { get; }
    public float Health { get; }

    public Rate(Unit unit,
        int damage,
        float health)
    {
        Unit = unit;
        Damage = damage;
        Health = health;
    }
}