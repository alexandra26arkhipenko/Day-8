using System;
using System.Collections.Generic;
using System.Linq;
using Books;
using BookService;
using BookStorage;
using ConsoleApp.Find;
using IBookStorage;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            IBookStorageService bookStorage = new BinaryBookStorage("Storage5.bin");
            IBookService bookService = new BookService.BookService(bookStorage);

            bookService.AddBookToShop(new Book("978-3-16-123451-0", "Ivanov", "one", "Minsk", 2000, 1000, 100));
            bookService.AddBookToShop(new Book("978-3-16-123452-1", "Petrov", "two", "Gomel", 2001, 2000, 200));
            bookService.AddBookToShop(new Book("978-3-16-123453-2", "Glebov", "three", "Brest", 2002, 3000, 300));
            bookService.AddBookToShop(new Book("978-3-16-123454-3", "Arkhipov", "four", "Vitebsk", 2003, 4000, 400));
           

           // bookService.Save();
            bookService.Sort(null);
            PrintBook(bookService.GetAllBooks());

            PrintBook(bookService.FindBook(new FindBookByName("One", bookService.GetAllBooks().ToList())));
            PrintBook(bookService.FindBook(new FindBookByIsbn("978-3-16-123455-4",
                bookService.GetAllBooks().ToList())));

            bookService.Save();
            Console.ReadKey();
        }

        private static void PrintBook(IEnumerable<Book> books)
        {
            foreach (var book in books)
                Console.WriteLine(book);
            Console.WriteLine();
        }

        private static void PrintBook(Book book)
        {
            Console.WriteLine(book.ToString());
        }
    }
}