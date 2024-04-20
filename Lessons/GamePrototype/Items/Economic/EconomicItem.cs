namespace BasicCsharp.Lessons.GamePrototype.Items.Economic;

public abstract class EconomicItem : Item
{
    protected EconomicItem(string name, uint price) : base(name, price)
    {
    }

    protected abstract bool IsStackable { get; }
    protected uint Amount { get; set; } = 1;
    
    public bool TryStack()
    {
        if (!IsStackable)
        {
            return false;
        }

        Amount++;
        return true;
    }
}