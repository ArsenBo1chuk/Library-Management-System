using Library.Enums;
using Library.Interface;
using Library.Menus;
using Library.Models;
using Library.Repositories;
using Library.Services;
using Library.Utils;

namespace Library;

public class Program
{
    static void Main()
    {
        FileLogger logger = new FileLogger();
        Repositories<Book> bookRepository = new Repositories<Book>();
        Repositories<BorrowRecord> borrowRepository = new Repositories<BorrowRecord>();
        Repositories<Reader> readerRepository = new Repositories<Reader>();
        BookService bookService = new BookService(bookRepository, logger);
        ReaderService readerService = new ReaderService(readerRepository, logger);
        BorrowSirvice borrowSirvice = new BorrowSirvice(bookRepository, readerRepository, borrowRepository, logger );
        StatisticsService statisticsService = new StatisticsService(bookRepository, readerRepository, borrowRepository);
        MainMenu mainMenu = new MainMenu(new BookMenu(bookService), new BorrowMenu(borrowSirvice), new ReaderMenu(readerService), new StatisticsMenu(statisticsService));
        mainMenu.Start();
    }
}
