using BookStore.Core.Domain;

namespace BookStore.Core.Interfaces
{
    public interface IBookRepository
    {
        Task<Book?> GetBookByIdAsync(Guid id);
        Task CreateBookAsync(Book book);
    }
}
