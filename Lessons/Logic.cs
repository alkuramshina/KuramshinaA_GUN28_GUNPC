namespace BasicCsharp.Lessons;

public static class Logic
{
    public static void Run()
    {
        int firstInt, secondInt;
        
        Console.WriteLine("Input first int:");
        while (!int.TryParse(Console.ReadLine(), out firstInt))
        {
            Console.WriteLine("Error: input must be integer!");
        }

        Console.WriteLine("Input second int:");
        while (!int.TryParse(Console.ReadLine(), out secondInt))
        {
            Console.WriteLine("Error: input must be integer!");
        }

        Console.WriteLine("Input operator (& | or ^):");

        var validOperators = new[] { "&", "|", "^" };

        var inputOperator = Console.ReadLine();
        while (!validOperators.Contains(inputOperator))
        {
            Console.WriteLine("Error: operator must be & | или ^");
            inputOperator = Console.ReadLine();
        }

        var operationResult = inputOperator switch
        {
            "&" => firstInt & secondInt,
            "|" => firstInt | secondInt,
            "^" => firstInt ^ secondInt,
            _ => throw new ArgumentOutOfRangeException(inputOperator)
        };

        Console.WriteLine($"Decimal: {firstInt} {inputOperator} {secondInt} = {operationResult}");
        Console.WriteLine($"Binary: {firstInt} {inputOperator} {secondInt} = {Convert.ToString(operationResult, 2)}");
        Console.WriteLine($"Hexadecimal: {firstInt} {inputOperator} {secondInt} = {operationResult:X}");
    }
}