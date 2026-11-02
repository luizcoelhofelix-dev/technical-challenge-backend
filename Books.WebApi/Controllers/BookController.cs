using Books.Application.Book.Commands;
using Books.Application.Book.CommandsValidation;
using Books.Application.Book.DTOs;
using Books.Application.Book.Queries;
using Books.Application.Genre.DTOs;
using Books.Application.Genre.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Books.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ICreateBookCommandValidation _createBookCommandValidation;
        private readonly IUpdateBookCommandValidation _updateBookCommandValidation;

        public BookController(
            ISender sender,
            ICreateBookCommandValidation createBookCommandValidation,
            IUpdateBookCommandValidation updateBookCommandValidation)
        {
            _sender = sender;
            _createBookCommandValidation = createBookCommandValidation;
            _updateBookCommandValidation = updateBookCommandValidation;
        }

        [HttpGet]
        public async Task<ApiResponse<IEnumerable<BookDto>>> Get(
            [FromQuery] BookComplexFilter command,
            CancellationToken cancellationToken)
        {
            var listBook = await _sender.Send(
                command,
                cancellationToken);

            return new ApiResponse<IEnumerable<BookDto>>(listBook);
        }

        [HttpPost("add")]
        public async Task<ApiResponse<BookDto>> Create(
            [FromBody] CreateBookCommand command,
            CancellationToken cancellationToken)
        {
            var validation = _createBookCommandValidation.Validate(command);
            if (validation.IsValid is false)
            {
                return new ApiResponse<BookDto>(validation.Message!, validation.Errors!);
            }

            var authorDTO = await _sender.Send(
                command,
                cancellationToken);

            return new ApiResponse<BookDto>(authorDTO);
        }

        [HttpPut("update/{id}")]
        public async Task<ApiResponse<BookDto>> Update(
            [FromBody] UpdateBookCommand command,
            CancellationToken cancellationToken)
        {
            var validation = _updateBookCommandValidation.Validate(command);
            if (validation.IsValid is false)
            {
                return new ApiResponse<BookDto>(validation.Message!, validation.Errors!);
            }

            var authorDTO = await _sender.Send(
                command,
                cancellationToken);

            if(authorDTO is null)
                return new ApiResponse<BookDto>("Não foi possível concluir a alteração", ["Não foi possível concluir a alteração"]);

            return new ApiResponse<BookDto>(authorDTO);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ApiResponse<bool>> Delete(
            [FromRoute] int id,
            CancellationToken cancellationToken)
        {
            if (id <= 0)
            {
                return new ApiResponse<bool>("Invalid book number code.", ["Invalid book number code."]);
            }

            var command = new DeleteBookCommand { Code = id };

            var bookDeleted = await _sender.Send(
                command,
                cancellationToken);

            var response = new ApiResponse<bool>(bookDeleted);

            return response;
        }
    }
}
