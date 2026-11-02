using Books.Application.Genre.Commands;
using Books.Application.Genre.DTOs;
using Books.Application.Mapping;
using Books.Domain.Interfaces;
using Books.Infrastructure;
using Books.Infrastructure.Interfaces;
using MediatR;

namespace Books.Application.Genre.Handlers
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, GenreDto>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IGenreService _genreService;
        public UpdateGenreCommandHandler(
            IGenreRepository genreRepository,
            IGenreService genreService)
        {
            _genreRepository = genreRepository;
            _genreService = genreService;
        }

        public async Task<GenreDto?> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var genreUpdated = MappingProfileFactory.UpdateMapToGenre(request);

            var registeredGenre = await _genreRepository.FirstOrDefaultAsync(g => g.Id == genreUpdated.Id);

            var recordValidated = _genreService.Update(registeredGenre, genreUpdated);

            if (recordValidated == null)
                return null;

            _genreRepository.Update(recordValidated);

            await _genreRepository.SaveChangesAsync();

            return MappingProfileFactory.MapToGenreDto(recordValidated);
        }
    }
}
