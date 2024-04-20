namespace BasicCsharp.Lessons.GamePrototype.Items.Economic;

public class Gold : EconomicItem
{
    public Gold(uint amount) : base(nameof(Gold), 1)
    {
        Amount = amount;
    }

    protected override bool IsStackable => true;

    public override string ToString()
        => $"{Amount} {Name}";
}