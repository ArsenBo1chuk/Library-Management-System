using Library.Repositories;
using Library.Services;
using Library.Models;
using Library.Enums;
using System;

namespace Library.Menus;

public class BookMenu
{

    private readonly BookService bookService;

    public BookMenu(BookService bookService)
    {
        this.bookService = bookService;
    }

    private void PrintMenu()
    {
        Console.Clear();

        Console.WriteLine("======================================");
        Console.WriteLine("            BOOK MENU");
        Console.WriteLine("======================================");
        Console.WriteLine("1. Add book");
        Console.WriteLine("2. Remove book");
        Console.WriteLine("3. Edit book");
        Console.WriteLine("4. Find book by ID");
        Console.WriteLine("5. Find books by title");
        Console.WriteLine("6. Find books by author");
        Console.WriteLine("7. Show all books");
        Console.WriteLine("8. Show available books");
        Console.WriteLine("9. Show books by genre");
        Console.WriteLine("0. Back");
        Console.WriteLine("======================================");
        Console.Write("Choose an option: ");
    }

    public void Show()
    {
        while (true)
        {
            PrintMenu();
            if(!int.TryParse(Console.ReadLine()!, out int choise))
            {
                continue;
            }
            switch (choise)
            {
                case 1:
                    AddBook();
                    break;

                case 2:
                    RemoveBook();
                    break;

                case 3:
                    EditBook();
                    break;

                case 4:
                    FindBookById();
                    break;

                case 5:
                    FindBookByTitle();
                    break;

                case 6:
                    FindBookByAuthor();
                    break;

                case 7:
                    ShowAllBooks();
                    break;

                case 8:
                    ShowAvaibleBooks();
                    break;

                case 9:
                    BooksByGenre();
                    break;

                case 0: return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

    }

    private void AddBook()
    {
        try
        {
            Console.Write("Title: ");
            string title = Console.ReadLine()!;

            Console.Write("Author: ");
            string author = Console.ReadLine()!;

            Console.Write("Year: ");
            if (!int.TryParse(Console.ReadLine()!, out int year))
            {
                throw new FormatException("Invalid year format.");
            }

            Console.Write("Pages: ");
            if (!int.TryParse(Console.ReadLine()!, out int pages))
            {
                throw new FormatException("Invalid pages format.");
            }

            Console.Write("Genre: ");
            if (!Enum.TryParse(Console.ReadLine()!, ignoreCase: true, out Genre genre))
            {
                throw new FormatException("Invalid genre format.");
            }

            bookService.AddBook(title, author, pages, year, genre);

            Console.WriteLine("\nBook added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }
        Console.WriteLine();
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private void RemoveBook()
    {
        try
        {
            Console.Write("Id: ");
            if (!Guid.TryParse(Console.ReadLine()!, out Guid Id))
            {
                throw new FormatException("Invalid ID format.");
            }

            bookService.RemoveBook(Id);
            Console.WriteLine("\nBook removed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }
        Console.WriteLine();
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }


    private void EditBook()
    {
        try
        {
            Console.Write("Id: ");
            if (!Guid.TryParse(Console.ReadLine()!, out Guid id))
            {
                throw new FormatException("Invalid ID format.");
            }

            Console.Write("Title: ");
            string title = Console.ReadLine()!;

            Console.Write("Author: ");
            string author = Console.ReadLine()!;

            Console.Write("Year: ");
            if (!int.TryParse(Console.ReadLine()!, out int year))
            {
                throw new FormatException("Invalid year format.");
            }

            Console.Write("Pages: ");
            if (!int.TryParse(Console.ReadLine()!, out int pages))
            {
                throw new FormatException("Invalid pages format.");
            }

            Console.Write("Genre: ");
            if (!Enum.TryParse(Console.ReadLine()!, ignoreCase: true, out Genre genre))
            {
                throw new FormatException("Invalid genre format.");
            }

            bookService.EditBook(id, title, author, pages, year, genre);

            Console.WriteLine("\nBook edited successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }
        Console.WriteLine();
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private void FindBookById()
    {
        try
        {
            Console.Write("Id: ");
            if (!Guid.TryParse(Console.ReadLine()!, out Guid Id))
            {
                throw new FormatException("Invalid ID format.");
            }

            Book? book = bookService.FindBook(Id);
            if (book is null)
            {
                Console.WriteLine("Book not found.");
            }
            else
            {
                Console.WriteLine();
                book.Print();
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

    private void FindBookByTitle()
    {
        try
        {
            Console.Write("Title: ");
            string title = Console.ReadLine()!;

            List<Book>? book = bookService.FindBooksByTitle(title);
            if (book is null)
            {
                Console.WriteLine("Book not found.");
            }
            else
            {
                Console.WriteLine();
                foreach (var b in book)
                {
                    b.Print();
                }
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

    private void FindBookByAuthor()
    {
        try
        {
            Console.Write("Author: ");
            string author = Console.ReadLine()!;

            List<Book>? book = bookService.FindBookByAuthor(author);
            if (book is null)
            {
                Console.WriteLine("Book not found.");
            }
            else
            {
                Console.WriteLine();
                foreach (var b in book)
                {
                    b.Print();
                }
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

    private void ShowAllBooks()
    {
        bookService.PrintAllBooks();
        Console.WriteLine();
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private void ShowAvaibleBooks()
    {
        List<Book> avaible = bookService.GetAvailableBooks();
        foreach (var book in avaible)
        {
            book.Print();
        }
        Console.WriteLine();
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private void BooksByGenre()
    {
        try
        {
            Console.Write("Genre: ");
            if (!Enum.TryParse(Console.ReadLine()!, ignoreCase: true, out Genre genre))
            {
                throw new FormatException("Invalid genre format.");
            }

            List<Book>? book = bookService.GetBooksByGenre(genre);
            if (book is null)
            {
                Console.WriteLine("Book not found.");
            }
            else
            {
                Console.WriteLine();
                foreach (var b in book)
                {
                    b.Print();
                }
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