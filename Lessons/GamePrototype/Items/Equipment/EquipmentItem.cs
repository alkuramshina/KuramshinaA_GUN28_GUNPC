using BasicCsharp.Lessons.GamePrototype.Units;

namespace BasicCsharp.Lessons.GamePrototype.Items.Equipment;

public abstract class EquipmentItem : Item
{
    private uint _durability;
    private readonly uint _maxDurability;

    public abstract EquipmentSlot EquipmentSlot { get; }

    protected EquipmentItem(string name, uint price, uint maxDurability) : base(name, price)
    {
        _maxDurability = maxDurability;
        _durability = maxDurability;
    }

    public void Fix(uint durabilityPointsToRestore)
    {
        _durability = Math.Clamp(_durability + durabilityPointsToRestore, _durability, _maxDurability);
    }

    public bool Break()
    {
        if (_durability-- > 0)
        {
            return false;
        }
        
        Console.WriteLine($"{Name} is broken!");
        return true;
    }

    public override string ToString()
        => $"{Name} (durability: {_durability})";
}