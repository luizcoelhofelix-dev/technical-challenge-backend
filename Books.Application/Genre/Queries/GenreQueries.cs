using Books.Application.Genre.DTOs;
using Books.Application.Mapping;
using Books.Infrastructure;
using Books.Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Books.Application.Genre.Queries
{
    public class GenreQueries : IRequestHandler<GenreComplexFilter, IEnumerable<GenreDto>>
    {
        private readonly IGenreRepository _genreRepository;
        public GenreQueries(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<GenreDto>> Handle(GenreComplexFilter request, CancellationToken cancellationToken)
        {
            if (request.Code > 0 || !string.IsNullOrEmpty(request.Description))
            {
                IQueryable<Domain.Entities.Genre> query = _genreRepository.QueryAsNoTracking();
                if (request.Code > 0)
                {
                    query = query.Where(g => g.Id == request.Code);
                }
                if (!string.IsNullOrEmpty(request.Description))
                {
                    query = query.Where(g => g.Name.Contains(request.Description));
                }

                var result = await query.ToListAsync();

                return result.Select(MappingProfileFactory.MapToGenreDto);
            }

            var genres = await _genreRepository.All();

            return genres.Select(MappingProfileFactory.MapToGenreDto);            
        }        
    }
}
