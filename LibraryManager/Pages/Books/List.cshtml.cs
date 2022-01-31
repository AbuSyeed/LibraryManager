using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Core;
using LibraryManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryManager.Pages.Books
{
    public class ListModel : PageModel
    {
        private readonly IBookData books;
        public IEnumerable<Book> Books { get; set; }
        
        [BindProperty(SupportsGet = true)] // by default binding is only done for POST
        public string SearchTerm { get; set; }

        public ListModel(IBookData books)
        {
            this.books = books;
        }
        public void OnGet()
        {
            SearchTerm ??= "";  //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator
            Books = books.GetBooksByTitle(SearchTerm);
        }
    }
}
