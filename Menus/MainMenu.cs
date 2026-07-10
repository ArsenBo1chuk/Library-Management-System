using Library.Repositories;
using Library.Services;
using Library.Models;
using Library.Enums;
using System;

namespace Library.Menus;

public class MainMenu
{

    private readonly BookMenu bookMenu;
    private readonly BorrowMenu borrowMenu;
    private readonly ReaderMenu readerMenu;
    private readonly StatisticsMenu statisticsMenu;

    public MainMenu(BookMenu bookMenu, BorrowMenu borrowMenu, ReaderMenu readerMenu, StatisticsMenu statisticsMenu)
    {
        this.bookMenu = bookMenu;
        this.borrowMenu = borrowMenu;
        this.readerMenu = readerMenu;
        this.statisticsMenu = statisticsMenu;
    }
    private void PrintMenu()
    {
        Console.Clear();

        Console.WriteLine("======================================");
        Console.WriteLine("         LIBRARY MANAGEMENT");
        Console.WriteLine("======================================");
        Console.WriteLine("1. Books");
        Console.WriteLine("2. Readers");
        Console.WriteLine("3. Borrow books");
        Console.WriteLine("4. Statistics");
        Console.WriteLine("0. Exit");
        Console.WriteLine("======================================");
        Console.Write("Choose an option: ");
    }

    public void Start()
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
                    bookMenu.Show();
                    break;

                case 2:
                    readerMenu.Show();
                    break;

                case 3:
                    borrowMenu.Show();
                    break;

                case 4:
                    statisticsMenu.Show();
                    break;

                case 0: return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}