using Library.Enums;
namespace Library.Models;

public sealed class Librarian : Employee
{
    public int ExpirianceYear{get; set;}
    public Librarian(string name, int age, string email, int exp, double salary, EmployeePosition pos) : base(name, age, email, salary, pos) {ExpirianceYear = exp;}

    public override void PrintInfo()
    {
    Console.WriteLine($"Name: {Name}, Age: {Age}, Email: {Email}, Salary: {Salary}, Position: {Position}, Exp Year: {ExpirianceYear}");
    }
}