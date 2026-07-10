using Library.Repositories;
using Library.Services;
using Library.Models;
using Library.Enums;
using System;

namespace Library.Menus;

public class StatisticsMenu
{

    private readonly StatisticsService statisticsService;

    public StatisticsMenu(StatisticsService statisticsService)
    {
        this.statisticsService = statisticsService;
    }
    private void PrintMenu()
    {
        Console.Clear();

        Console.WriteLine("======================================");
        Console.WriteLine("            STATISTICS");
        Console.WriteLine("======================================");
        Console.WriteLine("1. Print all statistics");
        Console.WriteLine("2. Most popular books");
        Console.WriteLine("3. Most active readers");
        Console.WriteLine("4. Books by genre");
        Console.WriteLine("5. Average borrow days");
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
                throw new FormatException("Invalid choise format.");
            }

            switch (choise)
            {
                case 1:
                    PrintAllStatistics();
                    break;

                case 2:
                    MostPopularBooks();
                    break;


                case 3:
                    MostActiveReaders();
                    break;

                case 4:
                    BookByGenre();
                    break;

                case 5:
                    AverageBorrowDAy();
                    break;

                case 0: return;

                default:
                    Console.WriteLine("Invalid choise");
                    break;
            }
        }
    }

    private void PrintAllStatistics()
    {
        statisticsService.PrintStatistics();
        Console.WriteLine();
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private void MostPopularBooks()
    {
        try
        {
            Console.Write("Count: ");
            if (!int.TryParse(Console.ReadLine()!, out int count))
            {
                throw new FormatException("Invalid count format.");
            }

            List<Book>? MostPopular = statisticsService.GetMostPopularBooks(count);
            foreach (var item in MostPopular)
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

    private void MostActiveReaders()
    {
        try
        {

            Console.Write("Count: ");
            if (!int.TryParse(Console.ReadLine()!, out int count))
            {
                throw new FormatException("Invalid count format.");
            }
            List<Reader>? MostActive = statisticsService.GetMostActiveReaders(count);
            foreach (var item in MostActive)
            {
                item.PrintInfo();
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

    private void BookByGenre()
    {
        try
        {
            Dictionary<Genre, int> result = statisticsService.GetBooksByGenre();
            foreach (var (genre, count) in result)
            {
                Console.WriteLine($"{genre} -> {count}");
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

    private void AverageBorrowDAy()
    {
        double AverageBorrowDAy = statisticsService.GetAverageBorrowDays();
        Console.WriteLine($"Average borrow day: {AverageBorrowDAy}");
        Console.WriteLine();
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}