using System.Collections.Generic;
using System.Linq;
using Books;
using ParameterForSearching;

namespace ConsoleApp.Find
{
    public class FindBookByIsbn : IFinder
    {
        public FindBookByIsbn(string isbn, IEnumerable<Book> books)
        {
            Isbn = isbn;
            Books = books.ToList();
        }

        public string Isbn { get; }
        public List<Book> Books { get; }

        public Book FindBookByTeg()
        {
            return Books.FirstOrDefault(book => book.Isbn == Isbn);
        }
    }
}