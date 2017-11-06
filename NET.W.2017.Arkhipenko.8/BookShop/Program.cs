using System;
using System.Collections.Generic;
using Books;
using Interfaces;

namespace BookShop
{
    class Program
    {
        static void Main(string[] args)
        {
            #region create list
            List <Book> books = new List<Book>();
          
            books.Add(new Book(111, "Булгаков", "Мастер и Маргарита", "OOO МоскваПечать", 1998, 15, 740));
            books.Add(new Book(112, "Достоевский", "Преступление и наказание", "OOO МоскваПечать", 1995, 12, 520));
            books.Add(new Book(113, "Толстой", "Война и мир", "OOO МоскваПечать", 2001, 25, 1740));
            books.Add(new Book(114, "Булгаков", "Мастер и Маргарита111", "OOO МоскваПечать", 1998, 15, 740));
            books.Add(new Book(115, "Достоевский11111", "Преступление и наказание", "OOO МоскваПечать", 1995, 12, 520));
            books.Add(new Book(116, "Толстой11111", "Война и мир", "OOO МоскваПечать", 2001, 25, 1740));

            #endregion

            #region Add to file
            IBookService  bookListService = new BookService.BookService();
            
            bookListService.AddBook(books[0]);
            bookListService.AddBook(books[1]);
            bookListService.AddBook(books[2]);
            bookListService.AddBook(books[3]);
            bookListService.AddBook(books[4]);
            bookListService.AddBook(books[5]);
            
            Print(bookListService.GetBookList());
            #endregion

            #region Find book
            Book bookFind = bookListService.FindBook(115);
            Console.WriteLine(bookFind.ToString());
            Console.WriteLine(new string('-', 20));
            #endregion

            #region Remove book
            bookListService.RemoveBook(116);
            Print(bookListService.GetBookList());
            #endregion

            #region Sorting
            foreach (var book in bookListService.Sort(books, BookPart.Name))
            {
                Console.WriteLine(book.ToString());
            }
            Console.ReadKey();
#endregion
        }

        #region Printer
        private static void Print(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(book.ToString());
            }
            Console.WriteLine(new string('-', 20));
        }
        #endregion

    }
}
