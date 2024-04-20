using BasicCsharp.Lessons.GamePrototype.Dungeon;
using BasicCsharp.Lessons.GamePrototype.Units;

namespace BasicCsharp.Lessons.GamePrototype;

public class GameLoop
{
    private Player _player;
    private Room _dungeonStart;

    private int _roomCount;
    
    public void Start()
    {
        _player = InitializePlayer();
        _dungeonStart = InitializeDungeon();
        
        Go();
    }

    private void Go()
    {
        var currentRoom = _dungeonStart;
        Console.WriteLine("Entering the Dungeon");
        
        while (true)
        {
            currentRoom.RunEncounter(_player, out var success);
            _roomCount++;

            if (!success)
            {
                Console.WriteLine("Game over!");
                break;
            }
            
            if (currentRoom.IsFinal)
            {
                break;
            }
            
            currentRoom = NavigateDungeon(currentRoom);
        }

        Console.WriteLine();
        Console.WriteLine($"Congratulations {_player.Name}!\n" +
                          $"Rooms completed: {_roomCount}.\n" +
                          $"Your final stats are:\n" +
                          $"{_player}");
    }

    private Room NavigateDungeon(Room currentRoom)
    {
        Console.WriteLine("Where to go next?");
        foreach (var room in currentRoom.NextRooms)
        {
            Console.Write($"{room.Key}: {(int)room.Key}\t");
        }

        Console.WriteLine();

        while (true)
        {
            if (Enum.TryParse<Direction>(Console.ReadLine(), out var direction))
            {
                return currentRoom.NextRooms[direction];
            }

            Console.WriteLine("Wrong direction!");
        }
    }

    private static Room InitializeDungeon()
    {
        while (true)
        {
            Console.WriteLine("Choose dungeon difficulty: EASY - 1, HARD - 2");

            if (Enum.TryParse<DungeonBuilder.DifficultyLevel>(Console.ReadLine(), out var difficulty))
            {
                return DungeonBuilder.Build(difficulty);
            }
        }
    }

    private static Player InitializePlayer()
    {
        Console.WriteLine("Welcome player!");
        Console.WriteLine("Enter your name:");

        var playerName = Console.ReadLine();

        while (string.IsNullOrEmpty(playerName))
        {
            Console.WriteLine("Enter your name:");
            playerName = Console.ReadLine();
        }
        
        Console.WriteLine($"Hello {playerName}!");
        
        return UnitFactory.CreatePlayer(playerName);
    }
}