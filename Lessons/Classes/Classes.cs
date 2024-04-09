namespace BasicCsharp.Lessons.Classes;

public static class Classes
{
    public static void Run()
    {
        Console.WriteLine("Подготовка к бою:");

        Console.WriteLine("Введите имя бойца:");
        var name = Console.ReadLine();
        
        Console.WriteLine("Введите начальное здоровье бойца (10-100):");
        if (!float.TryParse(Console.ReadLine(), out var baseHealth))
        {
            Console.WriteLine("Нулевое значение.");
        }
        
        var unit = new Unit(name, baseHealth);
        
        Console.WriteLine("Введите значение брони шлема от 0, до 1:");
        if (!float.TryParse(Console.ReadLine(), out var helmArmor))
        {
            Console.WriteLine("Нулевое значение.");
        }

        var helm = new Helm { Armor = helmArmor };
        unit.EquipHelm(helm);
        
        Console.WriteLine("Введите значение брони кирасы от 0, до 1:");
        if (!float.TryParse(Console.ReadLine(), out var shellArmor))
        {
            Console.WriteLine("Нулевое значение.");
        }
        
        var shell = new Shell { Armor = shellArmor };
        unit.EquipShell(shell);
        
        Console.WriteLine("Введите значение брони сапог от 0, до 1:");
        if (!float.TryParse(Console.ReadLine(), out var bootsArmor))
        {
            Console.WriteLine("Нулевое значение.");
        }
        
        var boots = new Boots { Armor = bootsArmor };
        unit.EquipBoots(boots);
        
        Console.WriteLine("Укажите минимальный урон оружия (1-10):");
        if (!float.TryParse(Console.ReadLine(), out var minDamage))
        {
            Console.WriteLine("Нулевое значение.");
        }
        
        Console.WriteLine("Укажите максимальный урон оружия (10 и более):");
        if (!float.TryParse(Console.ReadLine(), out var maxDamage))
        {
            Console.WriteLine("Нулевое значение.");
        }

        var weapon = new Weapon(minDamage, maxDamage);
        unit.EquipWeapon(weapon);
        
        Console.WriteLine($"Общий показатель брони равен: {unit.Armor}");
        Console.WriteLine($"Фактическое значение здоровья равно: {unit.GetRealHealth()}");
    }
}