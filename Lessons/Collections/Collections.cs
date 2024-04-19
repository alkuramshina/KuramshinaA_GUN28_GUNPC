namespace BasicCsharp.Lessons.Collections;

public static class Collections
{
    public static void Run()
    {
        Console.WriteLine("Enter 1, 2 or 3 to check task 1, 2 or 3");

        var input = Console.ReadLine();
        
        if (int.TryParse(input, out int taskNumber))
        {
            RunTask(taskNumber);
        }
    }
    
    private static void RunTask(int taskNumber)
    {
        BaseListTask task = taskNumber switch
        {
            1 => new ListTask(),
            2 => new DictionaryTask(),
            3 => new LinkedListTask(),
            _ => throw new ArgumentOutOfRangeException(nameof(taskNumber), "Task number was incorrect")
        };

        task.TaskLoop();
    }
}
