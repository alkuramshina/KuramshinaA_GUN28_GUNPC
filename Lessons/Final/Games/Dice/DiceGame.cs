using BasicCsharp.Lessons.Final.Game.Interfaces;

namespace BasicCsharp.Lessons.Final.Games.Dice;

public sealed class DiceGame : CasinoGameBase
{
    public override string Name => "Dice";
    
    private readonly int _diceCount;
    private readonly int _minValue;
    private readonly int _maxValue;

    private readonly List<Dice> _pool = new();
    
    private event Action<IHasBank, IHasBank> OnWin;
    private event Action<IHasBank, IHasBank> OnLoose;
    private event Action<IHasBank, IHasBank> OnDraw;
    
    public DiceGame(int diceCount,
        int minValue, int maxValue)
    {
        _diceCount = diceCount;
        _minValue = minValue;
        _maxValue = maxValue;
        
        FactoryMethod();
        
        OnWin += OnWinInvoke;
        OnLoose += OnLooseInvoke;
        OnDraw += OnDrawInvoke;
    }

    protected override void FactoryMethod()
    {
        for (var i = 0; i < _diceCount; i++)
        {
            _pool.Add(new Dice(_minValue, _maxValue));
        }
    }

    public override void PlayGame(IHasBank player, IHasBank dealer)
    {
        var playerScore = 0;
        var dealerScore = 0;
        
        Console.WriteLine($"Dice game with {_diceCount} dices (values from {_minValue} to {_maxValue}) starts.");
        Console.WriteLine("Player's turn. Input anything to roll the Dice!");
        Console.ReadLine();
        
        playerScore += RollDice();
        Console.WriteLine($"Score: {playerScore}");
        Console.WriteLine();
        
        Console.WriteLine("Dealer's turn. Rolling dice.");
        dealerScore += RollDice();
        Console.WriteLine($"Score: {dealerScore}");
        Console.WriteLine();

        if (playerScore > dealerScore)
        {
            OnWin(player, dealer);
            return;
        }

        if (dealerScore > playerScore)
        {
            OnLoose(player, dealer);
            return;
        }

        if (dealerScore == playerScore)
        {
            OnDraw(player, dealer);
        }
    }

    private int RollDice()
    {
        var resultString = string.Empty;
        var resultSum = 0;
        
        foreach (var roll in _pool.Select(dice => dice.Roll()))
        {
            resultString += $"{roll} ";
            resultSum += roll;
        }
            
        Console.WriteLine($"Dice roll: {resultSum} [{resultString}].");

        return resultSum;
    }
    
    private void DoOnWin()
    {
        Console.WriteLine("Player won!");
    }
    
    private void DoOnLoose()
    {
        Console.WriteLine("Dealer won!");
    }
    
    private void DoOnDraw()
    {
        Console.WriteLine("It's a draw!");
    }
}