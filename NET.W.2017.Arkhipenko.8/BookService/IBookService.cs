using System.Collections;
using System.Collections.Generic;
using Books;
using ParameterForSearching;

namespace BookService
{
    public interface IBookService
    {
        void AddBookToShop(Book book);
        void RemoveBookFromShop(Book book);
        Book FindBook(IFinder parameter);
        void Sort(IComparer<Book> comparator);
        void Save();
        IEnumerable<Book> GetAllBooks();
    }
}