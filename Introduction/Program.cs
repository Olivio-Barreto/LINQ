using System.Linq;

namespace Introduction;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // Specify data source
        int[] mainDataSource = [1, 2, 3, 4, 5];

        // Define the query expression
        IEnumerable<int> result = mainDataSource
            .Where(x => x % 2 == 0)
            .Select(x => x * 10);

        // Execute query
        foreach (int item in result)
        {
            Console.WriteLine(item);
        }
    }
}
