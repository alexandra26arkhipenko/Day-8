using System.Collections.Generic;
using System.IO;
using Books;

namespace BookStorage
{
    public class BookStorage
    {
        #region Private const 
        /// <summary>
        /// Field path is the way of file
        /// </summary>
        private const string Path = "D:\\Bin9";
        #endregion

        #region public
        
        /// <summary>
        /// Read book from file
        /// </summary>
        /// <returns>List of books IEnumerable</returns>
        public IEnumerable<Book> ReadBookFromFile()
        {
            var books = new List<Book>();
            using (var br = new BinaryReader(File.Open(Path, FileMode.OpenOrCreate,
                FileAccess.Read, FileShare.Read)))
            {
                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    var book = Reader(br);
                    books.Add(book);
                }
            }

            return books;
        }
        
        /// <summary>
        /// Write books to file 
        /// </summary>
        /// <param name="book"></param>
        public void AppendBookToFile(Book book)
        {
            using (var bw = new BinaryWriter(File.Open(Path, FileMode.Append,
                FileAccess.Write, FileShare.None)))
            {
                Writer(bw, book);
            }
        }

        /// <summary>
        /// OverWrite file
        /// </summary>
        /// <param name="books"></param>
        public void OverWriteFile(IEnumerable<Book> books)
        {
            using (var bw = new BinaryWriter(File.Open(Path, FileMode.Create,
                FileAccess.Write, FileShare.None)))
            {
                foreach (var book in books)
                    Writer(bw, book);
            }
        }
        #endregion

        #region private
        private static void Writer(BinaryWriter binary, Book book)
        {
            binary.Write(book.Isbn);
            binary.Write(book.Author);
            binary.Write(book.Name);
            binary.Write(book.PublishingHouse);
            binary.Write(book.Year);
            binary.Write(book.Price);
            binary.Write(book.Pages);
        }

        private static Book Reader(BinaryReader binary)
        {
            var isbn = binary.ReadInt32();
            var author = binary.ReadString();
            var name = binary.ReadString();
            var publish = binary.ReadString();
            var year = binary.ReadInt32();
            var price = binary.ReadDouble();
            var pages = binary.ReadInt32();

            return new Book(isbn, author, name, publish, year, price, pages);
        }
        #endregion
    }
}