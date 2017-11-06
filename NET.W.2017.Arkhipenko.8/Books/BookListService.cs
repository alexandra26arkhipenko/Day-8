using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;

namespace Books
{
    public class BookListService : IBookListService
    {
        #region private fields
        private List<Book> books = new List<Book>();
        private string path = "D:\\Bin8";
        #endregion

        #region public
        #region Srevice

        public List<Book> GetBookList()
        {
            return books;
        }
        public void AddBook(Book book)
        {
            if(ReferenceEquals(book, null)) throw new ArgumentNullException();
         //   if (books.Any(book.Equals)) throw new ArgumentException();           
            AppendBook(book);  
            //books.Add(book);
            BookReader();
        }
        public void RemoveBook(int isbn)
        {
            if (isbn < 0) throw new ArgumentException();

            var book = FindBook(isbn);

            books.Remove(book);
            Overwriting();
            
        }
        #region Find
        public Book FindBook(int isbn)
        {
            if (isbn < 0) throw new ArgumentException();
            foreach (var book in books)
            {
                if (book.Isbn == isbn)
                    return book;
            }
           return books.First();
        }
        public Book FindBook(string name)
        {
            if (name == null) throw new ArgumentException();
            foreach (var book in books)
            {
                if (book.Name == name)
                    return book;
            }
            return books.First();
        }
        #endregion
        #region Sort
        public IEnumerable SortByName(List<Book> booksS)
        {
            return booksS.OrderBy(x => x.Name);
        }
        public IEnumerable SortByIsbn(List<Book> booksS)
        {
            return booksS.OrderBy(x => x.Isbn);
        }
        public IEnumerable SortByAuthor(List<Book> booksS)
        {
            return booksS.OrderBy(x => x.Author);
        }
        public IEnumerable SortByPrice(List<Book> booksS)
        {
            return booksS.OrderBy(x => x.Price);

        }
        #endregion
#endregion
        #endregion

        #region private
        private static void Writer(BinaryWriter binary, Book book)
        {
            binary.Write(book.Isbn);
            binary.Write(book.Author);
            binary.Write(book.Name);
            binary.Write(book.Publish);
            binary.Write(book.Year);
            binary.Write(book.Price);
            binary.Write(book.Pages);
        }
        private static Book Reader(BinaryReader binary)
        {

            int isbn = binary.ReadInt32();
            string author = binary.ReadString();
            string name = binary.ReadString();
            string publish = binary.ReadString();
            int year = binary.ReadInt32();
            double price = binary.ReadDouble();
            int pages = binary.ReadInt32();

            return new Book(isbn, author, name, publish, year, price, pages);

        }

        private void BookReader()
        {
            using (var br = new BinaryReader(File.Open(path, FileMode.Open,
                FileAccess.Read, FileShare.Read)))
            {
                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    var book = Reader(br);
                    books.Add(book);
                }
            }
        }
        private void AppendBook(Book book)
        {
            using (var bw = new BinaryWriter(File.Open(path, FileMode.Append,
                FileAccess.Write, FileShare.None)))
            {
                Writer(bw, book);
            }
        }
        private void Overwriting()
        {
            using (var bw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate,
                FileAccess.Write, FileShare.None)))
            {
                foreach (var book in books)
                {
                    Writer(bw, book);
                }
            }
        }
#endregion
    }
}