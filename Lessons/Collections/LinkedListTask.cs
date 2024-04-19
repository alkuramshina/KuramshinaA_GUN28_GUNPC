namespace BasicCsharp.Lessons.Collections;

internal class LinkedListTask: BaseListTask
{
    private readonly LinkedList<string> _linkedList = new();

    public override void TaskLoop()
    {
        Console.WriteLine($"Third task: linked list. To exit use '{ExitWord}'.");

        Console.WriteLine($"Input 3 to 6 objects for linked list (separated by space):");
        var input = Console.ReadLine();
        if (IsExitWord(input))
        {
            return;
        }

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Your loss.");
        }

        foreach (var item in input.Split(' '))
        {
            _linkedList.AddLast(item);
        }
        
        Console.WriteLine("Initial order:");
        OutputCollectionItems(_linkedList);
        
        Console.WriteLine("Reverse order:");
        OutputCollectionItems(_linkedList.Reverse());
    }
}