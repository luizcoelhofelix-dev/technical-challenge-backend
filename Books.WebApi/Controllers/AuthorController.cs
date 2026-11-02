using Books.Application.Author.Commands;
using Books.Application.Author.CommandsValidation;
using Books.Application.Author.DTOs;
using Books.Application.Author.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Books.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ICreateAuthorCommandValidation _createAuthorCommandValidation;
        private readonly IUpdateAuthorCommandValidation _updateAuthorCommandValidation;        

        public AuthorController(
            ISender sender,
            ICreateAuthorCommandValidation createAuthorCommandValidation,
            IUpdateAuthorCommandValidation updateAuthorCommandValidation)
        {
            _sender = sender;            
            _createAuthorCommandValidation = createAuthorCommandValidation;
            _updateAuthorCommandValidation = updateAuthorCommandValidation;
        }

        [HttpGet]
        public async Task<ApiResponse<IEnumerable<AuthorDto>>> Get(
            [FromQuery] AuthorComplexFilter command,
            CancellationToken cancellationToken)
        {
            var listAuthors = await _sender.Send(
                command,
                cancellationToken);

            return new ApiResponse<IEnumerable<AuthorDto>>(listAuthors);
        }

        [HttpPost("add")]
        public async Task<ApiResponse<AuthorDto>> Create(
            [FromBody] CreateAuthorCommand command,
            CancellationToken cancellationToken)
        {
            var validation = _createAuthorCommandValidation.Validate(command);
            if (validation.IsValid is false)
            {
                return new ApiResponse<AuthorDto>(validation.Message!, validation.Errors!);
            }

            var authorDTO = await _sender.Send(
                command,
                cancellationToken);

            return new ApiResponse<AuthorDto>(authorDTO);
        }

        [HttpPut("update/{id}")]
        public async Task<ApiResponse<AuthorDto>> Update(
            [FromBody] UpdateAuthorCommand command,
            CancellationToken cancellationToken)
        {
            var validation = _updateAuthorCommandValidation.Validate(command);
            if (validation.IsValid is false)
            {
                return new ApiResponse<AuthorDto>(validation.Message!, validation.Errors!);
            }

            var authorDTO = await _sender.Send(
                command,
                cancellationToken);

            return new ApiResponse<AuthorDto>(authorDTO);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ApiResponse<bool>> Delete(
            [FromRoute] int id,
            CancellationToken cancellationToken)
        {
            if (id <= 0)
            {
                return new ApiResponse<bool>("Invalid author number code.", ["Invalid author number code."]);
            }

            var command = new DeleteAuthorCommand { Code = id };
            
            var authorDeleted = await _sender.Send(
                command,
                cancellationToken);

            var response = new ApiResponse<bool>(authorDeleted);

            return response;
        }
    }
}
