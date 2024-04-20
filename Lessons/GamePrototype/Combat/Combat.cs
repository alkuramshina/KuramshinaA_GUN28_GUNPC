using BasicCsharp.Lessons.GamePrototype.Units;

namespace BasicCsharp.Lessons.GamePrototype.Combat;

public sealed class Combat
{
    private readonly Unit _protagonist;
    private readonly Unit _antagonist;
    
    public Combat(Unit protagonist, Unit antagonist)
    {
        _protagonist = protagonist;
        _antagonist = antagonist;
    }

    public bool ProtagonistWon;

    public void Run()
    {
        do
        {
            AskCombatInput();
            
            if (Enum.TryParse<RockPaperScissors>(Console.ReadLine(), out var move))
            {
                HandleCombatInput(move);
            }
        } while (!_protagonist.IsDead && !_antagonist.IsDead);

        ProtagonistWon = !_protagonist.IsDead && _antagonist.IsDead;
        
        _protagonist.HandleCombatComplete();
        _antagonist.HandleCombatComplete();
    }

    private void AskCombatInput() => Console.WriteLine(
        $"Type {RockPaperScissors.Rock} = {(int)RockPaperScissors.Rock} " +
        $"or {RockPaperScissors.Paper} = {(int)RockPaperScissors.Paper} " +
        $"or {RockPaperScissors.Scissors} = {(int)RockPaperScissors.Scissors}");
    
    private void HandleCombatInput(RockPaperScissors move)
    {
        var enemyInput = (RockPaperScissors) new Random().Next(1, 3);
        Console.WriteLine($"Result player = {move} and enemy = {enemyInput}");
        switch (move) 
        {
            // player hit
            case RockPaperScissors.Rock when enemyInput == RockPaperScissors.Scissors:
                ApplyDamage(_protagonist, _antagonist);
                break;
            case RockPaperScissors.Scissors when enemyInput == RockPaperScissors.Paper:
                ApplyDamage(_protagonist, _antagonist);
                break;
            case RockPaperScissors.Paper when enemyInput == RockPaperScissors.Rock:
                ApplyDamage(_protagonist, _antagonist);
                break;
            // enemy hit
            case RockPaperScissors.Scissors when enemyInput == RockPaperScissors.Rock:
                ApplyDamage(_antagonist, _protagonist);
                break;
            case RockPaperScissors.Paper when enemyInput == RockPaperScissors.Scissors:
                ApplyDamage(_antagonist, _protagonist);
                break;
            case RockPaperScissors.Rock when enemyInput == RockPaperScissors.Paper:
                ApplyDamage(_antagonist, _protagonist);
                break;
            default:
                Console.WriteLine("Combatants tried to hit, but missed :(");
                break;
        }
    }
    
    private void ApplyDamage(Unit attacker, Unit defender)
    {
        defender.ApplyDamage(attacker);
        
        Console.WriteLine($"{attacker.Name} hits {defender.Name}. " +
                          $"{defender.Name} health {defender.Health}/{defender.MaxHealth}");
        
        if (defender.IsDead) 
        {
            Console.WriteLine($"{defender.Name} is dead!");
        }
    }
}