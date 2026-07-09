using System;
using Library.Models;
namespace Library.Utils;

static class ValidationHelper
{
    public static bool ValidateName(string name)
    {
        if (name == "" || name.Length < 2 || name.All(c => char.IsDigit(c))  || name.All(c=>char.IsPunctuation(c)) || name.All(c => char.IsSymbol(c)))
            return false;
        else
            return true;
    }

    public static bool ValidateEmail(string email)
    {
        if(email.Contains("@")  && email.Contains(".") && !email.StartsWith("@") && !email.EndsWith(".") && !(email == ""))
        return true;
        else
        return false;
    }

    public static bool ValidateAge(int age)
    {
        if(age >0 && age<120)
        return true;
        else
        return false;
    }

    public static bool ValidateBookTitle(string Title)
    {
        if(Title == null || Title =="" || Title.Length<2 || Title.Length>200)
        return false;
        else
        return true;
    }

    public static bool ValidateAuthor(string Author)
    {
        if(Author == null || Author.Length<2)
        return false;
        else
        return true;
    }

    public static bool ValidateYear(int year)
    {
        if(year >=1450 && year <= DateTime.Now.Year)
        return true;
        else
        return false;
    }

    public static bool ValidatePages(int pages)
    {
        if(pages > 0 && pages < 10000)
        return true;
        else
        return false;
    }

    public static bool ValidateSalary(double salary)
    {
        if(salary >= 0)
        return true;
        else
        return false;
    }

    public static bool ValidateMoney(double money)
    {
        if(money>=0)
        return true;
        else
        return false;
    }

}