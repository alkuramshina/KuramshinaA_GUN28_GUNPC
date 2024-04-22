namespace BasicCsharp.Lessons.Final.Games.BlackJack;

public class CardDeck
{
    private readonly int _deckSize;
    private readonly List<Card> _cardPool = new();
        
    public CardDeck(int deckSize)
    {
        _deckSize = deckSize;
    }
    
    public void Create()
    {
        foreach (var cardSuit in Enum.GetValues<CardSuit>())
        {
            foreach (var cardType in Enum.GetValues<CardType>())
            {
                _cardPool.Add(new Card(cardType, cardSuit,
                    Card.IsElder(cardType) ? 10 : (int)cardType));
            }
        }
    }
    
    private static readonly Random Randomizer = new();

    public Queue<Card> Shuffle()
    {
        var cardQueue = new Queue<Card>();
        var cards = new List<Card>(_cardPool);

        var n = _deckSize;
        while (n > 1)
        {
            n--;
            var k = Randomizer.Next(n + 1);
            (cards[k], cards[n]) = (cards[n], cards[k]);
        }

        foreach (var card in cards)
        {
            cardQueue.Enqueue(card);
        }

        return cardQueue;
    }
}