namespace BasicCsharp.Lessons.GamePrototype.Items.Economic.Consumables;

public abstract class ConsumableEconomicItem : EconomicItem
{
    protected ConsumableEconomicItem(string name, uint price) : base(name, price)
    {
    }

    protected override bool IsStackable => false;

    public override string ToString()
        => $"{Name} x {Amount} ({Price * Amount} gp)";
}