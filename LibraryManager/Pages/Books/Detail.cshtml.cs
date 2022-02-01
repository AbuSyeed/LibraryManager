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
    public class DetailModel : PageModel
    {
        private readonly IBookData bookData;
        public Book Book { get; set; }
        [TempData]
        public string Confirmation { get; set; }

        public DetailModel(IBookData bookData)
        {
            this.bookData = bookData;
        }

        public IActionResult OnGet(int bookId)
        {
            Book = bookData.GetBookById(bookId);
            
            if (Book == null)
            {
                TempData["ItemType"] = "book";
                return RedirectToPage("/Shared/NotFound");
            }

            return Page();
        }
    }
}
