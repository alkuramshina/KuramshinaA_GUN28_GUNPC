using BasicCsharp.Lessons.Final.Games;
using BasicCsharp.Lessons.Final.Games.BlackJack;
using BasicCsharp.Lessons.Final.Games.Dice;
using BasicCsharp.Lessons.Final.SaveLoad;

namespace BasicCsharp.Lessons.Final.Game.Builder;

public class CasinoBuilder : IBuilderSupporter<FileSystemSaveLoadService<Player>, Player, CasinoGameBase>
{
    public FileSystemSaveLoadService<Player> BuildSaveLoadService()
    {
        return new FileSystemSaveLoadService<Player>();
    }

    public Dictionary<string, CasinoGameBase> BuildGames()
    {
        var games = new Dictionary<string, CasinoGameBase>();

        var blackjack = new BlackJackGame(52);
        games.Add(blackjack.Name, blackjack);
        
        var dice = new DiceGame(10, 1, 6);
        games.Add(dice.Name, dice);

        return games;
    }
}