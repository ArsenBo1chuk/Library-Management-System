using System;
using System.Collections.Generic;
using Library.Repositories;
using Library.Models;
using Library.Interface;
using Library.Utils;
using Library.Enums;
using System.Data.Common;

namespace Library.Services;

public class BookService
{
    private readonly IRepository<Book> bookRepository;
    private readonly ILogger logger;

    public BookService(IRepository<Book> repository, ILogger logg)
    {
        bookRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        logger = logg ?? throw new ArgumentNullException(nameof(logg));
    }
    public void AddBook(string title, string author, int pages, int year, Genre genre)
    {
        Book book = new(title, author, year, pages, genre);
        bookRepository.Add(book);
        logger.Info($"Book {title} added. ID: {book.Id}");
    }

    public bool RemoveBook(Guid Id)
    {
        Book? book = bookRepository.FindById(Id);
        if (book is Book)
        {
            bookRepository.Remove(book);
            return true;
        }
        return false;
    }

    public bool EditBook(Guid id, string title, string author, int pages, int year, Genre genre)
    {
        Book book = new(id, title, author, year, pages, genre);
        if (bookRepository.Update(book))
            return true;
        else
            return false;
    }

    public Book? FindBook(Guid id)
    {
        return bookRepository.FindById(id);
    }

    public List<Book> FindBookByAuthor(string author)
    {
        return bookRepository.GetAll().Where(x => x.Author == author).ToList();
    }

    public List<Book> FindBooksByTitle(string title)
    {
        return bookRepository.GetAll().Where(x => x.Title == title).ToList();
    }

    public List<Book> GetAvailableBooks()
    {
        return bookRepository.GetAll().Where(x => x.IsAvailable == true).ToList();
    }

    public List<Book> GetBooksByGenre(Genre genre)
    {
        return bookRepository.GetAll().Where(x => x.Genre == genre).ToList();
    }

    public List<Book> SortByPages()
    {
        return bookRepository.GetAll().OrderBy(x => x.Pages).ToList();
    }

    public List<Book> SortByYear()
    {
        return bookRepository.GetAll().OrderBy(x => x.Year).ToList();
    }

    public void PrintAllBooks()
    {
        foreach(var book in bookRepository.GetAll())
        {
            book.Print();
        }
    }
}
