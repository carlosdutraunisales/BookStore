using BookStore.Core.Domain;
using BookStore.Core.Interfaces;

namespace BookStore.Application.UseCases
{
    public class CreateBookUseCase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookPricingService _bookPricingService;

        public CreateBookUseCase(IBookRepository bookRepository, IBookPricingService bookPricingService)
        {
            _bookRepository = bookRepository;
            _bookPricingService = bookPricingService;
        }

        public async Task ExecuteAsync(string name, string issn, DateTime publicationDate)
        {
            // Validar entrada
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("O nome do livro é obrigatório.");
            if (string.IsNullOrEmpty(issn)) throw new ArgumentException("O ISSN é obrigatório.");

            // Buscar preço no serviço externo
            decimal price = await _bookPricingService.GetPriceByISSNAsync(issn);

            // Criar e salvar o livro
            var book = new Book
            {
                Name = name,
                ISSN = issn,
                PublicationDate = publicationDate,
                Price = price
            };

            await _bookRepository.CreateBookAsync(book);
        }
    }
}
