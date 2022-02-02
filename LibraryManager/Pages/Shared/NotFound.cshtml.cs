using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryManager.Pages.Shared
{
    public class NotFoundModel : PageModel
    {
        [TempData]
        public string ItemType { get; set; } = "Item";
        public void OnGet()
        {
        }
    }
}
