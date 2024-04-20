namespace BasicCsharp.Lessons.GamePrototype.Units;

public class EnemyNPC : Unit
{
    public EnemyNPC(string name, uint maxHealth = 18, uint baseDamage = 2, uint inventorySize = 1)
        : base(name, maxHealth, baseDamage, inventorySize)
    {
    }

    protected override uint CalculateAppliedDamage(uint damage) => damage;
    public override uint GetUnitDamage() => BaseDamage;
    public override void HandleCombatComplete() => Health = MaxHealth;
}