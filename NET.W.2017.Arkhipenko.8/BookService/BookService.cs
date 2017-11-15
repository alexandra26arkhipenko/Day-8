using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Books;
using IBookStorage;
using ParameterForSearching;
using Logger;


namespace BookService
{ 
    /// <summary>
    /// BookService
    /// </summary>
    public class BookService : IBookService
    {
        #region private field
        /// <summary>
        /// private fields;
        /// </summary>
        private readonly IBookStorageService bookStorage;
        private List<Book> books = new List<Book>();
        #endregion

        private ILogger logger;

        #region Constructor
        /// <summary>
        /// Ctor for bookStorage's initialization
        /// </summary>
        /// <param name="bookStorage"></param>
        public BookService(IBookStorageService bookStorage)
        {
            if (ReferenceEquals(bookStorage, null))
            {
                throw new ArgumentException();
            }
            this.bookStorage = bookStorage;
           
        }
        #endregion

        #region public
        /// <inheritdoc />
        public void AddBookToShop(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException();
            }
            
            books.Add(book);
            
        }

        /// <inheritdoc />
        public void RemoveBookFromShop(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException();
            }
            books.Remove(book);
        }

        /// <inheritdoc />
        public Book FindBook(IFinder parameter)
        {
            if (ReferenceEquals(parameter, null))
            {
                throw new ArgumentNullException();
            }
            return parameter.FindBookByTeg();
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public void Save()
        {
            bookStorage.SaveBooks(books);
        }

        /// <inheritdoc />
        public IEnumerable<Book> GetAllBooks()
        {
            return bookStorage.GetBookList();
        }

#endregion
    }
}