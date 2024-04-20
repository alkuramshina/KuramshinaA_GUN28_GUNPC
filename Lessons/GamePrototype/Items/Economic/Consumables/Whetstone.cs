namespace BasicCsharp.Lessons.GamePrototype.Items.Economic.Consumables;

public class Whetstone : ConsumableEconomicItem
{
    public Whetstone(uint durabilityPointsToRestore = 4) : base("Whetstone", 20)
    {
        DurabilityPointsToRestore = durabilityPointsToRestore;
    }

    public readonly uint DurabilityPointsToRestore;
}