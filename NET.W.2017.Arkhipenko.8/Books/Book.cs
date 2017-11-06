using System;

namespace Books
{
   
    public class Book : IEquatable<Book>, IComparable
    {
        #region private properties 
        public int Isbn { get;  }
        public string Author { get;  }
        public string Name { get; }
        public string Publish  { get;  }
        public int Year { get;  }
        public double Price { get; }
        public int Pages { get; }
        #endregion

        #region public
        public Book(int isbn, string author, string name, string publish, int year, double price, int pages)
        {
            Isbn = isbn;
            Author = author;
            Name = name;
            Publish = publish;
            Year = year;
            Price = price;
            Pages = pages;
        }

        

        #region IEquatable methods

        public bool Equals(Book book)
        {
            if (book == null) return false;

            return Isbn == book.Isbn && Author == book.Author && Name == book.Name
                   && Publish == book.Publish && Year == book.Year && Pages == book.Pages;
        }

        public static bool operator ==(Book lhs, Book rhs)
        {
            if (ReferenceEquals(lhs, rhs)) return true;
            if (ReferenceEquals(lhs, null)) return false;
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Book lhs, Book rhs)
        {
            return !(lhs == rhs);
        }
        #endregion
        #region override

        public override bool Equals(object bookEq)
        {
            var book = (Book) bookEq;
            if (book == null)
            {
                return false;
            }

            return Isbn == book.Isbn && Author == book.Author && Name == book.Name
                   && Publish == book.Publish && Year == book.Year && Pages == book.Pages;
        }

        public override int GetHashCode()
        {
            return Pages;
        }

        public override string ToString()
        {
            return String.Format("Book:\"{0}\" {1}, {2} pages \nPublishing company {3}, {4} y.," +
                                 " ISBN: {5}\n Price: {6} y.e.", Name, Author,Pages, Publish, Year, Isbn, Price);
        }
        #endregion

        public int CompareTo(object bookObj)
        {
            if (ReferenceEquals(bookObj, null)) return 1;
            Book book = (Book) bookObj;
            return Name.CompareTo(book.Name);
        }
        #endregion
    }

}
