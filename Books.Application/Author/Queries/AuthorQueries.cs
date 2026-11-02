using Books.Application.Author.DTOs;
using Books.Application.Mapping;
using Books.Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Books.Application.Author.Queries
{
    public class AuthorQueries : IRequestHandler<AuthorComplexFilter, IEnumerable<AuthorDto>>
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorQueries(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<AuthorDto>> Handle(AuthorComplexFilter request, CancellationToken cancellationToken)
        {
            if (request.Code > 0 ||
                !string.IsNullOrEmpty(request.Name) ||
                !string.IsNullOrEmpty(request.Country))
            {

                IQueryable<Domain.Entities.Author> query = _authorRepository.QueryAsNoTracking();

                if (request.Code > 0)
                {
                    query = query.Where(a => a.Id == request.Code);
                }
                if (!string.IsNullOrEmpty(request.Name))
                {
                    query = query.Where(a => a.Name.Contains(request.Name));
                }
                if (!string.IsNullOrEmpty(request.Country))
                {
                    query = query.Where(a => a.Country.Contains(request.Country));
                }

                var result = await query.ToListAsync();

                return result.Select(MappingProfileFactory.MapToAuthorDto);
            }

            var authors = await _authorRepository.All();

            return authors.Select(MappingProfileFactory.MapToAuthorDto);
        }
    }
}
