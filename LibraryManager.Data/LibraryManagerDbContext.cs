using LibraryManager.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Data
{
    public class LibraryManagerDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Dev\LearningAndReference\shared projects\LibraryManagerDB\LibraryManagerDB.db;");
        }
    }
}
