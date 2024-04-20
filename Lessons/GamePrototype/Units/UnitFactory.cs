namespace BasicCsharp.Lessons.GamePrototype.Units;

public class UnitFactory
{
    public static Player CreatePlayer(string name) => new(name);
    public static EnemyNPC CreateGoblin() => new("Goblin");
    public static EnemyNPC CreateOrc() => new("Orc", 100, 10, 2);
}