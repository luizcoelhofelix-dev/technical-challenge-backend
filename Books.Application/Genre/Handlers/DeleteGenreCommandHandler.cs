using Books.Application.Genre.Commands;
using Books.Infrastructure;
using Books.Infrastructure.Interfaces;
using MediatR;

namespace Books.Application.Genre.Handlers
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, bool>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IBookRepository _bookRepository;

        public DeleteGenreCommandHandler(
            IGenreRepository genreRepository,
            IBookRepository bookRepository)
        {
            _genreRepository = genreRepository;
            _bookRepository = bookRepository;
        }

        public async Task<bool> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.FirstOrDefaultAsync(g => g.Id == request.Code);
            if (genre == null)
                return false;

            var book = await _bookRepository.FirstOrDefaultAsync(b => b.GenreId == genre.Id);
            if (book != null)
                return false;

            _genreRepository.Remove(genre);

            var result = await _genreRepository.SaveChangesAsync();

            return result > 0 ? true : false;
        }
    }
}
