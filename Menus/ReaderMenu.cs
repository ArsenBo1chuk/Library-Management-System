using Library.Repositories;
using Library.Services;
using Library.Models;
using Library.Enums;
using System;

namespace Library.Menus;

public class ReaderMenu
{
    private readonly ReaderService readerService;

    public ReaderMenu(ReaderService readerService)
    {
        this.readerService = readerService;
    }


    private void PrintMenu()
    {
        Console.Clear();

        Console.WriteLine("======================================");
        Console.WriteLine("            READER MENU");
        Console.WriteLine("======================================");
        Console.WriteLine("1. Register reader");
        Console.WriteLine("2. Remove reader");
        Console.WriteLine("3. Edit reader");
        Console.WriteLine("4. Find reader");
        Console.WriteLine("5. Show all readers");
        Console.WriteLine("6. Reader history");
        Console.WriteLine("0. Back");
        Console.WriteLine("======================================");
        Console.Write("Choose an option: ");
    }


    public void Show()
    {
        while (true)
        {
            PrintMenu();
            int choise = int.Parse(Console.ReadLine()!);

            switch (choise)
            {
                case 1:
                    RegisterReader();
                    break;

                case 2:
                    RemoveReader();
                    break;


                case 3:
                    EditReader();
                    break;

                case 4:
                    FindReader();
                    break;

                case 5:
                    ShowAllReaders();
                    break;

                case 6:
                    RaederHistory();
                    break;

                case 0: return;

                default:
                    Console.WriteLine("Invalid choise");
                    break;
            }
        }
    }

    private void RegisterReader()
    {
        try
        {
            Console.Write("Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine()!);

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            readerService.RegisterReader(name, age, email);
            Console.WriteLine("Reader registed.");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }
        Console.WriteLine();
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }


    private void RemoveReader()
    {
        try
        {
            Console.Write("Id: ");
            Guid Id = Guid.Parse(Console.ReadLine()!);

            if (readerService.RemoveReader(Id))
                Console.WriteLine("Reader remove successfully.");
            Console.WriteLine("Invalid id.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }
        Console.WriteLine();
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private void EditReader()
    {
        try
        {
            Console.Write("Id: ");
            Guid Id = Guid.Parse(Console.ReadLine()!);

            Console.Write("Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine()!);

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            readerService.EditReader(Id, name, age, email);
            Console.WriteLine("Reader edited.");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }
        Console.WriteLine();
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private void FindReader()
    {
        try
        {
            Console.Write("Id: ");
            Guid Id = Guid.Parse(Console.ReadLine()!);

            Reader reader = readerService.FindREader(Id)!;
            reader.PrintInfo();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }
        Console.WriteLine();
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private void ShowAllReaders()
    {
        try
        {
            readerService.GetAllReaders();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }
        Console.WriteLine();
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private void RaederHistory()
    {
        try
        {
            Console.Write("Id: ");
            Guid Id = Guid.Parse(Console.ReadLine()!);

            Reader reader = readerService.FindREader(Id)!;
            var history = reader.BorrowHistory;
            foreach (var item in history)
            {
                item.Print();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }
        Console.WriteLine();
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

}