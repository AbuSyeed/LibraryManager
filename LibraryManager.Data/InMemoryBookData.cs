using LibraryManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManager.Data
{
    public class InMemoryBookData : IBookData
    {
        List<Book> books;

        public InMemoryBookData()
        {
            books = new List<Book>()
            {
                new Book { Id = 1, Title = "Learn C# in One Day and Learn It Well", BookGenre = BookGenre.Science},
                new Book { Id = 2, Title = "12 Major World Religions", BookGenre = BookGenre.Religion},
                new Book { Id = 3, Title = "Humankind: A Hopeful History", BookGenre = BookGenre.History},
                new Book { Id =4, Title = "Soft Skills: The Software Developer's Life Manual", BookGenre = BookGenre.Other}
            };
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return books.OrderBy(b => b.Title).ToList();

        }

        public IEnumerable<Book> GetBooksByTitle(string searchTerm)
        {
            return books
                  .Where(r => string.IsNullOrEmpty(searchTerm) || r.Title.StartsWith(searchTerm))
                  .OrderBy(m => m.Title).ToList();
        }
    }
}
