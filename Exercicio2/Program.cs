using System.Globalization;
using Exercicio2.Entities;

const string path = "/home/olivio-barreto/funcionarios.csv";
List<Employee> employees = new();

using (var streamReader = File.OpenText(path))
{
    while (!streamReader.EndOfStream)
    {
        string[]? lines = streamReader.ReadLine()?.Split(',');

        string nome = lines?[0] != null ? lines[0] : throw new ArgumentNullException();
        string email = lines[1] != null ? lines[1] : throw new ArgumentNullException();
        double salary = double.Parse(lines[2], CultureInfo.InvariantCulture);

        employees.Add(new Employee(nome, email, salary));
    }
}

Console.Write("Digite o salário: ");
double inSalary = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
Console.WriteLine();

Console.WriteLine($"Email dos funcionários com o salário maios do que R${inSalary}:");
var emails = employees
    .Where(emp => emp.Salary > inSalary)
    .OrderBy(emp => emp.Email)
    .Select(emp => new { emp.Email });

foreach (var employee in emails)
    Console.WriteLine(employee.Email);

Console.WriteLine();
var sum = employees.Where(emp => emp.Name[0] == 'A').Sum(emp => emp.Salary);
Console.WriteLine($"A soma do salários dos funcionarios com nomes que começam com 'M' é: {sum:F2}");
