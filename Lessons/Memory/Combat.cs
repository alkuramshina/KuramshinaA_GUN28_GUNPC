using BasicCsharp.Lessons.Classes;

namespace BasicCsharp.Lessons.Memory;

public class Combat
{
    public List<Rate> RateLog { get; } = new ();

    public void StartCombat(Unit unit1, Unit unit2)
    {
        bool unit1IsDead = false, unit2IsDead = false;
        
        while (!unit1IsDead && !unit2IsDead)
        {
            var random = new Random();
            var diceRoll = random.Next(1, 10);

            if (diceRoll % 2 == 0)
            {
                unit1IsDead = unit1.SetDamage(unit2.Damage);
                RateLog.Add(new Rate(unit1, (int) unit2.Damage, unit1.Health));
            }
            else
            {
                unit2IsDead = unit2.SetDamage(unit1.Damage);
                RateLog.Add(new Rate(unit2, (int) unit1.Damage, unit2.Health));
            }
        }
        
    }

    public void ShowResults()
    {
        foreach (var rate in RateLog)
        {
            Console.WriteLine($"Боец {rate.Unit.Name} нанёс урон {rate.Damage} и оставил {rate.Health} здоровья.");
        }
    }
}