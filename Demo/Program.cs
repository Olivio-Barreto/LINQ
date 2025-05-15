using Demo.Entities;
using System.Linq;

namespace Demo;

internal class Program
{
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

        foreach (var product in products.Where(product => product.Price > 100))
        {
            Console.WriteLine(product);
        }
    }
}
