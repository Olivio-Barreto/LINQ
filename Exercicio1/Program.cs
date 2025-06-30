using Exercicio1.Entities;

string arquivo = "/home/olivio-barreto/produtos.csv";

List<Product> list = new();

using (StreamReader streamReader = File.OpenText(arquivo))
{
    while (!streamReader.EndOfStream)
    {
        string[]? lines = streamReader.ReadLine()?.Split(',');

        if (lines is not null)
        {
            list.Add(new Product(lines[0], decimal.Parse(lines[1])));
        }
    }
}

decimal media = list.Average(p => p.Price);
Console.WriteLine($"A media de preço dos produtos é {media}");
Console.WriteLine();
Console.WriteLine();

Console.WriteLine("PRODUTOS COM PREÇO ABAIXO DA MÉDIA:");
foreach (var product in list.Where(p => p.Price < media).OrderByDescending(p => p.Name))
{
    Console.WriteLine(product);
    Console.WriteLine();
}
