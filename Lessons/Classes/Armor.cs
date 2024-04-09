namespace BasicCsharp.Lessons.Classes;

public abstract class ArmorItem
{
    public ArmorItem()
    {
        Name = GetDefaultName();
    }

    public ArmorItem(string name)
    {
        Name = name;
    }

    protected abstract string GetDefaultName();

    public string Name { get; }

    private float ArmorValue;

    public float Armor
    {
        get => ArmorValue;
        set
        {
            ArmorValue = Math.Clamp(value, 0f, 10f);
            if (value is < 0f or > 10f)
            {
                Console.WriteLine("Значение брони было задано некорректно.");
            }
        }
    }
}

public class Shell : ArmorItem
{
    public Shell() : base()
    {
    }
    
    public Shell(string? name) : base(name)
    {
    }

    protected override string GetDefaultName() => nameof(Shell);
}

public class Helm : ArmorItem
{
    public Helm() : base()
    {
    }

    public Helm(string? name) : base(name)
    {
    }

    protected override string GetDefaultName() => nameof(Helm);
}

public class Boots : ArmorItem
{
    public Boots() : base()
    {
    }
    
    public Boots(string? name) : base(name)
    {
    }

    protected override string GetDefaultName() => nameof(Boots);
}