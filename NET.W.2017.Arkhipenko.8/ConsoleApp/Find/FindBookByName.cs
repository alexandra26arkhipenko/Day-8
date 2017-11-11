using System.Collections.Generic;
using System.Linq;
using Books;
using ParameterForSearching;

namespace ConsoleApp.Find
{
    public class FindBookByName : IFinder
    {
        
        

        public FindBookByName(string name, List<Book> books)
        {
            Name = name;
            Books = books;
        }

        public string Name { get; }
        public List<Book> Books { get; }

        public Book FindBookByTeg()
        {
            return Books.FirstOrDefault(book => book.Name == Name);
        }
    }
}