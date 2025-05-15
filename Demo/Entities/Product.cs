namespace Demo.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public double Price { get; set; }
    public Category Category { get; set; } = null!;

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Price: {Price}, Category: {Category}";
    }
}
