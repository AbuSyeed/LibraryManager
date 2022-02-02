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
        
        public IActionResult OnGet(int? bookId)
        {
            BookGenres = htmlHelper.GetEnumSelectList<BookGenre>();
            if (bookId.HasValue)
            {
                Book = bookData.GetBookById(bookId.Value);
            }
            else
            {
                Book = new Book();
            }
            if (Book == null)
            {
                TempData["ItemType"] = "Book";
                return RedirectToPage("/Shared/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                BookGenres = htmlHelper.GetEnumSelectList<BookGenre>();
                return Page();
            }
            if (Book.Id > 0)
            {
                bookData.UpdateBook(Book);
                TempData["Confirmation"] = "Book updated.";
            }
            else
            {
                bookData.AddBook(Book);
                TempData["Confirmation"] = "Book added.";
            }

            bookData.Commit();
            return RedirectToPage("./Detail", new { bookId = Book.Id });
        }
    }
}
