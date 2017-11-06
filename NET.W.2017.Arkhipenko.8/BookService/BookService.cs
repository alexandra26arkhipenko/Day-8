using System;
using System.Collections.Generic;
using System.Linq;
using Books;
using Interfaces;

namespace BookService
{
    public class BookService : IBookService
    {
        private readonly BookStorage.BookStorage _bookStorage;

        public BookService()
        {
            _bookStorage = new BookStorage.BookStorage();
        }

        public IEnumerable<Book> GetBookList()
        {
            return _bookStorage.ReadBookFromFile();
        }

        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            var books = _bookStorage.ReadBookFromFile().ToList();

            if (books.Any(book.Equals))
                throw new Exception();
            books.Add(book);

            _bookStorage.OverWriteFile(books);
        }

        public void RemoveBook(int isbn)
        {
            var books = _bookStorage.ReadBookFromFile().ToList();
            var bookForRemove = FindBook(isbn);
            if (bookForRemove == null)
                throw new Exception();
            books.Remove(bookForRemove);
            _bookStorage.OverWriteFile(books);
        }

        public Book FindBook(int isbn)
        {
            var books = _bookStorage.ReadBookFromFile().ToList();
            return books.FirstOrDefault(b => b.Isbn == isbn);
        }

        public Book FindBook(string name)
        {
            var books = _bookStorage.ReadBookFromFile().ToList();
            return books.FirstOrDefault(b => b.Name == name);
        }

        public IEnumerable<Book> Sort(IEnumerable<Book> books, BookPart partForSort)
        {
            switch (partForSort)
            {
                case BookPart.Isbn:
                    return books.OrderBy(b => b.Isbn);
                case BookPart.Name:
                    return books.OrderBy(b => b.Name);
                case BookPart.Author:
                    return books.OrderBy(b => b.Author);
                case BookPart.Pages:
                    return books.OrderBy(b => b.Pages);
                case BookPart.Price:
                    return books.OrderBy(b => b.Price);
                case BookPart.PublishHouse:
                    return books.OrderBy(b => b.PublishingHouse);
                case BookPart.Year:
                    return books.OrderBy(b => b.Year);
                default: return books;
            }
        }
    }
}