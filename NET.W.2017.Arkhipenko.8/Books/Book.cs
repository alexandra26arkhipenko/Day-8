using System;

namespace Books
{
    /// <summary>
    /// Book modal
    /// </summary>
    public class Book : IEquatable<Book>, IComparable
    {
        #region private properties 
        /// <summary>
        /// Book propreties
        /// </summary>
        public int Isbn { get; }
        public string Author { get; }
        public string Name { get; }
        public string PublishingHouse { get; }
        public int Year { get; }
        public double Price { get; }
        public int Pages { get; }

        #endregion

        #region public

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="author"></param>
        /// <param name="name"></param>
        /// <param name="publish"></param>
        /// <param name="year"></param>
        /// <param name="price"></param>
        /// <param name="pages"></param>
        public Book(int isbn, string author, string name, string publish, int year, double price, int pages)
        {
            Isbn = isbn;
            Author = author;
            Name = name;
            PublishingHouse = publish;
            Year = year;
            Price = price;
            Pages = pages;
        }
        #endregion

        #region IEquatable methods
        /// <summary>
        /// IEquatable override method 
        /// </summary>
        /// <param name="book"></param>
        /// <returns>true or false</returns>
        public bool Equals(Book book)
        {
            if (book == null) return false;

            return Isbn == book.Isbn && Author == book.Author && Name == book.Name
                   && PublishingHouse == book.PublishingHouse && Year == book.Year && Pages == book.Pages;
        }
        /// <summary>
        /// Override ==
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>true or false</returns>
        public static bool operator ==(Book lhs, Book rhs)
        {
            if (ReferenceEquals(lhs, rhs)) return true;
            if (ReferenceEquals(lhs, null)) return false;
            return lhs.Equals(rhs);
        }
        /// <summary>
        /// Override !=
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>true or false</returns>
        public static bool operator !=(Book lhs, Book rhs)
        {
            return !(lhs == rhs);
        }

        #endregion

        #region override
        /// <summary>
        /// override object class method Equals
        /// </summary>
        /// <param name="bookEq"></param>
        /// <returns>true or false</returns>
        public override bool Equals(object bookEq)
        {
            var book = (Book) bookEq;
            if (book == null)
                return false;

            return Isbn == book.Isbn && Author == book.Author && Name == book.Name
                   && PublishingHouse == book.PublishingHouse && Year == book.Year && Pages == book.Pages;
        }
        /// <summary>
        /// override object class method GetHashCode
        /// </summary>
        /// <returns>int</returns>
        public override int GetHashCode()
        {
            return Pages;
        }

        /// <summary>
        /// override object class method ToString
        /// </summary>
        /// <returns>string </returns>
        public override string ToString()
        {
            return string.Format("Book:\"{0}\" {1}, {2} pages \nPublishing company {3}, {4} y.," +
                                 " ISBN: {5}\n Price: {6} y.e.", Name, Author, Pages, PublishingHouse, Year, Isbn,
                Price);
        }

        #endregion
        /// <summary>
        /// IComparable override method 
        /// </summary>
        /// <param name="bookObj"></param>
        /// <returns>-1||0||1</returns>
        public int CompareTo(object bookObj)
        {
            if (ReferenceEquals(bookObj, null)) return 1;
            var book = (Book) bookObj;
            return String.Compare(Name, book.Name, StringComparison.Ordinal);
        }

        #endregion
    }
}