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
        Print("TIER 1 AND PRICE > 100:", result);

        var result2 = products
            .Where(p => p.Category.Name == "Tools")
            .Select(p => p.Name); // cria uma lista apenas com os nomes dos usuarios
        Print("NAMES OF PRODUCTS FROM TOOLS", result2);

        // cria uma lista de usuarios com apenas as propriedades desejadas
        var result3 = products
            .Where(p => p.Name[0] == 'C')
            .Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
        Print("NAMES STARTED WITH 'C' AND ANONIMOUS OBJECT:", result3);

        // cria uma lista de usuários ordenados por nome e por preço
        var result4 = products
            .Where(p => p.Category.Tier == 1)
            .OrderBy(p => p.Name)
            .ThenBy(p => p.Price);
        Print("TIER 1 ORDER NAME THEN BY PRICE:", result4);

        // cria uma lista com técnicas de paginação
        var result5 = result4.Skip(1).Take(2);
        Print("TIER 1 ORDER BY NAME THEN BY PRICE SKIP 1 TAKE 2", result5);

        var result6 = products.FirstOrDefault();
        Console.WriteLine($"First or default test 1: {result6}");

        var result7 = products.FirstOrDefault(p => p.Price > 3000.0);
        Console.WriteLine($"First or default test 2: {result7}");
        Console.WriteLine();

        var result8 = products.SingleOrDefault(p => p.Id == 3);
        Console.WriteLine($"Single or default test 1: {result8}");

        var result9 = products.SingleOrDefault(p => p.Id == 30);
        Console.WriteLine($"single or default test 2: {result9}");
        Console.WriteLine();

        // sem expressão lambda gera uma exceção
        var result10 = products.Max(product => product.Price);
        Console.WriteLine($"max price teste 1: {result10}");

        var result11 = products.Min(p => p.Price);
        Console.WriteLine($"min price teste 1: {result11}");
        Console.WriteLine();

        var result12 = products.Where(p => p.Category.Id == 3).Sum(p => p.Price);
        Console.WriteLine($"category 3 sum prices test 1: {result12}");

        // se não ouver objetos a função lança uma exceção
        var result13 = products.Where(p => p.Category.Id == 1).Average(p => p.Price);
        Console.WriteLine($"category 1 average prices test 1: {result13}");

        // MACETE
        /*
            evita a exceção de Average selecionando apenas uma propriedade do objeto
            e definindo um valor Default se não ouver objetos
         */
        var result14 = products
            .Where(p => p.Category.Id == 5)
            .Select(p => p.Price)
            .DefaultIfEmpty(0.0)
            .Average();
        Console.WriteLine($"category 5 average prices test 2: {result14}");

        // lança uma exceção se os objetos não forem encontrados
        var result15 = products
            .Where(p => p.Category.Id == 1)
            .Select(p => p.Price) // Selecionando propriedades específicas
            .Aggregate((x, y) => x + y); // implementa funções anônimas de sua necessidade
        // ou .Aggregate(0.0, (x, y) => x + y) para evitar a exceção
        Console.WriteLine($"category 1 aggregate sum test 1: {result15}");
        Console.WriteLine();


        // AGRUPAMENTO

        var result16 = products.GroupBy(p => p.Category);
        foreach (IGrouping<Category, Product> group in result16)
        {
            Console.WriteLine($"{group.Key.Name}: ");
            foreach (Product product in group)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine();
        }
    }
}
