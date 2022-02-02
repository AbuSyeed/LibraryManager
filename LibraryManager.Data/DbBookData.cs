using LibraryManager.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManager.Data
{
    public class DbBookData : IBookData
    {
        LibraryManagerDbContext db;
        public DbBookData()
        {
            db = new LibraryManagerDbContext();
        }

        public Book AddBook(Book newBook)
        {
            db.Books.Add(newBook);
            return newBook;
        }

        public int Commit()
        {
            return db.SaveChanges(); //returns the number of rows that are affected
        }

        public Book DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                db.Books.Remove(book);
            }
            return book;
        }

        public Book GetBookById(int id)
        {
            return db.Books.Find(id);
        }

        public int GetBookCount()
        {
            return db.Books.Count();
        }

        public IEnumerable<Book> GetBooksByTitle(string searchTerm)
        {
            return db.Books
                     .Where(r => string.IsNullOrEmpty(r.Title) || r.Title.StartsWith(searchTerm))
                     .OrderBy(m => m.Title).ToList();
        }

        public Book UpdateBook(Book updatedBook)
        {
            var entity = db.Books.Attach(updatedBook);
            entity.State = EntityState.Modified;
            return updatedBook;
        }
    }
}
