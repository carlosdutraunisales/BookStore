using BookStore.Core.Domain;
using BookStore.Core.Interfaces;
using BookStore.Infrastructure.Context;

namespace BookStore.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookstoreDbContext _dbContext;

        public BookRepository(BookstoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateBookAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Book?> GetBookByIdAsync(Guid id)
        {
            return await _dbContext.Books.FindAsync(id);
        }
    }
}
