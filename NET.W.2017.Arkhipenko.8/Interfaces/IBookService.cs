using System.Collections.Generic;
using Books;

namespace Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetBookList();
        void AddBook(Book book);
        void RemoveBook(int isbn);
        Book FindBook(int number);
        Book FindBook(string name);
        IEnumerable<Book> Sort(IEnumerable<Book> books,BookPart partForSort);

    }
}