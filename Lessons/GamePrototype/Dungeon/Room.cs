using BasicCsharp.Lessons.GamePrototype.Units;

namespace BasicCsharp.Lessons.GamePrototype.Dungeon;

public class Room
{
    protected string Name { get; }
    public Room(string name)
    {
        Name = name;
    }
    
    public readonly Dictionary<Direction, Room> NextRooms = new();
    public bool IsFinal => NextRooms.Count == 0;

    public bool TrySetDirection(Direction direction, Room room)
    {
        if (NextRooms.ContainsKey(direction))
        {
            Console.WriteLine($"Room {room.Name} already has room for {direction}.");
            return false;
        }
        
        NextRooms.Add(direction, room);
        return true;
    }

    public virtual void RunEncounter(Player player, out bool success)
    {
        Console.WriteLine($"Entered room {Name}. Room is empty!");
        success = true;
    }
}