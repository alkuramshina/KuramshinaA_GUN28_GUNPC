using System.Text;

namespace BasicCsharp.Lessons;

public static class Strings
{
    public static void Run()
    {
        Concat();
        Console.WriteLine();
        
        GreetUser();
        Console.WriteLine();
        
        StringInfo();
        Console.WriteLine();
        
        FirstSymbols();
        Console.WriteLine();
        
        StringBuilder();
        Console.WriteLine();
        
        FindAndReplace();
        Console.WriteLine();
    }

    // Напишите метод, который принимает две строки и возвращает конкатенацию этих строк.
    private static void Concat()
    {
        Console.WriteLine("Input first string:");
        var firstString = Console.ReadLine();
        
        Console.WriteLine("Input second string:");
        var secondString = Console.ReadLine();
        
        Console.WriteLine($"Concat: {string.Concat(firstString, secondString)}");
    }

    // Напишите метод GreetUser, который получает имя (string) и возраст (int),
    // а затем использует строку с форматом $ для возврата сообщения вида “Hello, [Name]! You are [Age] years old.”
    // Второе предложение должно идти с новой строки (используйте escape последовательность)
    private static void GreetUser()
    {
        Console.WriteLine("Input user name:");
        var userName = Console.ReadLine();
        
        Console.WriteLine("Input user age:");
        var userAge = Console.ReadLine();
        
        Console.WriteLine($"Hello, {userName}!\nYou are {userAge} years old.");
    }

    // Закончите метод, который получает строку и возвращает новую строку с информацией:
    // Количество символов в строке
    // Строку в верхнем регистре
    // Строку в нижнем регистре
    // Используйте методы класса string
    private static void StringInfo()
    {
        Console.WriteLine("Input string:");
        var input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("String is empty, nothing more to say.");
        }
        else
        {
            Console.WriteLine($"String '{input}':\n " +
                              $"{input.Length} symbols,\n " +
                              $"upper: {input.ToUpperInvariant()},\n " +
                              $"lower: {input.ToLowerInvariant()},\n ");
        }
    }
    
    // Напишите метод, который возвращает первые 5 символов строки. Используйте метод Substring
    private static void FirstSymbols()
    {
        Console.WriteLine("Input string:");
        var input = Console.ReadLine();

        Console.WriteLine(string.IsNullOrEmpty(input)
            ? "String is empty, nothing more to say."
            : $"First 5 symbols are: '{input[..5]}'");
    }
    
    // Напишите метод, принимающий на вход массив из строк и возвращающий экземпляр StringBuilder.
    // Вам нужно создать экземпляр StringBuilder, который объединяет все элементы входного массива в одно предложение,
    // каждый элемент - через пробел.
    // Какой метод StringBuilder вы будете использовать: Append или AppendLine?
    private static void StringBuilder()
    {
        Console.WriteLine("Input string array separated by spaces:");
        var input = Console.ReadLine();
        
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("String is empty, nothing more to say.");
            return;
        }

        var builder = new StringBuilder();
        foreach (var item in input.Split(' '))
        {
            builder.Append($"{item} ");
        }
        
        Console.WriteLine($"Resulting phrase: {builder}");
    }
    
    // Напишите метод, который принимает строку и два слова: одно для поиска и другое для замены.
    // Затем замените все вхождения первого слова на второе слово в введенной строке и верните результат.
    private static void FindAndReplace()
    {
        Console.WriteLine("Input initial string:");
        var initialInput = Console.ReadLine();
        if (string.IsNullOrEmpty(initialInput))
        {
            Console.WriteLine("String is empty, nothing more to say.");
            return;
        }
        
        Console.WriteLine("Input string to find:");
        var findInput = Console.ReadLine();
        if (string.IsNullOrEmpty(findInput))
        {
            Console.WriteLine("String is empty, nothing more to say.");
            return;
        }
        
        if (!initialInput.Contains(findInput))
        {
            Console.WriteLine("Initial string does not contain this string, nothing more to say.");
            return;
        }
        
        Console.WriteLine("Input string to replace with:");
        var replaceInput = Console.ReadLine();
        if (string.IsNullOrEmpty(replaceInput))
        {
            Console.WriteLine("String is empty, nothing more to say.");
            return;
        }
        
        Console.WriteLine($"Result is: {initialInput.Replace(findInput, replaceInput)}");
    }
}