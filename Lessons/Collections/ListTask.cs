namespace BasicCsharp.Lessons.Collections;

internal class ListTask : BaseListTask
{
    private readonly List<string> _basicList = new() { "first", "second", "third" };

    public override void TaskLoop()
    {
        Console.WriteLine($"First task: basic list. To exit use '{ExitWord}'.");
        OutputCollectionItems(_basicList);

        while (true)
        {
            Console.WriteLine("Input new value to add to the end of the list:");
            var newValue = Console.ReadLine();
            if (IsExitWord(newValue))
            {
                break;
            }

            _basicList.Add(newValue);
            OutputCollectionItems(_basicList);

            Console.WriteLine("Input new value to add in the middle of the list:");
            newValue = Console.ReadLine();
            if (IsExitWord(newValue))
            {
                break;
            }
            
            _basicList.Insert(_basicList.Count / 2, newValue);
            OutputCollectionItems(_basicList);
        }
    }
}