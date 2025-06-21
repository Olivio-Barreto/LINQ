namespace Demo.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Tier { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Tier: {Tier}";
    }
}
