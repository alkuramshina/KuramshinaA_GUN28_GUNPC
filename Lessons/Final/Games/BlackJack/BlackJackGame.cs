using BasicCsharp.Lessons.Final.Game.Interfaces;

namespace BasicCsharp.Lessons.Final.Games.BlackJack;

public sealed class BlackJackGame : CasinoGameBase
{
    private readonly CardDeck _deck;
    public override string Name => "Blackjack";

    public BlackJackGame(int deckSize)
    {
        _deck = new CardDeck(deckSize);
        FactoryMethod();
    }
    
    private event Action<IHasBank, IHasBank> OnWin;
    private event Action<IHasBank, IHasBank> OnLoose;
    private event Action<IHasBank, IHasBank> OnDraw;

    protected override void FactoryMethod()
    {
        _deck.Create();
        
        OnWin += OnWinInvoke;
        OnLoose += OnLooseInvoke;
        OnDraw += OnDrawInvoke;
    }

    private const int ScoreToEnd = 21;
    public override void PlayGame(IHasBank player, IHasBank dealer)
    {
        var cardQueue = _deck.Shuffle();
        
        Console.WriteLine($"Blackjack game starts. Shuffling {cardQueue.Count} cards.");

        var playerScore = 0;
        var dealerScore = 0;
        
        // first 2 card draws for player and dealer
        Console.WriteLine($"Player's starting cards.");
        DrawCard(cardQueue, ref playerScore);
        DrawCard(cardQueue, ref playerScore);
        Console.WriteLine();
        
        Console.WriteLine($"Dealer's starting cards.");
        DrawCard(cardQueue, ref dealerScore);
        DrawCard(cardQueue, ref dealerScore);
        Console.WriteLine();
        
        // main gameplay
        while (true)
        {
            var response = string.Empty;
            while (string.IsNullOrEmpty(response) || 
                   !response.ToLowerInvariant().Equals("y")
                   && !response.ToLowerInvariant().Equals("n"))
            {
                Console.WriteLine($"Player's turn. Current score: {playerScore}. Do you want to draw a card? Y/N");
                response = Console.ReadLine();
            }
                
            if (response.ToLowerInvariant().Equals("y") && DrawCard(cardQueue, ref playerScore))
            {
                break;
            }

            Console.WriteLine("Dealer's turn:");
            if (DrawCard(cardQueue, ref dealerScore))
            {
                break;
            }
        }

        if (playerScore <= ScoreToEnd && (dealerScore > ScoreToEnd || dealerScore < playerScore))
        {
            OnWin(player, dealer);
            return;
        }

        if (dealerScore <= ScoreToEnd && (playerScore > ScoreToEnd || playerScore < dealerScore))
        {
            OnLoose(player, dealer);
            return;
        }

        if (dealerScore > 21 && playerScore > 21)
        {
            OnDraw(player, dealer);
        }
    }

    private bool DrawCard(Queue<Card> deck, ref int score)
    {
        var card = deck.Dequeue();
        if (deck.Count == 0)
        {
            Console.WriteLine("Deck is finished.");
        }
        
        score += card.Value;
        Console.WriteLine($"{card.Type} of {card.Suit} - {card.Value} points. Score: {score}");

        return score >= 21;
    }
}