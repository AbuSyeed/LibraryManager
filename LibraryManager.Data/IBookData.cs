using LibraryManager.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Data
{
    public interface IBookData
    {
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetBooksByTitle(string searchTerm);
        Book GetBookById(int bookId);
        Book UpdateBook(Book updatedBook);

        Book AddBook(Book newBook);
        int GetBookCount();
        int Commit();
    }
}
