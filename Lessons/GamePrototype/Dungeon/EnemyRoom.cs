using BasicCsharp.Lessons.GamePrototype.Units;

namespace BasicCsharp.Lessons.GamePrototype.Dungeon;

public sealed class EnemyRoom: Room
{
    private EnemyNPC Enemy { get; }
    
    public EnemyRoom(string name, EnemyNPC enemy) : base(name)
    {
        Enemy = enemy;
    }
    
    public override void RunEncounter(Player player, out bool success)
    {
        Console.WriteLine($"Entered room {Name}");

        var combat = new Combat.Combat(player, Enemy);
        combat.Run();

        success = combat.ProtagonistWon;
        if (success)
        {
            player.Loot(Enemy);
        }
    }
}