using BasicCsharp.Lessons.Final.Game.Interfaces;

namespace BasicCsharp.Lessons.Final.Game;

public class Player : IHasBank
{
    public string Name { get; }
    public uint Bank { get; private set; }
    public uint CurrentBid { get; private set; }

    public void Bid(uint sum) => CurrentBid = Math.Clamp(sum, 1, Bank);

    public void Win(uint sum) => Bank += sum;
    public bool Loose()
    {
        Bank = Math.Clamp(Bank - CurrentBid, 0, Bank);
        return Bank == 0;
    }

    public Player(string name, uint bank)
    {
        Name = name;
        Bank = bank;
    }

    public static string GenerateSaveDataPath(string playerName) => $"{playerName}.json";
}