namespace BasicCsharp.Lessons;

public static class Loops
{
    public static void Run()
    {
        DoTask1();
        Console.WriteLine();
        
        DoTask2();
        Console.WriteLine();
        
        DoTask3();
        Console.WriteLine();
        
        DoTask4();
        Console.WriteLine();
    }

    // С помощью цикла for (или while) выведите первые 10 чисел Фиббоначи
    private static void DoTask1()
    {
        int a = 0, b = 1, c;
        Console.Write($"Task 1. Fibonacci: {a} {b} ");

        for(var i = 1; i <= 10; i++)
        {
            c = a + b;
            Console.Write($"{c} ");
            
            a = b;
            b = c;
        }
    }

    // Используя цикл for, выведите все чётные числа от 2 до 20
    private static void DoTask2()
    {
        Console.Write("Task 2. Even numbers: ");
        for (int i = 2; i <= 20; i+=2)
        {
            Console.Write($"{i} ");
        }
    }

    // С помощью вложенных циклов for выведите таблицу умножения от 1 до 5.
    // Каждая строка таблицы должна быть выведена в отдельной строке.
    private static void DoTask3()
    {
        Console.WriteLine("Task 3. Multiplication table:");
        for (int i = 1; i <= 5; i++)
        {
            for (int j = 1; j <= 5; j++)
            {
                Console.Write($"{i}x{j}={i*j}  ");
            }
            
            Console.WriteLine();
        }
    }
    
    // Дана строка string password = “qwerty”;
    // Напишите программу для ввода пароля, которая считывает пользовательский ввод Console.ReadLine.
    // Подсказка: используйте do-while
    private static void DoTask4()
    {
        Console.WriteLine();
        Console.WriteLine("Task 4. Input password:");
        
        const string validPassword = "qwerty";
        var attemts = 100;
        
        var inputPassword = Console.ReadLine();
        while (inputPassword is null || !inputPassword.Equals(validPassword))
        {
            if (--attemts == 0)
            {
                Console.WriteLine("Incorrect password. Try again later: too many incorrects attempts!");
                break;
            }
            
            Console.WriteLine("Incorrect password. Try again:");
            inputPassword = Console.ReadLine();
        }

        if (inputPassword is not null && inputPassword.Equals(validPassword))
        {
            Console.WriteLine("Congratulations!");
        }
    }
}