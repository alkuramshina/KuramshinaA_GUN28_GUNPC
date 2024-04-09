using BasicCsharp.Lessons.Classes;

namespace BasicCsharp.Lessons.Memory;

public static class Memory
{
    public static void Run()
    {
        var unit1 = new Unit("Unit 1", 20);
        var unit2 = new Unit("Unit 2", 20);

        var weapon = new Weapon(7, 10);

        var shell = new Shell();
        var boots = new Boots {Armor = .5f};
        var helm = new Helm { Armor = .5f };
        
        unit1.EquipWeapon(weapon);
        
        unit2.EquipHelm(helm);
        unit2.EquipBoots(boots);
        unit2.EquipShell(shell);
        
        Console.WriteLine("Боец 1:");
        Console.WriteLine($"{unit1.Name}: здоровье {unit1.Health}, урон {unit1.Damage}");
            
        Console.WriteLine("Боец 2:");
        Console.WriteLine($"{unit2.Name}: здоровье {unit2.Health}, урон {unit2.Damage}");

        var combat = new Combat();
        
        combat.StartCombat(unit1, unit2);
        combat.ShowResults();
        
        Console.WriteLine("Бой окончен.");
    }
}