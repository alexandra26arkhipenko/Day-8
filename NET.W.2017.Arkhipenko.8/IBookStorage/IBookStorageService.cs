using System;
using System.Collections.Generic;
using Books;

namespace IBookStorage
{
    public interface IBookStorageService
    {
        /// <summary>
        /// Reads book list from file
        /// </summary>
        /// <returns></returns>
        IEnumerable<Book> GetBookList();

        /// <summary>
        /// Writes books into list
        /// </summary>
        /// <param name="books"></param>
        void SaveBooks(IEnumerable<Book> books);
    }
}
