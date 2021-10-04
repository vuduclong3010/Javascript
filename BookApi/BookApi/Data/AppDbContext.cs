using BookApi.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Author)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(bi => bi.AuthorId);
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Publisher> Publisher { get; set; }

        public DbSet<Book_Author> book_Authors { get; set; }

        public DbSet<Author> Authors { get; set; }


    }
}
