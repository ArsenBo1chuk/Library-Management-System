using System.Diagnostics;
using Library.Enums;
using Library.Utils;

namespace Library.Models;

public class Book : Library.Interface.IEntity
{
    public Guid Id{get; private set;}
    public string? Title { get;private set; }
    public string? Author { get; private set; }
    public int Year { get; private set; }
    public Genre Genre { get; private set; }
    public int Pages { get; private set; }
    public bool IsAvailable { get;  set; }

    public Book(string title, string author, int year, int pages, Genre genre)
    {
        if(ValidationHelper.ValidateBookTitle(title))
        {
            Title = title;
        }
        else
        {
            throw new ArgumentException("Invalid title format.");
        }

        if(ValidationHelper.ValidateAuthor(author))
        {
            Author= author;
        }
        else
        {
            throw new ArgumentException("Invalid author format.");
        }

        if(ValidationHelper.ValidateYear(year))
        {
            Year = year;
        }
        else
        {
            throw new ArgumentException("Invalid year format.");
        }

        if(ValidationHelper.ValidatePages(pages))
        {
            Pages = pages;
        }
        else
        {
            throw new ArgumentException("Invalid pages format.");
        }

        Genre = genre;
        Id = Guid.NewGuid();
        IsAvailable = true;
    }
    
    public Book(Guid id,string title, string author, int year, int pages, Genre genre)
    {
        if(ValidationHelper.ValidateBookTitle(title))
        {
            Title = title;
        }
        else
        {
            throw new ArgumentException("Invalid title format.");
        }

        if(ValidationHelper.ValidateAuthor(author))
        {
            Author= author;
        }
        else
        {
            throw new ArgumentException("Invalid author format.");
        }

        if(ValidationHelper.ValidateYear(year))
        {
            Year = year;
        }
        else
        {
            throw new ArgumentException("Invalid year format.");
        }

        if(ValidationHelper.ValidatePages(pages))
        {
            Pages = pages;
        }
        else
        {
            throw new ArgumentException("Invalid pages format.");
        }

        Genre = genre;
        Id = id;
    }

    public void Print()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Year: {Year}, Genre: {Genre}, Peges: {Pages}");
    }

}