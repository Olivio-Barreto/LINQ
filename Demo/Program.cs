using Demo.Entities;
using System.Linq;

namespace Demo;

internal class Program
{
    private static void Print<T>(string message, IEnumerable<T> collection)
    {
        Console.WriteLine(message);
        foreach (T item in collection)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }
    static void Main()
    {
        var c1 = new Category { Id = 2, Name = "Comidas", Tier = 1 };
        var c2 = new Category { Id = 1, Name = "Tools", Tier = 1 };
        var c3 = new Category { Id = 3, Name = "Bebidas", Tier = 3 };

        List<Product> products = new()
        {
            new Product
            {
                Id = 1, Name = "TV", Price = 2000.00, Category = c2
            },
            new Product
            {
                Id = 2, Name = "Vinho", Price = 200.00, Category = c3
            },
            new Product
            {
                Id = 3, Name = "Coxinha", Price = 5.00, Category = c1
            }
        };

        var result = products
            .Where(product => product.Category.Tier == 1 && product.Price > 100);

        var result2 = products
            .Where(p => p.Category.Name == "Tools")
            .Select(p => p.Name);

        Print("TIER 1 AND PRICE > 100:", result);
        Print("NAMES OF PRODUCTS FROM TOOLS", result2);
    }
}
