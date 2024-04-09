namespace BasicCsharp.Lessons.Classes;

public class Unit
{
    public Unit(float baseHealth): this("Unknown Unit", baseHealth)
    {
    }
    
    public Unit(string name, float baseHealth)
    {
        Name = name;
        Health = baseHealth;
    }
    
    public string Name { get; private set; }
    public float Health { get; private set; }

    private const float BaseDamage = 5f;

    public float Damage => Weapon?.GetDamage() ?? 0 + BaseDamage;
    public float Armor => Helm?.Armor ?? 0
            + Shell?.Armor ?? 0
            + Boots?.Armor ?? 0;
    
    private Weapon? Weapon { get; set; }
    private Helm? Helm { get; set; }
    private Shell? Shell { get; set; }
    private Boots? Boots { get; set; }

    public float GetRealHealth() => Health * (1f + Armor);
    
    public bool SetDamage(float value)
    {
        Health -= value * Armor;
        return Health <= 0f;
    }

    public void EquipWeapon(Weapon weapon) => Weapon = weapon;
    public void EquipHelm(Helm helm) => Helm = helm;
    public void EquipShell(Shell shell) => Shell = shell;
    public void EquipBoots(Boots boots) => Boots = boots;
}