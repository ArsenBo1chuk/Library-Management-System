using Library.Utils;
using Library.Enums;
namespace Library.Models;

public class Employee : Person
{
    protected double Salary{get; set;}
    protected EmployeePosition Position{get; set;}
    public Employee(string name, int age, string email, double salary, EmployeePosition pos) :base(name, age, email)
    {
        Salary = salary;
        Position = pos;
    }
    public override void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Email: {Email}, Salary: {Salary}, Position: {Position}");
    }

    public void IncreaseSalary(double money)
    {
        if(ValidationHelper.ValidateMoney(money))
        {
            Salary += money;
        }
        else
        throw new ArgumentException("Invalid salary formaat.");
    }
}