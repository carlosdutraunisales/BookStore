using BookStore.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Context
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options)
      : base(options) { }

        public DbSet<Book> Books { get; set; }


    }
}
