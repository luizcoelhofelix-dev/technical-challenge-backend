using Books.Application.Author.Commands;
using Books.Application.Author.DTOs;
using Books.Application.Mapping;
using Books.Domain.Interfaces;
using Books.Infrastructure.Interfaces;
using MediatR;

namespace Books.Application.Author.Handlers
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, AuthorDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IAuthorService _authorService;

        public CreateAuthorCommandHandler(
            IAuthorRepository authorRepository,
            IAuthorService authorService)
        {
            _authorRepository = authorRepository;
            _authorService = authorService;
        }

        public async Task<AuthorDto?> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = MappingProfileFactory.CreateMapToAuthor(request);

            var authorValidated = _authorService.Add(author);

            if (authorValidated is null)
                return null;

            _authorRepository.Add(authorValidated);

            var result = await _authorRepository.SaveChangesAsync();

            return MappingProfileFactory.MapToAuthorDto(authorValidated);
        }
    }
}
