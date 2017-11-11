using System;
using System.Collections.Generic;
using Books;

namespace IBookStorage
{
    public interface IBookStorageService
    {
        IEnumerable<Book> GetBookList();
        void SaveBooks(IEnumerable<Book> books);
    }
}
