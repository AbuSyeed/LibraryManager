using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryManager.Core
{
    public class Book
    {
        public int Id { get; set; }
        [Required, StringLength(300)]
        public string Title { get; set; }
        [StringLength(20)]
        public string ISBN { get; set; }
        public BookGenre BookGenre { get; set; }
    }
}
