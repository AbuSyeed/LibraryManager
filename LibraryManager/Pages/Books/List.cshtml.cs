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

        public ListModel(IBookData books)
        {
            this.books = books;
        }
        public void OnGet()
        {
            Books = books.GetAllBooks();
        }
    }
}
