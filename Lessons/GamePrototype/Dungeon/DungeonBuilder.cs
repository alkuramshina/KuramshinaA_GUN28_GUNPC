using BasicCsharp.Lessons.GamePrototype.Items.Economic;
using BasicCsharp.Lessons.GamePrototype.Items.Economic.Consumables;
using BasicCsharp.Lessons.GamePrototype.Items.Equipment;
using BasicCsharp.Lessons.GamePrototype.Units;

namespace BasicCsharp.Lessons.GamePrototype.Dungeon;

public static class DungeonBuilder
{
    public static Room Build(DifficultyLevel difficulty)
    {
        var entrance = new Room("Entrance");

        var enemyRoom = new EnemyRoom("Enemy!",
            difficulty switch
            {
                DifficultyLevel.Easy => UnitFactory.CreateGoblin(),
                DifficultyLevel.Hard => UnitFactory.CreateOrc(),
                _ => throw new ArgumentOutOfRangeException(nameof(difficulty))
            });
        
        var emptyRoom = new Room("Empty room");

        var roomWithHealingPotion = new LootRoom("Healing potion!", new HealingPotion());
        var roomWithWhetstone = new LootRoom("Whetstone!", new Whetstone());

        var roomWithSword = new LootRoom("Sword!", 
            new Weapon("Shiny sword", WeaponType.Sword, 100, 10, 15));
        
        var roomWithBow = new LootRoom("Bow!", 
            new Weapon("Powerful bow", WeaponType.Bow, 100, 10, 15));
        
        var roomWithArmor = new LootRoom("Armor!", 
            new Armor("Shiny armor", 1000, ArmorType.Armor, 10, 5));
        
        var roomWithHelmet = new LootRoom("Helmet!", 
            new Armor("Shiny helmet", 500, ArmorType.Helmet, 5, 3));

        var goldRoom = new LootRoom("Gold!", new Gold(100));

        entrance.TrySetDirection(Direction.Left, roomWithArmor);
        entrance.TrySetDirection(Direction.Right, roomWithSword);

        roomWithArmor.TrySetDirection(Direction.Left, roomWithHealingPotion);
        roomWithArmor.TrySetDirection(Direction.Forward, enemyRoom);
        roomWithArmor.TrySetDirection(Direction.Right, roomWithWhetstone);

        roomWithSword.TrySetDirection(Direction.Left, roomWithHealingPotion);
        roomWithSword.TrySetDirection(Direction.Forward, enemyRoom);
        roomWithSword.TrySetDirection(Direction.Right, roomWithWhetstone);
        
        roomWithHealingPotion.TrySetDirection(Direction.Left, roomWithBow);
        roomWithHealingPotion.TrySetDirection(Direction.Forward, enemyRoom);
        roomWithHealingPotion.TrySetDirection(Direction.Right, roomWithHelmet);

        roomWithWhetstone.TrySetDirection(Direction.Left, roomWithBow);
        roomWithWhetstone.TrySetDirection(Direction.Forward, enemyRoom);
        roomWithWhetstone.TrySetDirection(Direction.Right, roomWithHelmet);

        roomWithBow.TrySetDirection(Direction.Forward, enemyRoom);
        roomWithHelmet.TrySetDirection(Direction.Forward, enemyRoom);

        enemyRoom.TrySetDirection(Direction.Left, emptyRoom);
        enemyRoom.TrySetDirection(Direction.Right, goldRoom);

        return entrance;
    }

    public enum DifficultyLevel
    {
        Easy,
        Hard
    }
}