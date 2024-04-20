namespace BasicCsharp.Lessons.GamePrototype.Units;

public abstract class Unit
{
    public string Name { get; }
    public uint Health { get; protected set; }
    public readonly uint MaxHealth;
    protected uint BaseDamage { get; }

    public readonly Inventory Inventory;

    protected Unit(string name,
        uint maxHealth,
        uint baseDamage,
        uint inventorySize)
    {
        Name = name;
        MaxHealth = maxHealth;
        Health = maxHealth;
        BaseDamage = baseDamage;
        Inventory = new Inventory(inventorySize);;
    }

    public bool IsDead => Health == 0;

    public void ApplyDamage(Unit unit)
    {
        Health = Math.Clamp(Health - CalculateAppliedDamage(unit.GetUnitDamage()), 0, Health);
        unit.DamageInvokedHandler();
        DamageReceivedHandler();
    }

    protected virtual void DamageReceivedHandler()
    {
    }
    
    protected virtual void DamageInvokedHandler()
    {
    }

    protected abstract uint CalculateAppliedDamage(uint damage);

    public abstract uint GetUnitDamage();
    public abstract void HandleCombatComplete();
}