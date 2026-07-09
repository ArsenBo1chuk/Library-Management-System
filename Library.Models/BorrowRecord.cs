using System.Data;
using Library.Enums;
using Library.Interface;
namespace Library.Models;


public class BorrowRecord : IEntity
{
    public Guid Id { get; } = Guid.NewGuid();
    public Book Book { get; set; }
    public Reader Reader { get; set; }
    public DateTime? ReturnDate { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime DueDate { get; set; }
    public BorrowRecord(Book _book, Reader _reader)
    {
        Book = _book;
        Reader = _reader;
        BorrowDate = DateTime.Now;
        DueDate = BorrowDate.AddDays(14);
    }
    public void returnBook()
    {
        if (ReturnDate != null)
            throw new ArgumentException("The book had already been returned.");
        ReturnDate = DateTime.Now;
        Book.IsAvailable = true;
    }
    public int GetBorrowDay()
    {
        if (GetStatus() == BorrowStatus.Active || GetStatus() == BorrowStatus.Late)
            throw new ArgumentException("The book hasn't been returned yet");
        if (ReturnDate == null)
            throw new ArgumentException("The book has not returned.");
        else
        {
            var duration = ReturnDate - BorrowDate;
            return duration?.Days ?? 0;
        }
    }

    public int GetLateDay()
    {
        TimeSpan lateDay;

        if (ReturnDate != null)
        {
            lateDay = ReturnDate.Value - DueDate;
        }
        else
        {
            lateDay = DateTime.Now - DueDate;
        }

        if (lateDay.Days < 0)
            return 0;

        return lateDay.Days;
    }
    public double CalculatePenalty()
    {
        return GetLateDay() * 10;
    }

    public BorrowStatus GetStatus()
    {
        if (ReturnDate != null)
            return BorrowStatus.Returned;
        else if (DateTime.Now > DueDate)
            return BorrowStatus.Late;
        else
            return BorrowStatus.Active;
    }

    public void Print()
    {
        if (ReturnDate == null)
        {
            Console.WriteLine($"Book: {Book.Title}, Reader: {Reader.Name}, Borrow Date: {BorrowDate}, Due Date: {DueDate}");
        }
        else
        {
            Console.WriteLine($"Book: {Book.Title}, Reader: {Reader.Name}, Borrow Date: {BorrowDate}, Return Date: {ReturnDate}");
        }
    }
}