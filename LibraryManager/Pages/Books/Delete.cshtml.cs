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
    public class DeleteModel : PageModel
    {
        private readonly IBookData bookData;

        public Book Book { get; set; }

        public DeleteModel(IBookData bookData)
        {
            this.bookData = bookData;
        }
        public IActionResult OnGet(int bookId)
        {
            Book = bookData.GetBookById(bookId);
            if (Book == null)
            {
                TempData["ItemType"] = "Book";
                return RedirectToPage("/Shared/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int bookId)
        {
            Book = bookData.DeleteBook(bookId);
            if (Book == null)
            {
                TempData["ItemType"] = "Book";
                return RedirectToPage("/Shared/NotFound");
            }

            bookData.Commit();
            TempData["Confirmation"] = "Book deleted.";
            return RedirectToPage("./List");
        }
    }
}
