using System;

namespace Books
{
    public static class Formater
    {
        public static Book BookFormat(this Book book)
        {
            if(ReferenceEquals(book, null)) throw new ArgumentNullException();
            book.Name = book.Name.ToUpper();
            book.Author = book.Author.ToUpper();
            return book;
        }
    }
}