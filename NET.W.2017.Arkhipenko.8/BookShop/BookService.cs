using System;
using System.Collections.Generic;
using System.Linq;
using Books;
using Interfaces;

namespace BookService
{ 
    /// <summary>
    /// BookService
    /// </summary>
    public class BookService : IBookService
    {
        #region private field
        private readonly BookStorage.BookStorage _bookStorage;
        #endregion
        #region Constructor

        public BookService()
        {
            _bookStorage = new BookStorage.BookStorage();
        }
        #endregion

        #region public
        /// <summary>
        /// GetBoolList returns all elements of file 
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<Book> GetBookList()
        {
            return _bookStorage.ReadBookFromFile();
        }

        /// <summary>
        /// AddBook adds Book to file
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            var books = _bookStorage.ReadBookFromFile().ToList();

            if (books.Any(book.Equals))
                throw new Exception();
            books.Add(book);

            _bookStorage.OverWriteFile(books);
        }

        /// <summary>
        /// RemoveBook deletes from file
        /// </summary>
        /// <param name="isbn"></param>
        public void RemoveBook(int isbn)
        {
            var books = _bookStorage.ReadBookFromFile().ToList();
            var bookForRemove = FindBook(isbn);
            if (bookForRemove == null)
                throw new Exception();
            books.Remove(bookForRemove);
            _bookStorage.OverWriteFile(books);
        }

        /// <summary>
        /// FindBook finds Book in file using ISBN
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public Book FindBook(int isbn)
        {
            var books = _bookStorage.ReadBookFromFile().ToList();
            return books.FirstOrDefault(b => b.Isbn == isbn);
        }

        /// <summary>
        /// FindBook finds Book in file using Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Book FindBook(string name)
        {
            var books = _bookStorage.ReadBookFromFile().ToList();
            return books.FirstOrDefault(b => b.Name == name);
        }

        /// <summary>
        /// Sort is sorting list of books
        /// </summary>
        /// <param name="books"></param>
        /// <param name="partForSort"></param>
        /// <returns>IEnumerable</returns>
        public IEnumerable<Book> Sort(IEnumerable<Book> books, BookPart partForSort)
        {
            switch (partForSort)
            {
                case BookPart.Isbn:
                    return books.OrderBy(b => b.Isbn);
                case BookPart.Name:
                    return books.OrderBy(b => b.Name);
                case BookPart.Author:
                    return books.OrderBy(b => b.Author);
                case BookPart.Pages:
                    return books.OrderBy(b => b.Pages);
                case BookPart.Price:
                    return books.OrderBy(b => b.Price);
                case BookPart.PublishHouse:
                    return books.OrderBy(b => b.PublishingHouse);
                case BookPart.Year:
                    return books.OrderBy(b => b.Year);
                default: return books;
            }
        }
#endregion
    }
}