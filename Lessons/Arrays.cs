namespace BasicCsharp.Lessons;

public static class Arrays
{
    public static void Run()
    {
        int[] fibonacci = { 0, 1, 1, 2, 3, 5, 8, 13 };
        OutputArray(nameof(fibonacci), fibonacci);
        Console.WriteLine();
        
        string[] monthNames =
        {
            "January", "February", "March", "April", "May", "June", "July", "August", "September", "October",
            "November", "December"
        };
        OutputArray(nameof(monthNames), monthNames);
        Console.WriteLine();

        int[][] matrix = { new[] { 2, 3, 4 }, new[] { 4, 9, 16 }, new[] { 8, 27, 64 } };
        OutputArray($"{nameof(matrix)}[0]", matrix[0]);
        OutputArray($"{nameof(matrix)}[1]", matrix[1]);
        OutputArray($"{nameof(matrix)}[2]", matrix[2]);
        Console.WriteLine();
        
        double[][] jaggedArray =
        {
            new double[] { 1, 2, 3, 4, 5 },
            new[] { Math.E, Math.PI },
            new[] { Math.Log10(1), Math.Log10(10), Math.Log10(100), Math.Log10(1000) }
        };
        OutputArray($"{nameof(jaggedArray)}[0]", jaggedArray[0]);
        OutputArray($"{nameof(jaggedArray)}[1]", jaggedArray[1]);
        OutputArray($"{nameof(jaggedArray)}[2]", jaggedArray[2]);
        Console.WriteLine();

        int[] array = { 1, 2, 3, 4, 5 };
        int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };

        Console.WriteLine("Copy");
        Array.Copy(array, 0, array2, 0, 3);
        OutputArray(nameof(array), array);
        OutputArray(nameof(array2), array2);
        Console.WriteLine();
        
        Console.WriteLine("Resize");
        Array.Resize(ref array, array.Length * 2);
        OutputArray(nameof(array), array);
    }

    private static void OutputArray(string title, Array array)
    {
        Console.Write($"Array for {title}: ");
        foreach (var item in array)
        {
            Console.Write($"{item} ");
        }

        Console.WriteLine();
    }
}