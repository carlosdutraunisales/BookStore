using BookStore.Application.UseCases;
using BookStore.Core.Domain;
using BookStore.Presentation.API.Request;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly CreateBookUseCase _createBookUseCase;
        private readonly GetBookByIdUseCase _getBookByIdUseCase;

        public BooksController(CreateBookUseCase createBookUseCase, GetBookByIdUseCase getBookByIdUseCase)
        {
            _createBookUseCase = createBookUseCase;
            _getBookByIdUseCase = getBookByIdUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookRequest request)
        {
            await _createBookUseCase.ExecuteAsync(request.Name, request.ISSN, request.PublicationDate);
            return Created("", null);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(Guid id)
        {
            var book = await _getBookByIdUseCase.ExecuteAsync(id);
            if (book == null) return NotFound();

            return Ok(book);
        }


    }
}
