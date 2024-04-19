namespace BasicCsharp.Lessons.Collections;

internal class DictionaryTask : BaseListTask
{
    private readonly Dictionary<string, int> _studentMarks = new();
    private const int StudentCount = 3;

    public override void TaskLoop()
    {
        Console.WriteLine($"Second task: dictionary with student marks. To exit use '{ExitWord}'.");

        Console.WriteLine($"Input names and marks for {StudentCount} students");
        while (_studentMarks.Count < StudentCount)
        {
            Console.WriteLine("Input student name:");
            var name = Console.ReadLine();
            if (IsExitWord(name))
            {
                return;
            }
            
            while (name is null || _studentMarks.ContainsKey(name))
            {
                Console.WriteLine("Input valid and non existing student name:");
                name = Console.ReadLine();
                if (IsExitWord(name))
                {
                    return;
                }
            }

            Console.WriteLine("Input student mark (2 to 5):");
            int mark;
            do
            {
                var inputMark = Console.ReadLine();
                if (IsExitWord(inputMark))
                {
                    return;
                }
                
                if (!int.TryParse(Console.ReadLine(), out mark)
                 || mark < 2 || mark > 5)
                {
                    Console.WriteLine("Input valid and non existing mark for student:");
                }
                
            } while (mark is < 2 or > 5);

            _studentMarks.Add(name, mark);
        }
        
        OutputCollectionItems(_studentMarks);

        while (true)
        {

            Console.WriteLine("Input student name to check their mark:");
            var inputName = Console.ReadLine();
            if (IsExitWord(inputName))
            {
                return;
            }
            
            if (inputName is not null && _studentMarks.TryGetValue(inputName, out var studentMark))
            {
                Console.WriteLine($"{inputName}: {studentMark}");
            }
            else
            {
                Console.WriteLine("Student doesn't exist.");
            }
        }
    }
}