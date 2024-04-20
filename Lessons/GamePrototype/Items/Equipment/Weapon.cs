using BasicCsharp.Lessons.GamePrototype.Units;

namespace BasicCsharp.Lessons.GamePrototype.Items.Equipment;

public class Weapon : EquipmentItem
{
    public Weapon(string name, WeaponType type, uint price,
        uint damage,
        uint maxDurability) 
        : base(name, price, maxDurability)
    {
        Type = type;
        Damage = damage;
    }

    public WeaponType Type { get; }
    public uint Damage { get; }

    public override EquipmentSlot EquipmentSlot => EquipmentSlot.Weapon;
}

public enum WeaponType
{
    Sword = 1,
    Bow
}