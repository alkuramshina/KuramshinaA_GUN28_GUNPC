using BasicCsharp.Lessons.GamePrototype.Units;

namespace BasicCsharp.Lessons.GamePrototype.Items.Equipment;

public class Armor : EquipmentItem
{
    public Armor(string name, uint price,
        ArmorType type,
        uint maxDurability,
        uint protection) 
        : base(name, price, maxDurability)
    {
        Type = type;
        _protection = Math.Clamp(protection, 0, MaxProtection);
    }

    private const uint MaxProtection = 50;
    private readonly uint _protection;
    
    public ArmorType Type { get; }

    public override EquipmentSlot EquipmentSlot => EquipmentSlot.Armor;

    public uint ProtectFrom(uint damage)
    {
        return (uint) (damage * (1 - _protection / 100f));
    }
}

public enum ArmorType
{
    Armor = 1,
    Helmet
}