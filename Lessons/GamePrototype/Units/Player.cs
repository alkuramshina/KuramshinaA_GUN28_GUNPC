using System.Text;
using BasicCsharp.Lessons.GamePrototype.Items;
using BasicCsharp.Lessons.GamePrototype.Items.Economic;
using BasicCsharp.Lessons.GamePrototype.Items.Economic.Consumables;
using BasicCsharp.Lessons.GamePrototype.Items.Equipment;

namespace BasicCsharp.Lessons.GamePrototype.Units;

public class Player : Unit
{
    private readonly Dictionary<EquipmentSlot, EquipmentItem> _equipment = new();

    public Player(string name, uint maxHealth = 30, uint baseDamage = 6, uint inventorySize = 3)
        : base(name, maxHealth, baseDamage, inventorySize)
    {
    }
    
    public override uint GetUnitDamage()
    {
        if (_equipment.TryGetValue(EquipmentSlot.Weapon, out var item) && item is Weapon weapon)
        {
            return BaseDamage + weapon.Damage;
        }

        return BaseDamage;
    }

    protected override uint CalculateAppliedDamage(uint damage)
    {
        if (_equipment.TryGetValue(EquipmentSlot.Armor, out var item) && item is Armor armor)
        {
            damage = armor.ProtectFrom(damage);
        }

        return damage;
    }

    public override void HandleCombatComplete()
    {
        var consumedItems = Inventory.Items
            .Where(TryConsume)
            .ToList();

        foreach (var consumedItem in consumedItems)
        {
            Console.WriteLine($"Consumed {consumedItem.Name}");
            Inventory.TryRemove(consumedItem);
        }
    }

    private bool TryConsume(EconomicItem item)
    {
        switch (item)
        {
            case HealingPotion healingPotion:
                Health += healingPotion.HealthPointsToRestore;
                return true;
            case Whetstone whetstone:
            {
                if (_equipment.TryGetValue(EquipmentSlot.Armor, out var armor))
                {
                    armor.Fix(whetstone.DurabilityPointsToRestore);
                }
            
                if (_equipment.TryGetValue(EquipmentSlot.Weapon, out var weapon))
                {
                    weapon.Fix(whetstone.DurabilityPointsToRestore);
                }
                
                return true;
            }
        }

        return false;
    }
    
    public void PickItem(Item item)
    {
        // Equip
        if (item is EquipmentItem equipmentItem)
        {
            if (_equipment.TryAdd(equipmentItem.EquipmentSlot, equipmentItem)) return;
            
            while (true)
            {
                Console.WriteLine($"{equipmentItem.EquipmentSlot} is already filled. " +
                                  $"Would you like to swap {_equipment[equipmentItem.EquipmentSlot].Name} to {equipmentItem.Name}? Y/N");

                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)
                    || !input.ToLowerInvariant().Equals("y") && !input.ToLowerInvariant().Equals("n"))
                {
                    continue;
                }

                if (input.ToLowerInvariant().Equals("y"))
                {
                    _equipment[equipmentItem.EquipmentSlot] = equipmentItem;
                }
                    
                break;
            }

            return;
        }

        // Or try to add to inventory
        if (item is not EconomicItem consumable || !Inventory.TryAdd(consumable))
        {
            Console.WriteLine($"Player inventory is full. {item.Name} was discarded.");
        }
        else
        {
            Console.WriteLine($"Picked up {item.Name}.");
        }
    }
    
    public void Loot(Unit unit)
    {
        foreach (var item in unit.Inventory.Items)
        {
            PickItem(item);
        }
    }

    protected override void DamageReceivedHandler()
    {
        if (_equipment.TryGetValue(EquipmentSlot.Armor, out var armor)
            && armor.Break())
        {
            _equipment.Remove(EquipmentSlot.Armor);
        }
        
        base.DamageReceivedHandler();
    }

    protected override void DamageInvokedHandler()
    {
        if (_equipment.TryGetValue(EquipmentSlot.Weapon, out var weapon)
            && weapon.Break())
        {
            _equipment.Remove(EquipmentSlot.Weapon);
        }
        
        base.DamageInvokedHandler();
    }

    public override string ToString()
    {
        var playerData = new StringBuilder();

        playerData.AppendLine($"{Name} {Health} HP");
        playerData.AppendLine($"Base damage: {BaseDamage} / Total damage: {GetUnitDamage()}");

        playerData.AppendLine("Equipment:");
        if (_equipment.Count == 0)
        {
            playerData.AppendLine("Empty.");
        }
        else
        {
            foreach (var item in _equipment)
            {
                playerData.AppendLine($"{item.Key}: {item.Value}");
            }
        }

        playerData.AppendLine("Inventory:");
        if (Inventory.IsEmpty)
        {
            playerData.AppendLine("Empty.");
        }
        else
        {
            foreach (var item in Inventory.Items)
            {
                playerData.AppendLine($"{item}");
            }
        }

        return playerData.ToString();
    }
}

public enum EquipmentSlot
{
    Armor = 1,
    Weapon = 2
}