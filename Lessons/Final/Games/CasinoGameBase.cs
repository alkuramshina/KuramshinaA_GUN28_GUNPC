using BasicCsharp.Lessons.Final.Game.Interfaces;

namespace BasicCsharp.Lessons.Final.Games;

public abstract class CasinoGameBase
{
    public abstract string Name { get; }

    public abstract void PlayGame(IHasBank player, IHasBank dealer);
    protected abstract void FactoryMethod();

    protected virtual void OnWinInvoke(IHasBank player, IHasBank dealer)
    {
        Console.WriteLine("Player won!");
        player.Win(dealer.CurrentBid);

        Console.WriteLine($"You won {dealer.CurrentBid}.");
        Console.WriteLine(dealer.Loose()
            ? "You broke the casino. Now it's closed and empty."
            : $"Current bank: {player.Bank}.");
    }

    protected virtual void OnLooseInvoke(IHasBank player, IHasBank dealer)
    {
        Console.WriteLine("Dealer won!");
        dealer.Win(player.CurrentBid);
        
        Console.WriteLine($"You lost {player.CurrentBid}.");
        Console.WriteLine(player.Loose()
            ? "No money? Kicked!"
            : $"Current bank: {player.Bank}.");
    }

    protected virtual void OnDrawInvoke(IHasBank player, IHasBank dealer)
    {
        Console.WriteLine("It's a draw!");
    }
}

public enum GameResult
{
    Loose,
    Draw,
    Win
}