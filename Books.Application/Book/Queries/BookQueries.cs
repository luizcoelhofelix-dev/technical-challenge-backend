using Books.Application.Book.DTOs;
using Books.Application.Genre.DTOs;
using Books.Application.Genre.Queries;
using Books.Application.Mapping;
using Books.Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Books.Application.Book.Queries
{
    public class BookQueries : IRequestHandler<BookComplexFilter, IEnumerable<BookDto>>
    {
        private readonly IBookRepository _bookRepository;
        public BookQueries(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookDto>> Handle(BookComplexFilter request, CancellationToken cancellationToken)
        {
            if (request.Code > 0 || 
                !string.IsNullOrEmpty(request.Description) ||
                request.AuthorId > 0 ||
                request.GenreId > 0 ||
                (request.PublishedDate != null && request.PublishedDate != DateTime.MinValue))
            {
                
                IQueryable<Domain.Entities.Book> query = _bookRepository.QueryAsNoTracking();
                
                if (request.Code > 0)
                {
                    query = query.Where(b => b.Id == request.Code);
                }
                if (!string.IsNullOrEmpty(request.Description))
                {
                    query = query.Where(b => b.Title.Contains(request.Description));
                }
                if (request.AuthorId > 0)
                {
                    query = query.Where(b => b.AuthorId == request.AuthorId);
                }
                if (request.GenreId > 0)
                {
                    query = query.Where(b => b.GenreId == request.GenreId);
                }
                if (request.PublishedDate != null && request.PublishedDate != DateTime.MinValue)
                {
                    query = query.Where(b => b.PublishedDate == request.PublishedDate);
                }

                var result = await query.ToListAsync();

                return result.Select(MappingProfileFactory.MapToBookDto);
            }

            var books = await _bookRepository.All();

            return books.Select(MappingProfileFactory.MapToBookDto);
        }
    }
}
