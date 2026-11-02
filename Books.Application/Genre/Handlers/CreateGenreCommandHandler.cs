using Books.Application.Genre.Commands;
using Books.Application.Genre.DTOs;
using Books.Application.Mapping;
using Books.Domain.Interfaces;
using Books.Domain.Services;
using Books.Infrastructure;
using Books.Infrastructure.Interfaces;
using MediatR;

namespace Books.Application.Genre.Handlers
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, GenreDto>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IGenreService _genreService;

        public CreateGenreCommandHandler(
            IGenreRepository genreRepository, 
            IGenreService genreService)
        {
            _genreRepository = genreRepository;
            _genreService = genreService;
        }

        public async Task<GenreDto?> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = MappingProfileFactory.CreateMapToGenre(request);

            var genreValidated = _genreService.Add(genre);

            if (genreValidated is null)
                return null;

            _genreRepository.Add(genreValidated);

           await _genreRepository.SaveChangesAsync();

            return MappingProfileFactory.MapToGenreDto(genreValidated);
        }
    }
}
