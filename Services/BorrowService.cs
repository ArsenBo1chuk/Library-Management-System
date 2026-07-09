using System;
using System.Collections.Generic;
using Library.Repositories;
using Library.Models;
using Library.Interface;
using Library.Utils;
using Library.Enums;
using System.Data.Common;

namespace Library.Services;

public class BorrowSirvice
{
    private readonly IRepository<Book> bookRepository;

    private readonly IRepository<Reader> readerRepository;

    private readonly IRepository<BorrowRecord> borrowRepository;

    private readonly ILogger logger;

    public BorrowSirvice(IRepository<Book> bookRep, IRepository<Reader> readerRep, IRepository<BorrowRecord> borrowRep, ILogger log)
    {
        bookRepository = bookRep ?? throw new ArgumentNullException(nameof(bookRep));
        readerRepository = readerRep ?? throw new ArgumentNullException(nameof(readerRep));
        borrowRepository = borrowRep ?? throw new ArgumentNullException(nameof(borrowRep));
        logger = log ?? throw new ArgumentNullException(nameof(log));
    }

    public BorrowRecord BorrowBook(Guid bookId, Guid readerId)
    {
        var book = bookRepository.GetAll().FirstOrDefault(x => x.Id == bookId);
        var reader = readerRepository.GetAll().FirstOrDefault(x => x.Id == readerId);
        if (book is null)
        {
            throw new ArgumentException("The book is missing.");
        }
        if (reader is null)
        {
            throw new ArgumentException("The reader is missing.");
        }
        if (book.IsAvailable == false)
        {
            throw new ArgumentException("The book is unavaible.");
        }
        int activeBook = reader.BorrowHistory.Count(x => x.GetStatus() == BorrowStatus.Active || x.GetStatus() == BorrowStatus.Late);
        if (activeBook >= 5)
        {
            throw new ArgumentException("Reader has more than 5 books.");
        }
        BorrowRecord record = new(book, reader);
        book.IsAvailable = false;
        reader.BorrowHistory.Add(record);
        borrowRepository.Add(record);
        logger.Info("Book borrowed.");
        return record;
    }

    public double ReturnBook(Guid borrowId)
    {
        var record = borrowRepository.GetAll().FirstOrDefault(x => x.Id == borrowId);
        if (record is null)
        {
            throw new ArgumentException($"Borrow id {borrowId} invalid.");
        }
        record.returnBook();
        double penalty = record.CalculatePenalty();
        if (penalty > 0)
        {
            record.Reader.AddPenalty(penalty);
            logger.Warning($"Reader '{record.Reader.Name}' received a penalty of {penalty} UAH.");
        }

        logger.Info($"Reader '{record.Reader.Name}' returned '{record.Book.Title}'.");
        return penalty;
    }

    public List<BorrowRecord> GetActiveBorrows()
    {
        return borrowRepository.GetAll().Where(x => x.GetStatus() == BorrowStatus.Active || x.GetStatus() == BorrowStatus.Late).ToList();
    }

    public List<BorrowRecord> GetLateBorrows()
    {
        return borrowRepository.GetAll().Where(x => x.GetStatus() == BorrowStatus.Late).ToList();
    }

    public List<BorrowRecord> GetReturnedBorrows()
    {
        return borrowRepository.GetAll().Where(x => x.GetStatus() == BorrowStatus.Returned).ToList();
    }

    public List<BorrowRecord> GetReaderHistory(Guid readerId)
    {
        var reader = readerRepository.GetAll().FirstOrDefault(x => x.Id == readerId);
        if (reader is null)
        {
            throw new ArgumentException("The reader is missing.");
        }
        else
        {
            return reader.BorrowHistory;
        }
    }

    public List<BorrowRecord> GetBookHistory(Guid bookId)
    {
        return borrowRepository.GetAll().Where(record => record.Book.Id == bookId).ToList();
    }

    public void PrintAllBorrows()
    {
        foreach(var borrow in borrowRepository.GetAll())
        {
            borrow.Print();
        }
    }



}