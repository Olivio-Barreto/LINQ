namespace Exercicio1.Entities;

public class Product(string name, decimal price)
{
    public string Name { get; set; } = name;
    public decimal Price { get; set; } = price;

    public override string ToString()
    {
        return $"Name: {Name}, Price: {Price}";
    }
}
