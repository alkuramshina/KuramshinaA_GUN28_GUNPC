using BasicCsharp.Lessons.GamePrototype.Items.Economic;

namespace BasicCsharp.Lessons.GamePrototype.Units;

public class Inventory
{
    private readonly uint _inventorySize;
    public Inventory(uint inventorySize)
    {
        _inventorySize = inventorySize;
    }
        
    
    private readonly List<EconomicItem> _items = new ();
    public IEnumerable<EconomicItem> Items => _items;

    public bool TryAdd(EconomicItem item)
    {
        var existingItem = _items.FirstOrDefault(i => i.Name == item.Name);
        if (existingItem is not null && existingItem.TryStack())
        {
            return true;
        }

        if (_items.Count == _inventorySize)
        {
            return false;
        }

        _items.Add(item);
        return true;
    }

    public bool TryRemove(EconomicItem inventoryItem)
    {
        if ( _items.Count == 0 || !_items.Contains(inventoryItem)) 
        {
            return false;
        }
        
        _items.Remove(inventoryItem);
        return true;
    }

    public bool IsEmpty => _items.Count == 0;
}

