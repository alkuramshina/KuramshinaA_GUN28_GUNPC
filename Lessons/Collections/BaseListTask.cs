using System.Collections;

namespace BasicCsharp.Lessons.Collections;

internal abstract class BaseListTask
{
    public abstract void TaskLoop();
    protected const string ExitWord = "q";
    protected static bool IsExitWord(string? input)
        => input is not null && input.Equals(ExitWord);
    

    protected void OutputCollectionItems(IEnumerable list)
    {
        var collectionString = list.Cast<object?>()
            .Aggregate(string.Empty, (current, item) => current + $"{item}, ");

        Console.WriteLine($"Collection contains: {collectionString[..^2]}");
    }
}