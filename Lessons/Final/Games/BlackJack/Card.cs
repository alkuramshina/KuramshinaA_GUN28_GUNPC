namespace BasicCsharp.Lessons.Final.Games.BlackJack;

public struct Card
{
    public Card(CardType type, CardSuit suit, int value)
    {
        Type = type;
        Suit = suit;
        Value = value;
    }

    public CardType Type { get; }
    public CardSuit Suit { get; }

    public int Value { get; }

    public static bool IsElder(CardType type)
        => new[] { CardType.Ace, CardType.King, CardType.Queen, CardType.Jack }
            .Contains(type);
}

public enum CardSuit
{
    Diamonds = 1,
    Hearts,
    Spades,
    Clubs
}

public enum CardType
{
    Two = 2,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King,
    Ace
}