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
    }
}
