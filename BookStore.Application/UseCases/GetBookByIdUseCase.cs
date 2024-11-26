using BookStore.Core.Domain;
using BookStore.Core.Interfaces;

namespace BookStore.Application.UseCases
{
    public class GetBookByIdUseCase
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book?> ExecuteAsync(Guid id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }
    }
}
