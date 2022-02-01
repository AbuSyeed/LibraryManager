using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Core;
using LibraryManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace LibraryManager.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly IBookData bookData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Book Book { get; set; }
        public IEnumerable<SelectListItem> BookGenres;

        public EditModel(IBookData bookData, IHtmlHelper htmlHelper)
        {
            this.bookData = bookData;
            this.htmlHelper = htmlHelper;
        }
        
        public IActionResult OnGet(int bookId)
        {
            BookGenres = htmlHelper.GetEnumSelectList<BookGenre>();

            Book = bookData.GetBookById(bookId);

            if (Book == null)
            {
                TempData["ItemType"] = "book";
                return RedirectToPage("/Shared/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            BookGenres = htmlHelper.GetEnumSelectList<BookGenre>();

            bookData.UpdateBook(Book);

            bookData.Commit();

            return Page();
        }
    }
}
