using System;
using System.Collections.Generic;
using Library.Repositories;
using Library.Models;
using Library.Interface;
using Library.Utils;
using Library.Enums;
using System.Data.Common;
using System.Linq;
using System.Text.RegularExpressions;

namespace Library.Services;

public class StatisticsService
{
    private readonly IRepository<Book> bookRepository;

    private readonly IRepository<Reader> readerRepository;

    private readonly IRepository<BorrowRecord> borrowRepository;

    public StatisticsService(IRepository<Book> bookRep, IRepository<Reader> readerRep, IRepository<BorrowRecord> borrowRep)
    {
        bookRepository = bookRep ?? throw new ArgumentNullException(nameof(bookRep));
        readerRepository = readerRep ?? throw new ArgumentNullException(nameof(readerRep));
        borrowRepository = borrowRep ?? throw new ArgumentNullException(nameof(bookRep));
    }

    public int GetBooksCount()
    {
        return bookRepository.GetAll().Count();
    }

    public int GetReadersCount()
    {
        return readerRepository.GetAll().Count;
    }

    public int GetBorrowsCount()
    {
        return borrowRepository.GetAll().Count;
    }

    public List<Book> GetMostPopularBooks(int count)
    {
        Dictionary<Book, int> allBorrows = new();
        foreach (var borrow in borrowRepository.GetAll())
        {
            if (!allBorrows.TryAdd(borrow.Book, 1))
            {
                allBorrows[borrow.Book]++;
            }
        }
        return allBorrows.OrderByDescending(x => x.Value).Take(count).Select(x => x.Key).ToList();
    }

    public List<Reader> GetMostActiveReaders(int count)
    {
        return readerRepository.GetAll().OrderByDescending(x => x.BorrowHistory.Count).Take(count).ToList();
    }

    public double GetAverageBorrowDays()
    {
        return borrowRepository.GetAll().Where(x => x.GetStatus() == BorrowStatus.Returned).Select(x => x.GetBorrowDay()).DefaultIfEmpty(0).Average();
    }

    public double GetTotalPenalty()
    {
        return borrowRepository.GetAll().Where(x => x.GetStatus() == BorrowStatus.Returned || x.GetStatus() == BorrowStatus.Late).Select(x => x.CalculatePenalty()).Sum();
    }

    public Dictionary<Genre, int> GetBooksByGenre()
    {
        return bookRepository.GetAll().GroupBy(x => x.Genre).ToDictionary(x => x.Key, x => x.Count());
    }

    public Book? GetBiggestBook()
    {
        return bookRepository.GetAll().OrderByDescending(x => x.Pages).FirstOrDefault();
    }

    public Book? GetSmallestBook()
    {
        return bookRepository.GetAll().OrderBy(x => x.Pages).FirstOrDefault();
    }

    public int CountOfAvaibleBook()
    {
        return bookRepository.GetAll().Count(x => x.IsAvailable == true);
    }

    public int GetActiveBorrows()
    {
        return borrowRepository.GetAll().Count(x => x.GetStatus()== BorrowStatus.Active);
    }

    public void PrintStatistics()
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("              LIBRARY STATISTICS");
        Console.WriteLine("==================================================");

        Console.WriteLine($"Total books:           {bookRepository.GetAll().Count}");
        Console.WriteLine($"Total readers:         {readerRepository.GetAll().Count}");
        Console.WriteLine($"Available books:       {CountOfAvaibleBook()}");
        Console.WriteLine($"Active borrows:        {GetActiveBorrows}");
        Console.WriteLine($"Average borrow days:   {GetAverageBorrowDays():F2}");

        Console.WriteLine();

        Console.WriteLine("Books by genre:");
        foreach (var item in GetBooksByGenre())
        {
            Console.WriteLine($"  {item.Key,-15} : {item.Value}");
        }

        Console.WriteLine();

        Console.WriteLine("Top 3 most popular books:");
        int i = 1;
        foreach (var book in GetMostPopularBooks(3))
        {
            Console.WriteLine($"  {i}. {book.Title} ({book.Author})");
            i++;
        }

        Console.WriteLine();

        Console.WriteLine("Top 3 most active readers:");
        i = 1;
        foreach (var reader in GetMostActiveReaders(3))
        {
            Console.WriteLine($"  {i}. {reader.Name}");
            i++;
        }

        Console.WriteLine("==================================================");
    }
}
