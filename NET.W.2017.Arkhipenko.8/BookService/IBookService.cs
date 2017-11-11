using System.Collections;
using System.Collections.Generic;
using Books;
using ParameterForSearching;

namespace BookService
{
    public interface IBookService
    {
        /// <summary>
        /// Adds book to list
        /// </summary>
        /// <param name="book"></param>
        void AddBookToShop(Book book);

        /// <summary>
        /// Removes book from list
        /// </summary>
        /// <param name="book"></param>
        void RemoveBookFromShop(Book book);

        /// <summary>
        /// Finds book in list
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Book FindBook(IFinder parameter);

        /// <summary>
        /// Sorts by some teg
        /// </summary>
        /// <param name="comparator"></param>
        void Sort(IComparer<Book> comparator);

        /// <summary>
        /// Saves information about books
        /// </summary>
        void Save();

        /// <summary>
        /// Returns list of books
        /// </summary>
        /// <returns></returns>
        IEnumerable<Book> GetAllBooks();
    }
}