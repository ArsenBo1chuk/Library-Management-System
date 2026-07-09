using System.Data;
using System.Linq;
using Library.Utils;
using Library.Interface;
namespace Library.Models;



public abstract class Person : IEntity
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Guid Id { get; private set; }
    public string? Email { get; set; }
    public readonly DateTime _createdAt;
    public Person(string name, int age, string _email)
    {
        if (ValidationHelper.ValidateName(name))
        {
            Name = name;
        }
        else
            throw new ArgumentException("Invalid name format");
        if (ValidationHelper.ValidateAge(age))
            Age = age;
        else
            throw new ArgumentException("Invalid age format");
        if (ValidationHelper.ValidateEmail(_email))
        {
            Email = _email;
        }
        else
        {
            throw new ArgumentException("Invalid email format");
        }
        Id = Guid.NewGuid();
        _createdAt = DateTime.Now;
    }
    public abstract void PrintInfo();
}