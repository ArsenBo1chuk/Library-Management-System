using Library.Repositories;
using Library.Services;
using Library.Models;
using Library.Enums;
using System;
using Microsoft.CSharp.RuntimeBinder;

namespace Library.Menus;

public class BorrowMenu
{
    private readonly BorrowSirvice borrowService;

    public BorrowMenu(BorrowSirvice borrowService)
    {
        this.borrowService = borrowService;
    }
    private void PrintMenu()
    {
        Console.Clear();

        Console.WriteLine("======================================");
        Console.WriteLine("            BORROW MENU");
        Console.WriteLine("======================================");
        Console.WriteLine("1. Borrow book");
        Console.WriteLine("2. Return book");
        Console.WriteLine("3. Active borrows");
        Console.WriteLine("4. Late borrows");
        Console.WriteLine("5. Borrow history");
        Console.WriteLine("0. Back");
        Console.WriteLine("======================================");
        Console.Write("Choose an option: ");
    }

    public void Show()
    {
        while (true)
        {
            PrintMenu();
            if (!int.TryParse(Console.ReadLine()!, out int choise))
            {
                continue;
            }
            switch (choise)
            {
                case 1:
                    BorrowBook();
                    break;

                case 2:
                    ReturnBook();
                    break;


                case 3:
                    ActiveBorrows();
                    break;

                case 4:
                    LateBorrows();
                    break;

                case 5:
                    BorrowHistory();
                    break;

                case 0: return;

                default:
                    Console.WriteLine("Invalid choise");
                    break;
            }
        }
    }

    private void BorrowBook()
    {
        try
        {
            Console.Write("Book id: ");
            if (!Guid.TryParse(Console.ReadLine()!, out Guid bookId))
            {
                throw new FormatException("Invalid ID format.");
            }
            Console.Write("Reader id: ");
            if (!Guid.TryParse(Console.ReadLine()!, out Guid readerId))
            {
                throw new FormatException("Invalid ID format.");
            }
            BorrowRecord br = borrowService.BorrowBook(bookId, readerId);
            Console.WriteLine();
            Console.WriteLine("\nBook borrowed successfully.");
            br.Print();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }
        Console.WriteLine();
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private void ReturnBook()
    {
        try
        {
            Console.Write("Id: ");
            if (!Guid.TryParse(Console.ReadLine()!, out Guid Id))
            {
                throw new FormatException("Invalid ID format.");
            }

            double penalty = borrowService.ReturnBook(Id);
            Console.WriteLine();
            Console.WriteLine("\nBook returned successfully.");
            Console.WriteLine($"Penalty money: {penalty}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }
        Console.WriteLine();
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private void ActiveBorrows()
    {
        try
        {
            List<BorrowRecord> activeBorrow = borrowService.GetActiveBorrows();
            foreach (var item in activeBorrow)
            {
                item.Print();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }
    }


    private void LateBorrows()
    {
        try
        {
            List<BorrowRecord> lateBorrow = borrowService.GetLateBorrows();
            foreach (var item in lateBorrow)
            {
                item.Print();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }
    }

    private void BorrowHistory()
    {
        try
        {
            Console.Write("Id: ");
            if (!Guid.TryParse(Console.ReadLine()!, out Guid Id))
            {
                throw new FormatException("Invalid ID format.");
            }
            List<BorrowRecord> activeBorrow = borrowService.GetReaderHistory(Id);
            foreach (var item in activeBorrow)
            {
                item.Print();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }
    }
}