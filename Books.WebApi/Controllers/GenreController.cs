using Books.Application.Genre.Commands;
using Books.Application.Genre.CommandsValidation;
using Books.Application.Genre.DTOs;
using Books.Application.Genre.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Books.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ICreateGenreCommandValidation _createGenreCommandValidation;
        private readonly IUpdateGenreCommandValidation _updateGenreCommandValidation    ;

        public GenreController(
            ISender sender,
            ICreateGenreCommandValidation createGenreCommandValidation,
            IUpdateGenreCommandValidation updateGenreCommandValidation)
        {
            _sender = sender;
            _createGenreCommandValidation = createGenreCommandValidation;
            _updateGenreCommandValidation = updateGenreCommandValidation;
        }

        [HttpGet]
        public async Task<ApiResponse<IEnumerable<GenreDto>>> Get(
            [FromQuery] GenreComplexFilter command,
            CancellationToken cancellationToken)
        {
            var listGenre = await _sender.Send(
                command,
                cancellationToken);

            return new ApiResponse<IEnumerable<GenreDto>>(listGenre);            
        }

        [HttpPost("add")]
        public async Task<ApiResponse<GenreDto>> Create(
            [FromBody] CreateGenreCommand command,
            CancellationToken cancellationToken)
        {
            var validation = _createGenreCommandValidation.Validate(command);
            if (validation.IsValid is false)
            {
                return new ApiResponse<GenreDto>(validation.Message!, validation.Errors!);
            }

            var genreDTO = await _sender.Send(
                command,
                cancellationToken);

            return new ApiResponse<GenreDto>(genreDTO);
        }

        [HttpPut("update/{id}")]
        public async Task<ApiResponse<GenreDto>> Update(
            [FromBody] UpdateGenreCommand command,
            CancellationToken cancellationToken)
        {
            var validation = _updateGenreCommandValidation.Validate(command);
            if (validation.IsValid is false)
            {
                return new ApiResponse<GenreDto>(validation.Message!, validation.Errors!);
            }

            var genreDTO = await _sender.Send(
                command,
                cancellationToken);

            return new ApiResponse<GenreDto>(genreDTO);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ApiResponse<bool>> Delete(
            [FromRoute] int id,
            CancellationToken cancellationToken)
        {
            if (id <= 0)
            {
                return new ApiResponse<bool>("Invalid genre number code.", ["Invalid genre number code."]);
            }

            var command = new DeleteGenreCommand { Code = id };

            var genreDeleted = await _sender.Send(
                command,
                cancellationToken);

            var response = new ApiResponse<bool>(genreDeleted);

            return response;
        }
    }
}
