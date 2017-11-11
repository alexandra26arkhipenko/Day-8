using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Books;
using IBookStorage;
using ParameterForSearching;


namespace BookService
{ 
    /// <summary>
    /// BookService
    /// </summary>
    public class BookService : IBookService
    {
        #region private field

        private readonly IBookStorageService bookStorage;
        private List<Book> books = new List<Book>();
        #endregion

        #region Constructor

        public BookService(IBookStorageService bookStorage)
        {
            this.bookStorage = bookStorage;
            try
            {
                books.AddRange(bookStorage.GetBookList());
            }
            catch (Exception)
            {
                books.Clear();
            }
        }
        #endregion

        public void AddBookToShop(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException();
            }
            
            books.Add(book);
            
        }

        public void RemoveBookFromShop(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException();
            }
            books.Remove(book);
        }

        public Book FindBook(IFinder parameter)
        {
            if (ReferenceEquals(parameter, null))
            {
                throw new ArgumentNullException();
            }
            return parameter.FindBookByTeg();
        }

        public void Sort(IComparer<Book> comparator)
        {
            var booksArray = books.ToArray();

            if (ReferenceEquals(comparator, null))
            {
                Array.Sort(booksArray);
            }
            else
            {
                Array.Sort(booksArray, comparator);
            }
            books.Clear();
            books.AddRange(booksArray);
        }

        public void Save()
        {
            bookStorage.SaveBooks(books);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return bookStorage.GetBookList();
        }
    }
}