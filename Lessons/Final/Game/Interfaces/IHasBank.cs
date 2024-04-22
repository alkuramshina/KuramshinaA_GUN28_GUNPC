namespace BasicCsharp.Lessons.Final.Game.Interfaces;

public interface IHasBank
{
    uint Bank { get; }
    uint CurrentBid { get; }

    public void Bid(uint sum);
    public void Win(uint sum);
    public bool Loose();
    
    public const uint MaxBank = 200;
}