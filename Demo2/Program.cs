using Demo.Entities;

namespace Demo2;

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

        var r1 =
            from p in products
            where p.Category.Tier == 1 && p.Price < 900
            select p;

        Print("TIER 1 AND PRICE > 100:", r1);

        var r2 =
            from p in products
            where p.Category.Name == "Tools"
            select p.Name;

        Print("NAMES OF PRODUCTS FROM TOOLS", r2);

        var r3 =
            from p in products
            where p.Name[0] == 'C'
            select new { p.Name, p.Price, CategoryName = p.Category.Name };

        Print("NAMES STARTED WITH 'C' AND ANONIMOUS OBJECT:", r3);

        // cria uma lista de usuários ordenados por nome e por preço
        var result4 = products
            .Where(p => p.Category.Tier == 1)
            .OrderBy(p => p.Name)
            .ThenBy(p => p.Price);

        var r4 =
            from p in products
            where p.Category.Tier == 1
            orderby p.Name, p.Price
            select p;
        Print("TIER 1 ORDER NAME THEN BY PRICE:", r4);

        var r5 = (from p in r4 select p).Skip(1).Take(2);
        Print("TIER 1 ORDER BY NAME THEN BY PRICE SKIP 1 TAKE 2", r5);
    }
}
