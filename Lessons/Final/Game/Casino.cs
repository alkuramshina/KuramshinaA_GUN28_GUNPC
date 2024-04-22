using BasicCsharp.Lessons.Final.Game.Builder;
using BasicCsharp.Lessons.Final.Game.Interfaces;
using BasicCsharp.Lessons.Final.Games;
using BasicCsharp.Lessons.Final.SaveLoad;

namespace BasicCsharp.Lessons.Final.Game;

public class Casino : IGame, IHasBank
{
    private readonly ISaveLoadService<Player> _saveLoadService;
    private readonly Dictionary<string, CasinoGameBase> _games;

    private Player _player;

    public uint Bank { get; private set; }
    public uint CurrentBid { get; private set; }

    public void Bid(uint sum) => CurrentBid = Math.Clamp(sum, 1, Bank);
    public void Win(uint sum) => Bank += sum;
    public bool Loose()
    {
        Bank = Math.Clamp(Bank - CurrentBid, 0, Bank);
        return Bank == 0;
    }

    private const uint StartingCasinoBank = 200;
    private const uint StartingPlayerBank = 10;
    
    public Casino()
    {
        var builder = new CasinoBuilder();
        
        _games = builder.BuildGames();
        _saveLoadService = builder.BuildSaveLoadService();

        Bank = StartingCasinoBank;
    }
    
    public void StartGame()
    {
        _player = InitializePlayer();
        Console.WriteLine($"Welcome to Console Casino, {_player.Name}! Your bank: {_player.Bank}");

        var game = ChooseGame();

        TakeBid();
        
        game.PlayGame(_player, this);
        
        GameOver();
    }

    private void GameOver()
    {
        Console.WriteLine("Game is over.");
        _saveLoadService.SaveData(_player, Player.GenerateSaveDataPath(_player.Name));
    }

    private void TakeBid()
    {
        uint playerBid = 0;
        Console.WriteLine($"Place a bid. Your current bank is {_player.Bank}.");

        while (!uint.TryParse(Console.ReadLine(), out playerBid))
        {
            Console.WriteLine($"Place a bid. Your current bank is {_player.Bank}.");
        }

        _player.Bid(playerBid);
        Bid(playerBid);
        
        Console.WriteLine($"Your bid is {_player.CurrentBid}");
        Console.WriteLine($"Dealer's bid is {CurrentBid}");
    }

    private CasinoGameBase ChooseGame()
    {
        var gameKey = string.Empty;
        var gameList = _games.Aggregate(string.Empty, 
            (current, game) => current + $"{game.Key}, ");
        
        while (string.IsNullOrEmpty(gameKey) || !_games.ContainsKey(gameKey))
        {
            Console.WriteLine($"Choose a game to play: {gameList}");
            gameKey = Console.ReadLine();
        }

        return _games[gameKey];
    }

    private Player InitializePlayer()
    {
        var playerName = string.Empty;
        while (string.IsNullOrEmpty(playerName))
        {
            Console.WriteLine("What's your name, Player?");
            playerName = Console.ReadLine();
        }

        var savePath = Player.GenerateSaveDataPath(playerName);
        if (_saveLoadService.SaveExists(savePath))
        {
            var response = string.Empty;
            while (string.IsNullOrEmpty(response) || 
                   !response.ToLowerInvariant().Equals("y")
                   && !response.ToLowerInvariant().Equals("n"))
            {
                Console.WriteLine("You have some saved files. Do you want to continue? Y/N");
                response = Console.ReadLine();
            }

            if (response.ToLowerInvariant().Equals("y"))
            {
                Console.WriteLine("Loading last saved file.");
                var savedData = _saveLoadService.LoadData(savePath);

                return savedData;
            }
        }
        
        Console.WriteLine("Starting new game.");
        return new Player(playerName, StartingPlayerBank);
    }
}