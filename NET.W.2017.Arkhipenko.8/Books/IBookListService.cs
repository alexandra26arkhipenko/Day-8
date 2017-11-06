using System.Collections;
using System.Collections.Generic;

namespace Books
{
    public interface IBookListService
    {
        List<Book> GetBookList();
        void AddBook(Book book);
        void RemoveBook(int isbn);
        Book FindBook(int number);
        Book FindBook(string name);
        IEnumerable SortByName(List<Book> booksS);
        IEnumerable SortByIsbn(List<Book> booksS);
        IEnumerable SortByPrice(List<Book> booksS);
        IEnumerable SortByAuthor(List<Book> booksS);
    }
}