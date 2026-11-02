using Books.Application.Author.Commands;
using Books.Application.Author.DTOs;
using Books.Application.Mapping;
using Books.Domain.Interfaces;
using Books.Infrastructure.Interfaces;
using MediatR;

namespace Books.Application.Author.Handlers
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, AuthorDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IAuthorService _authorService;
        public UpdateAuthorCommandHandler(
            IAuthorRepository authorRepository,
            IAuthorService authorService)
        {
            _authorRepository = authorRepository;
            _authorService = authorService;
        }

        public async Task<AuthorDto?> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var authorUpdated = MappingProfileFactory.UpdateMapToAuthor(request);

            var registeredAuthor = await _authorRepository.FirstOrDefaultAsync(a => a.Id == authorUpdated.Id);
            
            var recordValidated = _authorService.Update(registeredAuthor, authorUpdated);

            if (recordValidated == null)
                return null;

            _authorRepository.Update(recordValidated);

            await _authorRepository.SaveChangesAsync();

            return MappingProfileFactory.MapToAuthorDto(recordValidated);
        }
    }
}
