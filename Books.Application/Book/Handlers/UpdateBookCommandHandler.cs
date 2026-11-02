using Books.Application.Book.Commands;
using Books.Application.Book.DTOs;
using Books.Application.Mapping;
using Books.Domain.Interfaces;
using Books.Infrastructure.Interfaces;
using MediatR;

namespace Books.Application.Book.Handlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IBookService _bookService;

        public UpdateBookCommandHandler(
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            IGenreRepository genreRepository,
            IBookService bookService)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
            _bookService = bookService;
        }

        public async Task<BookDto?> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = MappingProfileFactory.UpdateMapToBook(request);
            var bookRegistered = await _bookRepository.FirstOrDefaultAsync(b => b.Id == book.Id);
            var author = await _authorRepository.FirstOrDefaultAsync(a => a.Id == book.AuthorId);
            var genre = await _genreRepository.FirstOrDefaultAsync(g => g.Id == book.GenreId);

            var bookValidated = _bookService.Update(bookRegistered, book, author, genre);

            if (bookValidated is null)
                return null;

            _bookRepository.Update(bookValidated);

            var result = await _bookRepository.SaveChangesAsync();

            return MappingProfileFactory.MapToBookDto(bookValidated);
        }
    }
}
