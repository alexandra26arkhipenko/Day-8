using System.Collections;
using System.Collections.Generic;
using Books;

namespace ConsoleApp
{
    public class SortByName : IComparer<Book>
    {
        public int Compare(Book lhs, Book rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                return 1;
            }
            if (ReferenceEquals(lhs, rhs))
            {
                return 0;
            }
            return lhs.CompareTo(rhs);
        }
    }
}