using System;
using System.Globalization;

namespace Books
{
    /// <summary>
    ///     Book modal
    /// </summary>
    
    public class Book : IEquatable<Book>, IComparable, IComparable<Book>, IFormattable
    {
        #region private properties 
        /// <summary>
        /// Books properties
        /// </summary>
        public string Isbn { get; }
        public string Author { get; set; }
        public string Name { get; set; }
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
        public Book(string isbn, string author, string name, string publish, int year, double price, int pages)
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
        /// <inheritdoc />
        /// <summary>
        /// IEquatable override method 
        /// </summary>
        /// <param name="book"></param>
        /// <returns>true or false</returns>
        public bool Equals(Book book)
        {
            if(ReferenceEquals(book, null))
            {
                return false;
            }
            if (ReferenceEquals(this, book))
            {
                return true;
            }
            return book.Isbn == Isbn;
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
            return Isbn.GetHashCode();
        }

        /// <summary>
        /// override object class method ToString
        /// </summary>
        /// <returns>string </returns>
        public override string ToString()
        {
            return "Book: " + Name + " Author: " + Year + " y. " + Pages + " p. " + Author + " ISBN: " + Isbn + " Publishing House : " + PublishingHouse + Price + " y.e ";
        }

        /// <summary>
        /// Output options
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns>string </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format)) format = "5";
            

            switch (format)
            {
                case "1": return "Book: " + Name +" Author: " + Author;
                case "2": return "Book: " + Name + " Author: " + Author + " ISBN: " + Isbn;
                case "3": return "Book: " + Name + " Author: " + Year + " y. " + Author + " ISBN: " + Isbn;
                case "4": return "Book: " + Name + " Author: " + Year + " y. " +Pages +" p. "+ Author + " ISBN: " + Isbn;
                case "5": return "Book: " + Name + " Author: " + Year + " y. " + Pages + " p. " + Author + " ISBN: " + Isbn + " Publishing House : " + PublishingHouse;
                case "6": return "Book: " + Name + " Author: " + Year + " y. " + Pages + " p. " + Author + " ISBN: " + Isbn + " Publishing House : " + PublishingHouse + Price + " y.e ";
                    default: throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
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
            return CompareTo(book);
        }

        public int CompareTo(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                return 1;
            }
            // ReSharper disable once StringCompareIsCultureSpecific.1
            return string.Compare(Name, book.Name);
        }

        #endregion
    }
}