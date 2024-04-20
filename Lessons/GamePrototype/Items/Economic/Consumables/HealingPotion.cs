namespace BasicCsharp.Lessons.GamePrototype.Items.Economic.Consumables;

public class HealingPotion : ConsumableEconomicItem
{
    public HealingPotion(uint healthPointsToRestore = 4) : base("Healing potion", 10)
    {
        HealthPointsToRestore = healthPointsToRestore;
    }

    public readonly uint HealthPointsToRestore;
}